using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persona.Persistence.Database;
using Personas.Service.EventHandlers.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Service.EventHandlers
{
    public class PersonaUpdateEventHandler : INotificationHandler<PersonaUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaUpdateEventHandler> _logger;

        public PersonaUpdateEventHandler(ApplicationDbContext context , 
            ILogger<PersonaUpdateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaUpdateCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- PersonaUpdateCommand inicando");            
            var persona = await _context.Personas.FindAsync(notification.PersonaID);

            if (persona != null)
            {
                _logger.LogInformation("--- Se encontraron datos");
                persona.Nombres = notification.Nombres;
                persona.Apellidos = notification.Apellidos;
                persona.FechaNacimiento = notification.FechaNacimiento;
                persona.Documento = notification.Documento;
                persona.TipoDocumento = notification.TipoDocumento;
            }
            else 
            {
                _logger.LogInformation("--- No se encontraron datos");
            }

            await _context.SaveChangesAsync();

        }


    }
}
