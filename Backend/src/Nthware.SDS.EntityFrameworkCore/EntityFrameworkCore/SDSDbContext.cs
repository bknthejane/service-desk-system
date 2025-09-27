using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Nthware.SDS.Authorization.Roles;
using Nthware.SDS.Authorization.Users;
using Nthware.SDS.MultiTenancy;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nthware.SDS.Domain.Technicians;
using Nthware.SDS.Domain.Tickets;
using Nthware.SDS.Domain.Organisations;

namespace Nthware.SDS.EntityFrameworkCore
{
    public class SDSDbContext : AbpZeroDbContext<Tenant, Role, User, SDSDbContext>
    {
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Organisation> Organisations { get; set; }

        public SDSDbContext(DbContextOptions<SDSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === DateTime UTC Converter ===
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
                v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v : v.Value.ToUniversalTime()) : v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                        property.SetValueConverter(dateTimeConverter);
                    if (property.ClrType == typeof(DateTime?))
                        property.SetValueConverter(nullableDateTimeConverter);
                }
            }

            modelBuilder.Entity<Technician>()
                .HasOne(t => t.Organisation)
                .WithMany(o => o.Technicians)
                .HasForeignKey(t => t.OrganisationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedTechnician)
                .WithMany(te => te.AssignedTickets)
                .HasForeignKey(t => t.AssignedTechnicianId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AssignedOrganisation)
                .WithMany(o => o.Users)
                .HasForeignKey(u => u.AssignedOrganisationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.RaisedBy)
                .WithMany(u => u.TicketsRaised)
                .HasForeignKey(t => t.RaisedById)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
