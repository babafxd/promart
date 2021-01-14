using MediatR;
using Microsoft.Extensions.Logging;
using Persona.Persistence.Database;
using Personas.Service.EventHandlers.Commands;
using System.Threading;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Service.EventHandlers
{
    public class PersonaDetalleCreateEventHandler : INotificationHandler<PersonaDetalleCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaDetalleCreateEventHandler> _logger;


        public PersonaDetalleCreateEventHandler(ApplicationDbContext context,
             ILogger<PersonaDetalleCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaDetalleCreateCommand notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("--- PersonaDetalleCreateCommand iniciando");
            var persona = await _context.Personas.FindAsync(notification.PersonaID);

            if (persona != null)
            {

                _logger.LogInformation("--- Se encontraron datos");
                await _context.AddAsync(new Model.PersonaDetalle
                {
                    PersonaID = persona.PersonaID,
                    Direccion = notification.Direccion,
                    Email = notification.Email,
                    Telefono = notification.Telefono,
                });

                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogInformation("--- No se encontraron datos");
            }


        }


    }
}
