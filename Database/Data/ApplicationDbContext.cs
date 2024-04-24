using Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OmniselloTask.Models;
using System.Diagnostics;
using System.Reflection.Emit;

namespace OmniselloTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order_Vege>().HasKey(sc => new { sc.IdOrder, sc.IdVege });

            builder.Entity<Order>()
            .HasOne<ApplicationUser>(s => s.ApplicationUser)
            .WithMany(g => g.Order)
            .HasForeignKey(s => s.ID_User);

            builder.Entity<Order_Vege>()
                .HasOne<Order>(o => o.Order)
                .WithMany(o => o.Order_Veges)
                .HasForeignKey(o => o.IdOrder);

            builder.Entity<Order_Vege>()
                .HasOne<Vegetables>(v => v.Vegetables)
                .WithMany(v => v.VegeOrder)
                .HasForeignKey(v => v.IdVege);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Vegetables>   Vegetable   { get; set; }
        public DbSet<Order>         Order       { get; set; }
        public DbSet<Order_Vege>    Order_Vege { get; set;}

       
    }
}
