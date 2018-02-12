using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Extensions
    {
        public static Boolean IsNullOrEmptyOrWhiteSpace(this String s)
        {
            return String.IsNullOrEmpty(s) || String.IsNullOrWhiteSpace(s);
        }
    }
}
