namespace DEPRECIACION2._0
{
    partial class informaPersonal
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
            this.recursosHumanosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recursosHumanosTableAdapter = new DEPRECIACION2._0.sis325DataSetTableAdapters.recursosHumanosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(143, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(499, 333);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.recursosHumanosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DEPRECIACION2._0.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(57, 361);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(645, 288);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // sis325DataSet
            // 
            this.sis325DataSet.DataSetName = "sis325DataSet";
            this.sis325DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recursosHumanosBindingSource
            // 
            this.recursosHumanosBindingSource.DataMember = "recursosHumanos";
            this.recursosHumanosBindingSource.DataSource = this.sis325DataSet;
            // 
            // recursosHumanosTableAdapter
            // 
            this.recursosHumanosTableAdapter.ClearBeforeFill = true;
            // 
            // informaPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 661);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.chart1);
            this.Name = "informaPersonal";
            this.Text = "informaPersonal";
            this.Load += new System.EventHandler(this.informaPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sis325DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursosHumanosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource recursosHumanosBindingSource;
        private sis325DataSet sis325DataSet;
        private sis325DataSetTableAdapters.recursosHumanosTableAdapter recursosHumanosTableAdapter;
    }
}