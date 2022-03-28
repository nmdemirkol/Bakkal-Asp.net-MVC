using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.ProductModels
{
    public class CatagoryClass
    {
        public CatagoryClass()
        {
            productCount = new int();
            catagory = new kategori();

        }
        public int productCount { get; set; }
        public kategori catagory { get; set; }
    }
}