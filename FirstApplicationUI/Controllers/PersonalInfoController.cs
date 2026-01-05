using FirstApplicationUI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FirstApplicationUI.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly IHttpClientFactory factory;

        public PersonalInfoController(IHttpClientFactory factory)
        {
            this.factory = factory;
        }
        public async Task<IActionResult> Index()
        {
            var client=factory.CreateClient();
           var result= await client.GetFromJsonAsync<List<PersonalIdentityDTO>>("http://localhost:5258/api/personalinfo");
            
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AddPersonal()
        {
           

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var client = factory.CreateClient();
            var result = await client.GetFromJsonAsync<PersonalIdentityDTO>($"http://localhost:5258/api/personalinfo/{id}");
            
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PersonalIdentityDTO personalIdentity)
        {
            if (ModelState.IsValid)
            {
                var client = factory.CreateClient();
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"http://localhost:5258/api/personalinfo/{personalIdentity.Id}"),
                    Content = new StringContent(JsonSerializer.Serialize(personalIdentity), Encoding.UTF8, "application/json"),

                };
                var response = await client.SendAsync(request);
                if (response is not null)
                {
                    return RedirectToAction("Index", "PersonalInfo");
                }
                return View(personalIdentity);
            }
            return View(personalIdentity);
            }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var client = factory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5258/api/personalinfo/{id}");
            //response.EnsureSuccessStatusCode();
            if (response is not null)
            {

                return RedirectToAction("Index", "PersonalInfo");
            }
            return View(null);
        }
            
        
        [HttpPost]
        public  async Task<IActionResult> AddPersonal(PersonalIdentityDTO personalIdentityDTO) 
        {
            var client = factory.CreateClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("http://localhost:5258/api/personalinfo"),
                Method = HttpMethod.Post
                ,
                Content = new StringContent(JsonSerializer.Serialize(personalIdentityDTO),Encoding.UTF8,"application/json"),
                
            };
           var response= await client.SendAsync(request);
            var responseAsJson=await response.Content.ReadFromJsonAsync<PersonalIdentityDTO>();
            if (responseAsJson != null)
            {
                return RedirectToAction("Index", "PersonalInfo");
            }
            return View(responseAsJson);

        }
     }
}
