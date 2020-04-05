using Microsoft.EntityFrameworkCore;
using MiliCare.Model;

namespace MiliCare.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options){

            
        }



        public DbSet<User> Users {get;set;}

    }
}