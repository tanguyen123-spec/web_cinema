﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using sell_movie.Entities;
using sell_movie.Secure.Data;
using sell_movie.Secure.Key;
using sell_movie.Secure.Models;

namespace sell_movie.Secure.Service
{
    public interface ITokenServices
    {
        Task<ApiResponse> Validate(LoginModels model);
        Task<ApiResponse> RenewToken(TokenModels tokenModels);
    }

    public class TokenServices : ITokenServices
    {
        private readonly web_cinema3Context context_;
        private readonly AppSetting appSettings_;
        public TokenServices(web_cinema3Context context, IOptionsMonitor<AppSetting> optionsMonitor)
        {
            context_ = context;
            appSettings_ = optionsMonitor.CurrentValue;
        }


        public async Task<ApiResponse> Validate(LoginModels model)
        {
            //kiểm tra có tài khoản trong dbAccount có trùng vs acc 
            //mà người dùng nhập hay không
            var account = context_.Nguoidungs.SingleOrDefault(p => p.Email == model.Email
            && p.Password == model.Passwords);
            if (account == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                };
            }
            //cấp token
            var token = await GeneratedToken(account);
            return new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = token
            };
        }

        //GeneratedToken tạo ra 1 cặp token(access và refresh)
        private async Task<TokenModels> GeneratedToken(Nguoidung account)
        {
            // Khởi tạo đối tượng JwtSecurityTokenHandler để tạo và xử lý JWT
            var jWtTokenHandler = new JwtSecurityTokenHandler();
            // Chuyển đổi chuỗi SecretKey từ cài đặt thành mảng byte
            var secretkeyBytes = Encoding.UTF8.GetBytes(appSettings_.SecretKey);
            // Mô tả thông tin về token
            var tokenDescription = new SecurityTokenDescriptor
            {
                // Subject chứa danh sách các Claims (khẳng định) về người dùng
                Subject = new ClaimsIdentity(new[]
                {
                   // Thêm claim "UserName" với giá trị là tên người dùng từ đối tượng Account
                    new Claim("UserName", account.Username),
                    //theem claim Email
                    new Claim(JwtRegisteredClaimNames.Email, account.Email),
                    //Jti được set bằng Guid để xác định token là duy nhất
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Role", account.Role.ToString()),
                    new Claim("MaNhanVien", account.MaNhanVien.ToString()),
                    //roles
               
                }),
                // Token sẽ hết hạn sau một khoảng thời gian 
                Expires = DateTime.UtcNow.AddSeconds(2),
                // Đặt thuật toán và khóa để ký và xác thực token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
               (secretkeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            //tạo token dựa trên mô tả của tokenDescription
            var token = jWtTokenHandler.CreateToken(tokenDescription);
            //viết var token thành một chuỗi token
            var accessToken = jWtTokenHandler.WriteToken(token);
            //tạo refresh token
            var refreshToken = GenerateRefreshToken();
            //tạo data token để thêm vào database
            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                JwtID = accessToken,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                IssuedAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddHours(1),
                nguoidungUsername = account.Username,
            };
            await context_.AddAsync(refreshTokenEntity);
            await context_.SaveChangesAsync();
            return new TokenModels
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
        }

        //hàm tạo refreshToken
        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public async Task<ApiResponse> RenewToken(TokenModels tokenModels)
        {
            // Khởi tạo đối tượng JwtSecurityTokenHandler để tạo và xử lý JWT
            var jWtTokenHandler = new JwtSecurityTokenHandler();
            // Chuyển đổi chuỗi SecretKey từ cài đặt thành mảng byte
            var secretkeyBytes = Encoding.UTF8.GetBytes(appSettings_.SecretKey);
            var tokenValidateparam = new TokenValidationParameters
            {
                //tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,
                //ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretkeyBytes),
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false, //không kiểm tra token hết hạn
            };
            try
            {
                //check 1: AccessToken valid format
                var tokenInverification = jWtTokenHandler.ValidateToken(tokenModels.AccessToken,
                    tokenValidateparam, out var validatedToken);
                //check 2: check thuật toán
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);
                    if (!result)
                    {
                        return new ApiResponse
                        {
                            Success = false,
                            Message = "Invalid Token"
                        };
                    }
                }
                //check 3: Check access token expire?
                var utcExpireDate = long.Parse(tokenInverification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = ConvertUnitTimeToDateTime(utcExpireDate);
                if (expireDate > DateTime.UtcNow)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Accses token has not yet expired"
                    };
                }
                // check 4: check refreshtoken exits in DB
                var storedToken = context_.RefreshTokens
                    .FirstOrDefault(x => x.Token == tokenModels.RefreshToken);
                if (storedToken == null)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token does not exist"
                    };
                }
                // check 5 : check refreshToken is used/revoked?
                if (storedToken.IsUsed)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been used"
                    };
                }
                //check bị thu hồi chưa
                if (storedToken.IsRevoked)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Refresh token has been revoked"
                    };
                }
                // check 6: Access token id == Jwt in RefreshToken
                var jti = tokenInverification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtID != jti)
                {
                    return new ApiResponse
                    {
                        Success = false,
                        Message = "Token doesn't not match"
                    };
                }
                //--------------------------------------
                //update Token is used
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                context_.Update(storedToken);
                await context_.SaveChangesAsync();
                //create new token
                var user = await context_.Nguoidungs.SingleOrDefaultAsync(a => a.Username == storedToken.nguoidungUsername);
                var token = await GeneratedToken(user);
                return new ApiResponse
                {
                    Success = true,
                    Message = "renew token success"

                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "Something went wrong"
                };
            }
        }

        private DateTime ConvertUnitTimeToDateTime(long utcExpireDate)
        {
            DateTime datetimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // Thêm số giây từ Unix timestamp
            return datetimeInterval.AddSeconds(utcExpireDate).ToUniversalTime();
        }
    }
}
