using BLL.reservas.bll;
using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReservaController : Controller
    {

        private ReservaViewModel reservaViewModel = new ReservaViewModel();
        private ReservasModelDb db = new ReservasModelDb();
        private static HotelService hotelService = new HotelService();
        // GET: Quartos/Index/1
       // public ActionResult Index() // Aqui é o id do hotel
        //{
            
        //}

       

        // No Post o valor selecionado do DropDownList}

        // será recebido no parametro clienteId

        public ActionResult Index()

        {

            //ViewBag.ReceberHotel = new SelectList(db.Hotel, "Id", "Nome");

            //ViewBag.ReceberQuarto = new SelectList(db.Quarto, "Id", "Descricao");
            var reserva = hotelService.listarReserva();
            return View(reserva);


        }
        
        public ActionResult Create()
        {
            
            Hotel hotel = db.Hotel.First();
           ViewBag.ReceberHotel = new SelectList(db.Hotel, "Id", "Nome");    


            ViewBag.ReceberQuarto = new SelectList(db.Quarto.Where(q => q.HotelId== hotel.Id).ToList(), "Id", "Descricao");

            // ViewBag.ReceberQuarto = new SelectList(db.Quarto.Where(prop=>prop.HotelId == prop.Id), "Id", "Descricao" );
            //LoadQuarto(hid);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {

            reserva.Quarto = hotelService.buscarQuartoPorId(reserva.QuartoId);

            try
            {
                var teste = hotelService.listarReserva().Last();
                reserva.Id = teste.Id + 1;

            }
            catch { }
            hotelService.incluiReserva(reserva);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BuscaQuartos(int id)
        {

            ViewBag.QuartoId = new SelectList(hotelService.ListarQuartosHotel(id), "Id", "Titulo");
            
            return View();
        }



        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }



        public void LoadHotel(ReservaViewModel reservaViewModel)
        {
            
            ViewBag.LoadH = new SelectList(hotelService.ListarHoteis(), "Nome").ToList();
            var tem = ViewBag.LoadH;            

        }

        public ActionResult LoadQuarto(int id) {



   //         List<Quarto> quartos = hotelService.ListarQuartosHotel(id);

           ViewBag.ReceberQuarto = new SelectList(db.Quarto.Where(prop => prop.HotelId == id).ToList(), "Id", "Descricao");


            return PartialView();
           /* else {
                ViewBag.Traga = new SelectList(achou, "Id", "Descricao");
                return View();
            }*/

           
        }

        //[HttpPost]
       // public ActionResult TestCarregar(ReservaViewModel reservaViewModel)
       // {
       //     LoadHotel(reservaViewModel);
       //     //LoadQuarto(reservaViewModel);

        //    return View(reservaViewModel);
       // }

    }
}