using System;
using System.Collections.Generic;
using System.Text;

namespace GymControl
{
    internal class Miembro
    {
        // Propiedades de la clase Miembro
        public string IdMiembro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Membresia { get; set; } 
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaVencimiento { get; private set; }
        public bool StatusActivo { get; private set; }

        //asignar valores a las propiedades de la clase Miembro
        public Miembro(string idMiembro, string nombre, string apellido, string telefono, string membresia, int diasMembresiaInicial)
        {
            IdMiembro = idMiembro;
            Nombre = nombre;
            Apellido = apellido; 
            Telefono = telefono;
            Membresia = membresia;
            FechaRegistro = DateTime.Now;

            AsignarNuevosDias(diasMembresiaInicial);
        } 
        // Método para validar el estado de la membresía
        public void ValidarEstatus()
        {
            if (DateTime.Now.Date > FechaVencimiento.Date)
            {
                StatusActivo = false;
            }
            else
            {
                StatusActivo = true;
            }
        }
        // Método para renovar la membresía
        public void RenovarMembresia(int diasComprados)
        {
            if (StatusActivo)
            {
                FechaVencimiento = FechaVencimiento.AddDays(diasComprados);
            }
            else
            {
                FechaVencimiento = DateTime.Now.AddDays(diasComprados);
            }

            ValidarEstatus();
        } 
        // Método privado para asignar nuevos días a la membresía
        private void AsignarNuevosDias(int dias)
        {
            FechaVencimiento = DateTime.Now.AddDays(dias);
            ValidarEstatus();
        }
        // Método para escribir los datos de los miembros en un archivo de reporte
        public void EscribirSociosEnArchivo(StreamWriter writer)
        {
            foreach (var m in listaMiembros)
            {
                m.ValidarEstatus();
                string estatus = m.StatusActivo ? "ACTIVO" : "VENCIDO";
                string nombreCompleto = $"{m.Nombre} {m.Apellido}";

                writer.WriteLine(string.Format("{0,-8} {1,-25} {2,-15} {3,-12}", m.IdMiembro, nombreCompleto, m.Membresia, estatus));
            }
        }
    }
}

