using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.BLL.Interface
{
    /// <summary>
    /// Interface represents common features for SystemStatusMonitor 
    /// </summary>
    public interface IService
    {
        string GetCurrentOsName();
        void GetCurrentOsInfo();

        void GetAllProcesses();
        void GetProcessByName(string processName);

        void GetAllDiscs();
        void GetDiskInfo(string diskName);

        void GetCPUTemp();
        void GetCPUPower();
        void GetCPULoad();

        void GetRAMInfo();
        void GetRAMLoad();

        WindowsIdentity GetCurrentUser();
        string GetCurrentUserName();
    }
}
