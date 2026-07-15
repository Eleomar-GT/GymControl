using System;
using System.Collections.Generic;
using System.Text;

namespace GymControl
{
    internal class Membresia
    {
        // Atributos que coinciden con las columnas de tu base de datos
        public int ID_Membresia { get; set; }
        public string Tipo_Membresia { get; set; }
        public decimal Precio { get; set; }

        // Constructor vacío (útil para cuando mapeas datos)
        public Membresia() { }

        // Constructor para asignar valores rápidamente
        public Membresia(int id, string tipo, decimal precio)
        {
            ID_Membresia = id;
            Tipo_Membresia = tipo;
            Precio = precio;
        }

        // Sobrescribimos ToString para que el ComboBox muestre el nombre y el precio
        public override string ToString()
        {
            return $"{Tipo_Membresia} (${Precio})";
        }
    }
}
