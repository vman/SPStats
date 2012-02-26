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
            //Microsoft.SharePoint.Administration.SPAdministrationWebApplication centralWeb = SPAdministrationWebApplication.Local;
            //Console.WriteLine(centralWeb.DisplayName);

            SPFarm farm = SPFarm.Local;

            //Print(farm.DisplayName);

            //foreach(SPFeatureDefinition featureDef in farm.FeatureDefinitions)
            //{
            //    Print(featureDef.DisplayName);
            //}

            //foreach(SPSolution solutionDef in farm.Solutions)
            //{
            //    Print(solutionDef.DisplayName);
            //}

            foreach (SPService service in farm.Services)
            {
                Print(service.DisplayName);
            }

            //Print(farm.Servers);

            //Print(farm.DefaultServiceAccount);

            //Print(farm.ServiceProxies);

            //farm.

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
            //if (obj is IEnumerable<object>)
            //{
            //    foreach (var item in (IList<object>)obj)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }
            //}
            //else
            //{
                Console.WriteLine(obj.ToString());
            //}
        }

    }
}
