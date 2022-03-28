using BakkalWebProjesi.Models;
using BakkalWebProjesi.ViewModels.UserModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalWebProjesi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
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
            UserListClass model = new UserListClass();
          

            model.users = ent.Database.SqlQuery<kullanici>("KullaniciGetir").ToList();
            model.roles = ent.Database.SqlQuery<rol>("RolGetir").ToList();
            return View(model);
        }

        public ActionResult UserDetail(int? id = 0)
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
            UserClass model = new UserClass();
            model.user = ent.kullanici.Find(id);
            model.roles = ent.rol.ToList();
            return View(model);
        }


        public ActionResult UserAdd(int? id = 0)
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
            UserClass model = new UserClass();
            if (id>0)
            {
                model.user = ent.kullanici.Find(id);

            }
            model.roles = ent.rol.ToList();
            return View(model);
        }


        [HttpPost]
        public ActionResult UserAdd(kullanici model)
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
              //  ent.kullanici.Add(model);
            //    ent.SaveChanges();

                ent.Database.ExecuteSqlCommand(@"KullaniciOlustur  @k_kullaniciadi,@k_parola,@k_adi,@k_soyadi,@k_eposta,@k_telefon,@k_durum,@rol_id",
                new SqlParameter("@k_kullaniciadi", model.k_kullaniciadi),
                new SqlParameter("@k_parola", model.k_parola),
                new SqlParameter("@k_adi", model.k_adi),
                new SqlParameter("@k_soyadi", model.k_soyadi),
                new SqlParameter("@k_eposta", model.k_eposta),
                new SqlParameter("@k_telefon", model.k_telefon),
                new SqlParameter("@k_durum", model.k_durum),
                new SqlParameter("@rol_id", model.rol_id)

                );
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }

        public ActionResult UserDelete(int? id)
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
            UserClass model = new UserClass();

            model.user = ent.kullanici.Find(id);
            model.roles = ent.rol.ToList();




            return View(model);
        }

      [HttpPost]
        public ActionResult UserDelete(kullanici model)
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
            kullanici _model = new kullanici();
            try
            {
               /* _model = ent.kullanici.Find(model.kullanici_id);
                ent.kullanici.Remove(_model);
                ent.SaveChanges();*/


                ent.Database.ExecuteSqlCommand(@"KullaniciSil @id", new SqlParameter("@id", model.kullanici_id));
         
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }



        public ActionResult UserUpdate(int? id = 0)
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
            UserClass model = new UserClass();
            if (id > 0)
            {
                model.user = ent.kullanici.Find(id);

            }
            model.roles = ent.rol.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult UserUpdate(kullanici model)
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
                kullanici user = ent.kullanici.Find(model.kullanici_id);
                user.k_adi = model.k_adi;
                user.k_durum = model.k_durum;
                user.k_eposta = model.k_eposta;
                user.k_kullaniciadi = model.k_kullaniciadi;
                user.k_parola = model.k_parola;
                user.k_soyadi = model.k_soyadi;
                user.k_telefon = model.k_telefon;
                user.rol_id = model.rol_id;



                ent.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }
    }


}