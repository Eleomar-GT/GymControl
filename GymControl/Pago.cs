using System;
using System.Collections.Generic;
using System.Text;

namespace GymControl
{
    internal class Pago
    {
        public int Id { get; set; }
        public string NombreSocio { get; set; }
        public string Concepto { get; set; }      
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }
    }
}
