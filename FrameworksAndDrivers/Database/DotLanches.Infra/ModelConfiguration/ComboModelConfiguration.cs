using DotLanches.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotLanches.Infra.ModelConfiguration
{
    internal class ComboModelConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.PedidoId);
            builder.Ignore(c => c.Price);
        }
    }
}
