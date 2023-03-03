using MediatR;
using MediatRProject.ApiFolder.Responses;

namespace MediatRProject.ApiFolder.Requests
{
    public class DeleteCompanyApiRequestModel:IRequest<DeleteCompanyApiResponseModel>
    {
        public Guid Id { get; set; }

    }
}
