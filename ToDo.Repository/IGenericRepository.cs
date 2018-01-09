using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.DomainModel;

namespace ToDo.Repository
{
    internal interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
    }
}
