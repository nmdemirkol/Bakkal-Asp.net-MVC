using BakkalWebProjesi.Models;
using BakkalWebProjesi.ViewModels.HomeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalWebProjesi.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index()
        {

            if (Request.Cookies["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (Request.Cookies["user"].Value == "")
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            BakkalDbEntities ent = new BakkalDbEntities();
            HomeClass model = new HomeClass();
            model.productCount = ent.urun.ToList().Count;
            model.roleCount = ent.rol.ToList().Count;
            model.salesCount = ent.satis.ToList().Count;
            List<stok> _stok = ent.stok.ToList();

            int stockCount = 0;
            for (int i = 0; i < _stok.Count; i++)
            {
                stockCount += _stok[i].s_adedi;
            }

            model.stockCount = stockCount;
            model.userCount = ent.kullanici.ToList().Count;
            model.brandCount = ent.marka.ToList().Count;
            model.catagoryCount = ent.kategori.ToList().Count;



            return View(model);
        }


    }
}