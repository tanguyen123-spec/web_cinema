using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sell_movie.Entities;
using sell_movie.Models;
using sell_movie.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await services_.GetAll();
            if (result != null && result.Count() > 0)
            {
                foreach (var item in result)
                {
                    item.Anh = GetImageByPhim(item.MaPhim);
                    await services_.UpdateImageUrl(item.MaPhim, item.Anh);
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
                string imageUrl = GetImageByPhim(phim.MaPhim);
                await services_.UpdateImageUrl(phim.MaPhim, imageUrl);
            }

            return Ok(phim);
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

    }
}
