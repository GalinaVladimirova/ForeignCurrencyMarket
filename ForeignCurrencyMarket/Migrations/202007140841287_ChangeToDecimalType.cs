namespace ForeignCurrencyMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToDecimalType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Currencies", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "Value", c => c.Double(nullable: false));
        }
    }
}
