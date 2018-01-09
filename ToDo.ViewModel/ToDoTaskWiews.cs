using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;

namespace ToDo.ViewModel
{
   
    public class ToDoTaskListView
    {
        public Guid Id { get; set; }
        public string Desc { get; set; }
        public bool NotificationRequested { get; set; }
        public NotificationType NotificationType { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime? NotificationDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? NotificationTime { get; set; }
        public string NotificationTimeString
        {
            get
            { return NotificationTime?.ToString("HH:mm"); }
        }
    }
    public class ToDoTaskEditView
    {
        public Guid? Id { get; set; }
        public Guid ListId { get; set; }
        public Guid UserId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description must be maximum 200 characters long.")]
        [MinLength(3, ErrorMessage = "Description must be minimum 3 characters long.")]
        public string Desc { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool NotificationRequested { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        public DateTime? NotificationDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime? NotificationTime { get; set; }
        public string NotificationTimeString { get
            { return NotificationTime?.ToString("HH:mm"); } }
    }
  
}
