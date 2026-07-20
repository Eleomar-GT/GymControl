namespace GymControl
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            dgvclientes = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvclientes).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(829, 438);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Imprint MT Shadow", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(86, 37);
            label1.Name = "label1";
            label1.Size = new Size(115, 40);
            label1.TabIndex = 4;
            label1.Text = "Socios";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(597, 6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(152, 80);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // dgvclientes
            // 
            dgvclientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvclientes.Location = new Point(12, 108);
            dgvclientes.Name = "dgvclientes";
            dgvclientes.RowHeadersWidth = 51;
            dgvclientes.Size = new Size(809, 231);
            dgvclientes.TabIndex = 14;
            dgvclientes.CellMouseClick += dgvclientes_CellMouseClick;
            // 
            // button1
            // 
            button1.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(643, 366);
            button1.Name = "button1";
            button1.Size = new Size(123, 39);
            button1.TabIndex = 15;
            button1.Text = "Regresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(503, 366);
            button2.Name = "button2";
            button2.Size = new Size(123, 39);
            button2.TabIndex = 16;
            button2.Text = "Visualizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.Location = new Point(58, 366);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(113, 39);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(211, 366);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(113, 39);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(833, 450);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvclientes);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvclientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private DataGridView dgvclientes;
        private Button button1;
        private Button button2;
        private Button btnEditar;
        private Button btnEliminar;
    }
}