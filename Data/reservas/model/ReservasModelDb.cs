namespace Data.reservas.model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReservasModelDb : DbContext
    {
        public ReservasModelDb()
            : base("name=ReservasModelDb")
        {
        }

        public virtual DbSet<bairros> bairros { get; set; }
        public virtual DbSet<cidades> cidades { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<logradouros> logradouros { get; set; }
        public virtual DbSet<Quarto> Quarto { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Turista> Turista { get; set; }
        public virtual DbSet<ufs> ufs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bairros>()
                .Property(e => e.desc_bairro)
                .IsUnicode(false);

            modelBuilder.Entity<bairros>()
                .HasMany(e => e.logradouros)
                .WithRequired(e => e.bairros)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cidades>()
                .Property(e => e.desc_cidade)
                .IsUnicode(false);

            modelBuilder.Entity<cidades>()
                .Property(e => e.flg_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<cidades>()
                .HasMany(e => e.bairros)
                .WithRequired(e => e.cidades)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Cep)
                .HasPrecision(8, 0);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Uf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Ddd)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Telefone)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Quarto)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<logradouros>()
                .Property(e => e.desc_logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<logradouros>()
                .Property(e => e.desc_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Quarto>()
                .HasMany(e => e.Reserva)
                .WithRequired(e => e.Quarto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turista>()
                .Property(e => e.Cpf)
                .HasPrecision(9, 0);

            modelBuilder.Entity<Turista>()
                .Property(e => e.Senha)
                .IsFixedLength();

            modelBuilder.Entity<ufs>()
                .Property(e => e.uf_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ufs>()
                .Property(e => e.desc_uf)
                .IsUnicode(false);

            modelBuilder.Entity<ufs>()
                .HasMany(e => e.cidades)
                .WithRequired(e => e.ufs)
                .HasForeignKey(e => e.flg_estado)
                .WillCascadeOnDelete(false);
        }
    }
}
