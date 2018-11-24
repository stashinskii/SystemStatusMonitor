using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

using SystemMonitor.BLL.Interface;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.ObjectModel;
using SystemMonitor.BLL.Interface.Entitites;
using SystemMonitor.BLL.Entities;
using System.IO;

namespace SystemMonitor.BLL.Service
{
    public class Service : IService
    {
        static Service()
        {

        }

        public ComputerInfo GetComputerInfo()
        {
            ComputerInfo computerInfo = new GeneralComputerInfo(GetCurrentOsName(), GetAmountOfProcessors(), GetMachineInfo());
            return computerInfo;
        }


        public ManagementObject GetVideoControllerInfo()
        {
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            ManagementObject videoInfo = new ManagementObject();

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                videoInfo = obj;
            }

            return videoInfo;

        }

        public IEnumerable<DriveInfo> GetHardDriveInfo()
        {
           return DriveInfo.GetDrives().ToList();

        }

        public void GetAllDiscs()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Process> GetAllProcesses()
        {
            List<Process> processesList = Process.GetProcesses().ToList();
            //processesList.GroupBy(x => x.ProcessName).Select(y => y.First());
            var processesCollection = new ObservableCollection<Process>(processesList as List<Process>);
            return processesCollection;
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

        public string GetCurrentOsName()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).First();

            return name != null ? name.ToString() : "Unknown";
        }

        public void GetCurrentOsInfo()
        {
            throw new NotImplementedException();
        }

        public string GetMachineInfo()
        {
            return Environment.MachineName;
        }

        public int GetAmountOfProcessors()
        {
            return Environment.ProcessorCount;
        }

        public void GetDiskInfo(string diskName)
        {
            throw new NotImplementedException();
        }

        public void GetProcessByName(string processName)
        {
            throw new NotImplementedException();
        }

        public ulong GetRAMInfo()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }

        public void GetRAMLoad()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns current Identity
        /// </summary>
        /// <returns></returns>
        public WindowsIdentity GetCurrentUser()
        {
            return WindowsIdentity.GetCurrent();
        }

        /// <summary>
        /// Returns current's Identity UserName
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUserName()
        {
            return WindowsIdentity.GetCurrent().Name;
        }

        public string GetDotNetVerison()
        {
            return Environment.Version.ToString();
        }


    }
}
