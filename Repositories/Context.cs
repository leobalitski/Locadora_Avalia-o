using Microsoft.EntityFrameworkCore;
using Models;

namespace DbRespositorie
{
    //Derived class from DbContext
    public class Context : DbContext
    {
        // propriedades        
       
        public DbSet<ClienteModels> Clientes { get; set; }
        
        public DbSet<FilmeModels> Filmes { get; set; }
       
        public DbSet<LocacaoModels> Locacoes { get; set; }
        
        public DbSet<LocacaoFilmeModels> LocacaoFilme { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql("Server=localhost;User Id=root;Database=locadorakadu");
        }
    }
}