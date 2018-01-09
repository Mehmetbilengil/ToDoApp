namespace ToDo.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdbbhh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "NotificationSent", c => c.Boolean(nullable: false));
            AddColumn("dbo.ToDoTasks", "NotificationSentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoTasks", "NotificationSentDate");
            DropColumn("dbo.ToDoTasks", "NotificationSent");
        }
    }
}
