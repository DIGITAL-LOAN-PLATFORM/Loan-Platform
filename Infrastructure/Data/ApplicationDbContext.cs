using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<PaymentType> PaymentTypes => Set<PaymentType>();
        public DbSet<PaymentModality> PaymentModalities => Set<PaymentModality>();
        public DbSet<Reason> Reasons => Set<Reason>();
        public DbSet<GuarantorType> GuarantorTypes => Set<GuarantorType>();
    }
}