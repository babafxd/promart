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
    public class PersonaCreateEventHandler : INotificationHandler<PersonaCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PersonaCreateEventHandler> _logger;

        public PersonaCreateEventHandler(ApplicationDbContext context,
            ILogger<PersonaCreateEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        //Desencadenante del evento
        public async Task Handle(PersonaCreateCommand command, CancellationToken cancellationToken)
        {
            
            await _context.AddAsync(new Model.Persona
            {
                Nombres = command.Nombres,
                Apellidos = command.Apellidos,
                FechaNacimiento = command.FechaNacimiento,
                Documento = command.Documento,
                TipoDocumento = command.TipoDocumento,
            });

            await _context.SaveChangesAsync();
        }


    }
}
