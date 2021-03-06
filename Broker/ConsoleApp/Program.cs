﻿using System;
using System.ServiceProcess;
using System.Threading;
using ConsoleApp;
using LiteNetLib;
using Network.Thread;

namespace TeamScreen.Broker.ConsoleApp
{
    public class Program
    {

        public static void Main()
        {
            string ServiceName = $"Screen Share Broker";



#if !RunAsService



            BrokerService brokerService = new BrokerService
            {
                ServiceName = ServiceName,
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
                {
                    ServiceName =ServiceName ,
                    AutoLog = true,
                    CanStop = true
                }
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}