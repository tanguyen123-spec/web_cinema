using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using sell_movie.Entities;

namespace sell_movie.Secure.Data
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string nguoidungUsername { get; set; }
        [ForeignKey(nameof(nguoidungUsername))]
        public Nguoidung nguoidung { get; set; }

        //refresh token
        public string Token { get; set; }
        //access token
        public string JwtID { get; set; }

        //đã sử dụng ?
        public bool IsUsed { get; set; }
        //đã thu hồi ?
        public bool IsRevoked { get; set; }
        //tạo ra ngày ?
        public DateTime IssuedAt { get; set; }
        //hết hạn lúc ?
        public DateTime ExpireAt { get; set; }
    }
}
