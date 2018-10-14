using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.BLL.Interface.Entitites
{
    public abstract class ComputerInfo
    {
        public ComputerInfo(string osName, int amount, string machineName)
        {
            OSName = osName;
            ProcessorsAmount = amount;
            MachineName = machineName;
        }

        public string OSName { get; set; }
        public int ProcessorsAmount { get; set; }
        public string MachineName { get; set; }
    }
}
