using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SofthouseTask.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace SofthouseTask.Data.Context
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<JobApplication> JobApplication { get; set; }
        public DbSet<User> User { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration): base(options) 
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            using var hmac = new HMACSHA512();

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "HrAdmin",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_configuration["HrAdminPassword"] )),
                PasswordSalt = hmac.Key
            });

            base.OnModelCreating(modelBuilder); 
        }
    }
}
