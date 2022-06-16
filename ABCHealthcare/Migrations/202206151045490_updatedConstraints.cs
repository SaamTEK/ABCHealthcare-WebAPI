namespace ABCHealthcare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicines", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Medicines", "Seller", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Roles", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Fullname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "Fullname", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Roles", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Medicines", "Seller", c => c.String());
            AlterColumn("dbo.Medicines", "Description", c => c.String());
            AlterColumn("dbo.Medicines", "Name", c => c.String());
        }
    }
}
