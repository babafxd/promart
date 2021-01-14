using MediatR;
using Persona.Persistence.Database;
using Personas.Service.EventHandlers.Commands;
using System.Threading;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Service.EventHandlers
{
    public class PersonaCreateEventHandler : INotificationHandler<PersonaCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public PersonaCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
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
