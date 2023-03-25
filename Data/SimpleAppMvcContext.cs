using Microsoft.EntityFrameworkCore;
using SimpleAppMvc.Models;

namespace SimpleAppMvc.Data
{
    public class SimpleAppMvcContext : DbContext
    {
        public SimpleAppMvcContext(DbContextOptions <SimpleAppMvcContext> options) : base(options){}
        public DbSet<UserModel> Users { get; set; }
    }
}