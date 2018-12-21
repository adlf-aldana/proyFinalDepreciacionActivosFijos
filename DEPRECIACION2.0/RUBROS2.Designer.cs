namespace DEPRECIACION2._0
{
    partial class RUBROS2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RUBROS2));
            this.label4 = new System.Windows.Forms.Label();
            this.txtCoeficiente = new System.Windows.Forms.TextBox();
            this.txtAnios = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pxbEditar = new System.Windows.Forms.PictureBox();
            this.pxbEliminar = new System.Windows.Forms.PictureBox();
            this.pxbGuardar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "POR AÑO";
            // 
            // txtCoeficiente
            // 
            this.txtCoeficiente.Enabled = false;
            this.txtCoeficiente.Location = new System.Drawing.Point(131, 238);
            this.txtCoeficiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtCoeficiente.Name = "txtCoeficiente";
            this.txtCoeficiente.Size = new System.Drawing.Size(87, 20);
            this.txtCoeficiente.TabIndex = 2;
            // 
            // txtAnios
            // 
            this.txtAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtAnios.FormattingEnabled = true;
            this.txtAnios.Items.AddRange(new object[] {
            "4",
            "5",
            "8",
            "10",
            "20",
            "40"});
            this.txtAnios.Location = new System.Drawing.Point(131, 193);
            this.txtAnios.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnios.Name = "txtAnios";
            this.txtAnios.Size = new System.Drawing.Size(74, 21);
            this.txtAnios.TabIndex = 1;
            this.txtAnios.SelectedIndexChanged += new System.EventHandler(this.txtAnios_SelectedIndexChanged);
            this.txtAnios.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnios_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 240);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "% DE DEPRECIACION:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 195);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "AÑOS DE VIDA UTIL:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(131, 135);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(319, 41);
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "DETALLE:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(511, 135);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(512, 480);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(364, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 29);
            this.label5.TabIndex = 27;
            this.label5.Text = "GESTION DE RUBROS ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(70, 414);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Guardar";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(333, 414);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Eliminar";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(201, 414);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Editar";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // pxbEditar
            // 
            this.pxbEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pxbEditar.Image = global::DEPRECIACION2._0.Properties.Resources.editar;
            this.pxbEditar.Location = new System.Drawing.Point(178, 312);
            this.pxbEditar.Margin = new System.Windows.Forms.Padding(2);
            this.pxbEditar.Name = "pxbEditar";
            this.pxbEditar.Size = new System.Drawing.Size(100, 100);
            this.pxbEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pxbEditar.TabIndex = 34;
            this.pxbEditar.TabStop = false;
            this.pxbEditar.Click += new System.EventHandler(this.pxbEditar_Click);
            // 
            // pxbEliminar
            // 
            this.pxbEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pxbEliminar.Image = global::DEPRECIACION2._0.Properties.Resources.eliminar;
            this.pxbEliminar.Location = new System.Drawing.Point(314, 312);
            this.pxbEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.pxbEliminar.Name = "pxbEliminar";
            this.pxbEliminar.Size = new System.Drawing.Size(100, 100);
            this.pxbEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pxbEliminar.TabIndex = 32;
            this.pxbEliminar.TabStop = false;
            this.pxbEliminar.Click += new System.EventHandler(this.pxbEliminar_Click);
            // 
            // pxbGuardar
            // 
            this.pxbGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pxbGuardar.Image = global::DEPRECIACION2._0.Properties.Resources.guardar;
            this.pxbGuardar.Location = new System.Drawing.Point(45, 312);
            this.pxbGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.pxbGuardar.Name = "pxbGuardar";
            this.pxbGuardar.Size = new System.Drawing.Size(100, 100);
            this.pxbGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pxbGuardar.TabIndex = 30;
            this.pxbGuardar.TabStop = false;
            this.pxbGuardar.Click += new System.EventHandler(this.pxbGuardar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1004, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 32);
            this.panel1.TabIndex = 38;
            // 
            // RUBROS2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pxbEditar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pxbEliminar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pxbGuardar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCoeficiente);
            this.Controls.Add(this.txtAnios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RUBROS2";
            this.Text = "RUBROS2";
            this.Load += new System.EventHandler(this.RUBROS2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCoeficiente;
        private System.Windows.Forms.ComboBox txtAnios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pxbGuardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pxbEliminar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pxbEditar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}