using System.Data.Entity.ModelConfiguration;
using RestApi.Models;

namespace RestApi.DataAccess
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            Property(produto => produto.Nome).HasMaxLength(100).IsRequired();

            Property(produto => produto.Sobrenome).HasMaxLength(100).IsRequired();
        }
    }
}