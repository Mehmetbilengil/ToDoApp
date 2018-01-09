using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DomainModel
{
    public class ErrorLog : BaseEntity
    {
        public ErrorLog():base()
        {
            CreateDate = DateTime.Now;
        }

        [StringLength(250)]
        public string ActionName { get; set; }

        [StringLength(550)]
        public string Message { get; set; }

       
        public string StackTrace { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
