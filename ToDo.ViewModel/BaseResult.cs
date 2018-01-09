using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.ViewModel
{
    public class BaseResult
    {
        public ResultType ResultType { get; set; }
        public string ResultMessage { get; set; }
    }

    public enum ResultType
    {
        Success = 0,
        BusinessError = 1,
        SystemError = 3
    }
}
