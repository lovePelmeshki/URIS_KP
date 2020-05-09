namespace URIS_KP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<URIS_KP.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // установить false
        }

        protected override void Seed(URIS_KP.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
