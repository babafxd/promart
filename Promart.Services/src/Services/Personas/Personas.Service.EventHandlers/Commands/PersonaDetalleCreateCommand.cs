using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Commands
{
    public class PersonaDetalleCreateCommand : INotification
    {
 
        public int ID { get; set; }
        public int PersonaID { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }


    }
}
