using conexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GymControl
{
    public partial class Form3 : Form
    {
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
            //Se crea un objeto de la clase CClientes para poder acceder a sus métodos
            CClientes objetoClientes = new CClientes();

            // Llamar al método guardarCliente para registrar el cliente en la base de datos
            objetoClientes.guardarCliente(textBox1, textBox2, textBox3, comboBox1);

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //limpiar los campos de texto y el comboBox después de guardar el cliente
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
