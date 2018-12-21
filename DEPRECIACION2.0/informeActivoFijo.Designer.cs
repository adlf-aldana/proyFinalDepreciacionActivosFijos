namespace DEPRECIACION2._0
{
    partial class informeActivoFijo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sis325DataSet = new DEPRECIACION2._0.sis325DataSet();
            this.activoFijoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.activoFijoTableAdapter = new DEPRECIACION2._0.sis325DataSetTableAdapters.activoFijoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activoFijoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(204, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(595, 345);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.activoFijoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DEPRECIACION2._0.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 363);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(950, 320);
            this.reportViewer1.TabIndex = 1;
            // 
            // sis325DataSet
            // 
            this.sis325DataSet.DataSetName = "sis325DataSet";
            this.sis325DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // activoFijoBindingSource
            // 
            this.activoFijoBindingSource.DataMember = "activoFijo";
            this.activoFijoBindingSource.DataSource = this.sis325DataSet;
            // 
            // activoFijoTableAdapter
            // 
            this.activoFijoTableAdapter.ClearBeforeFill = true;
            // 
            // informeActivoFijo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 695);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.chart1);
            this.Name = "informeActivoFijo";
            this.Text = "informeActivoFijo";
            this.Load += new System.EventHandler(this.informeActivoFijo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activoFijoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource activoFijoBindingSource;
        private sis325DataSet sis325DataSet;
        private sis325DataSetTableAdapters.activoFijoTableAdapter activoFijoTableAdapter;
    }
}