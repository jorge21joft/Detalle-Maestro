namespace Libros_maestro.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DetallePrestamo> DetallePrestamo { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Libros>()
                .Property(e => e.genero)
                .IsFixedLength();

            modelBuilder.Entity<Libros>()
                .HasMany(e => e.DetallePrestamo)
                .WithOptional(e => e.Libros)
                .HasForeignKey(e => e.libro_id);

            modelBuilder.Entity<Prestamo>()
                .HasMany(e => e.DetallePrestamo)
                .WithOptional(e => e.Prestamo)
                .HasForeignKey(e => e.prestamo_id);
        }
    }
}
