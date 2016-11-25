using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using auction.Models;
using System.IO;

namespace auction.Controllers
{
    public class ProductsController : Controller
    {
       
        private auctionContext db = new auctionContext();

        // GET: Products
         
        public ActionResult Index()
        {
           // var products = db.Products.Include(p => p.Category).Include(p => p.Product_Auction).Include(p => p.User);
            var prod = db.Products.Include(path => path.Category).Include(p => p.User).Include(p => p.Product_Auction);
            var files = Directory.GetFiles(Server.MapPath("~/UploadedFiles"));

            
            var category = db.Categories.ToList();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach(var item in category)
            {
                items.Add(
                           new SelectListItem
                           {
                               Text = item.Name,
                               Value = item.categoryid.ToString()
                    

                               }
                         );
            }


            //    var tuple = new Tuple<List<Product>,List<Category>>(prod.ToList(),category);
            ViewBag.CategoryID = items;
            var tuple = new Tuple<List<Product>, List<SelectListItem>>(prod.ToList(), items);
           
            return View(tuple);
           // return View(prod.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            //  var bids = db.Bids.Include(b => b.Auction).Include(b => b.User).Where(b => b.Auction_ID == id).ToList();
            var prodid = db.Products.Where(b=> b.ID == id).First();
            var auctionid = db.Auctions.Where(b => b.PA_ID == prodid.PA_ID).First();


          var counter = db.Auctions.Where(b => b.Auction_ID == auctionid.Auction_ID).First();
          var bids = db.Bids.Where(b => b.Auction.Auction_ID == auctionid.Auction_ID).ToList();
            if (product == null)
            {
                return HttpNotFound();
            }
             var tuple = new Tuple<Product, List<Bid>,Auction>(product, bids,counter);
            

            return View(tuple);
        }

        // GET: Products/Create
         
        public ActionResult Create()
        {
            ViewBag.categoryid = new SelectList(db.Categories, "categoryid", "Name");
            ViewBag.PA_ID = new SelectList(db.Product_Auction, "PA_ID", "PA_ID");
            ViewBag.userID = new SelectList(db.Users, "userID", "username");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create( Product product)
        {
            //if (ModelState.IsValid)
            //{
            //    //db.Products.Add(product);
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            ViewBag.categoryid = new SelectList(db.Categories, "categoryid", "Name", product.categoryid);
            ViewBag.PA_ID = new SelectList(db.Product_Auction, "PA_ID", "PA_ID", product.PA_ID);
            ViewBag.userID = new SelectList(db.Users, "userID", "username", product.userID);
            return View(product);
        }

        // GET: Products/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryid = new SelectList(db.Categories, "categoryid", "Name", product.categoryid);
            ViewBag.PA_ID = new SelectList(db.Product_Auction, "PA_ID", "PA_ID", product.PA_ID);
            ViewBag.userID = new SelectList(db.Users, "userID", "username", product.userID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,status,Publisheddate,Discription,Price,categoryid,userID,PA_ID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryid = new SelectList(db.Categories, "categoryid", "Name", product.categoryid);
            ViewBag.PA_ID = new SelectList(db.Product_Auction, "PA_ID", "PA_ID", product.PA_ID);
            ViewBag.userID = new SelectList(db.Users, "userID", "username", product.userID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        //public ActionResult Bids(decimal bidname)
        //{
        //    int user = 1;
        //    auctionContext db = new auctionContext();
        //    db.Bids.Add(new Bid() { Auction_ID = id, userID = user, Price = bidname });

        //    db.SaveChanges();

        //    return View();

        //}

        public void makebid(int id, decimal price, int userid)
        {
            
        }

        //public static void addbidinview(int id, decimal price, int userid)
        //{


        //    auctionContext db = new auctionContext();
        //    db.Bids.Add(new Bid() { Auction_ID = id, userID = userid, Price = price });

        //    db.SaveChanges();

        //}
        public ActionResult addbidinview()
        {

            auctionContext db = new auctionContext();
            int val1 = int.Parse(Request["val1"]);
            var auctionid=db.Auctions.FirstOrDefault(b=>b.PA_ID==val1);
            double val2 = double.Parse(Request["val2"]);
            
            
            if (Session["UserProfile"] != null)
            {
                var profile = (auction.Models.User)Session["UserProfile"];
                var j = profile.userID;
                int val3 = Convert.ToInt16(j.ToString().Trim());
                //int val3 = profile.userID;
                //int.Parse(Request["val3"]);
                // db.Bids.Add(new Bid() { Auction_ID = (int)val1, userID = (int)val3, Price = (decimal)val2 });
                db.Bids.Add(new Bid() { Auction_ID =  auctionid.Auction_ID, userID =  val3, Price = (decimal)val2 });
                db.SaveChanges();
            }

            

           
            return View("UpdateBid");
            
            //else
                
            //    return RedirectToAction("Index");
        }


        public void updateprofile()
        {


        }


        public ActionResult additem()
        {


            //IEnumerable<SelectListItem> items = db.Categories
            //  .Select(c => new SelectListItem
            //  {
            //      Value = c.categoryid.ToString(),
            //      Text = c.Name
            //  });
            //ViewBag.CategoryID = items;
            var category = db.Categories.ToList();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in category)
            {
                items.Add(
                           new SelectListItem
                           {
                               Text = item.Name,
                               Value = item.categoryid.ToString()


                           }
                         );
            }


            //    var tuple = new Tuple<List<Product>,List<Category>>(prod.ToList(),category);
            ViewBag.CategoryID = items;

            return View();
        }

        [HttpPost]
        public ActionResult addproduct(HttpPostedFileBase upload)
        {

            var imgname="";
            var imgPath = "";
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName));

                imgname = System.IO.Path.GetFileName(Request.Files[0].FileName);
                //   imgname = Path.GetFileName(file);
                imgPath = ("~/UploadedFiles/") + imgname;
            }
              
            var add_pa = new Product_Auction();
            db.Product_Auction.Add(add_pa);
            db.SaveChanges();


            var title = Request["productname"]; 
            var qu = Request["productname"];
            var status = Request["status"];
            var published = System.DateTime.Now;
            var disc = Request["disc"];
            var price =Convert.ToDecimal( Request["price"]);
            var value = Request["CategoryID"];
            var catid =Convert.ToInt16(value);
            int uid = 0;
            //  //int.Parse(Request["catid"]);
          //  int uid = Request["userid12"];
          // var userid =Convert.ToInt16(Request["userid12"].ToString().Trim());
            if (Session["UserProfile"] != null)
            {
                var profile = (auction.Models.User)Session["UserProfile"];

              uid= Convert.ToInt16(profile.userID.ToString().Trim());
                           
                             
                           }

            Product prod = new Product { Title = title, status = status, Publisheddate = published, Discription = disc, Price = price, categoryid = catid, userID = uid, PA_ID = add_pa.PA_ID, Path = imgPath, Name = imgname };
    db.Products.Add(prod);
           db.SaveChanges();


            DateTime stime = Convert.ToDateTime(Request["stime"].ToString());
            DateTime etime = Convert.ToDateTime(Request["etime"].ToString().Trim());
            //Convert.ToDateTime(Request["etime"].ToString().Trim());
            //          //DateTime.Parse(Request["etime"]);
            db.Auctions.Add(new Auction { Auction_Strat = stime, Auction_End = etime,PA_ID=add_pa.PA_ID,winning_amount=5000 });
      //      db.Auctions.Add(new Auction { Auction_Strat = stime, Auction_End = etime, PA_ID = add_pa.PA_ID, winning_amount =(double) price});
            db.SaveChanges();
            //  return View("Products");
            return Redirect("~/Products/Details/"+prod.ID);
        }


        [HttpPost]
        public void Upload()  //Here just store 'Image' in a folder in Project Directory 
                              //  name 'UplodedFiles'
        {
           
           
        }

        public ActionResult showdata()
        {
            var id =Convert.ToInt16( Request["id"]);
            List<Product> prod = null;
            if (id == 1)
            {
                prod = db.Products.ToList();
                return View("updatedProduct", prod);
            }
             

                prod = db.Products.Where(b => b.categoryid == id).ToList();
            
                  return View( "updatedProduct",prod);

        }

    }
}
