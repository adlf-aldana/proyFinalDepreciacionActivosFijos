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
        private SqlDataAdapter DA;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private DataTable DT1 = new DataTable();

        private String strCmd;
        private Boolean editando;
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
                    }
                   
                }
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA"+usuario.ToString());
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA"+pasword.ToString());
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTA");
                    textBox1.Clear();
                    textBox2.Clear();
                    
                }
                if (usuario == textBox1.Text && pasword == textBox2.Text)
                {
                    Form1 abrir = new Form1();
                    abrir.Show();

                }

                else
                {
                    MessageBox.Show("USUARIO O  INCORRECTA" + usuario.ToString());
                    MessageBox.Show("USUARIO O  INCORRECTA" + pasword.ToString());
                    MessageBox.Show("Error de usuario o contraseña");
                }
            }

           

            sql_con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            recuperarCampos();
        }
    }
}
