namespace ToDo.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdbb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoTasks", "NotificationRequested", c => c.Boolean(nullable: false));
            AddColumn("dbo.ToDoTasks", "NotificationType", c => c.Byte(nullable: false));
            AddColumn("dbo.ToDoTasks", "NotificationDate", c => c.DateTime());
            DropColumn("dbo.ToDoTasks", "Completed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoTasks", "Completed", c => c.Boolean(nullable: false));
            DropColumn("dbo.ToDoTasks", "NotificationDate");
            DropColumn("dbo.ToDoTasks", "NotificationType");
            DropColumn("dbo.ToDoTasks", "NotificationRequested");
        }
    }
}
