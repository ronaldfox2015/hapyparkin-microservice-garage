using Microsoft.EntityFrameworkCore;

namespace HappyParking.Infraestructure.Data
{
    public class MySqlContext: DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) :
            base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
        }
    }
}
