using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;
using System.Runtime.Remoting.Messaging;


namespace SPStats.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GetDataAsync();
            
        }

        public void GetDataWorker()
        {
            SPFarm farm = SPFarm.Local;

            foreach (SPServiceProxy proxy in farm.ServiceProxies)
            {
                listBox1.Items.Add(proxy.TypeName);

                if (proxy.ApplicationProxies.Count > 0)
                {
                    //Application Proxies
                    foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                    {
                        listBox1.Items.Add("--" + appProxy.TypeName);
                    }
                }
            }
        }

        private delegate void GetDataWorkerDelegate();

        private bool _getDataIsRunning = false;

        public bool IsBusy
        {
            get { return _getDataIsRunning; }
        }

        public void GetDataAsync()
        {
            GetDataWorkerDelegate worker = new GetDataWorkerDelegate(GetDataWorker);
            AsyncCallback completedCallback = new AsyncCallback(GetDataCompletedCallback);

            lock (_sync)
            {
                if (_getDataIsRunning)
                    throw new InvalidOperationException("The control is currently busy.");

                AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                worker.BeginInvoke(completedCallback, async);
                _getDataIsRunning = true;
            }
        }

        private readonly object _sync = new object();

        private void GetDataCompletedCallback(IAsyncResult ar)
        {
            // get the original worker delegate and the AsyncOperation instance
            GetDataWorkerDelegate worker =
              (GetDataWorkerDelegate)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            worker.EndInvoke(ar);

            // clear the running task flag
            lock (_sync)
            {
                _getDataIsRunning = false;
            }

            // raise the completed event
            AsyncCompletedEventArgs completedArgs = new AsyncCompletedEventArgs(null,
              false, null);
            async.PostOperationCompleted(
              delegate(object e) { OnMyTaskCompleted((AsyncCompletedEventArgs)e); },
              completedArgs);
        }

        public event AsyncCompletedEventHandler MyTaskCompleted;

        protected virtual void OnMyTaskCompleted(AsyncCompletedEventArgs e)
        {
            if (MyTaskCompleted != null)
                MyTaskCompleted(this, e);
        }

    }
}