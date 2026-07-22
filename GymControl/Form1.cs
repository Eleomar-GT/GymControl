namespace GymControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "12345")
            {
                MessageBox.Show("Bienvenido al sistema de control de gimnasio.", "Inicio de sesión exitoso");
                textBox1.Clear();
                textBox2.Clear();


                this.Hide();
                using (Form2 form2 = new Form2())
                {
                    form2.ShowDialog();
                }
                this.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Inténtalo de nuevo.", "Error de inicio de sesión");
                textBox1.Clear();
                textBox2.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual y salir de la aplicación
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

