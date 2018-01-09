using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Common
{
    public static class CommonExtensions
    {
        public static Exception GetInnerException(this Exception ex)
        {
            if (ex == null)
                return null;

            if (ex.InnerException == null)
                return ex;

            return GetInnerException(ex.InnerException);
        }

       

        public static string ShortenString(this string input, int size)
        {
            if (string.IsNullOrEmpty(input)) return input;

            return input.Length > size ? input.Substring(0, size) : input;
        }

    }
}
