using System;
using System.Collections.Generic;
using System.Text;

namespace GymControl
{
    internal class Miembro
    {
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoMembresia { get; set; } 
        public bool Activo { get; set; }

        public Miembro() { }

        // Constructor para registrar un socio nuevo (calcula fechas automáticamente)
        public Miembro(string nombre, string apellido, string telefono, string email, string tipoMembresia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            TipoMembresia = tipoMembresia;
            FechaInscripcion = DateTime.Now;
            FechaVencimiento = CalcularVencimiento(tipoMembresia, FechaInscripcion);
            Activo = true;
        }

        public static DateTime CalcularVencimiento(string tipoMembresia, DateTime desde)
        {
            switch (tipoMembresia)
            {
                case "Mensual":
                    return desde.AddMonths(1);
                case "Trimestral":
                    return desde.AddMonths(3);
                case "Anual":
                    return desde.AddYears(1);
                default:
                    return desde.AddMonths(1);
            }
        }

        public override string ToString()
        {
            return $"{IdSocio} - {Nombre} {Apellido} - {TipoMembresia} - Vence: {FechaVencimiento:dd/MM/yyyy}";
        }

    }
}

