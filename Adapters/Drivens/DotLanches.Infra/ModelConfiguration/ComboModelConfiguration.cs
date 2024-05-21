using DotLanches.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Infra.ModelConfiguration
{
    internal class ComboModelConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Price)
                   .IsRequired()
                   .HasColumnType("numeric");

            builder.HasOne(c => c.Pedido)
                   .WithMany(p => p.Combos)
                   .HasForeignKey(c => c.PedidoId);

            builder.HasOne(c => c.Lanche)
                   .WithMany()
                   .HasForeignKey(c => c.LancheId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Acompanhamento)
                   .WithMany()
                   .HasForeignKey(c => c.AcompanhamentoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Bebida)
                   .WithMany()
                   .HasForeignKey(c => c.BebidaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Sobremesa)
                   .WithMany()
                   .HasForeignKey(c => c.SobremesaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
