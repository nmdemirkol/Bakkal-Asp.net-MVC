using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakkalWebProjesi.ViewModels.ProductModels
{
    public class ProductClass
    {
        public ProductClass()
        {
            brandList = new List<marka>();
            catagoryList = new List<kategori>();
            stockList = new List<stok>();
            product = new urun();
            stock = new stok();
        }

        public List< marka> brandList { get; set; }
        public List<kategori> catagoryList { get; set; }
        public List<stok> stockList { get; set; }
        public urun product { get; set; }
        public stok stock { get; set; }
    }
}