namespace DemoAgenda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agendav2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgendaBEs", "LastChanged", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AgendaBEs", "LastChanged");
        }
    }
}
