using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_OC.Models;

namespace MVC_OC.Controllers
{
    public class OCModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OCModel
        public async Task<ActionResult> Index()
        {
            return View(await db.OCs.ToListAsync());
        }

        // GET: OCModel/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCModels oCModels = await db.OCs.FindAsync(id);
            if (oCModels == null)
            {
                return HttpNotFound();
            }
            return View(oCModels);
        }

        // GET: OCModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OCModel/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OC_ID,Name,Descripton,CarModel")] OCModels oCModels)
        {
            if (ModelState.IsValid)
            {
                db.OCs.Add(oCModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oCModels);
        }

        // GET: OCModel/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCModels oCModels = await db.OCs.FindAsync(id);
            if (oCModels == null)
            {
                return HttpNotFound();
            }
            return View(oCModels);
        }

        // POST: OCModel/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OC_ID,Name,Descripton,CarModel")] OCModels oCModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oCModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oCModels);
        }

        // GET: OCModel/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OCModels oCModels = await db.OCs.FindAsync(id);
            if (oCModels == null)
            {
                return HttpNotFound();
            }
            return View(oCModels);
        }

        // POST: OCModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            OCModels oCModels = await db.OCs.FindAsync(id);
            db.OCs.Remove(oCModels);
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
