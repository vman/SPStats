using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPStats.WPF.Models;

namespace SPStats.WPF
{
    public class FarmViewModel
    {
        Solution solution;

        public string SolutionName
        {
            get { return solution.SolutionName;}
            set { solution.SolutionName = value; }
        }
    }
}
