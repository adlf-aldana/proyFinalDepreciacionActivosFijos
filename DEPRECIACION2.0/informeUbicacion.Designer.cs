namespace DEPRECIACION2._0
{
    partial class informeUbicacion
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sis325DataSet = new DEPRECIACION2._0.sis325DataSet();
            this.ubicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ubicacionTableAdapter = new DEPRECIACION2._0.sis325DataSetTableAdapters.ubicacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ubicacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DEPRECIACION2._0.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(581, 409);
            this.reportViewer1.TabIndex = 0;
            // 
            // sis325DataSet
            // 
            this.sis325DataSet.DataSetName = "sis325DataSet";
            this.sis325DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ubicacionBindingSource
            // 
            this.ubicacionBindingSource.DataMember = "ubicacion";
            this.ubicacionBindingSource.DataSource = this.sis325DataSet;
            // 
            // ubicacionTableAdapter
            // 
            this.ubicacionTableAdapter.ClearBeforeFill = true;
            // 
            // informeUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 433);
            this.Controls.Add(this.reportViewer1);
            this.Name = "informeUbicacion";
            this.Text = "informeUbicacion";
            this.Load += new System.EventHandler(this.informeUbicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ubicacionBindingSource;
        private sis325DataSet sis325DataSet;
        private sis325DataSetTableAdapters.ubicacionTableAdapter ubicacionTableAdapter;
    }
}