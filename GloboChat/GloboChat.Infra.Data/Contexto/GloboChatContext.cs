using GloboChat.Dominio.Entidades;
using GloboChat.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboChat.Infra.Data.Contexto
{
    public class GloboChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLExpress;Initial Catalog=GloboChat;Integrated Security=SSPI;");
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

    }
}
