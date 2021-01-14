using MediatR;
using Microsoft.Extensions.Logging;
using Persona.Persistence.Database;
using Personas.Service.EventHandlers.Commands;
using System.Threading;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Service.EventHandlers
{
    public class PersonaDetalleUpdateEventHandler : INotificationHandler<PersonaDetalleUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaDetalleUpdateEventHandler> _logger;


        public PersonaDetalleUpdateEventHandler(ApplicationDbContext context,
             ILogger<PersonaDetalleUpdateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaDetalleUpdateCommand notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("--- PersonaDetalleUpdateCommand iniciando");
            var personaDetalle = await _context.PersonasDetalles.FindAsync(notification.ID);
            if (personaDetalle != null)
            {
                _logger.LogInformation("--- Se encontraron datos extras");
                personaDetalle.Direccion = notification.Direccion;
                personaDetalle.Telefono = notification.Telefono;
                personaDetalle.Email = notification.Email;
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("--- No se encontraron datos extras");
            }

        }


    }
}
