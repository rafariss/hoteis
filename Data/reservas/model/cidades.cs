namespace Data.reservas.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cidades()
        {
            bairros = new HashSet<bairros>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cidade_id { get; set; }

        [Required]
        [StringLength(60)]
        public string desc_cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string flg_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bairros> bairros { get; set; }

        public virtual ufs ufs { get; set; }
    }
}
