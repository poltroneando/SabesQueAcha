using SabesQueAcha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SabesQueAcha.Context
{
    public class SabesContext : DbContext
    {
        public SabesContext()
            :base("SabesQueAchaContext")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Lojista> Lojista { get; set; }                                             

        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Comentario> Comentario { get; set; }

        public DbSet<Categoria> Categoria { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            #region Usuario

            modelBuilder.Entity<Usuario>()
                .HasKey(p => p.IdUsuario);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.IdUsuario)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.Nome)
               .HasMaxLength(100);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.Email)
               .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.Foto)
               .IsOptional()
               .HasMaxLength(250);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.Login)
               .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
               .Property(p => p.Senha)
               .HasMaxLength(50);

            modelBuilder.Entity<Usuario>()
               .HasOptional(p => p.Lojista)
               .WithRequired(l => l.Usuario);


            #endregion

            #region Lojista

            modelBuilder.Entity<Lojista>()
                .HasKey(p => p.IdLojista);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.IdLojista)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.RazaoSocial)
               .HasMaxLength(200);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.NomeFantasia)
               .IsOptional()
               .HasMaxLength(200);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.CNPJ)
               .IsRequired()
               .HasMaxLength(20);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.Email)
               .HasMaxLength(50);

            modelBuilder.Entity<Lojista>()
               .Property(p => p.Telefone)
               .HasMaxLength(50);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.CEP)
              .HasMaxLength(15);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Logradouro)
              .HasMaxLength(200);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Numero)
              .HasMaxLength(20);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Complemento)
              .HasMaxLength(100);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Cidade)
              .HasMaxLength(100);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Bairro)
              .HasMaxLength(100);

            modelBuilder.Entity<Lojista>()
              .Property(p => p.Cidade)
              .HasMaxLength(200);

            #endregion

            #region Promoção

            modelBuilder.Entity<Promocao>()
                .HasKey(p => p.IdPromocao);

            modelBuilder.Entity<Promocao>()
               .Property(p => p.IdPromocao)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Promocao>()
               .Property(p => p.IdLojista)
               .IsOptional();

            modelBuilder.Entity<Promocao>()
               .Property(p => p.Titulo)
               .HasMaxLength(50);

            modelBuilder.Entity<Promocao>()
               .Property(p => p.UrlPromocao)
               .HasMaxLength(500);

            modelBuilder.Entity<Promocao>()
               .Property(p => p.Descricao)
               .HasMaxLength(200);

            modelBuilder.Entity<Promocao>()
               .Property(p => p.Foto)
               .HasMaxLength(250)
               .IsOptional();


            //modelBuilder.Entity<Promocao>()
            //        .HasRequired<Usuario>(s => s.Usuario) 
            //        .WithMany(s => s.Promocoes); 


            #endregion


            #region Comentario

            modelBuilder.Entity<Comentario>()
                .HasKey(p => p.IdComentario);

            modelBuilder.Entity<Comentario>()
               .Property(p => p.IdComentario)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Comentario>()
               .Property(p => p.Descricao)
               .HasMaxLength(200);

            //modelBuilder.Entity<Comentario>()
            //       .HasRequired<Usuario>(s => s.Usuario)
            //       .WithMany(s => s.Comentarios);

            //modelBuilder.Entity<Comentario>()
            //       .HasRequired<Promocao>(s => s.Promocao)
            //       .WithMany(s => s.Comentarios);

            #endregion

            #region Categoria

            modelBuilder.Entity<Categoria>()
                .HasKey(p => p.IdCategoria);

            modelBuilder.Entity<Categoria>()
               .Property(p => p.IdCategoria)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Categoria>()
               .Property(p => p.Descricao)
               .HasMaxLength(200);


            #endregion




            base.OnModelCreating(modelBuilder);
        }
    }   
}