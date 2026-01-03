using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstApplicationClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImage ImageHandler;

        public ImageController(IImage imageHandler)
        {
            this.ImageHandler = imageHandler;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] RegisterImageDTO registerImageDTO)
        {
            if (ValidateImage(registerImageDTO))
            {
                var image = new RegisterImage
                {
                    Id=registerImageDTO.Id,
                    FileName = registerImageDTO.file.FileName,
                    file = registerImageDTO.file,
                    FileExtensions = Path.GetExtension(registerImageDTO.file.FileName),
                    FileSize = registerImageDTO.file.Length
                };
                
               var imageUrl=await ImageHandler.Upload(image);
                return Ok(imageUrl);
            }
            return BadRequest("Unable to upload Image");

        }
        private  bool ValidateImage(RegisterImageDTO imageDTO) {

            string[] collection = { ".jpg", ".png", ".jpeg" };
            Console.Write(Path.GetExtension(imageDTO.file.FileName));

            if (!collection.Contains(Path.GetExtension(imageDTO.file.FileName))){
                return false;
            }

            return true;
        }

    }
}
