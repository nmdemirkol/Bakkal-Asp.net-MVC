using BakkalWebProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BakkalWebProjesi.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult Index(kullanici model)
        {
            BakkalDbEntities ent = new BakkalDbEntities();
            try
            {
                kullanici _user = ent.kullanici.FirstOrDefault(i => i.k_kullaniciadi == model.k_kullaniciadi && i.k_parola == model.k_parola);


                if (_user!=null)
                {
                    HttpCookie cookie = new HttpCookie("user", _user.k_adi);
                    Response.Cookies.Add(cookie);
                    HttpCookie cookie2 = new HttpCookie("userId", _user.kullanici_id.ToString());
                    Response.Cookies.Add(cookie2);


                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
             

            }
            catch (Exception)
            {

                throw;
            }




           
        }
        // GET: Login
        public ActionResult LoginOut()
        {
            HttpCookie cookie = new HttpCookie("user", "");
            Response.Cookies.Add(cookie);
            HttpCookie cookie2 = new HttpCookie("userId", "");
            Response.Cookies.Add(cookie2);
            return RedirectToAction("Index","Home");
        }


    }
}