using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Commands
{
    public class PersonaDetalleDeleteCommand : INotification
    {
        public int ID { get; set; }
    }
}
