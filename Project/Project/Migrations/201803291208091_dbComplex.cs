namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbComplex : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAccesses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        MenuItem = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccesses");
            DropTable("dbo.GroupInfoes");
        }
    }
}
