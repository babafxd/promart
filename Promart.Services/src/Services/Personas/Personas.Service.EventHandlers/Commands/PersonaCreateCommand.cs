using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Commands
{
    public class PersonaCreateCommand : INotification
    {
        public int PersonaID { get; set; }


        public string Nombres { get; set; }


        public string Apellidos { get; set; }


        public DateTime FechaNacimiento { get; set; }

        public string Documento { get; set; }


        public string TipoDocumento { get; set; }

    
    }
}
