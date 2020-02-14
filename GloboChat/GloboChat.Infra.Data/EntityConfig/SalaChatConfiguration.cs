using GloboChat.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboChat.Infra.Data.EntityConfig
{
    public class SalaChatConfiguration : IEntityTypeConfiguration<SalaChat>
    {
        public void Configure(EntityTypeBuilder<SalaChat> builder)
        {
            builder
                .HasKey(sc => new { sc.IdChat, sc.IdPessoa });

            builder
                .HasOne(sc => sc.Pessoa)
                .WithMany(p => p.SalasChat)
                .HasForeignKey(sc => sc.IdPessoa);

            builder
                .HasOne(sc => sc.Chat)
                .WithMany(c => c.SalasChat)
                .HasForeignKey(sc => sc.IdChat);

        }
    }
}
