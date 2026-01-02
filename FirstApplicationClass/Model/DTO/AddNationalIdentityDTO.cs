using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.DTO
{
    public class AddNationalIdentityDTO
    {
        [Key]
        [StringLength(100)]
        public string Id  = Guid.NewGuid().ToString();
        [Required]
        public int NationalId { get; set; }
    }
}
