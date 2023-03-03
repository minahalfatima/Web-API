using MediatR;
using MediatRProject.ApiFolder.Responses;
using MediatRProject.Models;

namespace MediatRProject.ApiFolder.Requests
{
    public class PostCompanyApiRequestModel : IRequest<PostCompanyApiResponseModel>
    {
        public string Name { get; set; }
    }
}
