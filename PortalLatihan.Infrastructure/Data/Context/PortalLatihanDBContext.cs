using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Infrastructure.Data.Context
{
    public class PortalLatihanDBContext(DbContextOptions<PortalLatihanDBContext> options) : DbContext(options)
    {
        public DbSet<Participant> PARTICIPANT { get; set; }
        public DbSet<RefRegion> REF_REGION { get; set; }
        public DbSet<RefZone> REF_ZONE { get; set; }
        public DbSet<Ticket> TICKET { get; set; }
        public DbSet<TicketStatusHistory> TICKET_STATUS_HISTORY { get; set; }
        public DbSet<Training> TRAINING { get; set; }
        public DbSet<TrainingFee> TRAINING_FEE { get; set; }
        public DbSet<TrainingDiscountCode> TRAINING_DISCOUNT_CODE { get; set; }
        public DbSet<TrainingDiscountGroup> TRAINING_DISCOUNT_GROUP { get; set; }
        public DbSet<TrainingStatusHistory> TRAINING_STATUS_HISTORY { get; set; }
        public DbSet<Staff> STAFF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
               .Property(p => p.TotalFee)
               .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
             .Property(p => p.DiscountCode)
             .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
            .Property(p => p.DiscountGroup)
            .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
             .Property(p => p.FinalFee)
             .HasPrecision(18, 2);

            modelBuilder.Entity<TrainingDiscountCode>()
               .Property(p => p.Discount)
               .HasPrecision(18, 2);

            modelBuilder.Entity<TrainingDiscountCode>()
               .Property(p => p.MaxDiscount)
               .HasPrecision(18, 2);

            modelBuilder.Entity<TrainingDiscountGroup>()
               .Property(p => p.Discount)
               .HasPrecision(18, 2);

            modelBuilder.Entity<TrainingFee>()
               .Property(p => p.Fee)
               .HasPrecision(18, 2);

            modelBuilder
            .Entity<Participant>()
            .Property(d => d.IdentityType)
            .HasConversion<string>();

            modelBuilder
            .Entity<Participant>()
            .Property(d => d.Status)
            .HasConversion<string>();

            modelBuilder
            .Entity<Ticket>()
            .Property(d => d.BuyerType)
            .HasConversion<string>();

            modelBuilder
            .Entity<Ticket>()
            .Property(d => d.Status)
            .HasConversion<string>();

            modelBuilder
           .Entity<TicketStatusHistory>()
           .Property(d => d.Status)
           .HasConversion<string>();

            modelBuilder
            .Entity<Training>()
            .Property(d => d.Status)
            .HasConversion<string>();

            modelBuilder
           .Entity<TrainingDiscountCode>()
           .Property(d => d.DiscountType)
           .HasConversion<string>();

            modelBuilder
           .Entity<TrainingDiscountGroup>()
           .Property(d => d.DiscountType)
           .HasConversion<string>();

            modelBuilder
           .Entity<TicketStatusHistory>()
           .Property(d => d.Status)
           .HasConversion<string>();

            modelBuilder.Entity<Participant>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RefRegion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<RefZone>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Ticket>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TicketStatusHistory>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Training>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TrainingFee>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TrainingDiscountCode>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TrainingDiscountGroup>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TrainingStatusHistory>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
