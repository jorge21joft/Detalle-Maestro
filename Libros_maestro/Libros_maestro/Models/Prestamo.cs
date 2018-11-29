namespace Libros_maestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prestamo")]
    public partial class Prestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prestamo()
        {
            DetallePrestamo = new HashSet<DetallePrestamo>();
        }

        [Key]
        public int id_prestamo { get; set; }

        [DataType (DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? fecha_prestamo { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? fecha_devolucion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePrestamo> DetallePrestamo { get; set; }
    }
}
