using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.CreditApplications.Commands.Create;
using KBS.CreditAppSys.Application.Features.CreditApplications.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KBS.CreditAppSys.Web.Api.Controllers
{
    public class CreditApplicationController(IMapper mapper) : BaseController
    {
        private readonly IMapper _mapper = mapper;

        [HttpPost("Add")]
        [ProducesResponseType(typeof(ResponseResult<CreateCreditApplicationCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponseResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Add([FromBody] CreateCreditApplicationCommand request)
        {
            var response = await base.Mediator.Send(request);
            if (!response.Succeeded)
                return BadRequest(_mapper.Map<BaseResponseResult>(response));

            return Ok(response);
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(ResponseResult<GetByIdCreditApplicationQueryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponseResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] GetByIdCreditApplicationQuery request)
        {
            var response = await base.Mediator.Send(request);

            if (!response.Succeeded)
                return BadRequest(_mapper.Map<BaseResponseResult>(response));

            return Ok(response);
        }

        [HttpGet("List")]
        [ProducesResponseType(typeof(ResponseResult<GetByIdCreditApplicationQueryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponseResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> List([FromRoute] GetByIdCreditApplicationQuery request)
        {
            var response = await base.Mediator.Send(request);

            if (!response.Succeeded)
                return BadRequest(_mapper.Map<BaseResponseResult>(response));

            return Ok(response);
        }
    }
}
