using Microsoft.EntityFrameworkCore;
using User.Core.Models;

namespace User.DAL
{
    public class UserDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Employee> Employees { get; set; }  

        public UserDbContext(DbContextOptions<UserDbContext> options)
                : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Client>()
                .HasKey(client => client.Id);
            modelBuilder.Entity<Client>()
                .HasIndex(client => client.Phone);
            modelBuilder.Entity<Client>()
                .HasIndex(client => new { client.FirstName, client.SecondName });

            modelBuilder.Entity<Employee>()
                .HasKey(Employee => Employee.Id);
            modelBuilder.Entity<Employee>()
                .HasIndex(employee => new { employee.FirstName, employee.SecondName });
        }
    }
}
