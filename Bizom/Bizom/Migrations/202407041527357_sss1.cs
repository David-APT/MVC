namespace Bizom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountCreations", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountCreations", "status");
        }
    }
}
