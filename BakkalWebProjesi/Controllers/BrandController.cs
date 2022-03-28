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
    public class BrandController : Controller
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
            List<marka> model = new List<marka>();
          //  model = ent.marka.ToList();
            model = ent.Database.SqlQuery<marka>("MarkaGetir").ToList();
            return View(model);
        }


        public ActionResult BrandAdd()
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

            return View();
        }

        [HttpPost]
        public ActionResult BrandAdd(marka model)
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
                //     ent.marka.Add(model);
                //    ent.SaveChanges();

                ent.Database.ExecuteSqlCommand(@"MarkaOlustur @m_adi", new SqlParameter("@m_adi", model.m_adi));
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult BrandDelete(int id)
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
            BrandClass model = new BrandClass();

            model.brand = ent.marka.Find(id);
            model.productCount = ent.urun.Where(i => i.marka_id == id).Count();



            return View(model);
        }

        [HttpPost]
        public ActionResult BrandDelete(marka model)
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

                // model = ent.marka.Find(model.marka_id);
                // ent.marka.Remove(model);
                // ent.SaveChanges();

                ent.Database.ExecuteSqlCommand(@"MarkaSil @id", new SqlParameter("@id", model.marka_id));

            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }



        public ActionResult BrandUpdate(int? id = 0)
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
            marka model = new marka();
            if (id > 0)
            {
                model = ent.marka.Find(id);

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult BrandUpdate(marka model)
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
          /*    marka Brand = ent.marka.Find(model.marka_id);
                Brand.m_adi = model.m_adi;
                 ent.SaveChanges();
                 */
          
                ent.Database.ExecuteSqlCommand(@"MarkaGuncelle @m_adi, @marka_id",
                    new SqlParameter("@m_adi", model.m_adi),
                    new SqlParameter("@marka_id", model.marka_id)
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