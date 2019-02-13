using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DEPRECIACION2._0
{
    public partial class BUSCAR_UBICACION2 : Form
    {
        public BUSCAR_UBICACION2()
        {
            InitializeComponent();
        }

        DataSet resultados = new DataSet();
        DataView mifiltro;
        String instancia = "CORCHO";
        String bd = "sis325";

        public void leer_datos(string query, ref DataSet dstprinsipal, string tabla)
        {
            try
            {
                string cadena = "Server=" + instancia + ";Database=" + bd + ";Trusted_Connection=True";
                SqlConnection cn = new SqlConnection(cadena);
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dstprinsipal, tabla);
                da.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se pudo conecar");

            }
        }


        private void BUSCAR_UBICACION2_Load(object sender, EventArgs e)
        {
            this.leer_datos("select * from ubicacion", ref resultados, "ubicacion");
            this.mifiltro = ((DataTable)resultados.Tables["ubicacion"]).DefaultView;
            this.dgvFiltro.DataSource = mifiltro;
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string salida_datos = "";

            string[] palabras_busqueda = this.txtBuscar.Text.Split(' ');
            foreach (string palabra in palabras_busqueda)
            {
                if (salida_datos.Length == 0)
                {
                    //salida_datos = "(descripcion LIKE '%"+palabra+"%' OR vida_util LIKE '%"+palabra+"%' OR Proc_DEPRECIACION LIKE '%"+palabra+"%' OR total '%"+palabra+"%')";
                    salida_datos = "(area LIKE '%" + palabra + "%')";
                }
                else
                {
                   // salida_datos += " AND (descripcion LIKE '%" + palabra + "%' OR vida_util LIKE '%" + palabra + "%' OR Proc_DEPRECIACION LIKE '%" + palabra + "%' OR total '%" + palabra + "%')";
                    salida_datos = "(area LIKE '%" + palabra + "%')";

                }
            }
            this.mifiltro.RowFilter = salida_datos;
        }
    }
}
