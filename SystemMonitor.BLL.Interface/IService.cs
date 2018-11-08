using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using SystemMonitor.BLL.Interface.Entitites;
using System.IO;

namespace SystemMonitor.BLL.Interface
{
    /// <summary>
    /// Interface represents common features for SystemStatusMonitor 
    /// </summary>
    public interface IService
    {
        string GetCurrentOsName();
        void GetCurrentOsInfo();

        ObservableCollection<Process> GetAllProcesses();
        void GetProcessByName(string processName);

        void GetAllDiscs();
        void GetDiskInfo(string diskName);

        void GetCPUTemp();
        void GetCPUPower();
        void GetCPULoad();

        ulong GetRAMInfo();
        void GetRAMLoad();

        string GetMachineInfo();

        int GetAmountOfProcessors();

        ComputerInfo GetComputerInfo();

        ManagementObject GetVideoControllerInfo();

        IEnumerable<DriveInfo> GetHardDriveInfo();

        WindowsIdentity GetCurrentUser();
        string GetCurrentUserName();

        string GetDotNetVerison();
    }
}
