using AutoMapper;
using FPTCertification.WebApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPTCertification.WebApi.Controllers
{
    [Route("error")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        public ErrorController()
        {
            
        }
        [HttpGet]
        public IActionResult Error()
        {
            return BadRequest("loi vl");
        }
    }
}
