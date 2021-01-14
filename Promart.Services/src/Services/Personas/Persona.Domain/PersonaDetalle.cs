using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persona.Domain
{
    public class PersonaDetalle
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey("PersonaID")]
        public int PersonaID { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

    }
}
