using Azure.Core;
using MediatR;
using MediatRProject.ApiFolder.Requests;
using MediatRProject.ApiFolder.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediatRProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost(nameof(ApiControllerPost))]
        public async Task<ActionResult<PostCompanyApiResponseModel>> ApiControllerPost([FromBody] PostCompanyApiRequestModel request)
        {
            try
            {
                return await _mediator.Send(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet(nameof(ApiControllerGetAll))]
        public async Task<ActionResult<GetAllCompaniesApiResponseModel>> ApiControllerGetAll()
        {
            try
            {
                var request = new GetAllCompaniesApiRequestModel();
                return Ok(await _mediator.Send(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{id:guid}", Name = nameof(ApiControllerGetById))]
        public async Task<ActionResult<GetAllCompaniesApiResponseModel>> ApiControllerGetById([FromRoute] Guid id)
        {
            try
            {
                var request = new GetbyIdCompaniesApiRequestModel(id);
                return Ok(await _mediator.Send(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id:guid}", Name = nameof(ApiControllerUpdate))]
        public async Task<ActionResult<UpdateCompanyApiResponseModel>> ApiControllerUpdate([FromRoute] Guid id, UpdateCompanyApiRequestModel request)
        {
            try
            {
                request.Id = id;
                return Ok(await _mediator.Send(request));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}",Name =nameof(ApiControllerDelete))]
        public async Task<IActionResult> ApiControllerDelete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteCompanyApiRequestModel { Id = id });

            return result.StatusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.NotFound => NotFound(result),
                _ => StatusCode((int)result.StatusCode, result)
            };
        }


    }
}
