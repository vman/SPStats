﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6BF6C6015669B5BC787E2590FD634F75"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SPStats.WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SPStats.WPF {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.ListBox lbDetails;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeView tvFarmElements;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviFeaturedenifions;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviServices;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviServiceProxies;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviApplicationPools;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviSolutions;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviServers;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviWebApps;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TreeViewItem tviPH;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SPStats.WPF;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\MainWindow.xaml"
            ((SPStats.WPF.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbDetails = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.tvFarmElements = ((System.Windows.Controls.TreeView)(target));
            return;
            case 4:
            this.tviFeaturedenifions = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 12 "..\..\..\MainWindow.xaml"
            this.tviFeaturedenifions.Selected += new System.Windows.RoutedEventHandler(this.tviFeaturedenifions_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tviServices = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 13 "..\..\..\MainWindow.xaml"
            this.tviServices.Selected += new System.Windows.RoutedEventHandler(this.tviServices_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tviServiceProxies = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.tviServiceProxies.Selected += new System.Windows.RoutedEventHandler(this.tviServiceProxies_Selected);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tviApplicationPools = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 15 "..\..\..\MainWindow.xaml"
            this.tviApplicationPools.Selected += new System.Windows.RoutedEventHandler(this.tviApplicationPools_Selected);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tviSolutions = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.tviSolutions.Selected += new System.Windows.RoutedEventHandler(this.tviSolutions_Selected);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tviServers = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 17 "..\..\..\MainWindow.xaml"
            this.tviServers.Selected += new System.Windows.RoutedEventHandler(this.tviServers_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            this.tviWebApps = ((System.Windows.Controls.TreeViewItem)(target));
            
            #line 18 "..\..\..\MainWindow.xaml"
            this.tviWebApps.Expanded += new System.Windows.RoutedEventHandler(this.tviWebApps_Expanded);
            
            #line default
            #line hidden
            return;
            case 11:
            this.tviPH = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
