using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhimController : ControllerBase
    {
        private readonly IPhimService services_;
        private readonly IWebHostEnvironment _env;
        public PhimController(IPhimService services_, IWebHostEnvironment env)
        {
            this.services_ = services_;
            this._env = env;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await services_.GetAll();
            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    item.Banner = GetBannerByPhim(item.MaPhim);
                    item.Anh = GetImageByPhim(item.MaPhim);
                    await services_.UpdateImageUrl(item.MaPhim, item.Anh, item.Banner);
                }
            }
            else
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var theloai = await services_.GetById(id);
            if (theloai == null)
            {
                return NotFound();
            }
            return Ok(theloai);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Phim phim)
        {
            if (phim == null)
            {
                return BadRequest();
            }
            await services_.Create(phim);
            return Ok();

        }

        [HttpPost("add-by-models")]
        public async Task<IActionResult> AddPhimByModels(PhimModels phim)
        {
            if (phim == null)
            {
                return BadRequest();
            }
            await services_.CreateByModels(phim);
            // Gọi phương thức GetImageByPhim để lấy đường dẫn ảnh đúng
            if (!string.IsNullOrEmpty(phim.MaPhim))
            {
                string bannerUrl = GetBannerByPhim(phim.MaPhim);
                string imageUrl = GetImageByPhim(phim.MaPhim);
                await services_.UpdateImageUrl(phim.MaPhim, imageUrl, bannerUrl);
            }

            return Ok(phim);
        }
        [HttpGet("now-playing")]
        public async Task<IActionResult> GetNowPlayingMovies()
        {
            try
            {
                var nowPlayingMovies = await services_.GetNowPlayingMovies();
                return Ok(nowPlayingMovies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcomingMovies()
        {
            try
            {
                var upcomingMovies = await services_.GetUpcomingMovies();
                return Ok(upcomingMovies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] PhimModels phim)
        {
            var entity = new Phim
            {
                // Map the properties from the PhimModels object to a new Phim entity
                MaPhim = phim.MaPhim,
                TenPhim = phim.TenPhim,
                Ngaykhoichieu = phim.Ngaykhoichieu,
                Mota = phim.Mota,
                Anh = phim.Anh,
                Trailer = phim.Trailer,
                MaTl = phim.MaTl,
                MaQuocGia = phim.MaQuocGia,
                Banner = phim.Banner,
                Thoiluong = phim.Thoiluong
            };

            await services_.Update(id, entity);
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await services_.Delete(id);
            return Ok("Ctdatve deleted successfully.");
        }
        [HttpGet("genres")]
        public async Task<IActionResult> GetGenresByMovieId()
        {
            var genres = await services_.GetGenresByMovieId();
            if (genres == null)
            {
                return NotFound();
            }
            return Ok(genres);
        }
        [HttpPost("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            try
            {
                var _uploadfiles = Request.Form.Files;
                foreach (IFormFile source in _uploadfiles)
                {
                    string Filename = source.FileName;
                    string Filepath = GetFilePath(Filename);

                    if (!System.IO.Directory.Exists(Filepath))
                    {
                        System.IO.Directory.CreateDirectory(Filepath);
                    }
                    string imagepath = Filepath + "\\image.png";
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                    using (FileStream stream = System.IO.File.Create(imagepath))
                    {
                        await source.CopyToAsync(stream);
                    }

                    // Trả về đường dẫn ảnh đã tải lên thành công
                    string imageUrl = "http://localhost:5110/Uploads/Phim/" + Filename + "/image.png";
                    return Ok(imageUrl);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (exception) ở đây
            }

            return BadRequest("Failed to upload image.");
        }
        [NonAction]
        private string GetFilePath( string Phimcode)
        {
            return this._env.WebRootPath + "\\Uploads\\Phim\\" + Phimcode;
        }
        [NonAction]
        private string GetImageByPhim(string phimcode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "http://localhost:5110/";
            string filepath = GetFilePath(phimcode);
            string imagepath = filepath + "\\image.png";
            if(!System.IO.File.Exists (imagepath))
            {
                ImageUrl = HostUrl + "/Uploads/common/noimage.jpg";

            }
            else
            {
                ImageUrl = HostUrl + "/Uploads/Phim/" + phimcode + "/image.png";
            }
            return ImageUrl;
        }
        [HttpPost("UploadBanner")]
        public async Task<ActionResult> UploadBanner()
        {
            try
            {
                var uploadFiles = Request.Form.Files;
                foreach (IFormFile source in uploadFiles)
                {
                    string filename = source.FileName;
                    string filepath = GetBannerPath(filename);

                    if (!System.IO.Directory.Exists(filepath))
                    {
                        System.IO.Directory.CreateDirectory(filepath);
                    }
                    string bannerPath = filepath + "\\banner.png";
                    if (System.IO.File.Exists(bannerPath))
                    {
                        System.IO.File.Delete(bannerPath);
                    }
                    using (FileStream stream = System.IO.File.Create(bannerPath))
                    {
                        await source.CopyToAsync(stream)
        ;
                    }

                    // Trả về đường dẫn banner đã tải lên thành công
                    string bannerUrl = "http://localhost:5110/Uploads/Phim/" + filename + "/banner.png";
                    return Ok(bannerUrl);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (exception) ở đây
            }

            return BadRequest("Failed to upload banner.");
        }

        [NonAction]
        private string GetBannerPath(string phimCode)
        {
            return this._env.WebRootPath + "\\Uploads\\Phim\\" + phimCode;
        }

        [NonAction]
        private string GetBannerByPhim(string phimCode)
        {
            string bannerUrl = string.Empty;
            string hostUrl = "http://localhost:5110/";
            string filepath = GetBannerPath(phimCode);
            string bannerPath = filepath + "\\banner.png";
            if (!System.IO.File.Exists(bannerPath))
            {
                bannerUrl = hostUrl + "/Uploads/common/nobanner.jpg";
            }
            else
            {
                bannerUrl = hostUrl + "/Uploads/Phim/" + phimCode + "/banner.png";
            }
            return bannerUrl;
        }
    }
}
