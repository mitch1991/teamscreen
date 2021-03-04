using LiteNetLib;
using Network.Thread;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace ConsoleApp
{
    public class BrokerService : ServiceBase
    {
        public static BrokerThread Manager { get { return Network.Instance.Broker.Instance.Thread; } }

        protected override void OnStart(string[] args)
        {
            Manager.Events.onPeerConnected += delegate (object sender, EventArgs eventArgs)
            {
                NetPeer peer = (NetPeer)sender;
                Console.WriteLine("Peer connected: " + peer.EndPoint);
            };

            Manager.Start();
        }
#if !RunAsService
        public void Start()
        {
            OnStart(null);
        }
#endif
    }
}
