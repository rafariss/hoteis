using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.reservas.dal
{
    public class QuartoDAO
    {
        public List<Quarto> ListarPorHotel(int idHotel)
        {
            using (var ctx = new ReservasModelDb())
            {
                return ctx.Quarto.Where(q => q.Hotel.Id == idHotel).Include(q => q.Hotel).ToList();
            }
        }

        public Quarto buscarPorId(int id)
        {
            using (var db = new ReservasModelDb())
            {
                return db.Quarto.Where(
                    q => q.Id == id
                    )
                    .First();
            }
        }


    }
}
