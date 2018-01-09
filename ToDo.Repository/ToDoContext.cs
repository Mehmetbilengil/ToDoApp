using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DomainModel;

namespace ToDo.Repository
{

    public class ToDoContext : DbContext
    {
        public ToDoContext()
            : base("ToDoContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDos { get; set; }
        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                    .Property(e => e.Email).IsRequired()
                    .HasColumnAnnotation(
                        IndexAnnotation.AnnotationName,
                        new IndexAnnotation(new IndexAttribute("UserEmailUniqueIndex", 1) { IsUnique = true }));

        }
    }
}
