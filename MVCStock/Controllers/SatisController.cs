using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStock.Models.Entities;

namespace MVCStock.Controllers
{
    public class SatisController : Controller
    {
        MVCDbStockEntities db = new MVCDbStockEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR satis)
        {
            db.TBLSATISLAR.Add(satis);
            db.SaveChanges();
            return View("Index");
        }
    }
}