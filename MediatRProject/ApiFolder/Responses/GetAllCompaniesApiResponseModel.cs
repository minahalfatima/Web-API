using System.Net;

namespace MediatRProject.ApiFolder.Responses
{
    public class GetAllCompaniesApiResponseModel
    {
        public string Response { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
