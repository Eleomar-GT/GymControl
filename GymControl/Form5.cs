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

            if (deseaCorte == "Sí")
            {
                archivoReporte = "ReporteUsuarios.rdlc";
                querySQL = "SELECT CAST(ID_Pago AS VARCHAR) AS Nombre, CAST(Monto AS VARCHAR) AS Apellido, CAST(Fecha_Inicio AS VARCHAR) AS Telefono, 'Corte' AS TipoMembresia FROM dbo.Pagos WHERE CAST(Fecha_Inicio AS DATE) = @Fecha";
            }
            else
            {
                querySQL = @"SELECT c.Nombre, c.Apellido, c.Telefono, 
                            @TipoMembresiaTexto AS TipoMembresia
                     FROM dbo.Clientes c 
                     INNER JOIN dbo.Pagos p ON c.ID_Cliente = p.ID_Cliente
                     WHERE CAST(p.Fecha_Inicio AS DATE) = @Fecha 
                       AND p.ID_Membresia = @IDMembresia";
            }

            string cadenaConexion = "Server=(local)\\SQLEXPRESS;Database=clientes_GC;Trusted_Connection=True;TrustServerCertificate=True;";
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos.Clear();
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(querySQL, conexion))
                    {
                        comando.Parameters.AddWithValue("@Fecha", fechaSeleccionada);

                        // Lógica de conversión de membresía a ID numérico
                        int idMembresiaBusqueda = 1;
                        string tTexto = (tipoSeleccionado ?? "").ToLower();

                        if (tTexto.Contains("anual")) idMembresiaBusqueda = 3;
                        else if (tTexto.Contains("semestral")) idMembresiaBusqueda = 2;
                        else if (tTexto.Contains("semanal")) idMembresiaBusqueda = 4;
                        else idMembresiaBusqueda = 1;

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
                MessageBox.Show("No hay conexión a la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


            