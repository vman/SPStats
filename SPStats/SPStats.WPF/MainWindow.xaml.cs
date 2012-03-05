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
        List<SPServiceProxy> serviceProxyList = null;
        List<SPFeatureDefinition> featureDefintionList = null;

        public MainWindow()
        {
            InitializeComponent();
            farm = SPFarm.Local;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServiceProxies));

        }

        public void GetServiceProxies(Object info)
        {   
            if (serviceProxyList != null)
            {
                foreach (SPServiceProxy proxy in serviceProxyList)
                {
                    //serviceProxyList.Add(proxy);

                    AddData(proxy.TypeName, listBox1);

                    if (proxy.ApplicationProxies.Count > 0)
                    {
                        //Application Proxies
                        foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                        {
                            AddData("--" + appProxy.TypeName, listBox1);
                        }
                    }

                }
            }
            else
            {
                serviceProxyList = new List<SPServiceProxy>();

                foreach (SPServiceProxy proxy in farm.ServiceProxies)
                {
                    serviceProxyList.Add(proxy);

                    AddData(proxy.TypeName, listBox1);

                    if (proxy.ApplicationProxies.Count > 0)
                    {
                        //Application Proxies
                        foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                        {
                            AddData("--" + appProxy.TypeName, listBox1);
                        }
                    }

                }

            }
        }
        
        void GetFeatureDefinitions(Object info)
        {
            if (featureDefintionList != null)
            {
                foreach (SPFeatureDefinition featureDef in featureDefintionList)
                {
                    AddData(featureDef.DisplayName, listBox1);
                }
            }
            else
            {
                featureDefintionList = new List<SPFeatureDefinition>();

                foreach (SPFeatureDefinition featureDef in farm.FeatureDefinitions)
                {
                    featureDefintionList.Add(featureDef);
                    AddData(featureDef.DisplayName,listBox1);
                }
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
            listBox1.Items.Clear();
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetFeatureDefinitions));
        }

        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetFeatureDefinitions));
        }

        private void tviFeaturedenifions_Selected(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetFeatureDefinitions));
        }

        private void tviServiceProxies_Selected(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServiceProxies));
        }
    }
}
