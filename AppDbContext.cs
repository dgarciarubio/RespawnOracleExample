namespace RespawnOracleExample
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        private readonly string connectionString;

        public AppDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Entity> Entities => Set<Entity>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(connectionString);
        }
    }

    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}