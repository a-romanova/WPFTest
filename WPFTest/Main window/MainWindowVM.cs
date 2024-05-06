using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace WPFTest
{
    public class MainWindowVM:ViewModelBase
    {
        MainWindowModel _model;

        public ObservableCollection<InstanceWithComment> Instances => _model.Instances;
        public bool WriteBttnEnabled => Instances!= null && Instances.Count() > 0;
        public StyleType CurrentStyle { get; set; } = StyleType.Light;
        
        public RelayCommand Update { get; set; }
        public RelayCommand SetComments { get; set; }
        public RelayCommand SwitchTheme { get; set; }

        public MainWindowVM(MainWindowModel model)
        {
            _model = model;
            SwitchTheme = new RelayCommand(_ =>
            {
                CurrentStyle = CurrentStyle == StyleType.Light ? StyleType.Dark : StyleType.Light;
                OnPropertyChanged(nameof(CurrentStyle));
            });

            SetComments = new RelayCommand(_ => _model.SetComments());
            Update = new RelayCommand(_ =>
            {
                _model.GetInstances();
            });

            Instances.CollectionChanged += (s, o) => OnPropertyChanged(nameof(WriteBttnEnabled));

        }

    }


}
