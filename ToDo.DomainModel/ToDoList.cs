using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DomainModel
{
    public class ToDoList: BaseEntity
    {
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        [StringLength(50), Required]
        public string ListTitle { get; set; }

        public virtual ICollection<ToDoTask> Tasks { get; set; }
    }
}
