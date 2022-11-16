using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class RoomAcessControlsController : Controller
    {
        private HospitalManagementSystemEntities3 db = new HospitalManagementSystemEntities3();

        // GET: RoomAcessControls
        public ActionResult Index()
        {
            return View(db.RoomAcessControls.ToList());
        }

        // GET: RoomAcessControls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAcessControl roomAcessControl = db.RoomAcessControls.Find(id);
            if (roomAcessControl == null)
            {
                return HttpNotFound();
            }
            return View(roomAcessControl);
        }
        public ActionResult ShowSearchForm()
        {
            return View();
        }
        // Post: Employees ShowSearchResults
        public ActionResult ShowSearchResults(string SearchPhrase)
        {
            return View("Index", db.RoomAcessControls.Where(j => j.RoomAcessControl_id.Equals(SearchPhrase)).ToList());
        }

        // GET: RoomAcessControls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomAcessControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomAcessControl_id,Room_number,DateTime,Permission_status,Rfid_key,Room_name,Room_status")] RoomAcessControl roomAcessControl)
        {
            if (ModelState.IsValid)
            {
                db.RoomAcessControls.Add(roomAcessControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomAcessControl);
        }

        // GET: RoomAcessControls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAcessControl roomAcessControl = db.RoomAcessControls.Find(id);
            if (roomAcessControl == null)
            {
                return HttpNotFound();
            }
            return View(roomAcessControl);
        }

        // POST: RoomAcessControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomAcessControl_id,Room_number,DateTime,Permission_status,Rfid_key,Room_name,Room_status")] RoomAcessControl roomAcessControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomAcessControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomAcessControl);
        }

        // GET: RoomAcessControls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomAcessControl roomAcessControl = db.RoomAcessControls.Find(id);
            if (roomAcessControl == null)
            {
                return HttpNotFound();
            }
            return View(roomAcessControl);
        }

        // POST: RoomAcessControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomAcessControl roomAcessControl = db.RoomAcessControls.Find(id);
            db.RoomAcessControls.Remove(roomAcessControl);
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
