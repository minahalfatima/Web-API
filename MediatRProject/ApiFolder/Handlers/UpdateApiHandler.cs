using AutoMapper;
using Azure;
using MediatR;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.DatabaseProject;
using MediatRProject.Models;
using MediatRProject.Repositories;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace MediatRProject.ApiFolder.Handlers
{
    public class UpdateApiHandler : IRequestHandler<UpdateCompanyApiRequestModel, UpdateCompanyApiResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Company> _repository;


        public UpdateApiHandler(IMapper mapper, IGenericRepository<Company> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }



        public async Task<UpdateCompanyApiResponseModel> Handle(UpdateCompanyApiRequestModel request, CancellationToken cancellationToken)
        {
            var existingCompany = await _repository.GetById(request.Id);

            if (existingCompany == null)
            {
                return new UpdateCompanyApiResponseModel
                {
                    Response = $"Company with ID {request.Id} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            // Update the entity with the request data
            _mapper.Map(request, existingCompany);

            // Save changes to the database
            _repository.Update();

            // Construct the response
            var response = $"Updated entity with ID {request.Id}.";
            return new UpdateCompanyApiResponseModel
            {
                Response = response
            };
        }
    }
}
