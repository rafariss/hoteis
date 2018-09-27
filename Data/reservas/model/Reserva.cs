namespace Data.reservas.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reserva")]
    public partial class Reserva
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }

       

        public int TuristaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Chegada { get; set; }

        [Column(TypeName = "date")]
        public DateTime Partida { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValorDiaria { get; set; }

        public int QuartoId { get; set; }

        public virtual Quarto Quarto { get; set; }
    }
}
