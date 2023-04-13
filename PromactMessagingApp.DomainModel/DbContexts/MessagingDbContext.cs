using Microsoft.EntityFrameworkCore;
using PromactMessagingApp.DomainModel.Models.Login;
using PromactMessagingApp.DomainModel.Models.Message;
using PromactMessagingApp.DomainModel.Models.User;

namespace PromactMessagingApp.DomainModel.DbContexts
{
    public class MessagingDbContext : DbContext
    {
        public MessagingDbContext(DbContextOptions<MessagingDbContext> options) : base(options)
        {

        }

        public DbSet<UserInformation> User { get; set; }

        public DbSet<UserLoginHistory> Login { get; set; }

        public DbSet<UserMessages> Message { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessages>(a =>
            {
                a.HasOne<UserInformation>().WithMany().HasForeignKey(a => a.SenderId).IsRequired().OnDelete(DeleteBehavior.NoAction);
                a.HasOne<UserInformation>().WithMany().HasForeignKey(a => a.ReceiverId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
