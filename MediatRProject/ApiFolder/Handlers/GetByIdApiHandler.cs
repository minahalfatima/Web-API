using AutoMapper;
using MediatR;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.DatabaseProject;
using MediatRProject.Models;
using MediatRProject.Repositories;
using System.Net;

namespace MediatRProject.ApiFolder.Handlers
{
    public class GetByIdApiHandler : IRequestHandler<GetbyIdCompaniesApiRequestModel, GetbyIdCompaniesApiResponseModel>
    {
        private readonly IGenericRepository<Company> _repository;


        public GetByIdApiHandler( IGenericRepository<Company> repository)
        {
            _repository = repository;
        }

        public async Task<GetbyIdCompaniesApiResponseModel> Handle(GetbyIdCompaniesApiRequestModel request, CancellationToken cancellationToken)
        {
            var company = await _repository.GetById(request.Id);

            if (company == null)
            {
                return new GetbyIdCompaniesApiResponseModel
                {
                    Response = $"Company with ID {request.Id} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
         

            return new GetbyIdCompaniesApiResponseModel
            {
                Response = $"Company with ID {company.Id} found. Name: {company.Name}",
                Data = company
            };
        }

     
    }

}
