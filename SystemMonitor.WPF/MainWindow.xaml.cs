using System;
using System.Collections.Generic;
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

        public MainWindow()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            MonitorService = resolver.Get<IService>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(MonitorService.GetCurrentOsName());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new DiskInfoPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProccessesPage();
        }
    }
}
