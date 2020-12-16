using ppedv.Druckverwaltung.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.Druckverwaltung.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Patient> Patienten { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<Druckauftrag> Druckauftrage { get; set; }
        public DbSet<Drucker> Drucker { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=(localdb)\\mssqllocaldb;Database=Druckverwaltung_dev;Trusted_Connection=true")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Patient>().Property(x => x.Ort).HasMaxLength(75).IsOptional();

            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }

    }
}
