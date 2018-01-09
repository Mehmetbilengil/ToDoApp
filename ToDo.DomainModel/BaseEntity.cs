using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.DomainModel
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
