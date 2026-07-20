using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GymControl
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Registrar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string cadenaConexion = "Server=(local)\\SQLEXPRESS;Database=clientes_GC;Trusted_Connection=True;TrustServerCertificate=True;";

        private void Registrar_Click_1(object sender, EventArgs e)
        {
            string tipoSeleccionado = comboBox1.SelectedItem?.ToString();
            DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
            string deseaCorte = comboBox3.SelectedItem?.ToString();

            string archivoReporte = "ReporteUsuarios.rdlc";
            string querySQL = "";

            // 2. Definición de la consulta según la opción seleccionada
            if (deseaCorte.Trim().ToLower().Contains("si"))
            {
                archivoReporte = "ReporteUsuarios.rdlc";

                querySQL = @"SELECT 
                        c.Nombre AS Nombre, 
                        c.Apellido AS Apellido, 
                        c.Telefono AS Telefono, 
                        (m.Tipo_Membresia + ' - $' + CAST(p.Monto_Pagado AS VARCHAR)) AS TipoMembresia 
                     FROM dbo.Pagos p
                     INNER JOIN dbo.Clientes c ON p.ID_Cliente = c.ID_Cliente
                     INNER JOIN dbo.Membresias m ON p.ID_Membresia = m.ID_Membresia
                     WHERE CAST(p.Fecha_Pago AS DATE) = @Fecha";
            }
            else
            {
                // REPORTE NORMAL: Filtra por el tipo de membresía escrito en la ficha del cliente.
                // Quitamos el candado estricto de la fecha para asegurar que se visualicen los registros existentes.
                querySQL = @"SELECT c.Nombre, c.Apellido, c.Telefono, 
                            c.[Tipo de membresia] AS TipoMembresia
                     FROM dbo.Clientes c
                     WHERE c.[Tipo de membresia] = @TipoMembresiaTexto";
            }

            string cadenaConexion = "Server=(local)\\SQLEXPRESS;Database=clientes_GC;Trusted_Connection=True;TrustServerCertificate=True;";
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos.Clear();
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    // Creamos el comando con la consulta SQL correspondiente
                    using (SqlCommand comando = new SqlCommand(querySQL, conexion))
                    {
                        // Pasamos la fecha seleccionada
                        comando.Parameters.AddWithValue("@Fecha", fechaSeleccionada);

                        // Calculamos el ID numérico de la membresía para que siempre exista
                        int idMembresiaBusqueda = 1;
                        string tTexto = (tipoSeleccionado ?? "").ToLower();

                        if (tTexto.Contains("anual")) idMembresiaBusqueda = 3;
                        else if (tTexto.Contains("semestral")) idMembresiaBusqueda = 2;
                        else if (tTexto.Contains("semanal")) idMembresiaBusqueda = 4;
                        else idMembresiaBusqueda = 1;

                        // Se declaran globalmente: si la consulta no los usa (como en el corte), SQL los ignora.
                        // Si la consulta los requiere (como en el reporte normal), no lanzará error.
                        comando.Parameters.AddWithValue("@IDMembresia", idMembresiaBusqueda);
                        comando.Parameters.AddWithValue("@TipoMembresiaTexto", tipoSeleccionado ?? "Mensual");

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dtDatos);
                        }
                    }
                }

                // Generamos la ventana del reporte enlazando los datos reales
                Form ventanaReporte = new Form();
                ventanaReporte.Text = deseaCorte == "Sí" ? "Corte de Caja" : "Reporte de Miembros";
                ventanaReporte.Size = new System.Drawing.Size(850, 600);
                ventanaReporte.StartPosition = FormStartPosition.CenterScreen;

                Microsoft.Reporting.WinForms.ReportViewer visor = new Microsoft.Reporting.WinForms.ReportViewer();
                visor.Dock = DockStyle.Fill;
                ventanaReporte.Controls.Add(visor);

                visor.LocalReport.ReportPath = archivoReporte;
                visor.LocalReport.DataSources.Clear();

                // Le pasamos el nombre que tu archivo .rdlc espera estrictamente
                Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetMiembros", dtDatos);
                visor.LocalReport.DataSources.Add(rds);

                visor.RefreshReport();
                ventanaReporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


