using FinTracker.Models;
using FinTracker.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Dal
{
    public partial class FinTrackerContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public FinTrackerContext() { }
        public FinTrackerContext(DbContextOptions<FinTrackerContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //public DbSet<GetTransactionsDto> GetTransactionsDto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=TORWLAOLES01;Initial Catalog=FinTracker;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: apply config from assembly
            var assemblyWithConfigurtations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurtations);

            // Configure DTO entities
            //modelBuilder.Entity<GetTransactionsDto>(x => {
            //    x.HasNoKey();
            //    x.ToView("GetTransactions");
            //});
        }
    }
}
