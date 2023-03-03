using AutoMapper;
using MediatR;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.DatabaseProject;
using MediatRProject.Models;
using MediatRProject.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MediatRProject.ApiFolder.Handlers
{
    public class GetApiHandler : IRequestHandler<GetAllCompaniesApiRequestModel, GetAllCompaniesApiResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Company> _repository;


        public GetApiHandler(IMapper mapper, IGenericRepository<Company> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GetAllCompaniesApiResponseModel> Handle(GetAllCompaniesApiRequestModel request, CancellationToken cancellationToken)
        {
            var companies = await _repository.GetAll();
            if (!companies.Any())
            {
                return new GetAllCompaniesApiResponseModel
                {
                    Response = "No companies Found",
                    StatusCode = HttpStatusCode.NotFound

                };
            }
            var companyDtos = _mapper.Map<List<GetAllCompaniesApiRequestModel>>(companies);
            return new GetAllCompaniesApiResponseModel
            {
                Response = $"{companies.Count()} companies found",
                Data = companyDtos

            };
        }
    }
}