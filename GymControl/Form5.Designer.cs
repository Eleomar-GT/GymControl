namespace GymControl
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox3 = new ComboBox();
            Registrar = new Button();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(793, 437);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Imprint MT Shadow", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 40);
            label1.Name = "label1";
            label1.Size = new Size(154, 40);
            label1.TabIndex = 5;
            label1.Text = "Reportes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Imprint MT Shadow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 151);
            label2.Name = "label2";
            label2.Size = new Size(331, 20);
            label2.TabIndex = 6;
            label2.Text = "Seleccione el tipo de reporte que desea:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Imprint MT Shadow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 209);
            label3.Name = "label3";
            label3.Size = new Size(365, 20);
            label3.TabIndex = 7;
            label3.Text = "Selecciona la fecha del reporte que se desea";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Imprint MT Shadow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 265);
            label4.Name = "label4";
            label4.Size = new Size(284, 20);
            label4.TabIndex = 8;
            label4.Text = "¿Desea visualizar el corte de caja?";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Semanal", "Mensual", "Anual" });
            comboBox1.Location = new Point(362, 148);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 9;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Si", "No" });
            comboBox3.Location = new Point(315, 265);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 11;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // Registrar
            // 
            Registrar.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Registrar.Location = new Point(169, 363);
            Registrar.Name = "Registrar";
            Registrar.Size = new Size(187, 36);
            Registrar.TabIndex = 14;
            Registrar.Text = "Generar reporte";
            Registrar.UseVisualStyleBackColor = true;
            Registrar.Click += Registrar_Click_1;
            // 
            // button1
            // 
            button1.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(395, 363);
            button1.Name = "button1";
            button1.Size = new Size(187, 36);
            button1.TabIndex = 15;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(395, 202);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 27);
            dateTimePicker1.TabIndex = 16;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(Registrar);
            Controls.Add(comboBox3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form5";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes";
            Load += Form5_Load;
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
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Button Registrar;
        private Button button1;
        private DateTimePicker dateTimePicker1;
    }
}