using AutoMapper;
using MediatR;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.DatabaseProject;
using MediatRProject.Models;
using MediatRProject.Repositories;
using Microsoft.EntityFrameworkCore;


namespace MediatRProject.ApiFolder.Handlers
{
    public class InsertApiHandler : IRequestHandler<PostCompanyApiRequestModel, PostCompanyApiResponseModel>
    {
        private readonly IMapper _mapper;
        // inject DTabase context here 
        //private readonly SqlServerContext _context;
        private readonly IGenericRepository<Company> _repository;   
        private readonly ILogger<InsertApiHandler> _logger;

        public InsertApiHandler(IMapper mapper, IGenericRepository<Company> repository, ILogger<InsertApiHandler> logger = null)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<PostCompanyApiResponseModel> Handle(PostCompanyApiRequestModel request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request);
            _repository.Add(company);
            // Construct the response
            var response = $"Inserted entity with ID {company.Id} ";
            _logger.LogInformation(response);
            _logger.LogError(response);
            _logger.LogDebug(response);
            _logger.LogTrace(response);
            return new PostCompanyApiResponseModel
            {
                Response = response,
            };

        }
    }
}
