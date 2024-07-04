namespace Bizom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Retailers", "EMAIL", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Retailers", "EMAIL");
        }
    }
}
