using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRSP2022
{
    public class ParseUtils
    {
        public static int IntParse(string text)
        {
            int tmp;
            int.TryParse(text, out tmp);
            return tmp;
        }
    }
}
