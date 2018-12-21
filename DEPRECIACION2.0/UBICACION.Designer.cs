namespace DEPRECIACION2._0
{
    partial class UBICACION
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
            System.Windows.Forms.Label areaLabel;
            System.Windows.Forms.Label descripcionUbicacionLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UBICACION));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.areaTextBox = new System.Windows.Forms.TextBox();
            this.descripcionUbicacionTextBox = new System.Windows.Forms.TextBox();
            this.ubicacionDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            areaLabel = new System.Windows.Forms.Label();
            descripcionUbicacionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // areaLabel
            // 
            areaLabel.AutoSize = true;
            areaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            areaLabel.Location = new System.Drawing.Point(205, 180);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new System.Drawing.Size(42, 17);
            areaLabel.TabIndex = 13;
            areaLabel.Text = "Area";
            // 
            // descripcionUbicacionLabel
            // 
            descripcionUbicacionLabel.AutoSize = true;
            descripcionUbicacionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionUbicacionLabel.Location = new System.Drawing.Point(205, 206);
            descripcionUbicacionLabel.Name = "descripcionUbicacionLabel";
            descripcionUbicacionLabel.Size = new System.Drawing.Size(174, 17);
            descripcionUbicacionLabel.TabIndex = 16;
            descripcionUbicacionLabel.Text = "Descripcion Ubicacion:";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(433, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "ELIMINAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(326, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "EDITAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(220, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // areaTextBox
            // 
            this.areaTextBox.Location = new System.Drawing.Point(384, 179);
            this.areaTextBox.Name = "areaTextBox";
            this.areaTextBox.Size = new System.Drawing.Size(167, 20);
            this.areaTextBox.TabIndex = 0;
            // 
            // descripcionUbicacionTextBox
            // 
            this.descripcionUbicacionTextBox.Location = new System.Drawing.Point(384, 205);
            this.descripcionUbicacionTextBox.Name = "descripcionUbicacionTextBox";
            this.descripcionUbicacionTextBox.Size = new System.Drawing.Size(167, 20);
            this.descripcionUbicacionTextBox.TabIndex = 1;
            // 
            // ubicacionDataGridView
            // 
            this.ubicacionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ubicacionDataGridView.Enabled = false;
            this.ubicacionDataGridView.Location = new System.Drawing.Point(636, 180);
            this.ubicacionDataGridView.Name = "ubicacionDataGridView";
            this.ubicacionDataGridView.Size = new System.Drawing.Size(341, 405);
            this.ubicacionDataGridView.TabIndex = 19;
            this.ubicacionDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ubicacionDataGridView_CellClick);
            this.ubicacionDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ubicacionDataGridView_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1003, 32);
            this.panel1.TabIndex = 85;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(973, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(466, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 37);
            this.label1.TabIndex = 86;
            this.label1.Text = "UBICACION";
            // 
            // UBICACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ubicacionDataGridView);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(areaLabel);
            this.Controls.Add(this.areaTextBox);
            this.Controls.Add(descripcionUbicacionLabel);
            this.Controls.Add(this.descripcionUbicacionTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UBICACION";
            this.Text = "UBICACION";
            this.Load += new System.EventHandler(this.UBICACION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox areaTextBox;
        private System.Windows.Forms.TextBox descripcionUbicacionTextBox;
        private System.Windows.Forms.DataGridView ubicacionDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}