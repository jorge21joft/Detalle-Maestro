namespace Libros_maestro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallePrestamo")]
    public partial class DetallePrestamo
    {
        [Key]
        public int id_detalle { get; set; }

        public int? cantidad { get; set; }

        public int? prestamo_id { get; set; }

        public int? libro_id { get; set; }

        public virtual Libros Libros { get; set; }

        public virtual Prestamo Prestamo { get; set; }
    }
}
