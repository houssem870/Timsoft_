using Microsoft.EntityFrameworkCore;
using timsoft.entities;
using Microsoft.EntityFrameworkCore.Design;

namespace timsoft.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.EnableSensitiveDataLogging();


        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Epreuve> Epreuve { get; set; }
        public DbSet<Reponse> Reponse { get; set; }
        public DbSet<Réclamation> Réclamation { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Rôle> Rôle { get; set; }
        public DbSet<Type_Epreuve> Type_Epreuve { get; set; }






    }
}

