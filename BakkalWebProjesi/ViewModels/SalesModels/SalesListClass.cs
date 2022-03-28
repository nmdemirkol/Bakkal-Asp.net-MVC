using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.SalesModels
{
    public class SalesListClass
    {
        public SalesListClass()
        {
            sales = new List<satis>();
            users = new List<kullanici>();
        
        }


        public List<satis> sales { get; set; }
        public List<kullanici> users { get; set; }
    }
}