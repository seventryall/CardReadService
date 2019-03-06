using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardReaderService
{
    public partial class Service1 : ServiceBase
    {
        private Thread thread;
        private CardReaderSocketServer socketServer;
        public Service1()
        {
            InitializeComponent();
        }

        private void InitSocket()
        {
            try
            {
                socketServer = new CardReaderSocketServer();
                socketServer.Start();
            }
            catch
            {
               
            }
        }

        protected override void OnStart(string[] args)
        {
            thread = new Thread(new ThreadStart(this.InitSocket));
            thread.Start();
        }

        protected override void OnStop()
        {
            thread.Abort();
        }
    }
}
