using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using point_of_sales.Models;

namespace pointOfSales.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            #region ViewData
            List<SelectListItem> UserRoles = new List<SelectListItem>()
            {
                new SelectListItem {
                    Text = "Administrator", Value = "Admin"
                },
                new SelectListItem {
                    Text = "End User", Value = "User"
                },
                new SelectListItem {
                    Text = "Manager", Value = "Manager"
                }
            };
            ViewData["UserRole"] = UserRoles;
            #endregion
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,FirstName,LastName,EmailAddress,Password,Re_typePassword,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            #region ViewData
            List<SelectListItem> UserRoles = new List<SelectListItem>()
            {
                new SelectListItem {
                    Text = "Administrator", Value = "Admin"
                },
                new SelectListItem {
                    Text = "End User", Value = "User"
                },
                new SelectListItem {
                    Text = "Manager", Value = "Manager"
                }
            };
            ViewData["UserRole"] = UserRoles;
            #endregion
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,FirstName,LastName,EmailAddress,Password,Re_typePassword,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Login()
        {
            #region ViewData
            List<SelectListItem> UserRoles = new List<SelectListItem>()

            {
                new SelectListItem {
                    Text = "Administrator", Value = "Admin"
                },
                new SelectListItem {
                    Text = "End User", Value = "User"
                },
                new SelectListItem {
                    Text = "Manager", Value = "Manager"
                }
            };
            ViewData["UserRole"] = UserRoles;
            #endregion
            return View();
        }
        //login
        [HttpPost]
        public ActionResult Login( User user)
        {
            if (ModelState.IsValid)
            {
                var obj = db.Users;
                var LoggedUser = obj.Where(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password) && u.Role.Equals(user.Role)).FirstOrDefault();
                if (LoggedUser != null)
                {
                    Session["UserID"] = LoggedUser.UserID.ToString();
                    Session["UserName"] = LoggedUser.UserName.ToString();
                    Session["FirstName"] = LoggedUser.FirstName.ToString();
                    Session["LastName"] = LoggedUser.LastName.ToString();
                    Session["Role"] = LoggedUser.Role;
                    return RedirectToAction("LoggedIn");
                }

              
            }
            #region ViewData
            List<SelectListItem> UserRoles = new List<SelectListItem>()
            {
                new SelectListItem {
                    Text = "Administrator", Value = "Admin"
                },
                new SelectListItem {
                    Text = "End User", Value = "User"
                },
                new SelectListItem {
                    Text = "Manager", Value = "Manager"
                }
            };
            ViewData["UserRole"] = UserRoles;
            #endregion
            return View(user);
        }
        public ActionResult LoggedIn()
        {
            //System.Diagnostics.Debug.WriteLine(user, "Hello World----------------------------------------------------------------------------------------------");
            //Console.Write("-------", db.Users.ToList());
            System.Diagnostics.Debug.WriteLine(Session["UserID"],"-----------------1");
            var count = db.ProductItems.Count();
            ViewBag.TotalSold = count;
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
