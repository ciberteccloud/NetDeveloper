﻿using Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess
{
    public class ChinookContext : DbContext
    {
        public ChinookContext() : base("ChinookConnection")
        {
            Database.SetInitializer<ChinookContext>(null);
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Album> Albums { get; private set; }
        public virtual DbSet<Customer> Customers { get; private set; }
        public virtual DbSet<Employee> Employees { get; private set; }
        public virtual DbSet<Genre> Genres { get; private set; }
        public virtual DbSet<Invoice> Invoices { get; private set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; private set; }
        public virtual DbSet<MediaType> MediaTypes { get; private set; }        
        public virtual DbSet<Track> Tracks { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configuramos las relaciones entre las entidades
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.SupportRepId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee1)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MediaType>()
                .HasMany(e => e.Tracks)
                .WithRequired(e => e.MediaType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.Tracks)
                .WithMany(e => e.Playlists)
                .Map(m => m.ToTable("PlaylistTrack").MapLeftKey("PlaylistId").MapRightKey("TrackId"));

            modelBuilder.Entity<Track>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.Track)
                .WillCascadeOnDelete(false);
        }
    }
}
