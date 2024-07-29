

using Microsoft.EntityFrameworkCore;
using WebApiPersons.Models;


namespace WebApiPersons.Context
{
    public class AppDbContext: DbContext{ 
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options){

        }
        public DbSet<Persons> Persons { get; set; }
    }
}
