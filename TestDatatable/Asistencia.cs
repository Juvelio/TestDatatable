using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDatatable
{
    public class Asistencia
    {
        public string MASPE_CARNE { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public int Canal { get; set; }
    }
}