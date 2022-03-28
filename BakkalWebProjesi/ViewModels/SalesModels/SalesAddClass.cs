using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.SalesModels
{
    public class SalesAddClass
    {
        public SalesAddClass()
        {
            sales = new satis();
            salesSubstances = new satis_maddeleri();
            product = new urun();
        }

        public satis_maddeleri salesSubstances { get; set; }
        public satis sales { get; set; }
        public urun product { get; set; }
    }
}