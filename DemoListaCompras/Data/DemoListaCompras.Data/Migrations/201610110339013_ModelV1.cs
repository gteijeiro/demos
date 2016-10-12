namespace DemoListaCompras.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraBEs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Decription = c.String(),
                        DateChanged = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CompraBEs");
        }
    }
}
