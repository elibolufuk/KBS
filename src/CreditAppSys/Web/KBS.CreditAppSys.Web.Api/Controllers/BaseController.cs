using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}