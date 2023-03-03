using System.Net;

namespace MediatRProject.ApiFolder.Responses
{
    public class DeleteCompanyApiResponseModel
    {
        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
