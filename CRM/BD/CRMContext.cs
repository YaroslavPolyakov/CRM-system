namespace CRM.BD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CRMContext : DbContext
    {
        public CRMContext()
            : base("name=CRMContext")
        {
        }

        public virtual DbSet<CatalogGroupManagers> CatalogGroupManagers { get; set; }
        public virtual DbSet<CatalogPositions> CatalogPositions { get; set; }
        public virtual DbSet<CatalogStatus> CatalogStatus { get; set; }
        public virtual DbSet<CatalogTasks> CatalogTasks { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogGroupManagers>()
                .HasMany(e => e.Managers)
                .WithOptional(e => e.CatalogGroupManagers)
                .HasForeignKey(e => e.Group);

            modelBuilder.Entity<CatalogPositions>()
                .Property(e => e.Pay)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CatalogStatus>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.CatalogStatus)
                .HasForeignKey(e => e.Status);

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
                .Property(e => e.Password)
                .IsFixedLength();

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
