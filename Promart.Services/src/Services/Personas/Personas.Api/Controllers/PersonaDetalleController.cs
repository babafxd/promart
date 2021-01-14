using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Personas.Service.EventHandlers.Commands;
using Personas.Service.Querys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Persona.Api.Controllers
{
    [ApiController]
    [Route("persona-datos-extras")]
    public class PersonaDetalleController : Controller
    {
        private readonly ILogger<PersonaDetalleController> _logger;
        private readonly IMediator _mediator;

        public PersonaDetalleController(ILogger<PersonaDetalleController> logger,
              IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("{personaId}")]
        public async Task<IActionResult> Create(int personaId, PersonaDetalleCreateCommand command)
        {
            try
            {
                command.PersonaID = personaId;
                await _mediator.Publish(command);
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"--- Excepcion controlada:  {ex}");
                return ValidationProblem();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonaDetalleUpdateCommand command)
        {
            try
            {
                command.ID = id;
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

                await _mediator.Publish(new PersonaDetalleDeleteCommand { ID = id });
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
