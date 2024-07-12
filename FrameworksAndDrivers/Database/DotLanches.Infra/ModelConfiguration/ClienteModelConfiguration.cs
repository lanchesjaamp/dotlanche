using DotLanches.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotLanches.Infra.ModelConfiguration
{
    internal class ClienteModelConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.OwnsOne(
                x => x.Cpf,
                cpf =>
                {
                    cpf.Property(c => c.Number)
                        .HasColumnName("Cpf")
                        .IsRequired();
                });

            builder.Property(x => x.Email).IsRequired();
        }
    }
}