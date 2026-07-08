// Copyright (c) 2026 - opx
using Microsoft.AspNetCore.Mvc;
using Opx.Api.Web.Common;
using Opx.Api.Web.Handlers;

namespace Chinook.Api.Dev.Controllers
{
    [ApiController]
    [OpxApiExceptionHandler]
    [OpxApiFilterHandler]
    public class ApiController : OpxApiController
    {
        
    }
}