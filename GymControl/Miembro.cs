using conexionBD.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms; // Necesario para los MessageBox

namespace GymControl
{
    internal class Miembro
    {
        // Propiedades exactas a la Base de Datos
        public int IdSocio { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string TipoMembresia { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        // Constructor vacío
        public Miembro() { }

        // Constructor adaptado
        public Miembro(string nombre, string apellido, string telefono, string tipoMembresia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            TipoMembresia = tipoMembresia;
            FechaInscripcion = DateTime.Now;
            FechaVencimiento = CalcularVencimiento(tipoMembresia, FechaInscripcion);
            Estado = "Activo";
        }

        // Plazos actualizados para los vencimientos
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

        // Método para eliminar un cliente de la base de datos
        public void eliminarCliente(string idSocio)
        {
            if (string.IsNullOrEmpty(idSocio))
            {
                MessageBox.Show("Por favor, selecciona un registro válido para eliminar.");
                return;
            }

            Conexion conex = new Conexion();
            string query = "DELETE FROM Clientes WHERE ID_Cliente = @id;";

            try
            {
                // 1. Obtenemos el objeto de conexión desde tu clase
                SqlConnection con = conex.estableceConexion();

                // 2. CORRECCIÓN: Si la conexión viene cerrada, la abrimos explícitamente
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand miConsulta = new SqlCommand(query, con))
                {
                    miConsulta.Parameters.AddWithValue("@id", idSocio);

                    miConsulta.ExecuteNonQuery();
                    MessageBox.Show("El socio se ELIMINÓ CORRECTAMENTE.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logró ELIMINAR el socio. Error: " + ex.Message);
            }
            finally
            {
                conex.cerrarConexion(); // Cierra la conexión de manera segura
            }
        }
    }
}