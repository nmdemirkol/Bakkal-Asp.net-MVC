using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.ProductModels
{
    public class ProductListClass
    {
        public ProductListClass()
        {
            brandList = new List<marka>();
            catagoryList = new List<kategori>();
            stockList = new List<stok>();
            productList = new List<urun>();
        }

        public List< marka> brandList { get; set; }
        public List<kategori> catagoryList { get; set; }
        public List<stok> stockList { get; set; }
        public List<urun> productList { get; set; }
    }
}