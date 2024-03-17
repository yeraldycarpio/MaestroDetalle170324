using System;
using System.Collections.Generic;

namespace PruebaTecHYCM.Models
{
    public partial class Fiador
    {
        public Fiador()
        {
            ReferenciasFamiliares = new HashSet<ReferenciasFamiliare>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Ocupacion { get; set; }
        public decimal? IngresoMensual { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual ICollection<ReferenciasFamiliare> ReferenciasFamiliares { get; set; }
    }
}
