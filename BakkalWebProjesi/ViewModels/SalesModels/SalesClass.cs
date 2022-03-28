using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.SalesModels
{
    public class SalesClass
    {
        public SalesClass()
        {
            sales = new satis();
            salesSubstances = new satis_maddeleri();
        }

        public satis_maddeleri salesSubstances { get; set; }
        public satis sales { get; set; }
    }
}