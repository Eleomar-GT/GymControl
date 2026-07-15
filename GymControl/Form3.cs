using conexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymControl
{
    public partial class Form3 : Form
    {
        // Tu cadena de conexión unificada apuntando a la base de datos 'Prueba'
        private readonly string conexionString = "Server=.\\SQLEXPRESS; Database=clientes_GC; Integrated Security=True;";
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual y abrir Form2
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // --- VALIDACIÓN DE SEGURIDAD CORREGIDA ---
            // Validamos que el ComboBox tenga texto seleccionado y que no sea el índice vacío (-1)
            if (cmbMembresia.SelectedIndex == -1 || string.IsNullOrEmpty(cmbMembresia.Text))
            {
                MessageBox.Show("Por favor, selecciona un tipo de membresía de la lista.");
                return;
            }

            // Obtenemos de forma segura el ID de la membresía y su texto
            int idMembresia = 1; // Valor por defecto (Mensual)
            string tipoMembresiaTexto = cmbMembresia.Text.ToLower();

            // Si logramos obtener el SelectedValue lo usamos, si no, lo calculamos por el texto seleccionado
            if (cmbMembresia.SelectedValue != null && int.TryParse(cmbMembresia.SelectedValue.ToString(), out int idResultado))
            {
                idMembresia = idResultado;
            }
            else
            {
                // Si por alguna razón de enlace da null, le asignamos el ID según el plan seleccionado en pantalla
                if (tipoMembresiaTexto.Contains("anual")) idMembresia = 3;      // ID correspondiente a Anual en tu BD
                else if (tipoMembresiaTexto.Contains("semestral")) idMembresia = 2; // ID correspondiente a Semestral
                else idMembresia = 1;                                           // ID correspondiente a Mensual
            }

            // 1. Consulta para insertar el cliente y OBTENER su ID autogenerado al instante
            string queryCliente = @"INSERT INTO Clientes (Nombre, Apellido, Telefono) 
                            VALUES (@Nombre, @Apellido, @Telefono);
                            SELECT SCOPE_IDENTITY();"; // Esto nos devuelve el ID recién creado

            // 2. Consulta para registrar el pago
            string queryPago = @"INSERT INTO Pagos (ID_Cliente, ID_Membresia, Monto_Pagado, Fecha_Pago, Fecha_Inicio, Fecha_Vencimiento, Estado) 
                         VALUES (@ID_Cliente, @ID_Membresia, @Monto, @FechaPago, @FechaInicio, @FechaVencimiento, @Estado);";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    // --- PASO 1: REGISTRAR AL CLIENTE ---
                    int nuevoIdCliente = 0;
                    using (SqlCommand cmdCliente = new SqlCommand(queryCliente, conexion))
                    {
                        cmdCliente.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());

                        nuevoIdCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());
                    }

                    // --- PASO 2: CALCULAR PRECIO Y FECHAS SEGÚN EL TEXTO ---
                    decimal montoCalculado = 350.00m; // Precio mensual por defecto
                    DateTime fechaInicio = DateTime.Today;
                    DateTime fechaVencimiento = DateTime.Today;

                    if (tipoMembresiaTexto.Contains("anual"))
                    {
                        montoCalculado = 3200.00m; // Precio anual
                        fechaVencimiento = fechaInicio.AddYears(1);
                    }
                    else if (tipoMembresiaTexto.Contains("semestral"))
                    {
                        montoCalculado = 1800.00m; // Precio semestral
                        fechaVencimiento = fechaInicio.AddMonths(6);
                    }
                    else
                    {
                        fechaVencimiento = fechaInicio.AddMonths(1);
                    }

                    // --- PASO 3: REGISTRAR EL PAGO EN LA TABLA PAGOS ---
                    using (SqlCommand cmdPago = new SqlCommand(queryPago, conexion))
                    {
                        cmdPago.Parameters.AddWithValue("@ID_Cliente", nuevoIdCliente);
                        cmdPago.Parameters.AddWithValue("@ID_Membresia", idMembresia);
                        cmdPago.Parameters.AddWithValue("@Monto", montoCalculado);
                        cmdPago.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                        cmdPago.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmdPago.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                        cmdPago.Parameters.AddWithValue("@Estado", "Activo");

                        cmdPago.ExecuteNonQuery(); // Guardamos el pago en la BD
                    }

                    MessageBox.Show("¡Socio registrado y membresía activada con éxito!");

                    // Limpias tus controles para un nuevo registro
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    cmbMembresia.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error en el registro: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // limpiar los campos de texto y el comboBox después de guardar el cliente
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cmbMembresia.SelectedIndex = -1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Objeto vacío mantenido intacto para conservar el enlace en el diseñador
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Membresia> listaMembresias = new List<Membresia>();

            // Consulta para traer los planes del gimnasio
            string query = "SELECT ID_Membresia, Tipo_Membresia, Precio FROM Membresias;";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                // Creamos un objeto Membresia por cada fila encontrada en la base de datos
                                Membresia m = new Membresia()
                                {
                                    ID_Membresia = Convert.ToInt32(lector["ID_Membresia"]),
                                    Tipo_Membresia = lector["Tipo_Membresia"].ToString(),
                                    Precio = Convert.ToDecimal(lector["Precio"])
                                };

                                listaMembresias.Add(m);
                            }
                        }

                        // Asignamos la lista al ComboBox de tu pantalla
                        cmbMembresia.DataSource = listaMembresias;
                        cmbMembresia.DisplayMember = "Tipo_Membresia"; // Lo que el usuario va a ver escrito
                        cmbMembresia.ValueMember = "ID_Membresia";     // El ID real que guardaremos en la tabla Pagos

                        // Inicializar el ComboBox sin ninguna selección por defecto
                        cmbMembresia.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("Error al cargar las membresías: " + ex.Message);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {        }
    }
}