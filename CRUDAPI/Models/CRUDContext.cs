using CRUDAPI.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDAPI.Models
{
    public class CRUDContext : DbContext
    {
        public CRUDContext() : base("name=CRUDConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CRUDContext, Configuration>());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}