using System.Net;

namespace MediatRProject.ApiFolder.Responses
{
    public class UpdateCompanyApiResponseModel
    {
        public string Response { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
