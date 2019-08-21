using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Domain.Usuario.Usuario>
    {
        public void Configure(EntityTypeBuilder<Domain.Usuario.Usuario> builder)
        {
            builder.ToTable("Usuario", "GraphQL");
            builder.HasKey(d => d.Id);
        }
    }
}
