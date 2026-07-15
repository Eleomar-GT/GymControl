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
                archivoReporte = "ReporteCorteCaja.rdlc";
                querySQL = "SELECT ID_Pago, Monto, Fecha FROM dbo.Pagos WHERE CAST(Fecha AS DATE) = @Fecha";
            }
            else
            {
                querySQL = @"SELECT Nombre, Apellido, Telefono, [Tipo de membresia] AS TipoMembresia 
                     FROM dbo.Clientes 
                     WHERE CAST([Fecha de inicio] AS DATE) = @Fecha 
                       AND [Tipo de membresia] = @TipoMembresia";
            }

            
            string cadenaConexion = "Server=(local)\\SQLEXPRESS;Database=clientes_GC;Trusted_Connection=True;TrustServerCertificate=True;";

            DataTable dtDatosReales = new DataTable();

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    using (SqlCommand comando = new SqlCommand(querySQL, conexion))
                    {
                        comando.Parameters.AddWithValue("@Fecha", fechaSeleccionada);

                        if (deseaCorte != "Sí")
                        {
                            comando.Parameters.AddWithValue("@TipoMembresia", tipoSeleccionado);
                        }

                        SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                        conexion.Open();
                        adaptador.Fill(dtDatosReales);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay conexión a la BD: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form ventanaReporte = new Form();
            ventanaReporte.Text = deseaCorte == "Sí" ? "Corte de Caja" : "Reporte de Miembros";
            ventanaReporte.Size = new System.Drawing.Size(850, 650);
            ventanaReporte.StartPosition = FormStartPosition.CenterScreen;

            Microsoft.Reporting.WinForms.ReportViewer visor = new Microsoft.Reporting.WinForms.ReportViewer();
            visor.Dock = DockStyle.Fill;
            ventanaReporte.Controls.Add(visor);

            visor.LocalReport.ReportPath = archivoReporte;

            
            visor.LocalReport.DataSources.Clear();
            string nombreDataSet = deseaCorte == "Sí" ? "DataSetCorte" : "DataSetMiembros";

            Microsoft.Reporting.WinForms.ReportDataSource rds = new Microsoft.Reporting.WinForms.ReportDataSource(nombreDataSet, dtDatosReales);
            visor.LocalReport.DataSources.Add(rds);

            visor.RefreshReport();
            ventanaReporte.ShowDialog();
        }
    }
    }