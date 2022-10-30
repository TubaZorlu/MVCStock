using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entities;
using PagedList;
using PagedList.Mvc;


namespace MVCStock.Controllers
{
    public class KategoriController : Controller
    {
        MVCDbStockEntities db = new MVCDbStockEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var values = db.TBLKATEGORILER_.ToList();

            // padedlist ürünleri listelerken sayfalara yaymak için kullanılıyor burada 1 başlayacağı sayfa numaraıı 4 kaç sayfa olacağı

            var values = db.TBLKATEGORILER_.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER_ p)
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }

            db.TBLKATEGORILER_.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id) 
        {
            var kategori = db.TBLKATEGORILER_.Find(id);
            db.TBLKATEGORILER_.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id) 
        {
            var kategori = db.TBLKATEGORILER_.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(TBLKATEGORILER_ p) 
        {
            var kategori = db.TBLKATEGORILER_.Find(p.KATEGORIID);
            kategori.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}