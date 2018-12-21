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
    public partial class BUSCAR_PERSONAL : Form
    {
        /*****************************
        * COMANDO BASICOS PARA LA BD
        *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        public BUSCAR_PERSONAL()
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
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUDO CONECTAR A LA BASE DE DATOS");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void buscar()
        {
            obtConexion();
            sql_con.Open();
            var query = "SELECT * FROM recursosHumanos WHERE CiPersonal='" + txtDescripcion.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sql_con))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        lbCi.Text = read["CiPersonal"].ToString();
                        lbProcedencia.Text = read["procedencia"].ToString();
                        lbNombres.Text = read["Nombres"].ToString();
                        lbPaterno.Text = read["ApellidoPat"].ToString();
                        lbMaterno.Text = read["ApellidoMat"].ToString();
                        lbCargo.Text = read["Cargo"].ToString();
                        lbDireccion.Text = read["Dir"].ToString();
                        lbEmail.Text = read["Email"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("NO SE ENCONTRO EL PERSONAL CON EL CI "+txtDescripcion.Text);
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

        private void lbNombres_Click(object sender, EventArgs e)
        {

        }

        /**********************************
         * LIBRERIAS PARA PODER MOVER LA 
         * VENTANA DE BUSQUEDA DE PERSONAL
         **********************************/
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
