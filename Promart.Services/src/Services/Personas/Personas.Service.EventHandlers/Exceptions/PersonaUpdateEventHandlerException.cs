using System;
using System.Collections.Generic;
using System.Text;

namespace Personas.Service.EventHandlers.Exceptions
{
    public class PersonaUpdateEventHandlerException : Exception
    {
        public PersonaUpdateEventHandlerException(string mensajeExcepcion) 
               :base(mensajeExcepcion)
        {
            
        }
    }
}
