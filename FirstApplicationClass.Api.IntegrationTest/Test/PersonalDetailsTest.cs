using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FirstApplicationClass.Api.IntegrationTest;
using FirstApplicationClass.Api.IntegrationTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FirstApplicationClass.Api.IntegrationTest.Controller
{
    public class PersonalDetailsTest:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;
        public PersonalDetailsTest(WebApplicationFactory<Program> factory)
        {
           httpClient=factory.CreateClient(); 
        }

        [Fact]
        public async Task GetPersonalInfo()
        {
            var persons = await httpClient.GetAsync("/api/personalinfo");
            persons.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, persons.StatusCode);
        }
        [Fact]
        public async Task PostPersonalInfo()
        {
            var person = personalDetails();
            var result = await httpClient.PostAsJsonAsync<PersonalDetails>("/api/personalinfo", person, JsonSerializerOptions.Default);
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
        [Fact]
        public async Task NullTestingOfPersonalInfo()
        {
            var person = personalDetails().cloneWith(req => req.FirstName = null);
            var request = await httpClient.PostAsJsonAsync("/api/personalinfo", person, JsonSerializerOptions.Default);
            Assert.Equal(HttpStatusCode.BadRequest,request.StatusCode);
            var response=await request.Content.ReadFromJsonAsync<ValidationProblemDetails>();
            Assert.Collection(response.Errors, (req) =>
            {
                Assert.Equal("FirstName", req.Key);
            });
        }
        public static PersonalDetails personalDetails()
        {
            return new PersonalDetails
            {
                Address="test",
                City="test",
                DOB="test",
                EmailAddress="test@gmail.com",
                FirstName="test",
                LastName="test",
                Income="test",
                NationalId=10,
                PhoneNumber="9800000000"
            };
        }
        }
}
