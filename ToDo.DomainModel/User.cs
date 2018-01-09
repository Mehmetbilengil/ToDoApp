using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DomainModel
{
    public class User : BaseEntity
    {
        [StringLength(50),Required]
        public string FirstName { get; set; }

        [StringLength(50),Required]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50), Required]
        public string Email { get; set; }

     
        [DataType(DataType.Password)]
        [StringLength(255), Required]
        public string Password { get; set; }

        public virtual ICollection<ToDoList> Todos { get; set; }


    }
}
