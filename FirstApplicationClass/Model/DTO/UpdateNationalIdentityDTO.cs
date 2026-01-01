using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.DTO
{
    public class UpdateNationalIdentityDTO
    {
        [Required]
        public int NationalId { get; set; }
    }
}
