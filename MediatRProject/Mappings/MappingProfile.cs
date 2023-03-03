using AutoMapper;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.Models;

namespace MediatRProject.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PostCompanyApiRequestModel,Company >();
            CreateMap<UpdateCompanyApiRequestModel, Company>();
            CreateMap<Company,GetAllCompaniesApiRequestModel>();
            CreateMap<Company, GetAllCompaniesApiRequestModel>();
        }
    }
}
