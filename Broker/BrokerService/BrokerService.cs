using LiteNetLib;
using Network.Thread;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BrokerService
{
    public partial class BrokerService : ServiceBase
    {
        public BrokerService()
        {
            InitializeComponent();
        }

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
        protected override void OnStop()
        {
        }
#if !RunAsService
        public void Start()
        {
            OnStart(null);
        }
#endif
    }
}
