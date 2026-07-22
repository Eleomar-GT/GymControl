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
        // Variable global para saber si estamos editando (Debe ir DENTRO de la clase)
        private int? idClienteAEditar = null;

        // Tu cadena de conexión unificada apuntando a la base de datos 'Prueba'
        private readonly string conexionString = "Server=.\\SQLEXPRESS; Database=clientes_GC; Integrated Security=True;";

        // CONSTRUCTOR 1: Para cuando es un registro NUEVO
        public Form3()
        {
            InitializeComponent();
        }

        // CONSTRUCTOR 2: Para cuando es una EDICIÓN desde Form4
        public Form3(string id, string nombre, string apellido, string telefono, string membresia)
        {
            InitializeComponent();

            // Guardamos el ID del cliente
            idClienteAEditar = Convert.ToInt32(id);

            // Cargamos los datos actuales en los componentes
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtTelefono.Text = telefono;
            cmbMembresia.Text = membresia;

            // Cambiamos el texto del botón para que sea intuitivo
            button1.Text = "Actualizar";
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
            // --- VALIDACIÓN DE SEGURIDAD (ComboBox) ---
            if (cmbMembresia.SelectedIndex == -1 || string.IsNullOrEmpty(cmbMembresia.Text))
            {
                MessageBox.Show("Por favor, selecciona un tipo de membresía de la lista.");
                return;
            }

            // --- VALIDACIÓN DE SEGURIDAD (Campos de Texto Vacíos) ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, rellena todos los campos obligatorios.");
                return;
            }

            // --- PASO DE CÁLCULO PREVIO DE PRECIOS Y FECHAS (Para inserción de nuevos) ---
            int idMembresia = 1;
            string tipoMembresiaTexto = cmbMembresia.Text.ToLower();

            if (cmbMembresia.SelectedValue != null && int.TryParse(cmbMembresia.SelectedValue.ToString(), out int idResultado))
            {
                idMembresia = idResultado;
            }
            else
            {
                if (tipoMembresiaTexto.Contains("anual")) idMembresia = 3;
                else if (tipoMembresiaTexto.Contains("semestral")) idMembresia = 2;
                else idMembresia = 1;
            }

            decimal montoCalculado = 350.00m;
            DateTime fechaInicio = DateTime.Today;
            DateTime fechaVencimiento = DateTime.Today;
            string estadoInicial = "Activo";

            if (tipoMembresiaTexto.Contains("anual"))
            {
                montoCalculado = 3200.00m;
                fechaVencimiento = fechaInicio.AddYears(1);
            }
            else if (tipoMembresiaTexto.Contains("semestral"))
            {
                montoCalculado = 1800.00m;
                fechaVencimiento = fechaInicio.AddMonths(6);
            }
            else if (tipoMembresiaTexto.Contains("semanal"))
            {
                montoCalculado = 100.00m;
                fechaVencimiento = fechaInicio.AddDays(7);
            }
            else
            {
                fechaVencimiento = fechaInicio.AddMonths(1);
            }

            // Cambiamos las strings de las consultas según sea Nuevo o Edición
            string queryCliente = "";

            if (idClienteAEditar == null)
            {
                // se ingresa un nuevo registro
                queryCliente = @"INSERT INTO Clientes (Nombre, Apellido, Telefono, [Tipo de membresia], Estado, [Fecha de inicio], [Fecha de vencimiento]) 
                        VALUES (@Nombre, @Apellido, @Telefono, @Membresia, @Estado, @FechaInicio, @FechaVencimiento);
                        SELECT SCOPE_IDENTITY();";
            }
            else
            {
                // ES UNA EDICIÓN
                queryCliente = @"UPDATE Clientes 
                        SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, [Tipo de membresia] = @Membresia
                        WHERE ID_Cliente = @IdCliente;";
            }

            // Consulta para registrar el pago (Solo usado en nuevos registros)
            string queryPago = @"INSERT INTO Pagos (ID_Cliente, ID_Membresia, Monto_Pagado, Fecha_Pago, Fecha_Inicio, Fecha_Vencimiento, Estado)                     
                             VALUES (@ID_Cliente, @ID_Membresia, @Monto, @FechaPago, @FechaInicio, @FechaVencimiento, @Estado);";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmdCliente = new SqlCommand(queryCliente, conexion))
                    {
                        cmdCliente.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Apellido", txtApellido.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());
                        cmdCliente.Parameters.AddWithValue("@Membresia", cmbMembresia.Text.Trim());

                        if (idClienteAEditar == null)
                        {
                            // Lógica para Insertar Nuevo
                            cmdCliente.Parameters.AddWithValue("@Estado", estadoInicial);
                            cmdCliente.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                            cmdCliente.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);

                            int nuevoIdCliente = Convert.ToInt32(cmdCliente.ExecuteScalar());

                            // Registrar el Pago inicial
                            using (SqlCommand cmdPago = new SqlCommand(queryPago, conexion))
                            {
                                cmdPago.Parameters.AddWithValue("@ID_Cliente", nuevoIdCliente);
                                cmdPago.Parameters.AddWithValue("@ID_Membresia", idMembresia);
                                cmdPago.Parameters.AddWithValue("@Monto", montoCalculado);
                                cmdPago.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                                cmdPago.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                                cmdPago.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                                cmdPago.Parameters.AddWithValue("@Estado", estadoInicial);

                                cmdPago.ExecuteNonQuery();
                            }

                            MessageBox.Show("¡Socio registrado con éxito!");
                        }
                        else
                        {
                            // Lógica para Modificar Existente
                            cmdCliente.Parameters.AddWithValue("@IdCliente", idClienteAEditar.Value);
                            cmdCliente.ExecuteNonQuery();

                            MessageBox.Show("¡Datos del socio actualizados con éxito!");

                            // Indicamos a Form4 que todo salió bien y cerramos el diálogo
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }

                    // Limpieza de campos (solo si fue registro nuevo)
                    if (idClienteAEditar == null)
                    {
                        txtNombre.Clear();
                        txtApellido.Clear();
                        txtTelefono.Clear();
                        cmbMembresia.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
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

            // Consulta para traer los planes de membresias
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
                        cmbMembresia.DisplayMember = "Tipo_Membresia";
                        cmbMembresia.ValueMember = "ID_Membresia";

                        // Inicializar el ComboBox sin ninguna selección por defecto si es nuevo registro
                        if (idClienteAEditar == null)
                        {
                            cmbMembresia.SelectedIndex = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show("Error al cargar las membresías: " + ex.Message);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        { }
    }
}