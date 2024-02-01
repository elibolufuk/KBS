using KBS.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace KBS.CreditAppSys.Web.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator? _mediator;
#nullable disable
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
#nullable restore

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
        {
            if (error is BaseResponseResult response)
            {
                response.HttpStatusCode = HttpStatusCode.BadRequest;
            }
            return base.BadRequest(error);
        }
    }
}