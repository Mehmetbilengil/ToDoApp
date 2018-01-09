namespace ToDo.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiald : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ActionName = c.String(maxLength: 250),
                        Message = c.String(maxLength: 550),
                        StackTrace = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ErrorLogs");
        }
    }
}
