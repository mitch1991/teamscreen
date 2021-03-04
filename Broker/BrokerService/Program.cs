using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrokerService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if !RunAsService



            BrokerService brokerService = new BrokerService
            {
                ServiceName = "Screen Share Broker",
                AutoLog = true,
                CanStop = true
            };
            brokerService.Start();



            Thread.Sleep(Timeout.Infinite);




#else

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new BrokerService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
