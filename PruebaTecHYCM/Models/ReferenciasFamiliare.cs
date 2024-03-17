using System;
using System.Collections.Generic;

namespace PruebaTecHYCM.Models
{
    public partial class ReferenciasFamiliare
    {
        public int Id { get; set; }
        public int? IdFiador { get; set; }
        public string? Nombre { get; set; }
        public string? Relacion { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        public virtual Fiador? IdFiadorNavigation { get; set; }
    }
}
