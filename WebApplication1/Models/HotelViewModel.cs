using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HotelViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(10, ErrorMessage = "Nome de ter pelo menos 10 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        public int Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string Complemento { get; set; }

        [RegularExpression(@"\d\d\d\d\d-\d\d\d", ErrorMessage="CEP inválido")]
        public string Cep { get; set; }
        [Required]
        [StringLength(60)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [Required]
        [StringLength(2)]
        public decimal Ddd { get; set; }

        public decimal Telefone { get; set; }

        [StringLength(250)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}