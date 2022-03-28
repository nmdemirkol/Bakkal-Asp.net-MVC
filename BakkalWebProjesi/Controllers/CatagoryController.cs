using BakkalWebProjesi.Models;
using BakkalWebProjesi.ViewModels.ProductModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalWebProjesi.Controllers
{
    public class CatagoryController : Controller
    {
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
            List<kategori> model = new List<kategori>();
            // model = ent.kategori.ToList();
            model = ent.Database.SqlQuery<kategori>("KategoriGetir").ToList();
            return View(model);
        }


        public ActionResult CatagoryAdd(int? id = 0)
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
            kategori model = new kategori();
            if (id > 0)
            {
                model = ent.kategori.Find(id);

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CatagoryAdd(kategori model)
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
            try
            {
                //ent.kategori.Add(model);
                //ent.SaveChanges();
                ent.Database.ExecuteSqlCommand(@"KategoriOlustur @k_adi", new SqlParameter("@k_adi", model.k_adi));


            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }

        public ActionResult CatagoryDelete(int id)
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
            CatagoryClass model = new CatagoryClass();

            model.catagory = ent.kategori.Find(id);
            model.productCount = ent.urun.Where(i => i.kategori_id == id).Count();

     

            return View(model);
        }

        [HttpPost]
        public ActionResult CatagoryDelete(kategori model)
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
            try
            {
               // model = ent.kategori.Find(model.kategori_id);
               // ent.kategori.Remove(model);
               // ent.SaveChanges();

                ent.Database.ExecuteSqlCommand(@"KategoriSil @id", new SqlParameter("@id", model.kategori_id));
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }



        public ActionResult CatagoryUpdate(int? id = 0)
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
            kategori model = new kategori();
            if (id > 0)
            {
                model = ent.kategori.Find(id);

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CatagoryUpdate(kategori model)
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
            try
            {
          /*      kategori catagory = ent.kategori.Find(model.kategori_id);
                catagory.k_adi = model.k_adi;


                ent.SaveChanges();
*/

                ent.Database.ExecuteSqlCommand(@"KategoriGuncelle @k_adi, @kategori_id", 
                    new SqlParameter("@k_adi", model.k_adi), 
                    new SqlParameter("@kategori_id", model.kategori_id)
                    );


            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }

    }
}