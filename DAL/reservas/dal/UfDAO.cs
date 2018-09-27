using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.reservas.dal
{
    public class UfDAO
    {
        public List<ufs> ListarTodos()
        {
            using (var db = new ReservasModelDb())
            {
                return db.ufs.ToList();
            }
        }
    }
}
