using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ipbpr> Ipbpr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Ipbpr>(entity =>
            {
                entity.HasKey(e => e.PrimaryId);

                entity.ToTable("ipbpr");

                entity.Property(e => e.PrimaryId)
                    .HasColumnName("primary_id")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasMaxLength(10);

                entity.Property(e => e.DlugoscMieszkania)
                    .HasColumnName("dlugosc_mieszkania")
                    .HasMaxLength(10);

                entity.Property(e => e.Ilosc)
                    .HasColumnName("ilosc")
                    .HasMaxLength(10);

                entity.Property(e => e.Kategoria)
                    .HasColumnName("kategoria")
                    .HasMaxLength(10);
            });
        }
    }
}
