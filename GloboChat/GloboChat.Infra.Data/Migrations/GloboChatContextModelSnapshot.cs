﻿// <auto-generated />
using System;
using GloboChat.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GloboChat.Infra.Data.Migrations
{
    [DbContext(typeof(GloboChatContext))]
    partial class GloboChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("loginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("loginId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Canal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Canais");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nick")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nivelAcesso")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Moderador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.Property<int?>("loginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.HasIndex("loginId");

                    b.ToTable("Moderadores");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CanalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanalId");

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ProgramaAtualId")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramaAtualId");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("loginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.HasIndex("loginId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Admin", b =>
                {
                    b.HasOne("GloboChat.Dominio.Entidades.Login", "login")
                        .WithMany()
                        .HasForeignKey("loginId");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Moderador", b =>
                {
                    b.HasOne("GloboChat.Dominio.Entidades.Sala", null)
                        .WithMany("Moderadores")
                        .HasForeignKey("SalaId");

                    b.HasOne("GloboChat.Dominio.Entidades.Login", "login")
                        .WithMany()
                        .HasForeignKey("loginId");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Programa", b =>
                {
                    b.HasOne("GloboChat.Dominio.Entidades.Canal", null)
                        .WithMany("Programas")
                        .HasForeignKey("CanalId");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Sala", b =>
                {
                    b.HasOne("GloboChat.Dominio.Entidades.Programa", "ProgramaAtual")
                        .WithMany()
                        .HasForeignKey("ProgramaAtualId");
                });

            modelBuilder.Entity("GloboChat.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("GloboChat.Dominio.Entidades.Sala", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("SalaId");

                    b.HasOne("GloboChat.Dominio.Entidades.Login", "login")
                        .WithMany()
                        .HasForeignKey("loginId");
                });
#pragma warning restore 612, 618
        }
    }
}
