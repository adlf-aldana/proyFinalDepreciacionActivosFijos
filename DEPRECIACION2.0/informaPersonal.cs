using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* LIBRERIA PARA LA BASE DE DATOS*/
using System.Data.SqlClient;
/* LIBRERIA PARA GRAFICAR */
using System.Windows.Forms.DataVisualization.Charting;

namespace DEPRECIACION2._0
{

    public partial class informaPersonal : Form
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

        public informaPersonal()
        {
            InitializeComponent();
            /* TITULO PARA DEL INFORME */
            chart1.Titles.Add("CANTIDAD DE PERSONAL");
            /* CARGA LOS GRAFICOS DEL INFORME */
            LoadGraphics();
        }


        //CONEXION DB
        private void SetConnection()
        {
            /* */
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

        /************************************
         * CLASE PARA REALIZAR LAS GRAFICAS
         ************************************/
        public void LoadGraphics()
        {
            chart1.Series.Clear();

            SetConnection();
            sql_con.Open();
            string sql1 = "select count(idCliente) FROM recursosHumanos";

            sql_cmd = new SqlCommand(sql1, sql_con);
            SqlDataReader cant = sql_cmd.ExecuteReader();
            cant.Read();

            int i = Convert.ToInt32(cant.GetValue(0).ToString());
            int cont = 1;

            sql_con.Close();

            sql_con.Open();
            string sql = "select count(idCliente) from recursosHumanos where cargo='Contador'";

            sql_cmd = new SqlCommand(sql, sql_con);
            SqlDataReader sdr = sql_cmd.ExecuteReader();
            sdr.Read();
            var valor = sdr.GetValue(0).ToString();

            chart1.Series.Add("Contador");
            chart1.Series["Contador"].Label = valor;
            chart1.Series["Contador"].ChartType = SeriesChartType.Column;
            chart1.Series["Contador"].Points.AddY(valor);
            chart1.Series["Contador"].ChartArea = "ChartArea1";
            sql_con.Close();

            sql_con.Open();
            sql = "select count(idCliente) from recursosHumanos where cargo='Auxiliar en contaduria'";

            sql_cmd = new SqlCommand(sql, sql_con);
            sdr = sql_cmd.ExecuteReader();
            sdr.Read();
            valor = sdr.GetValue(0).ToString();

            chart1.Series.Add("Auxiliar");
            chart1.Series["Auxiliar"].Label = valor;
            chart1.Series["Auxiliar"].ChartType = SeriesChartType.Column;
            chart1.Series["Auxiliar"].Points.AddY(valor);
            chart1.Series["Auxiliar"].ChartArea = "ChartArea1";
            sql_con.Close();

            sql_con.Open();
            sql = "select count(idCliente) from recursosHumanos where cargo='Gerente'";

            sql_cmd = new SqlCommand(sql, sql_con);
            sdr = sql_cmd.ExecuteReader();
            sdr.Read();
            valor = sdr.GetValue(0).ToString();

            chart1.Series.Add("Gerente");
            chart1.Series["Gerente"].Label = valor;
            chart1.Series["Gerente"].ChartType = SeriesChartType.Column;
            chart1.Series["Gerente"].Points.AddY(valor);
            chart1.Series["Gerente"].ChartArea = "ChartArea1";
            sql_con.Close();
        }

        private void informaPersonal_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.recursosHumanos' Puede moverla o quitarla según sea necesario.
            this.recursosHumanosTableAdapter.Fill(this.sis325DataSet.recursosHumanos);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
