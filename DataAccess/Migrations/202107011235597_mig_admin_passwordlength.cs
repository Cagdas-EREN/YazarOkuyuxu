namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_passwordlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
        }
    }
}
