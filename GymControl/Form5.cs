using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Registrar_Click_1(object sender, EventArgs e)
        {
            List<Pago> pagosDelSistema = ObtenerPagosDesdeBD();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo de texto (*.txt)|*.txt";
                sfd.FileName = $"ReportePagos_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ReportePagos.GenerarReporteTxt(pagosDelSistema, sfd.FileName);
                        MessageBox.Show("Reporte generado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opcional: abrir el archivo automáticamente
                        System.Diagnostics.Process.Start("notepad.exe", sfd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
    }
}
