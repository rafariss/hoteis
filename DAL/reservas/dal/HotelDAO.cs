using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.reservas.dal
{
    public class HotelDAO
    {
        public List<Hotel> ListarTodos()
        {
            using(var db = new ReservasModelDb())
            {
                return db.Hotel.ToList();
            }
        }
        public void Incluir(Hotel hotel)
        {
            using (var db = new ReservasModelDb())
            {
                db.Hotel.Add(hotel);
                db.SaveChanges();
            }
        }
        public void Alterar(Hotel hotel)
        {
            using (var db = new ReservasModelDb())
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Hotel Detalhar(int id)
        {
            using (var db = new ReservasModelDb())
            {
                return db.Hotel.Where(h => h.Id == id).Include(h => h.Quarto).First();
                //return db.Hotel.Find(id);
            }
        }
        public void Excluir(int id)
        {
            using (var db = new ReservasModelDb())
            {
                Hotel hotel = new Hotel { Id = id };
                db.Entry(hotel).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
