using BLL.reservas.bll;
using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HotelController : Controller
    {
        static HotelService hotelService = new HotelService();
        // GET: Hotel/Index ou Hotel
        public ActionResult Index()
        {
            return View(hotelService.ListarHoteis());
        }
        // GET: Hotel/Incluir
        public ActionResult Incluir()
        {
            List<ufs> ufs = hotelService.ListarUfs();
            SelectList lista = new SelectList(ufs, "uf_id", "desc_uf", "");
            ViewBag.Ufs = lista;
            return View();
        }
        // POST: Hotel/Incluir
        [HttpPost]
        public ActionResult Incluir(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                List<ufs> ufs = hotelService.ListarUfs();
                SelectList lista = new SelectList(ufs, "uf_id", "desc_uf", "");
                ViewBag.Ufs = lista;
                return View(hotel);
            }
            else
            {
                hotelService.IncluirHotel(hotel);
                return RedirectToAction("Index");
            }
        }
        // GET /Hotel/Detalhar?id=0
        public ActionResult Detalhar(int id)
        {
            Hotel hotel = hotelService.DetalharHotel(id);
            return View(hotel);
        }
        // GET /Hotel/Alterar?id=0
        public ActionResult Alterar(int id)
        {
            Hotel hotel = hotelService.DetalharHotel(id);
            return View(hotel);
        }
        // POST /Hotel/Alterar?id=0
        [HttpPost]
        public ActionResult Alterar(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelService.AlterarHotel(hotel);

                return RedirectToAction("Index");
            }
            return View(hotel);
        }
        // GET /Hotel/Excluir/0
        public ActionResult Excluir(int id)
        {
            Hotel hotel = hotelService.DetalharHotel(id);
            return View(hotel);
        }
        // POST /Hotel/Excluir/0
        [HttpPost]
        [ActionName("Excluir")]
        public ActionResult EfetivarExcluir(int id)
        {
            hotelService.ExcluirHotel(id);
            return RedirectToAction("Index");
        }
    }
}