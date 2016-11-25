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
using System.Drawing;

namespace auction.Controllers
{
    public class UsersController : Controller
    {
        private auctionContext db = new auctionContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            var product = db.Products.Where(b => b.userID == id).ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            var tuple = new Tuple<User, List<Product>>(user, product);
            return View(tuple);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,username,FirstName,LastName,Email,Password,Dob,City,Address,Gender,MobileNo")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userID,username,FirstName,LastName,Email,Password,Dob,City,Address,Gender,MobileNo")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
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

        // POST: Users/Delete/5
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
        [HttpPost]
        public ActionResult img()
        {

            var userimg = "";
            var userPath = "";
            User profile = null;
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName));
                userimg = System.IO.Path.GetFileName(Request.Files[0].FileName);
                //imgname = Path.GetFileName(file);
                userPath = ("~/UploadedFiles/") + userimg;
            }
            if (Session["UserProfile"] != null)
            { 
                 profile = (User)Session["UserProfile"];
                User updateuser = db.Users.FirstOrDefault(b => b.userID == profile.userID);
                updateuser.userimgName = userimg;
                updateuser.userimgPath = userPath;
                db.SaveChanges();

            }
            //var image = Request.Form["updateimg"];


            return Redirect("Details/"+profile.userID);
          //  return View("Details/"+profile.userID);
        }

        [HttpPost]
        public ActionResult login(String email, String password)
         {
            String val1 = (Request.Form["email"]);
            String val2 = (Request.Form["password"]).ToString();

            try {
                var listitem = db.Users.FirstOrDefault(b => b.Email == val1 && b.Password == val2);

                Session["UserProfile"] = listitem;
                 
                    return Redirect("~/Home/Index");

                 
               // return View("logedin");
 
                 }
           catch(Exception e)
            { }

            return View();
            
        }



        public ActionResult logout()
        //public PartialViewResult logout()
        {
            if (Session["UserProfile"] != null)
                Session.Clear();
            
            // return new HttpStatusCodeResult(HttpStatusCode.OK);
            //return View("logedin");
             
            return Redirect("~/Home/Index");
        }




        public ActionResult signup()
        {
            var val1 = Request["username"];
            var val2 = Request["fname"];
            var val3 = Request["lname"];
            var val4 = Request["email"];
            var val5 = Request["password"];
            var val6 = Request["dob"];
            var val7 = Request["city"];
            var val8 = Request["address"];
            var val9 = Request["gender"];
            var val10 = Request["mobile"];



            auctionContext db = new auctionContext();
            db.Users.Add(new User() { username = val1, FirstName = val2, LastName = val3, Email = val4, Password = val5, Dob = val6, City = val7, Address = val8, Gender = val9, MobileNo = val10 });

            db.SaveChanges();
            return View();




        }
      //  [HttpPost]
        public ActionResult updateprofile()
        {
           


            var fname = Request["fname"];
            var lname = Request["lname"];
            var mobile = Request["mobile"];
            var email = Request["email"];
            var password = Request["password"];
            var address = Request["address"];
            var username = Request["username"];
            var j = Request["userid"];
            var userid = Convert.ToInt16(Request["userid"].ToString().Trim());

            User updateuser = db.Users.FirstOrDefault(b=>b.userID==userid);
            updateuser.FirstName = fname;
            updateuser.LastName = lname;
            updateuser.Password = password;
            updateuser.Email = email;
            updateuser.MobileNo = mobile;
            updateuser.Address = address;
            //updateuser.userimgName = userimg;
            //updateuser.userimgPath = userPath;
           // updateuser.username = username;
            db.SaveChanges();

            return View();

        }
        [HttpPost]
       public ActionResult updateimage()
        {

            var userimg = "";
            var userPath = "";
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName));
                userimg = System.IO.Path.GetFileName(Request.Files[0].FileName);
                //imgname = Path.GetFileName(file);
                userPath = ("~/UploadedFiles/") + userimg;
            }
            return View();
        }
    }
}
