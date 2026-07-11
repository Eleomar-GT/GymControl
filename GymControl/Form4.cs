using conexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using conexionBD.Clases;

namespace GymControl
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cerrar el formulario actual y abrir el formulario de registro
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion objetConexion = new Conexion(); // Se crea objetoConexion apartir de la clase CConexion que se encuentra dentro de la carpeta DAL.
            objetConexion.estableceConexion(); // Se establece la conexion

            //Instanciamos tu clase de lógica
            CClientes objetoClientes = new CClientes();

            //Le pasamos como parámetro el DataGridView de tu diseño (asegúrate de que se llame dgvAlumnos o el nombre que le diste)
            objetoClientes.mostrarClientes(dgvclientes);

        }
    }
}
