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
        private int selectedElementIndex = -2; 
        public MainWindow()
        {
            IKernel resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            MonitorService = resolver.Get<IService>();
            InitializeComponent();
            GetOrderedProcesses();
            SetPCInfo();
            SetVCInfo();
            SetDriveInfo();
            SetRamInfo();
            SetNetInfo();
            UpdateList();

            
        }

            private void GetOrderedProcesses()
        {
           
            Processes = MonitorService.GetAllProcesses().OrderBy(data => data.BasePriority);
            ProcessesGridView.ItemsSource = Processes;
        }


        private async void UpdateList()
        {
            while (true)
            {
                await Task.Delay(3000);
                GetOrderedProcesses();
              
            }
        }

        private void SetRamInfo()
        {
            RAMAmount.Content = Math.Round(MonitorService.GetRAMInfo() / Math.Pow(1024, 3), 1);
            RAMAmount.Content += " GB";
        }

        private void SetNetInfo()
        {
            NETVersion.Content = MonitorService.GetDotNetVerison();
        }

        private void SetPCInfo()
        {
            var computerInfo = MonitorService.GetComputerInfo();
            OSName.Content = computerInfo.OSName;
            MachineName.Content = computerInfo.MachineName;
            AmountOfProcessorsName.Content = computerInfo.ProcessorsAmount;
        }

        private void SetVCInfo()
        {
            var vcInfo = MonitorService.GetVideoControllerInfo();
            VCName.Content = vcInfo["Name"]; 
            VCDriver.Content = vcInfo["DriverVersion"];
            VCProc.Content = vcInfo["VideoProcessor"];
            VCStatus.Content = vcInfo["VideoProcessor"];
        }

        private void SetDriveInfo()
        {
            var drives = MonitorService.GetHardDriveInfo();
            foreach (var drive in drives)
            {
                DisksInfoList.Items.Add($"Drive {drive.Name}");
                DisksInfoList.Items.Add($"  Drive type: {drive.DriveType}");
                if (drive.IsReady == true)
                {
                    DisksInfoList.Items.Add($"  Volume label: {drive.VolumeLabel}");
                    DisksInfoList.Items.Add($"  File system: {drive.DriveFormat}");
                    DisksInfoList.Items.Add($"  Available space to current user:{drive.AvailableFreeSpace} bytes");

                    DisksInfoList.Items.Add($"  Total available space:          {drive.TotalFreeSpace} bytes");

                    DisksInfoList.Items.Add($"  Total size of drive:            {drive.TotalSize} bytes ");
                    DisksInfoList.Items.Add($"  Root directory:            {drive.RootDirectory}");
                }
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setting page = new Setting();
            page.Show();
        }

        private void KillProcess(object sender, RoutedEventArgs e)
        {
            try
            {
                var process = ProcessesGridView.SelectedItem as Process;
               
                //MessageBox.Show($"Process {process.ProcessName} killed!");
                Process.GetProcessById(process.Id).Kill();
                MessageBox.Show($"Process {process.ProcessName} killed!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("You don't have permission to delete this task!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Please, choose task one more time!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}

