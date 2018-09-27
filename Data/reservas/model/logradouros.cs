namespace Data.reservas.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class logradouros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int num_cep { get; set; }

        public int bairro_id { get; set; }

        [Required]
        [StringLength(45)]
        public string desc_logradouro { get; set; }

        [Required]
        [StringLength(10)]
        public string desc_tipo { get; set; }

        public virtual bairros bairros { get; set; }
    }
}
