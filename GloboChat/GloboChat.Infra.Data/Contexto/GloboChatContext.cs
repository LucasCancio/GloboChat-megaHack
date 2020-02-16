using GloboChat.Dominio.Entidades;
using GloboChat.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GloboChat.Infra.Data.Contexto
{
    public class GloboChatContext : DbContext
    {
        public GloboChatContext(DbContextOptions<GloboChatContext> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Canal> Canais { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<SalaChat> SalasChat { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new SalaChatConfiguration());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
