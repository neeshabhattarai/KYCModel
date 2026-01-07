using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.Model.Domains
{
    public class PersonalDetails
    {

        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; }=string.Empty;
 
        public string LastName { get; set; } = string.Empty;

      
        public string DOB { get; set; }

        public string EmailAddress { get; set; }= string.Empty;

      
        public string PhoneNumber { get; set; } 
  
        public string Address { get; set; }=string.Empty;
       
        public string City { get; set; }=string.Empty;

      
     
       
        public string Income { get; set; } = string.Empty;

        public string NationalIdentityId {  get; set; }=string.Empty;
        public NationalIdentity NationalIdentity { get; set; }


    }
}
