using MediatR;
using Persona.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Personas.Service.EventHandlers.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model = Persona.Domain;
using System;

namespace Personas.Service.EventHandlers
{
    public class PersonaDetalleDeleteEventHandler : INotificationHandler<PersonaDetalleDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaDetalleDeleteEventHandler> _logger;

        public PersonaDetalleDeleteEventHandler(ApplicationDbContext context,
            ILogger<PersonaDetalleDeleteEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaDetalleDeleteCommand notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("--- PersonaDetalleDeleteCommand iniciando");
            var personaDetalle = await _context.PersonasDetalles.FindAsync(notification.ID);

            if (personaDetalle != null)
            {
                _logger.LogInformation("--- Se encontraron datos");
                _context.PersonasDetalles.Remove(personaDetalle);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("--- No se encontraron datos");
            }

        }


    }
}
