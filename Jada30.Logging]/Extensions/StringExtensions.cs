using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30.Logging.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCaseAny(this string str, params string[] toCheck)
        {
            try
            {
                foreach (var item in toCheck)
                    if (str.Equals(item, StringComparison.OrdinalIgnoreCase))
                        return true;

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
