using Lab11_KazanovAlexandr.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11_KazanovAlexandr.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)  { }
        public DbSet<User> Users { get; set; }
    }
}
