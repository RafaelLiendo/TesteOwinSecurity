using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestApi.Migrations;
using RestApi.Models;

namespace RestApi.DataAccess
{
    public class DomainDbContext : IdentityDbContext<Usuario>
    {
        public DomainDbContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DomainDbContext, Configuration>());

            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
        }

        public static DomainDbContext Create()
        {
            return new DomainDbContext();
        }
    }    
}