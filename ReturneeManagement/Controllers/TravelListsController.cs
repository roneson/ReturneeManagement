using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReturneeManagement.Models;

namespace ReturneeManagement.Controllers
{
    [Authorize]
    public class TravelListsController : Controller
    {
        private ReturneeManagement_DBEntities db = new ReturneeManagement_DBEntities();

        // GET: TravelLists
        public async Task<ActionResult> Index()
        {
            return View(await db.TravelLists.ToListAsync());
        }

        // GET: TravelLists/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelList travelList = await db.TravelLists.FindAsync(id);
            if (travelList == null)
            {
                return HttpNotFound();
            }
            return View(travelList);
        }

        // GET: TravelLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TravelID,FlightVessel,FlightCode,ArrivalDate")] TravelList travelList)
        {
            if (ModelState.IsValid)
            {
                travelList.TravelID = Guid.NewGuid();
                db.TravelLists.Add(travelList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(travelList);
        }

        // GET: TravelLists/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelList travelList = await db.TravelLists.FindAsync(id);
            if (travelList == null)
            {
                return HttpNotFound();
            }
            return View(travelList);
        }

        // POST: TravelLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TravelID,FlightVessel,FlightCode,ArrivalDate")] TravelList travelList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(travelList);
        }

        // GET: TravelLists/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelList travelList = await db.TravelLists.FindAsync(id);
            if (travelList == null)
            {
                return HttpNotFound();
            }
            return View(travelList);
        }

        // POST: TravelLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TravelList travelList = await db.TravelLists.FindAsync(id);
            db.TravelLists.Remove(travelList);
            await db.SaveChangesAsync();
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
