using BakkalWebProjesi.Models;
using BakkalWebProjesi.ViewModels.SalesModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalWebProjesi.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
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
            SalesListClass model = new SalesListClass();
            model.sales = ent.Database.SqlQuery<satis>("SatisGetir").ToList();
            model.users = ent.Database.SqlQuery<kullanici>("KullaniciGetir").ToList();
            return View(model);
        }

        public ActionResult SalesDetail(int id)
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
            SalesClass model = new SalesClass();
            model.sales = ent.satis.FirstOrDefault(i => i.satis_id == id);
            model.salesSubstances = ent.satis_maddeleri.FirstOrDefault(i => i.satis_id == id);
            return View(model);
        }



        public ActionResult SalesAdd(int id)
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
            SalesAddClass model = new SalesAddClass();
            model.product = ent.urun.FirstOrDefault(i => i.urun_id == id);

            return View(model);
        }



        [HttpPost]
        public ActionResult SalesAdd(satis satisModel, satis_maddeleri satisMaddeleriModel)
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
            /*    satis _satis = ent.satis.Add(satisModel);
                ent.SaveChanges();

                satisMaddeleriModel.satis_id = _satis.satis_id;
                ent.satis_maddeleri.Add(satisMaddeleriModel);
                ent.SaveChanges();
*/

               ent.Database.ExecuteSqlCommand(@"SatisOlustur  @s_tarih,@s_durum,@kullanici_id",
                    new SqlParameter("@s_tarih", satisModel.s_tarih),
                    new SqlParameter("@s_durum", satisModel.s_durum),
                    new SqlParameter("@kullanici_id", satisModel.kullanici_id)
                    );

                List<satis> _satis = ent.Database.SqlQuery<satis>("SatisGetir").ToList();

                ent.Database.ExecuteSqlCommand(@"SMOlustur  @si_miktar,@si_fiyat,@si_iskonto,@satis_id,@urun_id",
                    new SqlParameter("@si_miktar", satisMaddeleriModel.si_miktar),
                    new SqlParameter("@si_fiyat", satisMaddeleriModel.si_fiyat),
                    new SqlParameter("@si_iskonto", satisMaddeleriModel.si_iskonto),
                    new SqlParameter("@satis_id", _satis[_satis.Count-1].satis_id),
                    new SqlParameter("@urun_id", satisMaddeleriModel.urun_id)

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