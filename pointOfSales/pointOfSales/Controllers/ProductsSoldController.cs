using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pointOfSales.Models;
using point_of_sales.Models;

namespace pointOfSales.Controllers
{
    public class ProductsSoldController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ProductsSold
        public ActionResult Index()
        {
            return View(db.ProductsSolds.ToList());
        }

        // GET: ProductsSold/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSold productsSold = db.ProductsSolds.Find(id);
            if (productsSold == null)
            {
                return HttpNotFound();
            }
            return View(productsSold);
        }

        // GET: ProductsSold/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsSold/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductSoldID,ProductName,sold,InStock,ReStock")] ProductsSold productsSold)
        {
            if (ModelState.IsValid)
            {
                db.ProductsSolds.Add(productsSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsSold);
        }

        // GET: ProductsSold/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSold productsSold = db.ProductsSolds.Find(id);
            if (productsSold == null)
            {
                return HttpNotFound();
            }
            return View(productsSold);
        }

        // POST: ProductsSold/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductSoldID,ProductName,sold,InStock,ReStock")] ProductsSold productsSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productsSold);
        }

        // GET: ProductsSold/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsSold productsSold = db.ProductsSolds.Find(id);
            if (productsSold == null)
            {
                return HttpNotFound();
            }
            return View(productsSold);
        }

        // POST: ProductsSold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsSold productsSold = db.ProductsSolds.Find(id);
            db.ProductsSolds.Remove(productsSold);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
