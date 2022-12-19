using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OgrTum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrTum.Controllers
{
    public class OgrenciController : Controller
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        // GET: OgrenciController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(ogrenciler);
        }
        // GET: OgrenciController/Details/5
        public ActionResult Details(int id)
        {
            Ogrenci gelen = new Ogrenci();
           // gelen = ogrenciler.Find(x => x.OgrNo = id);
            foreach (var ogr in ogrenciler)
            {
                if (Convert.ToInt32(ogr.OgrNo) == id)
                {
                   // ogr.OgrAd=gelen.
                    gelen = ogr;
                    break;
                }
               
            }
            if (gelen.OgrAd is null)
                return View("Hata");
            return View(gelen);
        }

        // GET: OgrenciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgrenciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                ogrenciler.Add(ogr);
                TempData["ogr"] = ogr.OgrAd + " Adlı öğrenci Eklendi";
                return RedirectToAction("List");
            }
            else
            {
                return View("Hata");
            }
        }

        // GET: OgrenciController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OgrenciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OgrenciController/Delete/5
        public ActionResult Delete(int id)
        {
            Ogrenci silinecek = new Ogrenci();
            foreach (var ogr in ogrenciler)
            {
                if (Convert.ToInt32(ogr.OgrNo) == id)
                {
                    silinecek = ogr;
                    break;
                }
            }
            if (silinecek.OgrAd is null)
            {
                return View("Hata");
            }
            else
            {
                TempData["ogr"] = silinecek.OgrAd + " adlı öğrenci silindi";
                ogrenciler.Remove(silinecek);
                return RedirectToAction("List");
            }
               
            
         
        }

        // POST: OgrenciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
