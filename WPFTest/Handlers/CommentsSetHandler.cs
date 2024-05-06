using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFTest.Utils;

namespace WPFTest.Handlers
{
    class CommentsSetHandler : IExternalEventHandler
    {
        public IList<InstanceWithComment> InstancesToUpdate { get; set; }
       
        public void Execute(UIApplication app)
        {
            var doc = app.ActiveUIDocument.Document;
            using(var Tr = new Transaction(doc, "Записать комментарии"))
            {
                Tr.Start();
                try
                {
                    foreach (var inst in InstancesToUpdate)
                    {
                        if (inst.Edited)
                        {
                            var instElement = doc.GetElement(inst.Id);
                            instElement.SetComment(inst.Comment);
                        }
                    }

                    
                }
                catch(Exception ex)
                {
                    TaskDialog.Show("error", $"Не удалось записать\n{ex.Message}\n{ex.StackTrace}") ;
                }

                Tr.Commit();
            }    
        }

        public string GetName()
        {
            return "CommentsSetHandler";
        }
    }
}
