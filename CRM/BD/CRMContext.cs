namespace CRM.BD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRMContext : DbContext
    {
        public CRMContext()
            : base("name=CRMContext2")
        {
        }

        public virtual DbSet<CatalogGroupManagers> CatalogGroupManagers { get; set; }
        public virtual DbSet<CatalogPositions> CatalogPositions { get; set; }
        public virtual DbSet<CatalogStatus> CatalogStatus { get; set; }
        public virtual DbSet<CatalogTasks> CatalogTasks { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogPositions>()
                .Property(e => e.Pay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.CheckingAccount)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Info)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Clients)
                .HasForeignKey(e => e.Client);

            modelBuilder.Entity<Managers>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Managers>()
                .Property(e => e.Passport)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Managers>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Managers>()
                .Property(e => e.Info)
                .IsUnicode(false);

            modelBuilder.Entity<Managers>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.Managers)
                .HasForeignKey(e => e.Manager);

            modelBuilder.Entity<Tasks>()
                .Property(e => e.Info)
                .IsUnicode(false);
        }
    }
}
