using MediatR;
using MediatRProject.ApiFolder.Responses;

namespace MediatRProject.ApiFolder.Requests
{
    public class GetbyIdCompaniesApiRequestModel:IRequest<GetbyIdCompaniesApiResponseModel>
    {
        public Guid Id;
        public GetbyIdCompaniesApiRequestModel(Guid id)
        {
            Id = id;
        }
    }
}
