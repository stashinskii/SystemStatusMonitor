using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using DependencyResolving;
using MahApps.Metro.Controls;
using Ninject;
using SystemMonitor.BLL.Interface;
using SystemMonitor.Pages;

namespace SystemMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public IService MonitorService { get; set; }
        public IEnumerable<Process> Processes { get; set; }

        public MainWindow()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            MonitorService = resolver.Get<IService>();
            Processes = MonitorService.GetAllProcesses().Take(20);
            InitializeComponent();
            ProcessesGridView.ItemsSource = Processes;
            SetPCInfo();
        }

        private void SetPCInfo()
        {
            var computerInfo = MonitorService.GetComputerInfo();
            OSName.Content = computerInfo.OSName;
            MachineName.Content = computerInfo.MachineName;
            AmountOfProcessorsName.Content = computerInfo.ProcessorsAmount;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setting page = new Setting();
            page.Show();
        }
    }
}
