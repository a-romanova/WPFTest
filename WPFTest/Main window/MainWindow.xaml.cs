using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow windowInstance;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public static void ShowWindow(MainWindowVM vm)
        {
            if (windowInstance != null)
                return;

          
            
            windowInstance = new MainWindow() { DataContext = vm };
            windowInstance.Topmost = true;
            windowInstance.Closed += (object sender, EventArgs e) => { windowInstance = null; };
            windowInstance.Show();

        }
    }
}
