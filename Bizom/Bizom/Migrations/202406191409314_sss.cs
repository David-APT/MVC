namespace Bizom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "PRODUCT_MAR", c => c.Double(nullable: false));
            AlterColumn("dbo.products", "PRODUCT_MARGIN", c => c.Double(nullable: false));
            AlterColumn("dbo.products", "PRODUCT_CASE", c => c.Double(nullable: false));
            AlterColumn("dbo.products", "PRODUCT_PRICE", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "PRODUCT_PRICE", c => c.String());
            AlterColumn("dbo.products", "PRODUCT_CASE", c => c.String());
            AlterColumn("dbo.products", "PRODUCT_MARGIN", c => c.String());
            AlterColumn("dbo.products", "PRODUCT_MAR", c => c.String());
        }
    }
}
