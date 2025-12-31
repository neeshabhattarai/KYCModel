using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model
{
    public class PersonalDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string DOB { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }= string.Empty;

        [Required]
        [MinLength(10)]
        public string PhoneNumber { get; set; } 
        [Required]
        [StringLength(100)]
        public string Address { get; set; }=string.Empty;
        [Required]
        [StringLength(100)]
        public string City { get; set; }=string.Empty;

        [Required]
       public int NationalId { get; set;  }
        [Required]

        [StringLength(100)]
        public string Income { get; set; } = string.Empty;


    }
}
