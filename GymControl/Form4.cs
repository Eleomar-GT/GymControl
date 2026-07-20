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
        //método para mostrar los datos en el datagridview al cargar el formulario
        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir Form2 para registrar un nuevo socio
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Show();

            // Refrescar el grid automáticamente al regresar
            CClientes objetoClientes = new CClientes();
            objetoClientes.mostrarClientes(dgvclientes);
        }
        //método para mostrar los datos en el datagridview al cargar el formulario
        private void button2_Click(object sender, EventArgs e)
        {
            // Refrescar el grid automáticamente al regresar
            Conexion objetConexion = new Conexion();
            objetConexion.estableceConexion();
            //mostrar clientes
            CClientes objetoClientes = new CClientes();
            objetoClientes.mostrarClientes(dgvclientes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        //boton para editar registros
        private void btnEditar_Click(object sender, EventArgs e)
        {
             //Validar que haya una fila seleccionada
            if (dgvclientes.CurrentRow != null)
            {
                //Extraer los datos de la fila actual
                string id = dgvclientes.CurrentRow.Cells[0].Value?.ToString() ?? "";
                string nombre = dgvclientes.CurrentRow.Cells[1].Value?.ToString() ?? "";
                string apellido = dgvclientes.CurrentRow.Cells[2].Value?.ToString() ?? "";
                string telefono = dgvclientes.CurrentRow.Cells[3].Value?.ToString() ?? "";
                string membresia = dgvclientes.CurrentRow.Cells[4].Value?.ToString() ?? "";

                //Abrir Form3 pasándole los datos mediante el segundo constructor
                Form3 formEditar = new Form3(id, nombre, apellido, telefono, membresia);

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    //Si se guardó con éxito, refrescamos el DataGridView
                    CClientes objetoClientes = new CClientes();
                    objetoClientes.mostrarClientes(dgvclientes);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un socio de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvclientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        //boton para eliminar registros
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Validar que haya una fila seleccionada en la cuadrícula
            if (dgvclientes.CurrentRow != null)
            {
                //Obtener el ID y el nombre del socio directo de la celda
                string id = dgvclientes.CurrentRow.Cells["id"].Value.ToString();
                string nombreCompleto = dgvclientes.CurrentRow.Cells["nombre"].Value.ToString() + " " + dgvclientes.CurrentRow.Cells["apellido"].Value.ToString();

                //Preguntar al usuario si realmente quiere borrarlo
                DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que deseas eliminar permanentemente a {nombreCompleto}?",
                                                             "Confirmar Eliminación",
                                                             MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    //Instanciar la clase Miembro y ejecutar el método seguro pasándole el string ID
                    Miembro objetoMiembro = new Miembro();
                    objetoMiembro.eliminarCliente(id);

                    // 5. Refrescar el DataGridView automáticamente para reflejar el borrado
                    CClientes objetoClientes = new CClientes();
                    objetoClientes.mostrarClientes(dgvclientes);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un socio de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}