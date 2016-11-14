using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class MeetingDbContext : DbContext
    {
       public DbSet<Conference> Conferences {get; set;}
       public DbSet<Session> Sessions {get; set;}

       protected override void OnConfiguring (DbContextOptionsBuilder optionBuilder)
       {
           optionBuilder.UseSqlite("Filename=./WebApplication.db");

       }  
    }
}