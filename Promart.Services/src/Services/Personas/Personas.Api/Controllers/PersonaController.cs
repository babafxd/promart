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

    /// <summary>
    /// Marco Saavedra - PROMART - servicio PersonaController, verbos GET/POST/PUT/DELETE para el manejo de personas
    /// </summary>
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


        /// <summary>
        /// Metodo para listar personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        [HttpGet]
        public async Task<List<Model.Persona>> Get()
        {
            try
            {
                _logger.LogInformation($"--- Iniciando listado de personas");
                return await _personaQueryService.Personas();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }



        /// <summary>
        /// Metodo para crear una persona
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
                _logger.LogError($"--- Excepcion controlada:  {ex}");
                return ValidationProblem(ex.ToString());
            }
        }


        /// <summary>
        /// Metodo para actualizar una persona
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
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
                _logger.LogError($"--- Excepcion controlada:  {ex}");
                return ValidationProblem();
            }
        }

        /// <summary>
        /// Metodo para eliminar una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                _logger.LogError($"--- Excepcion controlada:  {ex}");
                return ValidationProblem();
            }
        }


    }
}
