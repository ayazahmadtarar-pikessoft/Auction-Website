using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using auction.Models;

namespace auction.Controllers
{
    public class Product_AuctionController : Controller
    {
        private auctionContext db = new auctionContext();

        // GET: Product_Auction
        public ActionResult Index()
        {
            return View(db.Product_Auction.ToList());
        }

        // GET: Product_Auction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Auction product_Auction = db.Product_Auction.Find(id);
            if (product_Auction == null)
            {
                return HttpNotFound();
            }
            return View(product_Auction);
        }

        // GET: Product_Auction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_Auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PA_ID")] Product_Auction product_Auction)
        {
            if (ModelState.IsValid)
            {
                db.Product_Auction.Add(product_Auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Auction);
        }

        // GET: Product_Auction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Auction product_Auction = db.Product_Auction.Find(id);
            if (product_Auction == null)
            {
                return HttpNotFound();
            }
            return View(product_Auction);
        }

        // POST: Product_Auction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PA_ID")] Product_Auction product_Auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Auction);
        }

        // GET: Product_Auction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Auction product_Auction = db.Product_Auction.Find(id);
            if (product_Auction == null)
            {
                return HttpNotFound();
            }
            return View(product_Auction);
        }

        // POST: Product_Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Auction product_Auction = db.Product_Auction.Find(id);
            db.Product_Auction.Remove(product_Auction);
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
