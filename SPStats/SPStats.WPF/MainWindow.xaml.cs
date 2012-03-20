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
using Microsoft.SharePoint;

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

        public void GetServiceProxies(Object info)
        {   
            if (serviceProxyList != null)
            {
                foreach (SPServiceProxy proxy in serviceProxyList)
                {
                    //Service Proxies
                    AddData(proxy.TypeName, lbDetails);

                    if (proxy.ApplicationProxies.Count > 0)
                    {
                        //Application Proxies
                        foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                        {
                            AddData("--" + appProxy.TypeName, lbDetails);
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

                    //Service Proxies
                    AddData(proxy.TypeName, lbDetails);

                    if (proxy.ApplicationProxies.Count > 0)
                    {
                        //Application Proxies
                        foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
                        {
                            AddData("--" + appProxy.TypeName, lbDetails);
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
                    AddData(featureDef.DisplayName, lbDetails);
                }
            }
            else
            {
                featureDefintionList = new List<SPFeatureDefinition>();

                foreach (SPFeatureDefinition featureDef in farm.FeatureDefinitions)
                {
                    featureDefintionList.Add(featureDef);
                    AddData(featureDef.DisplayName, lbDetails);
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

        private void tviFeaturedenifions_Selected(object sender, RoutedEventArgs e)
        {
            ClearListBox(lbDetails);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetFeatureDefinitions));
        }

        private void tviServiceProxies_Selected(object sender, RoutedEventArgs e)
        {
            ClearListBox(lbDetails);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServiceProxies));
        }

        private void tviSolutions_Selected(object sender, RoutedEventArgs e)
        {
            ClearListBox(lbDetails);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetSolutions));
        }

        void GetSolutions(Object info)
        {
            foreach (SPSolution solutionDef in farm.Solutions)
            {
                AddData(solutionDef.DisplayName, lbDetails);
            }
        }

        private void tviServers_Selected(object sender, RoutedEventArgs e)
        {
            ClearListBox(lbDetails);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetServers));
        }

        void GetServers(Object info)
        {
            foreach (SPServer server in farm.Servers)
            {
                AddData(server.DisplayName, lbDetails);
            }
        }

        static void ClearListBox(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        static void ClearTreeViewItem(TreeViewItem treeviewItem)
        {
            treeviewItem.Items.Clear();
        }

        private void tviWebApps_Selected(object sender, RoutedEventArgs e)
        {
           //ClearTreeViewItem(tviWebApps);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(GetWebApps));
        }

        void GetWebApps(Object info)
        {
            foreach (SPService service in farm.Services)
            {
                if (service as SPWebService != null)
                {
                    foreach (SPWebApplication webApp in ((SPWebService)service).WebApplications)
                    {
                        AddWebAppTreeViewItem(tviWebApps, webApp);
                    }
                }

            }
        }

        void AddWebAppTreeViewItem(TreeViewItem parentItem, SPWebApplication webApp)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(delegate()
            {
                TreeViewItem tvi = new TreeViewItem();
                tvi.Header = webApp.DisplayName;
                tvi.Tag = webApp;
                tvi.Selected += new RoutedEventHandler(tvi_Selected);
                parentItem.Items.Add(tvi);

            }));
        }

        void tvi_Selected(object sender, RoutedEventArgs e)
        {
            ClearListBox(lbDetails);

            var selectedTvi = sender as TreeViewItem;

            foreach (SPSite site in ((SPWebApplication)selectedTvi.Tag).Sites)
            {
                AddData(site.Url, lbDetails);
            }

        }

        private void tviWebApps_Expanded(object sender, RoutedEventArgs e)
        {
            ClearTreeViewItem(tviWebApps);
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetWebApps));
        }
    }
}
