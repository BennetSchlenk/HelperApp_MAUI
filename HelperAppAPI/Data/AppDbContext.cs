using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TODO_API.Models;

namespace TODO_API.Data
{
    public class AppDbContext : IdentityUserContext<IdentityUser>
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}
