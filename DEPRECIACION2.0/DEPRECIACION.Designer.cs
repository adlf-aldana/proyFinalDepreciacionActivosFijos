namespace DEPRECIACION2._0
{
    partial class DEPRECIACION
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
            System.Windows.Forms.Label idRegistroLabel;
            System.Windows.Forms.Label idPersonalLabel;
            System.Windows.Forms.Label idUbicacionLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            idRegistroLabel = new System.Windows.Forms.Label();
            idPersonalLabel = new System.Windows.Forms.Label();
            idUbicacionLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // idRegistroLabel
            // 
            idRegistroLabel.AutoSize = true;
            idRegistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idRegistroLabel.Location = new System.Drawing.Point(80, 52);
            idRegistroLabel.Name = "idRegistroLabel";
            idRegistroLabel.Size = new System.Drawing.Size(675, 24);
            idRegistroLabel.TabIndex = 53;
            idRegistroLabel.Text = "CALCULO DE ACTUALIZACION Y DEPRECIACION DE ACTIVOS FIJOS";
            // 
            // idPersonalLabel
            // 
            idPersonalLabel.AutoSize = true;
            idPersonalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idPersonalLabel.Location = new System.Drawing.Point(204, 93);
            idPersonalLabel.Name = "idPersonalLabel";
            idPersonalLabel.Size = new System.Drawing.Size(185, 20);
            idPersonalLabel.TabIndex = 56;
            idPersonalLabel.Text = "PERIODO DEL 01/01/";
            // 
            // idUbicacionLabel
            // 
            idUbicacionLabel.AutoSize = true;
            idUbicacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            idUbicacionLabel.Location = new System.Drawing.Point(368, 93);
            idUbicacionLabel.Name = "idUbicacionLabel";
            idUbicacionLabel.Size = new System.Drawing.Size(57, 20);
            idUbicacionLabel.TabIndex = 57;
            idUbicacionLabel.Text = "AAAA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(428, 93);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 20);
            label1.TabIndex = 62;
            label1.Text = "AL 31/12/";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(506, 93);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 20);
            label2.TabIndex = 63;
            label2.Text = "AAAA";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(488, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(102, 20);
            label3.TabIndex = 65;
            label3.Text = "UFV Inicial:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(494, 188);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(94, 20);
            label4.TabIndex = 66;
            label4.Text = "UFV Final:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 296);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(752, 348);
            this.dataGridView1.TabIndex = 61;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 241);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "ACTUALIZAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(586, 153);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(103, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(586, 191);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // DEPRECIACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 634);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(idRegistroLabel);
            this.Controls.Add(idPersonalLabel);
            this.Controls.Add(idUbicacionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DEPRECIACION";
            this.Text = "DEPRECIACION";
            this.Load += new System.EventHandler(this.DEPRECIACION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}