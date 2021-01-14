using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Personas.Service.EventHandlers.Commands;
using Personas.Service.Querys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("persona")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaQueryService _personaQueryService;
        private readonly ILogger<PersonaController> _logger;
        private readonly IMediator _mediator;
        public PersonaController(ILogger<PersonaController> logger,
                IPersonaQueryService personaQueryService,
                IMediator mediator)
        {
            _logger = logger;
            _personaQueryService = personaQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Model.Persona>> Get()
        {
            return await _personaQueryService.Personas();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaCreateCommand command)
        {
            try
            {
                await _mediator.Publish(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"--- Excepcion controlada:  {ex}");
                return ValidationProblem();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonaUpdateCommand command)
        {
            try
            {
                await _mediator.Publish(command);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"--- Excepcion controlada:  {ex}"); 
                return ValidationProblem();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                await _mediator.Publish(new PersonaDeleteCommand { PersonaID = id });
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"--- Excepcion controlada:  {ex}");
                return ValidationProblem();
            }
        }


    }
}
