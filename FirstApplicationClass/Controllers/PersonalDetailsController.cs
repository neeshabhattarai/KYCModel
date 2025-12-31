using AutoMapper;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstApplicationClass.Controllers
{
    [ApiController]
    [Route("api/personalinfo")]
    public class PersonalDetailsController : Controller
    {
        private readonly IPersonalDetails personalInfoRepository;
        private readonly IMapper mapper;

        public PersonalDetailsController(IPersonalDetails repository,IMapper mapper)
        {
            this.personalInfoRepository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetData()
        {
            var personalDetails = personalInfoRepository.ListOfPerson();
           var personalDetailsMapping= mapper.Map<List<AddPersonalDetaislDTO>>(personalDetails);
            return Ok(personalDetailsMapping);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDataById(string id)
        {
            var personalDetails =await personalInfoRepository.GetById(id);
            if (personalDetails == null)
            {
                return NotFound();
            }
            var personalDetailsMapping = mapper.Map<ReadPersonalDetailsDTO>(personalDetails);
            return Ok(personalDetailsMapping);
        }
        [HttpPost]
        public async Task<IActionResult> CreateData([FromBody]AddPersonalDetaislDTO details)
        {
            var personDetails = mapper.Map<PersonalDetails>(details);
            var personInfo = await personalInfoRepository.PostPersonalDetails(personDetails);

            var response = mapper.Map<ReadPersonalDetailsDTO>(personInfo);
            return Ok(response);
           
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(string id,UpdatePersonalDetailsDTO details)
        {
           var updatedResult= mapper.Map<PersonalDetails>(details);
            var result = await personalInfoRepository.UpdatePersonalInfo(id,updatedResult);
            if (result == null)
            {
                return NotFound();
            }
            var response = mapper.Map<ReadPersonalDetailsDTO>(result);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(string id)
        {
            var result = await personalInfoRepository.DeletePerson(id);
            if (result == null)
            {
                return NotFound();
            }
           var response= mapper.Map<ReadPersonalDetailsDTO>(result);
           return Ok(response);


        }
    }
}
