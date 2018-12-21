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
    public partial class BUSCAR_ACTIVO : Form
    {
        /*****************************
        * COMANDO BASICOS PARA LA BD
        *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        public BUSCAR_ACTIVO()
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


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void buscar()
        {
            obtConexion();
            sql_con.Open();
            var query = "select * from activoFijo WHERE DESCRIPCION='" + txtDescripcion.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sql_con))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        lbCodRubro.Text = read["CODIGO_ACTIVO"].ToString();
                        lbDescripcion.Text = read["DESCRIPCION"].ToString();
                        lbVidaUtil.Text = read["MARCA"].ToString();
                        lbCoeficiente.Text = read["COLOR"].ToString();
                        lbEstado.Text = read["ESTADO"].ToString();
                        lbTotal.Text = read["VALOR_COMPRA"].ToString();
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

       

        

    }
}
