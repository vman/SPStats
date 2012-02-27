using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint;

namespace SPStats
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Central Admin
            //SPAdministrationWebApplication centralWeb = SPAdministrationWebApplication.Local;
            //Print(centralWeb.DisplayName);

            SPFarm farm = SPFarm.Local;

            //Print(farm.DisplayName);

           // Feature Definitions
            Print("**Feature Defitions:");
            foreach (SPFeatureDefinition featureDef in farm.FeatureDefinitions)
            {   
                Print(featureDef.DisplayName);
            }

            ////Solutions
            //Print("**Solutions:");
            //foreach (SPSolution solutionDef in farm.Solutions)
            //{
            //    Print(solutionDef.DisplayName);
            //}

            ////Services
            //Print("**Services");
            //foreach (SPService service in farm.Services)
            //{
            //    Print(string.IsNullOrEmpty(service.TypeName) ? string.IsNullOrEmpty(service.Name) ? service.DisplayName : service.Name : service.TypeName);
            //}

            ////Servers
            //Print("**Servers");
            //foreach (SPServer server in farm.Servers)
            //{
            //    Print(server.DisplayName);
            //}

            ////Print(farm.DefaultServiceAccount);

            //Service Proxies
            //Print("**Service Proxies");
            //foreach (SPServiceProxy proxy in farm.ServiceProxies)
            //{
            //    Print(proxy.TypeName);

            //    if (proxy.ApplicationProxies.Count > 0)
            //    {
            //        //Application Proxies
            //        foreach (SPServiceApplicationProxy appProxy in proxy.ApplicationProxies)
            //        {
            //            Print("--" + appProxy.TypeName);
            //        }
            //    }
            //}

            //Web Applications
            //Print("**Web Applications");
            //foreach (SPService service in farm.Services)
            //{

            //    if(service as SPWebService != null)
            //    {
            //        Print(string.IsNullOrEmpty(service.TypeName) ? string.IsNullOrEmpty(service.Name) ? service.DisplayName : service.Name : service.TypeName);

            //        foreach (SPWebApplication webApp in ((SPWebService)service).WebApplications)
            //        {
            //            Print("--"+webApp.DisplayName);
            //        }
            //    }
              
            //}
           
            //foreach (SPService curService in SPFarm.Local.Services)
            //{
            //    if (curService is SPWebService)
            //    {
            //        SPWebService webService = (SPWebService)curService;

            //        foreach (SPWebApplication webApp in webService.WebApplications)
            //        {
            //            Console.WriteLine(webApp.DisplayName);

            //            foreach (SPSite site in webApp.Sites)
            //            {
            //                foreach(SPWeb web in site.AllWebs)
            //                {
            //                    Console.WriteLine(web.Title);

            //                    foreach (SPWeb subWeb in web.Webs)
            //                    {
            //                        Console.WriteLine(subWeb.Title);
            //                    }
            //                }
                            
            //            }
            //        }
            //    }
            //}

            
            Console.ReadKey();
        }

        public static void Print(object obj)
        {
            Console.WriteLine(obj.ToString());
        }

    }
}
