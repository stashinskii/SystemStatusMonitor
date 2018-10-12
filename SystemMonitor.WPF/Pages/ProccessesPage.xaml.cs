using DependencyResolving;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemMonitor.BLL.Interface;

namespace SystemMonitor.Pages
{
    /// <summary>
    /// Interaction logic for ProccessesPage.xaml
    /// </summary>
    public partial class ProccessesPage : Page
    {
        public IService MonitorService { get; set; }
        public IEnumerable<Process> Processes { get; set; }

        public ProccessesPage()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            MonitorService = resolver.Get<IService>();
            InitializeComponent();
            Processes = MonitorService.GetAllProcesses().Take(20);
            ProcessesGridView.ItemsSource = Processes;
        }
    }
}
