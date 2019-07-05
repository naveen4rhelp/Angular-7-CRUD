namespace CRUDAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CRUDDBV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FullName", c => c.String());
            DropColumn("dbo.Employees", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "FullName");
        }
    }
}
