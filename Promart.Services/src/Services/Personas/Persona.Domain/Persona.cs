using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persona.Domain
{
    public class Persona
    {
 
        [Key]
        public int PersonaID { get; set; }


        public string Nombres { get; set; }


        public string Apellidos { get; set; }


        public DateTime FechaNacimiento { get; set; }

        public string Documento { get; set; }


        public string TipoDocumento { get; set; }

        public List<PersonaDetalle> Detalle { get; set; }


    }
}


