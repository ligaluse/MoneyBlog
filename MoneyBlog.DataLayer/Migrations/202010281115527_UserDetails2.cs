namespace MoneyBlog.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetails2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserRole_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserRole_Id", c => c.String());
        }
    }
}
