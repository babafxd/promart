using Microsoft.EntityFrameworkCore;
using Persona.Persistence.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Persona.Domain;

namespace Personas.Service.Querys
{
    public interface IPersonaQueryService 
    {
        Task<List<Model.Persona>> Personas();


    }


    public class PersonaQueryService : IPersonaQueryService
    {
        private readonly ApplicationDbContext _context;
        public PersonaQueryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Model.Persona>> Personas()
        {
            var personas = await _context.Personas.OrderByDescending(x => x.PersonaID).ToListAsync();
            
            return personas;

        }

    }
}
