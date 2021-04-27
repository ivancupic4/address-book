using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AddressBook.DAL.Models
{
    public partial class AddressBookContext : DbContext
    {
        public AddressBookContext()
        {
        }

        public AddressBookContext(DbContextOptions<AddressBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=postgres; Password=123; Host=localhost; Port=5432; Database=AddressBook; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_Croatia.1252");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.HasIndex(e => new { e.Name, e.Address }, "no_duplicate_contact")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.ToTable("Telephone");

                entity.Property(e => e.Number).HasMaxLength(50);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Telephones)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("fk_contact");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
