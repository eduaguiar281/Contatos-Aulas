using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendasContatos.Infra
{
    public class ContatosDbContextFactory : IDesignTimeDbContextFactory<ContatosDbContext>
    {
        public ContatosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContatosDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost, 2433; Database=ContatosDb; User ID=sa; Password=A123456@;");

            return new ContatosDbContext(optionsBuilder.Options);
        }
    }
}
