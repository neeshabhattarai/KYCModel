using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.DTO
{
    public class ReadPersonalDetailsDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;


        public string DOB { get; set; }


        public string EmailAddress { get; set; } = string.Empty;


        public string PhoneNumber { get; set; }

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;


        public NationalIdentityDTO nationalIdentity { get; set; }

        public string Income { get; set; } = string.Empty;
    }
}
