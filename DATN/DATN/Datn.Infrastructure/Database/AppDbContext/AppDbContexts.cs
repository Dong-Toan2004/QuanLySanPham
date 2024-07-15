using Datn.Domain.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datn.Infrastructure.Database.AppDbContext
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts()
        {
            
        }
        public AppDbContexts(DbContextOptions<AppDbContexts> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartsDetails { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-JMN439Q3\\SQLEXPRESS02;Initial Catalog=TestDATN;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var dataUser = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    UserName = "Admin1",
                    PassWord = "123"
                }
            };
            modelBuilder.Entity<User>().HasData(dataUser);

            var dataCategory = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Mô hình anime"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mô hình GunDam"
                }
            };
            modelBuilder.Entity<Category>().HasData(dataCategory);

            var dataProduct = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "SP1",
                    Description = "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.",
                    Image = "/img/sanpham4.jpg",
                    Price = 100000,
                    Quantity = 100,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "SP2",
                    Description = "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.",
                    Image = "/img/sanpham6.jpg",
                    Price = 150000,
                    Quantity = 100,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "SP3",
                    Description = "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.",
                    Image = "/img/sanpham5.jpg",
                    Price = 200000,
                    Quantity = 100,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "SP4",
                    Description = "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.",
                    Image = "/img/sanpham6.jpg",
                    Price = 150000,
                    Quantity = 100,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "SP5",
                    Description = "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.",
                    Image = "/img/sanpham4.jpg",
                    Price = 100000,
                    Quantity = 100,
                    CategoryId = 1
                },
            };
            modelBuilder.Entity<Product>().HasData(dataProduct);
        }
    }
}
