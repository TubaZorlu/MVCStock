using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entities;
namespace MVCStock.Controllers

{
    public class UrunlerController : Controller
    {
        MVCDbStockEntities db = new MVCDbStockEntities();

        public ActionResult Index()
        {
            var values = db.TBLURUNLER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {

            List<SelectListItem> values = (from i in db.TBLKATEGORILER_.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr = values;

            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER u)
        {
            var kategori = db.TBLKATEGORILER_.Where(m => m.KATEGORIID == u.TBLKATEGORILER_.KATEGORIID).FirstOrDefault();
            u.TBLKATEGORILER_ = kategori;
            db.TBLURUNLER.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> values = (from i in db.TBLKATEGORILER_.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr = values;

            return View ("UrunGetir", urun);
        }

        public ActionResult Guncelle(TBLURUNLER u)
        {
            var urun = db.TBLURUNLER.Find(u.URUNID);
            urun.URUNAD = u.URUNAD;
            urun.MARKA = u.MARKA;
            urun.STOK = u.STOK;
            urun.FIYAT = u.FIYAT;
            var yeniKategori = db.TBLKATEGORILER_.Where(x => x.KATEGORIID == u.TBLKATEGORILER_.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORİ = yeniKategori.KATEGORIID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
