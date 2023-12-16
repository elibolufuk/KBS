using AutoMapper;
using KBS.Core.Responses;
using KBS.CreditAppSys.Application.Features.Customers.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KBS.CreditAppSys.Web.Api.Controllers;
public class CustomerController(IMapper mapper) : BaseController
{
    private readonly IMapper _mapper = mapper;

    [HttpPost("Add")]
    [ProducesResponseType(typeof(ResponseResult<CreateCustomerCommandResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BaseResponseResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCommand request)
    {
        var response = await Mediator.Send(request);
        if (!response.Succeeded)
            return BadRequest(_mapper.Map<BaseResponseResult>(response));

        return Ok(response);
    }
}