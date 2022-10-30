using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entities;

namespace MVCStock.Controllers
{
    public class MusterilerController : Controller
    {
        MVCDbStockEntities db = new MVCDbStockEntities();

        public ActionResult Index(string p)
        {
            var deger = from d in db.TBLMUSTERİLER select d;

            if (!string.IsNullOrEmpty(p))
            {
                deger = deger.Where(m => m.MUTERİAD.Contains(p));
            }
            return View(deger.ToList());

            //var values = db.TBLMUSTERİLER.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult YeniMusteri()       
        {
            
            return View();

        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİLER m)
        {

            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }

            db.TBLMUSTERİLER.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var values = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERİLER.Find(id);
            return View("MusteriGetir", musteri);

        }

        public ActionResult Guncelle(TBLMUSTERİLER m)
        {
            var musteri = db.TBLMUSTERİLER.Find(m.MUSTERİID);
            musteri.MUTERİAD = m.MUTERİAD;
            musteri.MUSTERİSOYAD = m.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}