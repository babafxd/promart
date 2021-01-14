using System;
using System.Collections.Generic;
using System.Text;
using Model = Persona.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persona.Persistence.Database.Configuration
{
    public class PersonaDetalleConfiguration
    {

        public PersonaDetalleConfiguration(EntityTypeBuilder<Model.PersonaDetalle> entityBuilder)
        {
            //entityBuilder.HasKey(x => x.IdPersonaDetalle);
            entityBuilder.Property(x => x.Direccion).IsRequired().HasMaxLength(300);
            entityBuilder.Property(x => x.Telefono).HasMaxLength(13);
            entityBuilder.Property(x => x.Email).HasMaxLength(50);


            //Generar data
            var personaDetalle = new List<Model.PersonaDetalle>();
            for (int i = 1; i < 5; i++)
            {
                personaDetalle.Add(
                        new Model.PersonaDetalle
                        {
                            ID = i,
                            PersonaID = i,
                            Direccion = $"Santa Anita numero {i}",
                            Telefono = $"+5{i}998989333",
                            Email = $"msaavedra.{i}@gmail.com",

                        }
                    );
            }
            entityBuilder.HasData(personaDetalle);

        }

    }
}
