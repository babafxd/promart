using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persona.Test.Config;
using Model = Persona.Domain;
using Microsoft.Extensions.Logging;
using Personas.Service.EventHandlers;
using Moq;
using Personas.Service.EventHandlers.Commands;
using Personas.Service.EventHandlers.Exceptions;
using System;

namespace Persona.Test
{



    [TestClass]
    public class PersonaUpdateEventHandlerTest
    {
        //Objetos falsos para envio
        private ILogger<PersonaUpdateEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<PersonaUpdateEventHandler>>()
                        .Object;
            }
        }


        [TestMethod]
        [ExpectedException(typeof(PersonaUpdateEventHandlerException))]
        public void testActualizarPersonaNoExistente()
        {
            var context = ApplicationDbContextInMemory.Get();
            var handler = new PersonaUpdateEventHandler(context, GetLogger);

            try
            {
                handler.Handle(new PersonaUpdateCommand
                {
                    PersonaID = 99,
                    Nombres = "NO EXISTO",
                    Apellidos = "SAAVEDRA CASTRO",
                    FechaNacimiento = "13/06/1989",
                    TipoDocumento = "DNI",
                    Documento = 206022332332

                }, new System.Threading.CancellationToken()).Wait();

            }
            catch (AggregateException ae)
            {
                var exception = ae.GetBaseException();

                if (exception is PersonaUpdateEventHandlerException)
                {
                    throw new PersonaUpdateEventHandlerException(exception?.InnerException?.Message);
                }
            }

        }
    }
}
