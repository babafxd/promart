using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persona.Api.CloudStorage;
using Personas.Service.EventHandlers.Commands;
using Personas.Service.Querys;
using System;
using System.Collections.Generic;
using System.IO;
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



        private readonly ICloudStorage _cloudStorage;

        public PersonaController(ILogger<PersonaController> logger,
                IPersonaQueryService personaQueryService,
                IMediator mediator,
                ICloudStorage cloudStorage)
        {
            _logger = logger;
            _personaQueryService = personaQueryService;
            _mediator = mediator;
            _cloudStorage = cloudStorage;
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

        /// <summary>
        /// Metodo para subir fotos
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("upload")]
        [AllowAnonymous]
        public async Task<string> SubirFoto(IFormFile file)
        {
            try
            {

                if (file != null)
                {
                    return await UploadFile(file);
                }
                else
                {
                    return "No adjunto un documento";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"--- Excepcion controlada:  {ex}");
                return ex.ToString();
            }

        }


        private async Task<string> UploadFile(IFormFile ImageFile)
        {
            string fileNameForStorage = FormFileName("foto", ImageFile.FileName);
            return "Url descarga:" + await _cloudStorage.UploadFileAsync(ImageFile, fileNameForStorage);

        }

        private static string FormFileName(string title, string fileName)
        {
            var fileExtension = Path.GetExtension(fileName);
            var fileNameForStorage = $"{title}-{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}";
            return fileNameForStorage;
        }






    }
}
