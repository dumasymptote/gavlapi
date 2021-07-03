using AutoMapper;
using gavl_api.Models;
using gavl_api.Models.DTO;

namespace gavl_api.Models.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Account, AccountResource>();
        }
    }
}
