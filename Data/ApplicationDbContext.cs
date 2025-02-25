using Microsoft.EntityFrameworkCore;
using API_DUAN_C5.Models;

namespace API_DUAN_C5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Diner> Diners { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<FoodVoucher> FoodVouchers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Quan hệ 1-n giữa Food và Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Food)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.FoodId)
                .OnDelete(DeleteBehavior.Cascade); // Vẫn giữ CASCADE

            // Quan hệ 1-n giữa User và Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction); // Sửa thành NO ACTION để tránh conflict
                                                    // Quan hệ 1-n giữa OrderDetails và Food
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Food)
                .WithMany(f => f.OrderDetails)
                .HasForeignKey(od => od.FoodId)
                .OnDelete(DeleteBehavior.Cascade); // Giữ Cascade cho Food vì ít gây lỗi

            // Quan hệ 1-n giữa OrderDetails và Order
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.NoAction); // Đổi thành NO ACTION để tránh lỗi
        }

    }
}
