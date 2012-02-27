using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.SharePoint.Administration;
using System.Windows.Threading;
using System.Threading;

namespace SPStats.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SPFarm farm = null;

        public MainWindow()
        {
            InitializeComponent();
            farm = SPFarm.Local;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServiceProxies));

        }

        public void GetServiceProxies(Object info)
        {
            

            foreach (SPServiceProxy proxy in farm.ServiceProxies)
            {
                AddData(proxy.TypeName, listBox1);

                if (proxy.ApplicationProxies.Count > 0)
                {
                    //Application Proxies
                    foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                    {
                        AddData("--"+appProxy.TypeName,listBox1);                        
                    }
                }

            }
        }

        void GetFeatureDefinitions(Object info)
        {
            foreach (SPFeatureDefinition featureDef in farm.FeatureDefinitions)
            {
                AddData(featureDef.DisplayName,listBox2);
            }
        }

        void AddData(string item,ListBox control)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
            {
                control.Items.Add(item);

            }));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetFeatureDefinitions));
        }
    }
}
