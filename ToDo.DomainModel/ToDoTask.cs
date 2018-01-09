using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;

namespace ToDo.DomainModel
{
    public class ToDoTask : BaseEntity
    {
        public Guid ToDoListId { get; set; }

        [ForeignKey("ToDoListId")]
        public virtual ToDoList List { get; set; }

        [StringLength(200), Required]
        public string Desc { get; set; }

        public bool NotificationRequested { get; set; }

        public NotificationType NotificationType { get; set; }

        public DateTime? NotificationDate { get; set; }

        public bool NotificationSent { get; set; }
        public DateTime? NotificationSentDate { get; set; }
    }
}
