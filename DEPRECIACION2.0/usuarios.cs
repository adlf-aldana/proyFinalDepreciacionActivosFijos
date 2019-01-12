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
            string CommandText = "Select idUsuario, CiPersona as 'CI Personal', usuario as Usuario from usuarios";
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
                MessageBox.Show("ERROR: REGISTRO NO INSERTADO"+ex, "Error");
                return false;
            }
        }

        public void limpiarTextBox()
        {
            comboBox1.Text = "";
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

        /***********************
         * BLOQUEA Y DESBLOQUEA 
         * LOS TXTBOXS
         * Y COMBOBOX
         ***********************/
        public void bloquearControladores(bool i)
        {
            if (i == true)
            {
                //Bloqueando
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                comboBox1.Enabled = false;
            }
            else
            {
                //Desbloqueandp
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                comboBox1.Enabled = true;
            }


        }

        char accion = ' ';
        int c = 0;
        /****************
         * BOTON GUARDAR
         ****************/
        private void button1_Click(object sender, EventArgs e)
        {
            if (c == 1)
            {
                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                btnEditar.Name = "Editar";
                btnEliminar.Visible = true;

                bloquearControladores(true);
                accion = 'i';
                //c = 0;
            }
            else if (c == 2)
            {
                accion = 'e';
            }

            if (c == 0)
            {
                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                btnEditar.Name = "Cancelar";
                btnEliminar.Visible = false;
                bloquearControladores(false);
                c = 1;
            }

            switch (accion)
            {
                case 'i':
                    {
                        if (textBox2.Text != textBox3.Text)
                        {
                                MessageBox.Show("Las contraseñas deben ser iguales");

                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                                btnEditar.Name = "Cancelar";
                                btnEliminar.Visible = false;
                                bloquearControladores(false);
                                c = 1;
                        }
                        else if (camposCompletos())
                        {
                            if (MessageBox.Show("¿Esta seguro que desea insertar el registro?", "Insertar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                                btnEditar.Name = "Editar";
                                btnEliminar.Visible = true;

                                bloquearControladores(true);

                                guardar();
                                limpiarTextBox();
                                cargarDatos();
                                c = 0;
                            }
                        } 
                        else
                        {
                            MessageBox.Show("VERIFIQUE TODOS LOS CAMPOS DEBEN ESTAR CORRECTOS");

                            btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                            btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                            btnEditar.Name = "Cancelar";
                            btnEliminar.Visible = false;

                            bloquearControladores(false);
                        }

                        c = 0;
                        break;
                    }
                case 'e':
                    {
                        if (textBox2.Text != textBox3.Text)
                        {
                            MessageBox.Show("Las contraseñas deben ser iguales");
                        }
                        else if (camposCompletos())
                        {
                            if (MessageBox.Show("¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                                btnEditar.Name = "Editar";
                                btnEliminar.Visible = true;
                                label6.Visible = false;
                                textBox4.Visible = false;

                                bloquearControladores(true);
                                c = 0;

                                editar();
                                cargarDatos();
                                dataGridView1.DataSource = DT;
                            }
                        }
                        else
                        {
                            MessageBox.Show("VERIFIQUE TODOS LOS CAMPOS DEBEN ESTAR CORRECTOS");
                            btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                            btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                            btnEditar.Name = "Cancelar";
                            btnEliminar.Visible = false;
                            bloquearControladores(false);
                        }
                    }
                    break;
            }
        }



        /********************************
         * VALIDA QUE TODOS LOS CAMPOS 
         * NO ESTEN VACIOS
         *********************************/
        private bool camposCompletos()
        {
            if (textBox1.Text.Equals("") && textBox2.Text.Equals(""))
            {
                MessageBox.Show("Campo usuario y contraseña vacio");
                return false;
            }
            else if (textBox1.Text.Equals("") && textBox3.Text.Equals(""))
            {
                MessageBox.Show("Campo usuario y repetir contraseña vacio");
                return false;
            }
            else if (textBox2.Text.Equals("") && textBox3.Text.Equals(""))
            {
                MessageBox.Show("Campo contraseña y repetir contraseña vacio");
                return false;
            }
            else if (textBox1.Text.Equals("") && textBox2.Text.Equals("") && textBox3.Text.Equals(""))
            {
                MessageBox.Show("Error: Todos los campos estan vacios");
                return false;
            }
            else
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Campo usuario vacio");
                    return false;
                }
                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Campo contraseña vacio");
                    return false;
                }
                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Campo repetir contraseña vacio");
                    return false;
                }
                return true;
            }

            
        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            if (btnEditar.Name == "Cancelar")
            {
                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                btnEliminar.Visible = true;
                btnEditar.Name = "Editar";
                bloquearControladores(true);
                accion = ' ';
                c = 0;
                limpiarTextBox();
                label6.Visible = false;
                textBox4.Visible = false;
            }
            else if (!(textBox1.Text == ""))
            {

                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                btnEditar.Name = "Cancelar";
                btnEliminar.Visible = false;
                label6.Visible = true;
                textBox4.Visible = true;

                bloquearControladores(false);
                c = 2;
            }
            else
            {
                MessageBox.Show("Elija el elemento que desea editar");
            }
        }

        public void orden(string x)
        {
            if(x == "INSERTAR")
            {
                guardar();
                cargarDatos();
                dataGridView1.DataSource = DT;
                bloquearControladores(true);
                btnAgregar.Text = "NUEVO";
                btnEditar.Text = "CANCELAR";
                btnEliminar.Visible = true;
            }
            if (x == "CANCELAR")
            {
                btnAgregar.Text = "NUEVO";
                btnEditar.Text = "EDITAR";
                bloquearControladores(true);
                btnEliminar.Visible = true;
            }
            if (x == "EDITAR")
            {
                btnAgregar.Text = "GUARDAR";
                btnEditar.Text = "CANCELAR";
                bloquearControladores(false);
                btnEliminar.Visible = false;
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
                    strCmd = "UPDATE usuarios SET CiPersona='" + comboBox1.Text + "', usuario='" + textBox1.Text + "', contraseña= '"+textBox2.Text+"', confirContraseña= '"+textBox3.Text+"' WHERE idUsuario='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idUsuario"].Value.ToString() + "'";
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
                strCmd = "DELETE FROM usuarios WHERE idUsuario='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idUsuario"].Value.ToString() + "'" + "AND CiPersona='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CI Personal"].Value.ToString() + "'";
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
                //textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["contraseña"].Value.ToString();
                //textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["confirContraseña"].Value.ToString();
            }
        }
        
        /*****************
         * BOTON ELIMINAR
         ******************/
        private void button3_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == ""))
                {
                if (MessageBox.Show("¿Esta seguro que desea eliminar al usuario "+textBox1.Text+"?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                borrar();
                cargarDatos();
                dataGridView1.DataSource = DT;
                c = 0;
                limpiarTextBox();
                accion = ' ';
                }

            }
            else
            {
                MessageBox.Show("Error: No se puede eliminar, existen campos vacios");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
