namespace DemoAgenda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agendav1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgendaBEs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firtname = c.String(),
                        Lastname = c.String(),
                        Number = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AgendaBEs");
        }
    }
}
