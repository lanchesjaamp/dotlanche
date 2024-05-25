using DotLanches.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotLanches.Infra.ModelConfiguration
{
    internal class PedidoModelConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ClienteCpf);
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("NOW()");

            builder.HasOne<Status>()
                .WithMany()
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(p => p.StatusId);

            builder.Ignore(p => p.TotalPrice);
        }
    }
}
