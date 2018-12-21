using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* LIBRERIA PARA LA BASE DE DATOS*/
using System.Data.SqlClient;
/* LIBRERIA PARA GRAFICAR */
using System.Windows.Forms.DataVisualization.Charting;

namespace DEPRECIACION2._0
{
    public partial class informeActivoFijo : Form
    {
        /***************************
         * NECESARIO PARA CONEXION 
         * Y CONSULTAS A LA
         * BASE DE DATOS
         * *************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        /***************************
         * INICIO DE LA APLICACION
         ***************************/
        public informeActivoFijo()
        {
            InitializeComponent();
            /* TITULO PARA DEL INFORME */
            chart1.Titles.Add("CANTIDAD DE ACTIVOS FIJOS");
            /* CARGA LOS GRAFICOS DEL INFORME */
            LoadGraphics();
            //MessageBox.Show("Aun se esta trajando!");
            //Close();
        }

        //CONEXION DB
        private void SetConnection()
        {
            sql_con = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True");
        }

        /********************
         * EJECUTA CONSULTA
         *    CON LA BD
         ********************/
        private void Execute(String txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        /* CARGAR BD
        private void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "Select *from persona";
            DB = new SqlDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            //sql_con.Close();
        }*/


        /************************************
         * CLASE PARA REALIZAR LAS GRAFICAS
         ************************************/
        public void LoadGraphics()
        {
            chart1.Series.Clear();

            SetConnection();
            sql_con.Open();
            string sql1 = "select count(ID_RUBRO) FROM activofijo";

            sql_cmd = new SqlCommand(sql1, sql_con);
            SqlDataReader cant = sql_cmd.ExecuteReader();
            cant.Read();

            int i = Convert.ToInt32(cant.GetValue(0).ToString());
            int cont = 1;

            sql_con.Close();

            while (cont <= i)
            {

                sql_con.Open();
                string sql = "select count(ID_RUBRO),(Select DESCRIPCION from rubro where id_rubro='" + (10000 * cont) + "') FROM activofijo where ID_RUBRO=" + (10000 * cont);

                sql_cmd = new SqlCommand(sql, sql_con);
                SqlDataReader sdr = sql_cmd.ExecuteReader();
                sdr.Read();

                /*
                 * Comprueba si hay alguno  de los activos fijos no este en 0 
                 * o que no tenga nombre el rubro
                 */
                if (sdr.GetValue(0).ToString() != "0" || !string.IsNullOrEmpty(sdr.GetValue(1).ToString()))
                {

                    double valor = Convert.ToDouble(sdr.GetValue(0).ToString());

                    chart1.Series.Add(sdr.GetValue(1).ToString());
                    chart1.Series[sdr.GetValue(1).ToString()].Label = valor.ToString();
                    chart1.Series[sdr.GetValue(1).ToString()].ChartType = SeriesChartType.Column;
                    chart1.Series[sdr.GetValue(1).ToString()].Points.AddY(valor);
                    chart1.Series[sdr.GetValue(1).ToString()].ChartArea = "ChartArea1";
                }

                cont++;
                sql_con.Close();
            }
        }

        private void informeActivoFijo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.activoFijo' Puede moverla o quitarla según sea necesario.
            this.activoFijoTableAdapter.Fill(this.sis325DataSet.activoFijo);

            this.reportViewer1.RefreshReport();
        }
    }
}
