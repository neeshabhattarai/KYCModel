using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApplicationClass.Model.DTO
{
    public class RegisterImageDTO
    {
        [Required]
        public string Id = Guid.NewGuid().ToString();

        [NotMapped]
        public IFormFile file {  get; set; }

       
        public string? FileDescription { get; set; }

    }
}
