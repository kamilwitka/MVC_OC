namespace MVC_OC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OC",
                c => new
                    {
                        OC_ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 30),
                        Descripton = c.String(maxLength: 200),
                        CarModel = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.OC_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OC");
        }
    }
}
