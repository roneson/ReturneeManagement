namespace ReturneeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Birthdate");
        }
    }
}
