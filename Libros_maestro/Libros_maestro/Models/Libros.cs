namespace Libros_maestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Libros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Libros()
        {
            DetallePrestamo = new HashSet<DetallePrestamo>();
        }

        [Key]
        public int id_libro { get; set; }

        [StringLength(100)]
        public string titulo { get; set; }

        [StringLength(10)]
        public string genero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; set; }
    }
}
