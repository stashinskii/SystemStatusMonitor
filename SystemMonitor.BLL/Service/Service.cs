using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemMonitor.BLL.Interface;

namespace SystemMonitor.BLL.Service
{
    public class Service : IService
    {
        public void GetAllDiscs()
        {
            throw new NotImplementedException();
        }

        public void GetAllProcesses()
        {
            throw new NotImplementedException();
        }

        public void GetCPULoad()
        {
            throw new NotImplementedException();
        }

        public void GetCPUPower()
        {
            throw new NotImplementedException();
        }

        public void GetCPUTemp()
        {
            throw new NotImplementedException();
        }

        public string GetCurrentOs()
        {
            return "Windows OS";
        }

        public void GetCurrentOsInfo()
        {
            throw new NotImplementedException();
        }

        public void GetDiskInfo(string diskName)
        {
            throw new NotImplementedException();
        }

        public void GetProcessByName(string processName)
        {
            throw new NotImplementedException();
        }

        public void GetRAMInfo()
        {
            throw new NotImplementedException();
        }

        public void GetRAMLoad()
        {
            throw new NotImplementedException();
        }
    }
}
