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
    public class ProductController : Controller
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
            ProductListClass model = new ProductListClass();
            model.brandList = ent.Database.SqlQuery<marka>("MarkaGetir").ToList();
            model.catagoryList = ent.Database.SqlQuery<kategori>("KategoriGetir").ToList();
            model.productList = ent.Database.SqlQuery<urun>("UrunGetir").ToList();
            model.stockList = ent.Database.SqlQuery<stok>("StokGetir").ToList();

            return View(model);
        }

        public ActionResult ProductDetail(int? id = 0)
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
            urun model = ent.urun.FirstOrDefault(s => s.urun_id == id);


            return View(model);
        }


        public ActionResult ProductAdd()
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
            ProductClass model = new ProductClass();


            model.brandList = ent.marka.ToList();
            model.catagoryList = ent.kategori.ToList();
            model.stockList = ent.stok.ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult ProductAdd(ProductClass model)
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

                //  ent.urun.Add(model);
                //  ent.SaveChanges();

                ent.Database.ExecuteSqlCommand(@"StokOlustur @stok_id,@s_adedi,@s_giris_tarihi",

          new SqlParameter("@stok_id", model.stock.stok_id),

     new SqlParameter("@s_adedi", model.stock.s_adedi),


     new SqlParameter("@s_giris_tarihi", model.stock.s_giris_tarihi)


                        );

                ent.Database.ExecuteSqlCommand(@"UrunOlustur @u_adi,@u_barkodu,@u_uretim_tarihi,@u_tuketim_tarihi,@u_fiyat,@u_agirlik,@u_rengi,@marka_id,@kategori_id,@stok_id",
             
                    new SqlParameter("@u_adi", model.product.u_adi),
                    new SqlParameter("@u_barkodu", model.product.u_barkodu),
                    new SqlParameter("@u_uretim_tarihi", model.product.u_uretim_tarihi),
                    new SqlParameter("@u_tuketim_tarihi", model.product.u_tuketim_tarihi),
                    new SqlParameter("@u_fiyat", model.product.u_fiyat),
                    new SqlParameter("@u_agirlik", model.product.u_agirlik),
                    new SqlParameter("@u_rengi", model.product.u_rengi),
                    new SqlParameter("@marka_id", model.product.marka_id),
                    new SqlParameter("@kategori_id", model.product.kategori_id),
                    new SqlParameter("@stok_id", model.product.stok_id)
                    );

     

            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }


        public ActionResult ProductDelete(int? id)
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
            urun model = ent.urun.Find(id);




            return View(model);
        }

        [HttpPost]
        public ActionResult ProductDelete(urun model)
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
                // model = ent.urun.Find(model.urun_id);
                // ent.urun.Remove(model);
                // ent.SaveChanges();

                
                ent.Database.ExecuteSqlCommand(@"UruneAitSatisMaddeleriniSil @urun_id", new SqlParameter("@urun_id", model.urun_id));
                ent.Database.ExecuteSqlCommand(@"UrunSil @id", new SqlParameter("@id", model.urun_id));
            }
            catch (Exception)
            {

                throw;
            }




            return RedirectToAction("Index");
        }



        public ActionResult ProductUpdate(int? id = 0)
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
            ProductClass model = new ProductClass();
            if (id > 0)
            {
                model.product = ent.urun.Find(id);

            }

            model.brandList = ent.marka.ToList();
            model.catagoryList = ent.kategori.ToList();
            model.stockList = ent.stok.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult ProductUpdate(ProductClass model)
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

                ent.Database.ExecuteSqlCommand(@"UrunGuncelle @urun_id, @u_adi,@u_barkodu,@u_uretim_tarihi,@u_tuketim_tarihi,@u_fiyat,@u_agirlik,@u_rengi,@marka_id,@kategori_id,@stok_id",
                     new SqlParameter("@urun_id", model.product.urun_id),

                    new SqlParameter("@u_adi", model.product.u_adi),


                    new SqlParameter("@u_barkodu", model.product.u_barkodu),
                    new SqlParameter("@u_uretim_tarihi", model.product.u_uretim_tarihi),
                    new SqlParameter("@u_tuketim_tarihi", model.product.u_tuketim_tarihi),
                    new SqlParameter("@u_fiyat", model.product.u_fiyat),
                    new SqlParameter("@u_agirlik", model.product.u_agirlik),
                    new SqlParameter("@u_rengi", model.product.u_rengi),
                    new SqlParameter("@marka_id", model.product.marka_id),
                    new SqlParameter("@kategori_id", model.product.kategori_id),
                    new SqlParameter("@stok_id", model.product.stok_id) 

                    
                                       );

                ent.Database.ExecuteSqlCommand(@"StokGuncelle @stok_id,@s_adedi,@s_giris_tarihi",
                 new SqlParameter("@stok_id", model.stock.stok_id),

                new SqlParameter("@s_adedi", model.stock.s_adedi),


                new SqlParameter("@s_giris_tarihi", model.stock.s_giris_tarihi)
  


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