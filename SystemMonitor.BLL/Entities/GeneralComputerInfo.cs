using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.BLL.Interface.Entitites;

namespace SystemMonitor.BLL.Entities
{
    internal class GeneralComputerInfo: ComputerInfo
    {
        public GeneralComputerInfo(string osName, int amount, string machineName) : base(osName, amount, machineName)
        { }
    }
}
