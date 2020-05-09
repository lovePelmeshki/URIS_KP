using System.Data.Entity;

namespace URIS_KP
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DBConnection") { }

        public DbSet<Detector> Detectors { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
