using System.Data.Entity.ModelConfiguration;
using RestApi.Models;

namespace RestApi.DataAccess
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("Produtos");

            HasKey(produto => produto.Id);

            Property(produto => produto.Nome).IsRequired();
        }
    }
}