using Data.reservas.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ReservaViewModel
    {
        public int Id { get; set; }

        public virtual Hotel hotel { get; set; }    

        public DateTime DataReserva { get; set; }

        public int TuristaId { get; set; }

        public DateTime Chegada { get; set; }

        
        public DateTime Partida { get; set; }

        
        public decimal? ValorDiaria { get; set; }

        public int QuartoId { get; set; }

        public virtual Quarto Quarto { get; set; }





    }
}