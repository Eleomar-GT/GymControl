using System;

namespace GymControl
{
    internal class Miembro
    {
        // 1. Propiedades exactas a la Base de Datos
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; } // Qué bueno que lo pusiste string aquí, ya machea con el VARCHAR de la BD
        public string TipoMembresia { get; set; }
        public string Estado { get; set; } // Cambiado de bool a string ("Activo")
        public DateTime FechaInscripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Miembro() { }

        // 2. Constructor adaptado
        public Miembro(string nombre, string apellido, string telefono, string tipoMembresia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            TipoMembresia = tipoMembresia;
            FechaInscripcion = DateTime.Now;
            FechaVencimiento = CalcularVencimiento(tipoMembresia, FechaInscripcion);
            Estado = "Activo"; // Estado inicial por defecto
        }

        // 3. Tus plazos actualizados igual que en CClientes
        public static DateTime CalcularVencimiento(string tipoMembresia, DateTime desde)
        {
            switch (tipoMembresia)
            {
                case "Semanal":
                    return desde.AddDays(7);
                case "Mensual":
                    return desde.AddMonths(1);
                case "Anual":
                    return desde.AddYears(1);
                default:
                    return desde.AddMonths(1);
            }
        }

        public override string ToString()
        {
            return $"{IdSocio} - {Nombre} {Apellido} - {TipoMembresia} - Estado: {Estado} - Vence: {FechaVencimiento:dd/MM/yyyy}";
        }
    }
}