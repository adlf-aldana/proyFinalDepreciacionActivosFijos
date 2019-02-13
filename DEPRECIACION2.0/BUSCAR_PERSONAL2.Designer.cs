namespace DEPRECIACION2._0
{
    partial class BUSCAR_PERSONAL2
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFiltro = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "INTRODUZCA NOMBRE DEL PERSONAL O CI A BUSCAR:";
            // 
            // dgvFiltro
            // 
            this.dgvFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiltro.Location = new System.Drawing.Point(117, 172);
            this.dgvFiltro.Name = "dgvFiltro";
            this.dgvFiltro.RowTemplate.Height = 24;
            this.dgvFiltro.Size = new System.Drawing.Size(753, 422);
            this.dgvFiltro.TabIndex = 10;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(677, 95);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(222, 22);
            this.txtBuscar.TabIndex = 9;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // BUSCAR_PERSONAL2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 675);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFiltro);
            this.Controls.Add(this.txtBuscar);
            this.Name = "BUSCAR_PERSONAL2";
            this.Text = "BUSCAR_PERSONAL2";
            this.Load += new System.EventHandler(this.BUSCAR_PERSONAL2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiltro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFiltro;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}