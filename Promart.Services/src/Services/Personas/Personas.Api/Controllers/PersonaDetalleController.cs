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
    /// <summary>
    /// Marco Saavedra - PROMART - servicio PersonaDetalleController, verbos POST/PUT/DELETE para el manejo de los datos extras de personas
    /// </summary>
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

        /// <summary>
        /// Metodo para agregar direccion, email o telefono a una persona por personaId
        /// </summary>
        /// <param name="personaId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo para actualizar un registro extra por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo para eliminar un registro extra por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
