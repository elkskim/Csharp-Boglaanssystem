namespace Obligatorisk_opg_1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Obligatorisk_opg_1.DAL.BiblioteksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Obligatorisk_opg_1.DAL.BiblioteksContext";
        }

        protected override void Seed(Obligatorisk_opg_1.DAL.BiblioteksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
