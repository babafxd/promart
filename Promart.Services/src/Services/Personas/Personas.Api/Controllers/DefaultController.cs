﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("/prueba")]
    public class DefaultController : ControllerBase
    {

        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Solo es una prueba...";
        }
    }
}
