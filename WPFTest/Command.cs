using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uidoc = commandData.Application.ActiveUIDocument;
            var mainWinModel = new MainWindowModel(uidoc);
            var vm = new MainWindowVM(mainWinModel);
            var mainWin = new MainWindow() { DataContext = vm };
            mainWin.ShowDialog();

            return Result.Succeeded;
        }
    }
}
