using Car4EgarAPI.Models.Configurations;
using Car4EgarAPI.Models.Entities;
using Car4EgarAPI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace Car4EgarAPI.Models.Context
{
    public class Car4EgarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Car4Egar;Integrated Security=true ;Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }
        public Car4EgarContext()
        {

        }
        public Car4EgarContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RentConfigration());
            modelBuilder.ApplyConfiguration(new CarConfigration());
            modelBuilder.ApplyConfiguration(new CostesConfigration());
            modelBuilder.ApplyConfiguration(new SysteUsersConfigration());
            modelBuilder.ApplyConfiguration(new TransactionConfigration());
            modelBuilder.ApplyConfiguration(new MCarConfigration());


            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<MCar> MCars { get; set; }

        public virtual DbSet<Rent>  Rents { get; set; }
        public virtual DbSet<Costes> Costes { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminRequest> AdminRequests { get; set; }
        public virtual DbSet<RentRequest> RentRequests { get; set; }
        public virtual DbSet<CarVM> CarVM { get; set; }
        public virtual DbSet<RatedFrom> RatedFrom { get; set; }


    }
}
