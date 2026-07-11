using conexionBD.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GymControl
{
    internal class CClientes
    {
        // Método para volver a ver los datos en tu DataGridView
        public void mostrarClientes(DataGridView tablaClientes)
        {
            Conexion objetoConexion = new Conexion();
            try
            {
                // Consulta SQL para obtener los datos de la tabla Clientes
                string query = "SELECT ID, Nombre, Apellido, Telefono, [Tipo de membresia], Estado, [Fecha de inicio], [Fecha de vencimiento] FROM Clientes;";
                using (SqlConnection conexionAbierta = objetoConexion.estableceConexion())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexionAbierta);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    tablaClientes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }

        // Método definitivo para registrar socios
        public void guardarCliente(TextBox txtNombre, TextBox txtApellido, TextBox txtTelefono, ComboBox cbMembresia)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtTelefono.Text) || cbMembresia.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, llena todos los campos.");
                return;
            }
            // Validar que el teléfono tenga 10 dígitos
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaVencimiento = DateTime.Now;
            string membresiaSeleccionada = cbMembresia.SelectedItem.ToString();

            // Calcular la fecha de vencimiento según el tipo de membresía
            if (membresiaSeleccionada == "Semanal") fechaVencimiento = fechaInicio.AddDays(7);
            else if (membresiaSeleccionada == "Mensual") fechaVencimiento = fechaInicio.AddMonths(1);
            else if (membresiaSeleccionada == "Anual") fechaVencimiento = fechaInicio.AddYears(1);

            // Validar el estado del socio (Activo o Inactivo) según la fecha de vencimiento
            string estado = "Activo";
            Conexion objetoConexion = new Conexion();

            // Insertar los datos en la base de dato
            string query = "INSERT INTO Clientes (Nombre, Apellido, Telefono, [Tipo de membresia], Estado, [Fecha de inicio], [Fecha de vencimiento]) " +
                           "VALUES (@Nombre, @Apellido, @Telefono, @T_Membresia, @Estado, @f_inicio, @f_vencimiento);";

            try
            {
                // Abrir la conexión y ejecutar el comando SQL
                using (SqlConnection conexionAbierta = objetoConexion.estableceConexion())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexionAbierta))
                    {
                        comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        comando.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        comando.Parameters.AddWithValue("@T_Membresia", membresiaSeleccionada);
                        comando.Parameters.AddWithValue("@Estado", estado);
                        comando.Parameters.AddWithValue("@f_inicio", fechaInicio.Date);
                        comando.Parameters.AddWithValue("@f_vencimiento", fechaVencimiento.Date);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Socio registrado con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar socio: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarConexion();
            }
        }
    }
}