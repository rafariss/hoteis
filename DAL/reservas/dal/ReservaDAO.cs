using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReservaDAO
    {
        public List<Hotel> obterHotel()
        {
            using (var ctx = new ReservasModelDb())
            {
                return ctx.Hotel.ToList();

            }

        }

        public List<Quarto> ListarPorHotel(int idHotel)
        {
            using (var ctx = new ReservasModelDb())
            {

                
                return ctx.Quarto.Where(q => q.Hotel.Id == idHotel).Include(q => q.Hotel).ToList();
            }
        }

        public List<Reserva> listaReserva()
        {
            using (var ctx = new ReservasModelDb())
            {
                return ctx.Reserva.Include(r=>r.Quarto).ToList();

            }
        }

        public void Incluir(Reserva reserva)
        {
            using (var db = new ReservasModelDb())
            {
                db.Reserva.Add(reserva);
                db.SaveChanges();
            }
        }



    }
}
