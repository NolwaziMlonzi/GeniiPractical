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
        public int? value;
        // GET: InvoiceID
        public ActionResult Index()
        {
                return View(db.Invoice.ToList());
            
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
        public ActionResult ItemCreate([Bind(Include = "ItemID,ItemName,CostPerItem,TotalCost,Invoice_Id")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.ProductItems.Add(productItem);
                db.SaveChanges();
                return RedirectToAction("Indexs");
            }
            UpdateTotalInvoice();
            return View(productItem);
        }
        public ActionResult UpdateTotalInvoice()
        {
           
            System.Diagnostics.Debug.WriteLine(Session["InvoiceID"] + "-----viewData--InvoiceID----------1" + Session["InvoiceTotal"]);
            return View();
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

        public ActionResult Test(int? id)
        {
            //InvoiceID item = db.InvoiceIDs.Find(id);
            
            Session["InvoiceID"] = id;
            value = id;
            return RedirectToAction("Indexs");
        }
        public ActionResult Indexs()
        {
            //UpdateTotalInvoice();
            var obj = db.ProductItems;
            value = Convert.ToInt16(Session["InvoiceID"]);
            //ProductItem item = db.ProductItems.Find(id);
            //var items = obj.Where(u => u.Invoice_Id.(Session["InvoiceID"]);
            //System.Diagnostics.Debug.WriteLine(Session["InvoiceID"] + "-------InvoiceID----------1" + value);
            var cart = (from n in db.ProductItems  where n.Invoice_Id == value select n).ToList();
            return View(cart);

        }
        //public ActionResult ItemIndexs()
        //{
        //    var obj = db.ProductItems;
        //    var items = obj.Where(u => u.Invoice_Id.Equals(Session["InvoiceID"])).FirstOrDefault();
        //    ProductItem item = db.Pr.Find(Session["InvoiceID"]);
        //    return View(item);
        //}
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
                return RedirectToAction("Indexs");
            }
            return View(productItem);
        }
        public ActionResult LogInvoice()
        {
            //UpdateTotalInvoice();
            var obj = db.Invoice;
            value = Convert.ToInt16(Session["InvoiceID"]);
            //ProductItem item = db.ProductItems.Find(id);
            //var items = obj.Where(u => u.Invoice_Id.(Session["InvoiceID"]);
            //System.Diagnostics.Debug.WriteLine(Session["InvoiceID"] + "-------InvoiceID----------1" + value);
            var cart = (from n in db.Invoice where n.InvoiceID == value select n).ToList();
            return View(cart);

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

        // GET: ProductItem/Delete/5
        public ActionResult ItemDelete(int? id)
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
        [HttpPost, ActionName("ItemDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult IDeleteConfirmed(int id)
        {
            ProductItem productItem = db.ProductItems.Find(id);
            db.ProductItems.Remove(productItem);
            db.SaveChanges();
            return RedirectToAction("Indexs");
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
