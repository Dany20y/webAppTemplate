namespace WebApp.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CoCardDBTables", "img", c => c.String());
            AlterColumn("dbo.CoCardDBTables", "pdf_file", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CoCardDBTables", "pdf_file", c => c.Binary());
            AlterColumn("dbo.CoCardDBTables", "img", c => c.Binary());
        }
    }
}
