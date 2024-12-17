﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTrackingSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator? _mediator => HttpContext.RequestServices.GetService<IMediator>()?? throw new InvalidOperationException("IMediator can not be resolved.");
    }
}
