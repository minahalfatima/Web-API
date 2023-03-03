using MediatR;
using MediatRProject.ApiFolder.Responses;

namespace MediatRProject.ApiFolder.Requests
{
    public class UpdateCompanyApiRequestModel:IRequest<UpdateCompanyApiResponseModel>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
       
       
    }
}
