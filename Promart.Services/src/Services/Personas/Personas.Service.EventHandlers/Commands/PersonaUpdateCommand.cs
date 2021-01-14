using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Commands
{
    public class PersonaUpdateCommand : INotification
    {
        public int PersonaID { get; set; }


        public string Nombres { get; set; }


        public string Apellidos { get; set; }


        public string FechaNacimiento { get; set; }

        public Int64 Documento { get; set; }


        public string TipoDocumento { get; set; }

    
    }
}
