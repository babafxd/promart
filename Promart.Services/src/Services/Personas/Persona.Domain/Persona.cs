using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persona.Domain
{
    public class Persona
    {
 
        /// <summary>
        /// Persona Id
        /// </summary>
        [Key]
        public int PersonaID { get; set; }

        /// <summary>
        /// Nombres de la persona
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos de la persona
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Fecha nacimiento de la persona formato dd/mm/yyyy
        /// </summary>
        public string FechaNacimiento { get; set; }

        /// <summary>
        /// Numero documento de la persona
        /// </summary>
        public Int64 Documento { get; set; }

        /// <summary>
        /// Tipo documento : DNI / RUC
        /// </summary>
        public string TipoDocumento { get; set; }

        public List<PersonaDetalle> Detalle { get; set; }


    }
}


