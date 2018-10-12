﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

using SystemMonitor.BLL.Interface;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace SystemMonitor.BLL.Service
{
    public class Service : IService
    {
        public void GetAllDiscs()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Process> GetAllProcesses()
        {
            List<Process> processesList = Process.GetProcesses().ToList();
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


    }
}
