using MediatR;
using MediatRProject.ApiFolder.Responses;

namespace MediatRProject.ApiFolder.Requests
{
    public class GetAllCompaniesApiRequestModel : IRequest<GetAllCompaniesApiResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
