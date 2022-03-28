using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.ProductModels
{
    public class BrandClass
    {
        public BrandClass()
        {
            productCount = new int();
            brand = new marka();

        }
        public int productCount { get; set; }
        public marka brand { get; set; }
    }
}