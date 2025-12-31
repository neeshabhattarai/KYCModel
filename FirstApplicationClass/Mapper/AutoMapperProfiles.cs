using AutoMapper;
using FirstApplicationClass.Model.Domains;
using FirstApplicationClass.Model.DTO;
namespace FirstApplicationClass.Mapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddPersonalDetaislDTO, PersonalDetails>().ReverseMap();
            CreateMap<UpdatePersonalDetailsDTO, PersonalDetails>().ReverseMap();
            CreateMap<ReadPersonalDetailsDTO, PersonalDetails>().ReverseMap();

        }
    }
}
