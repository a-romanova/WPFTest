using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.Utils
{
    static class ElementsExt
    {
        public static void SetComment(this Element e, string str) => 
            e?.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS)?.Set(str);
        public static string GetComment(this Element e) =>
            e?.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS)?.AsString();

    }
}
