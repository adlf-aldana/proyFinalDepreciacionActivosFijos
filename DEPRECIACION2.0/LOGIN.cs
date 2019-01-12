using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEPRECIACION2._0
{
    public partial class LOGIN : Form
    {
        static bool creadoDB = false;

        private SqlConnection sql_con;
        private SqlCommand sql_cmd;

        public LOGIN()
        {
            InitializeComponent();
            
            crearDbTablas cdt = new crearDbTablas();
            
            if (!creadoDB)
            {
                cdt.creacion();
                creadoDB = true;
            }
        }

        private void obtConexion()
        {
            try
            {
                sql_con = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True; MultipleActiveResultSets=true");
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUDO CONECTAR A LA BASE DE DATOS");
            }
        }

        /*****************************
         * RECUPERA DATOS DE LA BD 
         * Y COMPRUEBA QUE EL USUARIO 
         * Y LA CONTRASEÑA EXISTAN
         *****************************/
        string usuario;
        string pasword;
        public void recuperarCampos()
        {
            var query = "SELECT * FROM usuarios";
            obtConexion();
            sql_con.Open();
            using (SqlCommand cmd = new SqlCommand(query, sql_con))
            {
                
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        usuario = read["usuario"].ToString();
                        pasword= read["contraseña"].ToString();

                        if (usuario == textBox1.Text && pasword == textBox2.Text)
                        {
                            Form1 abrir = new Form1();
                            abrir.Show();
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Error: USUARIO O CONTRASEÑA NO EXISTE!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            sql_con.Close();
        }

        /****************
         * BOTON ENTRAR
         ****************/
        private void button1_Click(object sender, EventArgs e)
        {
            recuperarCampos();
        }
    }
}
