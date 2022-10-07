using Apiteste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Apiteste.Controllers.Data
{
    public class FilmeContext: DbContext, IDesignTimeDbContextFactory<FilmeContext>
    {
        public FilmeContext()
        {
            
        }
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }

        public FilmeContext CreateDbContext(string[] args)
        {
             var optionsBuilder = new DbContextOptionsBuilder<FilmeContext>();
        optionsBuilder.UseMySql(
        "server=localhost;port=9999;initial catalog=FilmeAPI;uid=root;pwd=",
        ServerVersion.Parse("8.0.30-mysql"));

        return new FilmeContext(optionsBuilder.Options);
        }
    }
}