using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApplicationClass.Api.IntegrationTest.Model
{
    public class PersonalDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Income { get; set; }
        public string DOB { get; set; }

        public int NationalId { get; set; }
        public PersonalDetails cloneWith(Action<PersonalDetails> changes)
        {
            var shallowCopy = (PersonalDetails) MemberwiseClone();
            changes(shallowCopy);
            return shallowCopy;


        }
       

    }
}
