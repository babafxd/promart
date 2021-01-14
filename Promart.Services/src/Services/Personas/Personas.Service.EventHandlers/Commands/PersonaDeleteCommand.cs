using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Commands
{
    public class PersonaDeleteCommand : INotification
    {
        public int PersonaID { get; set; }

   
    }
}
