using LibraryManagement.Entity;
using LibraryManagement.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.dbcontext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     public DbSet<Books> LibraryBooks { get; set; } //table name LibraryBooks

      
        //fluent api operations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BookCofiguration()); //mannual
            
            //automatic using asp.net assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
