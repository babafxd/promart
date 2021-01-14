using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Model = Persona.Domain;

namespace Persona.Persistence.Database.Configuration
{
    public class PersonaConfiguration
    {
        public PersonaConfiguration(EntityTypeBuilder<Model.Persona> entityBuilder)
        {
            
            entityBuilder.Property(x => x.Nombres).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Apellidos).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.FechaNacimiento).IsRequired();
            entityBuilder.Property(x => x.TipoDocumento).IsRequired().HasMaxLength(3);
            entityBuilder.Property(x => x.Documento).IsRequired().HasMaxLength(11);

            //Generar data
            var persona = new List<Model.Persona>();
            for (int i = 1; i < 5; i++)
            {
                persona.Add(
                        new Model.Persona
                        {

                            PersonaID = i,
                            Nombres = $"Marco Antonio {i}",
                            Apellidos = $"Saavedra Castro {i}",
                            FechaNacimiento = $"13/06/198{i}",
                            TipoDocumento = "DNI",
                            Documento = Convert.ToInt64($"{i}5957844")

                        }
                    );
            }

            entityBuilder.HasData(persona);

        }
    }
}
