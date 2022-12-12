using Microsoft.EntityFrameworkCore;
using Unik.Domain.Booking.Model;
using Unik.Domain.Kompetence.Model;
using Unik.Domain.Kunde.Model;
using Unik.Domain.Medarbejder.Model;
using Unik.Domain.Opgave.Model;
using Unik.Domain.Projekt.Model;
using Unik.Domain.Sales.Model;
using Unik.SqlServerContext.Booking;
using Unik.SqlServerContext.Kompetence;
using Unik.SqlServerContext.Kunde;
using Unik.SqlServerContext.Medarbejder;
using Unik.SqlServerContext.Opgave;
using Unik.SqlServerContext.Projekt;
using Unik.SqlServerContext.Sales;
using SalesTypeConfiguration = Unik.SqlServerContext.Sales.SalesTypeConfiguration;

namespace Unik.SqlServerContext
{
    public class UnikContext : DbContext
    {
        public UnikContext(DbContextOptions<UnikContext> options) : base(options)
        {

        }
        public DbSet<KompetenceEntity> KompetenceEntities { get; set; }
        public DbSet<MedarbejderEntity> MedarbejderEntities { get; set; }
        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<KundeEntity> KundeEntities { get; set; }
        public DbSet<ProjektEntity> ProjektEntities { get; set; }
        public DbSet<OpgaveEntity> OpgaveEntities { get; set; }
        public DbSet<SalesEntity> SalesEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new KompetenceTypeConfiguration());
            builder.ApplyConfiguration(new MedarbejderTypeConfiguration());
            builder.ApplyConfiguration(new KundeTypeConfiguration());
            builder.ApplyConfiguration(new BookingTypeConfiguration());
            builder.ApplyConfiguration(new OpgaveTypeConfigation());
            builder.ApplyConfiguration(new SalesTypeConfiguration());
        }
    }
}
