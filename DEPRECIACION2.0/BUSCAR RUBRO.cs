using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
/* LIBRERIA PARA LA BB*/
using System.Data.SqlClient;

namespace DEPRECIACION2._0
{
    public partial class BUSCAR_RUBRO : Form
    {
        /*****************************
         * COMANDO BASICOS PARA LA BD
         *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private String strCmd;
        private Boolean editando;


        public BUSCAR_RUBRO()
        {
            InitializeComponent();
        }

        /********************************
         * OBTIENE LA CONEXION CON LA BD
         ********************************/
        private void obtConexion()
        {
            try
            {
                sql_con = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True");
            }catch(SqlException)
            {
                MessageBox.Show("ERROR AL ESTABLECER CONEXION");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buscar()
        {
            obtConexion();
            var query = "select * from rubro WHERE descripcion='" + txtDescripcion.Text + "'";
            sql_con.Open();
            using (SqlCommand cmd = new SqlCommand(query, sql_con))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        lbCodRubro.Text = read["id_rubro"].ToString();
                        lbDescripcion.Text = read["descripcion"].ToString();
                        lbVidaUtil.Text = read["vida_util"].ToString();
                        lbCoeficiente.Text = read["Porc_DEPRECIACION"].ToString();
                        lbTotal.Text = read["total"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("NO SE ENCUENTRAN LOS RUBRO","AVISO");
                    pnlDescripcion.Visible = false;
                }
                sql_con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buscar();
            pnlDescripcion.Visible = true;
            

        }

        private void BUSCAR_RUBRO_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
