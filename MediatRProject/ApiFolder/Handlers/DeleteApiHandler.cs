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
    public class DeleteApiHandler:IRequestHandler<DeleteCompanyApiRequestModel,DeleteCompanyApiResponseModel>
    {
        private readonly IMapper _mapper;
        //private readonly SqlServerContext _context;
        private readonly IGenericRepository<Company> _repository;

        public DeleteApiHandler(IMapper mapper, IGenericRepository<Company> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DeleteCompanyApiResponseModel> Handle(DeleteCompanyApiRequestModel request, CancellationToken cancellationToken)
        {
            var company =await _repository.GetById(request.Id);
            if (company == null)
            {

                return new DeleteCompanyApiResponseModel
                {
                    Response = $"Company with ID {request.Id} not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            _repository.Delete (company);
            var response = $"Company with ID {request.Id} deleted successfully";
            return new DeleteCompanyApiResponseModel
            {
                Response = response,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
