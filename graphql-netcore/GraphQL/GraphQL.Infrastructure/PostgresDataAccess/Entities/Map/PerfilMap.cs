using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Infrastructure.PostgresDataAccess.Entities.Map
{
    public class PerfilMap : IEntityTypeConfiguration<Domain.Perfil.Perfil>
    {
        public void Configure(EntityTypeBuilder<Domain.Perfil.Perfil> builder)
        {
            builder.ToTable("Perfil", "GraphQL");
            builder.HasKey(d => d.Id);
        }
    }
}
