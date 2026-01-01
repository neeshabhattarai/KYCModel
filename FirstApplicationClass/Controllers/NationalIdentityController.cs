using AutoMapper;
using FirstApplicationClass.CustomValidationAttribute;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplicationClass.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalIdentityController : ControllerBase
    {
        private readonly INationalIdentity nationalIDentityRepository;
        private readonly IMapper mapper;

        public NationalIdentityController(INationalIdentity nationalIDentityRepository,IMapper mapper)
        {
            this.nationalIDentityRepository = nationalIDentityRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GeAll()
        {
            var resutl= await nationalIDentityRepository.GetAll();

            return Ok(mapper.Map<List<ReadNationalIdentityDTO>>(resutl));
        }
        [ValidationModel]
        [HttpPost]
        public async Task<IActionResult> PostNationalIdentity([FromBody]AddNationalIdentityDTO resutl)
        {
            var result= mapper.Map<NationalIdentity>(resutl);
          var response= await nationalIDentityRepository.Create(result);


            return CreatedAtAction(nameof(GetById),new {id=result.Id},response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            
            var response = await nationalIDentityRepository.GetById(id);
            


            return Ok(mapper.Map<ReadNationalIdentityDTO>(response));
        }
        [HttpPut]
        [Route("{id}")]
        [ValidationModel]

        public async Task<IActionResult> UpdateNationalIdentity([FromBody] UpdateNationalIdentityDTO nationaldto, [FromRoute] string id)
        {
            var nationalDto=mapper.Map<NationalIdentity>(nationaldto);
            var user = await nationalIDentityRepository.Update(id, nationalDto);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteNationalIdById(string id)
        {
            var result = await nationalIDentityRepository.Delete(id);
            return Ok(mapper.Map<ReadNationalIdentityDTO>(result));
        }

    }
}
