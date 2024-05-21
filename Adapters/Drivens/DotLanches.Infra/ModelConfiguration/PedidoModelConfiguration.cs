using DotLanches.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Infra.ModelConfiguration
{
    internal class PedidoModelConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("NOW()")
                   .IsRequired();

            builder.Property(p => p.ClienteCPF).HasColumnName("ClienteCPF");

            builder.Property(p => p.TotalPrice)
                   .IsRequired()
                   .HasColumnType("numeric");

            builder.HasMany(p => p.Combos)
                   .WithOne(c => c.Pedido)
                   .HasForeignKey(c => c.PedidoId);

            builder.HasOne(p => p.Cliente)
                   .WithMany(c => c.Pedidos)
                   .HasForeignKey(p => p.ClienteCPF)
                   .HasPrincipalKey(c => c.Cpf);
        }
    }
}
