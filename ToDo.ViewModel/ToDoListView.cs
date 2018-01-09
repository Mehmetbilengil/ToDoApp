using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.ViewModel
{
   
    public class ToDoItemListView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
    public class ToDoItemEditView
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Title must be maximum 50 characters long.")]
        [MinLength(3, ErrorMessage = "Title must be minimum 3 characters long.")]
        public string Title { get; set; }
    }
    public class ToDoItemDetailView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        //public List<ToDoTaskListView> Tasks { get; set; }
    }
    //public class SaveResult:BaseResult
    //{
    //    public Guid Id { get; set; }
    //}
}
