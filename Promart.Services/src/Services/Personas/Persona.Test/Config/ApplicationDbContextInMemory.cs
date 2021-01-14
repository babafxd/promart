using Microsoft.EntityFrameworkCore;
using Persona.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persona.Test.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get() 
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"dbpromart.Db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
