namespace DraGLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "InviteCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "PromoCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PromoCode", c => c.String());
            DropColumn("dbo.AspNetUsers", "InviteCode");
        }
    }
}
