using AutoMapper;
using Castle.Core.Logging;
using FirstApplicationClass.Controllers;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApplicatinClass.UnitTest.ControllerTest
{
    public class PersonalDetailsControllerTest
    {
        private readonly PersonalDetailsController detailsController;
        private Mock<IPersonalDetails> service;
        private Mock<IMapper> mapper;
        private Mock<ILogger<PersonalDetailsController>> logger;
        public PersonalDetailsControllerTest()
        {
            service= new Mock<IPersonalDetails>();
            mapper=new Mock<IMapper>();
            logger=new Mock<ILogger<PersonalDetailsController>>();
            detailsController=new PersonalDetailsController(service.Object,mapper.Object,logger.Object);
        }
        [Fact]
        public async Task GetAllPersonalDetails_ShouldReturnTrue()
        {
            service.Setup(x => x.ListOfPerson(filterBy: null, null, null)).Returns(new List<PersonalDetails> { GetPersonalDetails() });
            var result=detailsController.GetData(null,null,null);
            Assert.IsType<OkObjectResult>(result);
        }
        public static PersonalDetails GetPersonalDetails()
        {
            var id = Guid.NewGuid().ToString();
            return new PersonalDetails
            {
                Id = Guid.NewGuid().ToString(),
                Address = "test",
                LastName = "test",
                FirstName = "test",
                City = "test",
                DOB = "2004",
                EmailAddress = "test@gmail.com",
                Income = "Testing",
                PhoneNumber = "9876087769",
                NationalIdentityId = id,
                NationalIdentity = new NationalIdentity
                {
                    Id = id,
                    NationalId = 333
                }
            };
        }

    }

}

