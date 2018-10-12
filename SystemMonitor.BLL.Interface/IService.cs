using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.BLL.Interface
{
    /// <summary>
    /// Interface represents common features for SystemStatusMonitor 
    /// </summary>
    public interface IService
    {
        string GetCurrentOs();
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
    }
}
