using LoginDemoProj.Model;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace LoginDemoProj.Data
{
    public class LoginProfileDbContext : DbContext
    {
        public LoginProfileDbContext()
        {

        }

        public LoginProfileDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoginProfile>LoginProfiles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer(  "Server = DESKTOP - SGE027L; Database = LoginProfile; User ID = sa; Password = 123; MultipleActiveResultSets = true; "
//);
//            }
//        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LoginProfile");
                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.Property(e => e.Password).HasColumnName("Password");


     
            });
        }
    }
}
