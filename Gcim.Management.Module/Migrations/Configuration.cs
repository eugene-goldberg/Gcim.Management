namespace Gcim.Management.Module.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gcim.Management.Module.BusinessObjects.ManagementDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Gcim.Management.Module.BusinessObjects.ManagementDbContext context)
        {

        }
    }
}
