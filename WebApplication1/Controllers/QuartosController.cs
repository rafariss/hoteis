using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL.reservas.bll;
using Data.reservas.model;

namespace WebApplication1.Controllers
{
    public class QuartosController : Controller
    {
        private ReservasModelDb db = new ReservasModelDb();
        private static HotelService hotelService = new HotelService();
        // GET: Quartos/Index/1
        public ActionResult Index(int id) // Aqui é o id do hotel
        {
            List<Quarto> quartos = hotelService.ListarQuartosHotel(id);
            return View(quartos);
        }

        // GET: Quartos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // GET: Quartos/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(db.Hotel, "Id", "Nome");
            return View();
        }

        // POST: Quartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HotelId,Titulo,Descricao,Quantidade,MaximoOcupantes,ValorDiaria,ValorDiariaCrianca,DiariaPorOcupante")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Quarto.Add(quarto);
                db.SaveChanges();
                // /Quartos/Index/111
                return RedirectToAction("Index", new { Id = quarto.HotelId });
            }

            ViewBag.HotelId = new SelectList(db.Hotel, "Id", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hotel, "Id", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HotelId,Titulo,Descricao,Quantidade,MaximoOcupantes,ValorDiaria,ValorDiariaCrianca,DiariaPorOcupante")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                db.SaveChanges();
                // /Quartos/Index/111
                return RedirectToAction("Index", new { Id = quarto.HotelId });
            }
            ViewBag.HotelId = new SelectList(db.Hotel, "Id", "Nome", quarto.HotelId);
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quarto quarto = db.Quarto.Find(id);
            if (quarto == null)
            {
                return HttpNotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quarto quarto = db.Quarto.Find(id);
            db.Quarto.Remove(quarto);
            db.SaveChanges();
            // /Quartos/Index/111
            return RedirectToAction("Index", new { Id = quarto.HotelId });
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
