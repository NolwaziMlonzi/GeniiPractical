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
    public class ProductItemController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ProductItem
        public ActionResult Index()
        {
            return View(db.ProductItems.ToList());
        }

        // GET: ProductItem/Details/5
        public ActionResult ItemDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // GET: ProductItem/Create
        public ActionResult ItemCreate()
        {
            return View();
        }

        // POST: ProductItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemCreate([Bind(Include = "ItemID,ItemName,CostPerItem,TotalCost,TotalAmount,Invoice_ID")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.ProductItems.Add(productItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productItem);
        }

        // GET: ProductItem/Edit/5
        public ActionResult ItemEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // POST: ProductItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ItemEdit([Bind(Include = "ItemID,ItemName,CostPerItem,TotalCost,TotalAmount,Invoice_Id")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productItem);
        }

        // GET: ProductItem/Delete/5
        public ActionResult ProductItemDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = db.ProductItems.Find(id);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(productItem);
        }

        // POST: ProductItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ProductItemDeleteConfirmed(int id)
        {
            ProductItem productItem = db.ProductItems.Find(id);
            db.ProductItems.Remove(productItem);
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
