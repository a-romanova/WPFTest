using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.Utils
{
    static class DocExt
    {
        public static IEnumerable<T> GetElements<T>(this Document doc) where T : Element =>
            new FilteredElementCollector(doc)
            .WhereElementIsNotElementType()
            .OfClass(typeof(T))
            .ToElements()
            .Cast<T>();

        public static IEnumerable<T> GetElements<T>(this Document doc, ElementId viewId) where T : Element =>
            new FilteredElementCollector(doc, viewId)
            .WhereElementIsNotElementType()
            .OfClass(typeof(T))
            .ToElements()
            .Cast<T>();
    }
}
