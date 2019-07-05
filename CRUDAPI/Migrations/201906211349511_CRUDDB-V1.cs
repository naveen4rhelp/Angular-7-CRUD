namespace CRUDAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CRUDDBV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        EmpCode = c.String(),
                        Mobile = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
