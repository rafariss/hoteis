namespace Data.reservas.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            Quarto = new HashSet<Quarto>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(10, ErrorMessage="Nome de ter pelo menos 10 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        public int Numero { get; set; }

        [Required]
        [StringLength(20)]
        public string Complemento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cep { get; set; }
        [NotMapped]
        [Display(Name ="CEP")]
        [MaxLength(9, ErrorMessage = "CEP deve estar no formato 00000-000")]
        [RegularExpression(@"\d\d\d\d\d-\d\d\d", ErrorMessage = "CEP deve estar no formato 00000-000")]
        public string Cep2
        {
            get
            {
                return String.Format("{0:00000-000}", Cep);
            }
            set
            {
                // 99999-999
                string cep = value.Replace("-", "");
                // 99999999
                Cep = int.Parse(cep);
            }
        }

        [Required]
        [StringLength(60)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
        [Range(10, 99, ErrorMessage = "DDD deve ter 2 dígitos")]
        public decimal Ddd { get; set; }
         
        [Column(TypeName = "numeric")]
        [Range(0,99999999, ErrorMessage = "Telefone inválido")]
        [DisplayFormat(DataFormatString = "{0:#######0}")]
        public decimal Telefone { get; set; }

        [NotMapped]
        [Display(Name = "Telefone")]
        [MaxLength(10, ErrorMessage = "Telefone deve estar no formato 00000-0000")]
        [RegularExpression(@"9{0,1}\d\d\d\d-\d\d\d\d", ErrorMessage = "Telefone deve estar no formato 0000-0000 ou 90000-0000")]
        public string Telefone2
        {
            get
            {
                return String.Format("{0:#0000-0000}", Telefone);
            }
            set
            {
                // 99999-9999
                string telefone = value.Replace("-", "");
                // 999999999
                Telefone = int.Parse(telefone);
            }
        }

        [StringLength(250)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quarto> Quarto { get; set; }
    }
}
