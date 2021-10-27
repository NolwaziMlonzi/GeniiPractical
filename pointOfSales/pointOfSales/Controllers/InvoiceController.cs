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
    public class InvoiceController : Controller
    {
        private DataContext db = new DataContext();

        // GET: InvoiceID
        public ActionResult Index()
        {
            return View(db.Invoice.ToList());
        }
       
        public ActionResult Test(int? id)
        {
            //InvoiceID item = db.InvoiceIDs.Find(id);
            
            Session["InvoiceID"] = id;
            return RedirectToAction("Indexs");
        }
        public ActionResult Indexs()
        {
            return View(db.ProductItems.ToList());
        }
        // GET: InvoiceID/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice Invoice = db.Invoice.Find(id);
            if (Invoice == null)
            {
                return HttpNotFound();
            }
            return View(Invoice);
        }

        // GET: InvoiceID/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceID/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,DateCreated,UserName,Total")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoice.Add(invoice);
                //Session["InvoiceIDID"] = InvoiceID.InvoiceIDID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: InvoiceID/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice Invoice = db.Invoice.Find(id);
            if (Invoice == null)
            {
                return HttpNotFound();
            }
            return View(Invoice);
        }

        // POST: InvoiceID/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,DateCreated,UserName,Total")] Invoice Invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Invoice);
        }

        // GET: InvoiceID/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice Invoice = db.Invoice.Find(id);
            if (Invoice == null)
            {
                return HttpNotFound();
            }
            return View(Invoice);
        }

        // POST: InvoiceID/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice Invoice = db.Invoice.Find(id);
            db.Invoice.Remove(Invoice);
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
