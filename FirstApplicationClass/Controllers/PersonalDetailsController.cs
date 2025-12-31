using FirstApplicationClass.Model;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplicationClass.Controllers
{
    [ApiController]
    [Route("api/personalinfo")]
    public class PersonalDetailsController : Controller
    {
        private readonly IPersonalInfo personalInfoRepository;
        public PersonalDetailsController(IPersonalInfo repository)
        {
            this.personalInfoRepository = repository;
        }
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(personalInfoRepository.ListOfPerson());
        }
        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody]PersonalDetails details)
        {
            
            var personInfo = await personalInfoRepository.PostPersonalDetails(details);
            return Ok(personInfo);
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(string id,PersonalDetails details)
        {
            var result = await personalInfoRepository.UpdatePersonalInfo(id,details);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(string id)
        {
           string result= await personalInfoRepository.DeletePerson(id);
           return Ok(result);


        }
    }
}
