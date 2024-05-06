using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFTest;

namespace WPFTest.Utils
{
    static class StringExt
    {
        public static TypeOfComment GetCommentType(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return TypeOfComment.Empty;
            else if (double.TryParse(str.Replace('.', ','), out var parsed))
                return TypeOfComment.Number;
            else
                return TypeOfComment.Text;
        }
    }
}
