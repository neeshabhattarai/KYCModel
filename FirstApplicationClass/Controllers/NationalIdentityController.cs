using AutoMapper;
using FirstApplicationClass.CustomValidationAttribute;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
using FirstApplicationClass.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplicationClass.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
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
        [Authorize]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GeAllv1()
        {
            var resutl= await nationalIDentityRepository.GetAll();


            return Ok(mapper.Map<List<ReadNationalIdentityDTOv1>>(resutl));
        }
        [HttpGet]
        [Authorize]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GeAllv2()
        {
            var resutl = await nationalIDentityRepository.GetAll();
            var result = new List<ReadNationalIdentityDTOv2>();
            foreach (var val1 in resutl)
            {
                result.Add(new ReadNationalIdentityDTOv2
                {
                    Id = val1.Id,
                    NationalIdName = val1.NationalId
                });
            }

            return Ok(result);
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
            


            return Ok(mapper.Map<ReadNationalIdentityDTOv1>(response));
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
            return Ok(mapper.Map<ReadNationalIdentityDTOv1>(result));
        }

    }
}
