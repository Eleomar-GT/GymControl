namespace GymControl
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelefono = new TextBox();
            button1 = new Button();
            button2 = new Button();
            cmbMembresia = new ComboBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-5, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(793, 438);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Imprint MT Shadow", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 30);
            label1.Name = "label1";
            label1.Size = new Size(244, 40);
            label1.TabIndex = 3;
            label1.Text = "Registrar socio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Imprint MT Shadow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(68, 110);
            label2.Name = "label2";
            label2.Size = new Size(100, 27);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Imprint MT Shadow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(68, 172);
            label3.Name = "label3";
            label3.Size = new Size(103, 27);
            label3.TabIndex = 5;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Imprint MT Shadow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(68, 232);
            label4.Name = "label4";
            label4.Size = new Size(107, 27);
            label4.TabIndex = 6;
            label4.Text = "Telefono";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Imprint MT Shadow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(68, 293);
            label5.Name = "label5";
            label5.Size = new Size(129, 27);
            label5.TabIndex = 7;
            label5.Text = "Membresia";
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.Silver;
            txtNombre.Location = new Point(203, 112);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 27);
            txtNombre.TabIndex = 8;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.Silver;
            txtApellido.Location = new Point(203, 174);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(155, 27);
            txtApellido.TabIndex = 9;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.Silver;
            txtTelefono.Location = new Point(203, 234);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(155, 27);
            txtTelefono.TabIndex = 10;
            // 
            // button1
            // 
            button1.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(277, 348);
            button1.Name = "button1";
            button1.Size = new Size(126, 49);
            button1.TabIndex = 13;
            button1.Text = "Registrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(612, 348);
            button2.Name = "button2";
            button2.Size = new Size(126, 49);
            button2.TabIndex = 14;
            button2.Text = "Regresar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // cmbMembresia
            // 
            cmbMembresia.FormattingEnabled = true;
            cmbMembresia.Items.AddRange(new object[] { "Semanal", "Mensual", "Anual" });
            cmbMembresia.Location = new Point(203, 293);
            cmbMembresia.Name = "cmbMembresia";
            cmbMembresia.Size = new Size(155, 28);
            cmbMembresia.TabIndex = 15;
            cmbMembresia.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // button3
            // 
            button3.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(460, 348);
            button3.Name = "button3";
            button3.Size = new Size(126, 49);
            button3.TabIndex = 16;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(cmbMembresia);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de socios";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelefono;
        private Button button1;
        private Button button2;
        private ComboBox cmbMembresia;
        private Button button3;
    }
}