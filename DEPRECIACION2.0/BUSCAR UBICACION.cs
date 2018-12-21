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
    public partial class BUSCAR_UBICACION : Form
    {
        /*****************************
        * COMANDO BASICOS PARA LA BD
        *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        public BUSCAR_UBICACION()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /********************************
         * OBTIENE LA CONEXION CON LA BD
         ********************************/
        private void obtConexion()
        {
            try
            {
                sql_con = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True");
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUDO CONECTAR A LA BASE DE DATOS");
            }
        }

        private void buscar()
        {
            obtConexion();
            sql_con.Open();
            var query = "select * from ubicacion WHERE area='" + txtDescripcion.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sql_con))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        lbCodRubro.Text = read["id_ubicacion"].ToString();
                        lbDescripcion.Text = read["area"].ToString();
                        txtDesc.Text = read["descripcionUbicacion"].ToString();
                        
                    }
                }
                else
                {
                    MessageBox.Show("no se encontro dicho rubro");
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


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
