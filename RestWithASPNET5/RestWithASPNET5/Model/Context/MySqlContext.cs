using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETMesaRadionica.Model.Context
{
    public class MySqlContext : DbContext
    {

        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base (options)
        {

        }

        public DbSet<Consulente> Consulentes { get; set; }

        public DbSet<Chacras> Chacras { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
