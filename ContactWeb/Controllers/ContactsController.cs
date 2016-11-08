using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactWeb.Models;
using Microsoft.AspNet.Identity;

// the code runs anytime we make request to the application
// The following are GET requests


namespace ContactWeb.Controllers
{
    public class ContactsController : Controller
    {
        private ContactWebContext db = new ContactWebContext();


        /* Addng authentication to the Application
           This means we can't see , edit or delete any contact info
           unless we are logged in as an authenticated user.

           NOTE : Authentication for every view :
           1.Contact
           2.Create
           3.Edit
           4.Details
           5.Delete


         */


        // GET: Contacts
        [Authorize]  // Ensures user needs to be logged in to do anything with the contact data
        public ActionResult Index()
        {

            var userId = GetCurrentUserId(); 
            return View(db.Contacts.Where(x => x.UserId == userId ).ToList()); 
        }

        // GET: Contacts/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Essentially will intialise the local connection the database
            }                                                               // Retrieves contacts from the list and throws them into the view in oder to be used and rendered on the page
            Contact contact = db.Contacts.Find(id);
            if (contact == null || !EnsureIsUserContact(contact)) // Prevents user from looking into someone else details 
            { 
                return HttpNotFound(); 
            }
            return View(contact); 
        }

        // GET: Contacts/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserId = GetCurrentUserId();
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "id,UserId,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birthday,StreetAddress1,StreetAddress2,City,County,PostCode")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = GetCurrentUserId();
            return View(contact);    
        } 

        // GET: Contacts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null || !EnsureIsUserContact(contact))  // if contact is null OR contact is NOT my contact then it will return "not found" 
            {
                return HttpNotFound();
            }
             
            ViewBag.UserId = GetCurrentUserId();
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "id,UserId,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birthday,StreetAddress1,StreetAddress2,City,County,PostCode")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = GetCurrentUserId();
            return View(contact);  
        } 

        // GET: Contacts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null || !EnsureIsUserContact(contact))
            {
                return HttpNotFound();
            }
            return View(contact);
        } 

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (!EnsureIsUserContact(contact))
            {
                return HttpNotFound();  // if its not your user contact , then it will prevent user from deleting it !
                 
            }
            db.Contacts.Remove(contact);
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

        public Guid GetCurrentUserId()
        {
            return new Guid(User.Identity.GetUserId());
        }

        private bool EnsureIsUserContact(Contact contact) //Determines whether this contact is one that I have created (the user id on the contact has to match mine )
        {
            return contact.UserId == GetCurrentUserId();
        }

    }
}
