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
    public class IndividualsController : Controller
    {
        private ReturneeManagement_DBEntities db = new ReturneeManagement_DBEntities();

        // GET: Individuals
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var individuals = db.Individuals.Include(i => i.IndiVidual_Address1);
            return View(await individuals.ToListAsync());
        }

        // GET: Individuals/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = await db.Individuals.FindAsync(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            return View(individual);
        }

        // GET: Individuals/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.IndiVidual_Address, "AddressID", "Type");
            return View();
        }

        // POST: Individuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IndividualID,LastName,FirstName,MiddleName,BirthDate,Gender,CivilStatus,Occupation,Religion,TelepnoeNo,MobileNo,AddressID")] Individual individual)
        {
            if (ModelState.IsValid)
            {
                individual.IndividualID = Guid.NewGuid();
                db.Individuals.Add(individual);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.IndiVidual_Address, "AddressID", "Type", individual.AddressID);
            return View(individual);
        }

        // GET: Individuals/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = await db.Individuals.FindAsync(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.IndiVidual_Address, "AddressID", "Type", individual.AddressID);
            return View(individual);
        }

        // POST: Individuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IndividualID,LastName,FirstName,MiddleName,BirthDate,Gender,CivilStatus,Occupation,Religion,TelepnoeNo,MobileNo,AddressID")] Individual individual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.IndiVidual_Address, "AddressID", "Type", individual.AddressID);
            return View(individual);
        }

        // GET: Individuals/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Individual individual = await db.Individuals.FindAsync(id);
            if (individual == null)
            {
                return HttpNotFound();
            }
            return View(individual);
        }

        // POST: Individuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Individual individual = await db.Individuals.FindAsync(id);
            db.Individuals.Remove(individual);
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
