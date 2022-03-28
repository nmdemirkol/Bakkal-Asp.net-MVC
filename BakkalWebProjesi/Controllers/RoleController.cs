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
    public class RoleController : Controller
    {
        // GET: Role
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
            List<rol> model;
            model = ent.Database.SqlQuery<rol>("RolGetir").ToList();
            return View(model);
        }


        public ActionResult RoleAdd(int? id = 0)
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
            rol model = new rol();
            if (id > 0)
            {
                model = ent.rol.Find(id);

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult RoleAdd(rol model)
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
            //    ent.rol.Add(model);
             //   ent.SaveChanges();


                ent.Database.ExecuteSqlCommand(@"RolOlustur @r_adi",
                    new SqlParameter("@r_adi", model.r_adi)
                    );
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }

        public ActionResult RoleDelete(int id)
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
            RoleClass model = new RoleClass();

            model.role = ent.rol.Find(id);
            model.userCount = ent.kullanici.Where(i => i.rol_id == id).Count();



            return View(model);
        }

        [HttpPost]
        public ActionResult RoleDelete(rol model)
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
          /*      model = ent.rol.Find(model.rol_id);
                ent.rol.Remove(model);
                ent.SaveChanges();*/


                ent.Database.ExecuteSqlCommand(@"RolSil @id", new SqlParameter("@id", model.rol_id));
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }



        public ActionResult RoleUpdate(int? id = 0)
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
            rol model = new rol();
            if (id > 0)
            {
                model = ent.rol.Find(id);

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult RoleUpdate(rol model)
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
                rol role = ent.rol.Find(model.rol_id);
                role.r_adi = model.r_adi;


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