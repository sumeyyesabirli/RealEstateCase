using RealEstateCase.Core.ResponseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace RealEstateCase.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected IActionResult HandleResponse(BaseResponseModel responseModel)
        {
            if (responseModel.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok(responseModel);
            }
            else if (responseModel.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(responseModel);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, responseModel);
            }
        }

        protected IActionResult HandleResponse<T>(BaseResponseModel<T> responseModel)
        {
            if (responseModel.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok(responseModel);
            }
            else if (responseModel.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(responseModel);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, responseModel);
            }
        }
    }

}
