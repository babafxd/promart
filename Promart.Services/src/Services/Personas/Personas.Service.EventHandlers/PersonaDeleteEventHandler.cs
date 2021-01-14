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
    public class PersonaDeleteEventHandler : INotificationHandler<PersonaDeleteCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaUpdateEventHandler> _logger;

        public PersonaDeleteEventHandler(ApplicationDbContext context,
            ILogger<PersonaUpdateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaDeleteCommand notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("--- PersonaUpdateCommand inicando");
            var persona = await _context.Personas.FindAsync(notification.PersonaID);

            if (persona != null)
            {
                _logger.LogInformation("--- Se encontraron datos");
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("--- No se encontraron datos");
            }

        }


    }
}
