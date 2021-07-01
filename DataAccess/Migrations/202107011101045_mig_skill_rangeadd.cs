namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_skill_rangeadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Range", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "Range");
        }
    }
}
