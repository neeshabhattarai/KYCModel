using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.DTO
{
    public class NationalIdentityDTO
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NationalId { get; set; }
    }
}
