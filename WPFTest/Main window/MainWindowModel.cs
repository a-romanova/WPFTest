using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTest.Handlers;
using WPFTest.Utils;

namespace WPFTest
{
    public class MainWindowModel
    {
        static CommentsSetHandler _commentsSetHandler;
        static ExternalEvent _setComments;
        static MainWindowModel()
        {
            _commentsSetHandler = new CommentsSetHandler();
            _setComments = ExternalEvent.Create(_commentsSetHandler);
        }


        UIDocument _uiDoc;
        public ObservableCollection<InstanceWithComment> Instances;
        

        public MainWindowModel(UIDocument UIDoc)
        {
            _uiDoc = UIDoc;
            Instances = new ObservableCollection<InstanceWithComment>();
            
        }

        

        public void GetInstances()
        {
            var instances = _uiDoc.Document.GetElements<FamilyInstance>(_uiDoc.ActiveView.Id);
            Instances.Clear();
            foreach (var inst in instances)
                Instances.Add(new InstanceWithComment(inst));
        }

        public void SetComments()
        {
            _commentsSetHandler.InstancesToUpdate = Instances;
            _setComments.Raise();
        }
       
    
    }
}
