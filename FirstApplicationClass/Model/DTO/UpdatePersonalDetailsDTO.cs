using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.DTO
{
    public class UpdatePersonalDetailsDTO
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DOB { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        public string NationalIdentityId { get; set; } = string.Empty;
        [Required]

        [StringLength(100)]
        public string Income { get; set; } = string.Empty;
    }
}
