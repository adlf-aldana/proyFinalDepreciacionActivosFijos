using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* LIBRERIA PARA LA BB*/
using System.Data.SqlClient;

namespace DEPRECIACION2._0
{
    public partial class usuarios : Form
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

        public usuarios()
        {
            InitializeComponent();
            cargarDatos();
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

        /********************
         * EJECUTA CONSULTA
         *    CON LA BD
         ********************/
        private void ejecutarConsulta(String txtQuery)
        {
            obtConexion();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        /******************************
         * CARGA DATOS AL DATAGRIDVIEW
         *****************************/
        private void cargarDatos()
        {
            obtConexion();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "Select *from usuarios";
            DB = new SqlDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private Boolean guardar()
        {
            try
            {
                string strCmd = "INSERT INTO usuarios (CiPersona, usuario, contraseña, confirContraseña) VALUES ('" + comboBox1.Text + "','" + textBox1.Text + "','"+textBox2.Text+"','"+textBox3.Text+"')";
                ejecutarConsulta(strCmd);
                limpiarTextBox();
                MessageBox.Show("REGISTRO INSERTADO EXITOSAMENTE", "Aviso");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR: REGISTRO NO INSERTADO", "Error");
                return false;
            }
        }

        public void limpiarTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.sis325DataSet.usuarios);
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.recursosHumanos' Puede moverla o quitarla según sea necesario.
            this.recursosHumanosTableAdapter.Fill(this.sis325DataSet.recursosHumanos);

        }

        /****************
         * BOTON GUARDAR
         ***************+*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (MessageBox.Show("¿Esta seguro que desea insertar el registro?", "Insertar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (textBox2.Text != textBox3.Text)
                        MessageBox.Show("Las contraseñas deben ser iguales");
                    else
                    {
                        guardar();
                        cargarDatos();
                        dataGridView1.DataSource = DT;
                    }
                }
            }
        }



        /********************************
         * VALIDA QUE TODOS LOS CAMPOS 
         * NO ESTEN VACIOS
         *********************************/
        private Boolean camposCompletos()
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") | textBox3.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (textBox2.Text != textBox3.Text)
                    MessageBox.Show("Las contraseñas deben ser iguales");
                else
                {
                    editar();
                    cargarDatos();
                    dataGridView1.DataSource = DT;
                }
            }
        }

        /************************************
         * MODIFICA LOS VALORES DE UNA TABLA
         ************************************/
        private Boolean editar()
        {
            try
            {
                if (editando)
                {
                    strCmd = "UPDATE usuarios SET CiPersona='" + comboBox1.Text + "',usuario='" + textBox1.Text + "', contraseña: '"+textBox1+"', repetirContraseña: '"+textBox2+"' WHERE idUsuario=" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idUsuario"].Value.ToString() + "";
                    ejecutarConsulta(strCmd);
                    cargarDatos();
                    limpiarTextBox();
                    MessageBox.Show("REGISTRO EDITADO EXITOSAMENTE", "Aviso");
                    editando = false;
                }
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE ACTUALIZARON LOS DATOS", "Error");
                return false;
            }
        }


        /******************************
         * ELIMINA UN REGISTRO DE LA DB
         ******************************/
        private Boolean borrar()
        {
            try
            {
                strCmd = "DELETE FROM usuarios WHERE idCliente='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["area"].Value.ToString() + "'" + "AND idCliente='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idUsuario"].Value.ToString() + "'";
                ejecutarConsulta(strCmd);
                MessageBox.Show("ELIMINADO CORRECTAMENTE", "Advertencia");
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUDO ELIMINAR EL REGISTRO", "Error");
                return false;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editando = true;
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["usuario"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["contraseña"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["confirContraseña"].Value.ToString();
            }
        }
        
        /*****************
         * BOTON ELIMINAR
         ******************/
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                borrar();
                cargarDatos();
                dataGridView1.DataSource = DT;
            }
        }


        

    }
}
