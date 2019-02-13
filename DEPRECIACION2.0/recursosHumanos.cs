using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* LIBRERIA PARA LA BB*/
using System.Data.SqlClient;

namespace DEPRECIACION2._0
{
    public partial class recursosHumanos : Form
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

        public recursosHumanos()
        {
            InitializeComponent();
            bloquearControladores(true);
        }
        /********************************
         * OBTIENE LA CONEXION CON LA BD
         ********************************/
        private void obtConexion()
        {
            sql_con = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True");
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
            string CommandText = "Select *from recursosHumanos";
            DB = new SqlDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        private void recursosHumanosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
          // this.recursosHumanosBindingSource.EndEdit();
          // this.tableAdapterManager.UpdateAll(this.sis325DataSet);
        }

        private void recursosHumanos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.recursosHumanos' Puede moverla o quitarla según sea necesario.
           // this.recursosHumanosTableAdapter.Fill(this.sis325DataSet.recursosHumanos);
        }

        /********************************
         * VALIDA QUE TODOS LOS CAMPOS 
         * NO ESTEN VACIOS
         *********************************/
        private Boolean camposCompletos()
        {
            if (nombresTextBox.Text.Equals("") || apellidoMatTextBox.Text.Equals("") || apellidoPatTextBox.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
        /************************
         * INSERTA DATOS A LA BD
         ************************/
        private Boolean guardar()
        {
            try
            {
                string ciPersonal = ciPersonalTextBox.Text;
                string nombres = nombresTextBox.Text;
                string apellidoPat = apellidoPatTextBox.Text;
                string apelidoMat = apellidoMatTextBox.Text;
                string sexo = sexoComboBox.Text;
                string direccion = dirTextBox.Text;
                string profesion = profesTextBox.Text;
                string email = emailTextBox.Text;
                string cargo = cargoComboBox.Text;

                string procedencia = procedenciaComboBox.Text;

                string c1 = "INSERT INTO recursosHumanos (CiPersonal,Nombres,ApellidoPat,ApellidoMat,Sexo,Dir,Profes,Email,Cargo,procedencia) VALUES ('" + ciPersonal + "','" + nombres + "','" + apellidoPat + "','" + apelidoMat + "','" + sexo + "','" + direccion + "','" + profesion + "','" + email + "','" + cargo + "','" + procedencia + "');";
                ejecutarConsulta(c1);
                cargarDatos();
                limpiarTextBox();
                MessageBox.Show("DATOS INSERTADOS CORRECTAMENTE");
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("ERROR: REGISTRO NO INSERTADO", "Error");
                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                btnEditar.Name = "Cancelar";
                btnEliminar.Visible = false;
                bloquearControladores(false);
                c = 1;
                return false;
            }

        }

        public void bloquearControladores(bool i)
        {
            if (i == true)
            {
                //Bloqueando
                ciPersonalTextBox.ReadOnly = true;
                nombresTextBox.ReadOnly = true;
                apellidoPatTextBox.ReadOnly = true;
                apellidoMatTextBox.ReadOnly = true;
                dirTextBox.ReadOnly = true;
                profesTextBox.ReadOnly = true;
                emailTextBox.ReadOnly = true;
                ciPersonalTextBox.Focus();
            }
            else
            {
                //Desbloqueandp
                ciPersonalTextBox.ReadOnly = false;
                nombresTextBox.ReadOnly = false;
                apellidoPatTextBox.ReadOnly = false;
                apellidoMatTextBox.ReadOnly = false;
                dirTextBox.ReadOnly = false;
                profesTextBox.ReadOnly = false;
                emailTextBox.ReadOnly = false;
                ciPersonalTextBox.Focus();
            }
        }


        char accion = ' ';
        int c = 0;
        /****************
         * BOTON GUARDAR
         ***************/
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
                        if (camposCompletos())
                        {
                            if (MessageBox.Show("¿Esta seguro que desea insertar el registro?", "Insertar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                                btnEditar.Name = "Editar";
                                btnEliminar.Visible = true;

                                bloquearControladores(true);

                                guardar();
                                cargarDatos();
                                dataGridView1.DataSource = DT;
                            }
                            else
                            {
                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                                btnEditar.Name = "Cancelar";
                                btnEliminar.Visible = false;
                                bloquearControladores(false);
                                c = 1;
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
                        if (camposCompletos())
                        {
                            if (MessageBox.Show("¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.agregar;
                                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.editar;
                                btnEditar.Name = "Editar";
                                btnEliminar.Visible = true;

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

        /************************************
         * MODIFICA LOS VALORES DE UNA TABLA
         ************************************/
        /*private Boolean editar()
        {
            try
            {
                if (editando)
                {
                    if (MessageBox.Show("¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string ciPersonal = ciPersonalTextBox.Text;
                        string nombres = nombresTextBox.Text;
                        string apellidoPat = apellidoPatTextBox.Text;
                        string apelidoMat = apellidoMatTextBox.Text;
                        string sexo = sexoComboBox.Text;
                        string direccion = dirTextBox.Text;
                        string profesion = profesTextBox.Text;
                        string email = emailTextBox.Text;
                        string cargo = cargoComboBox.Text;
                        string procedencia = procedenciaComboBox.Text;

                        string c1 = "UPDATE recursosHumanos SET CiPersonal='" + ciPersonal + "',Nombres='" + nombres + "', ApellidoPat='" + apellidoPat + "',ApellidoMat='" + apelidoMat + "', Sexo='" + sexo + "', Dir='" + direccion + "', Profes='" + profesion + "', Email='" + email + "', Cargo='" + cargo + "', procedencia= '" + procedencia + "' WHERE idCliente='" + recursosHumanosDataGridView.Rows[recursosHumanosDataGridView.SelectedRows[0].Index].Cells["idCliente"].Value.ToString() + "';";
                        ejecutarConsulta(c1);
                        cargarDatos();
                        limpiarTextBox();
                        MessageBox.Show("ACTUALIZADO LOS DATOS CORRECTAMENTE!");
                    }
                    editando = false;
                }
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE ACTUALIZARON LOS DATOS", "Error");
                return false;
            }
        }*/
        private Boolean editar()
        {
            try
            {
                if (editando)
                {
                    strCmd = "UPDATE recursosHumanos SET CiPersonal='" + ciPersonalTextBox.Text + "',Nombres='" + nombresTextBox.Text + "',ApellidoPat='" + apellidoPatTextBox.Text + "',ApellidoMat='" + apellidoMatTextBox.Text + "',Dir='" + dirTextBox.Text + "',Profes='" + profesTextBox.Text + "',Email='" + emailTextBox.Text + "',Cargo='" + cargoComboBox.Text + "',procedencia='" + procedenciaComboBox.Text + "',Sexo='" + sexoComboBox.Text + "' WHERE CiPersonal=" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CiPersonal"].Value.ToString() + "";
                    ejecutarConsulta(strCmd);
                    MessageBox.Show("REGISTRO EDITADO EXITOSAMENTE", "Aviso");
                    editando = false;
                }
                return true;

            }
            catch (SqlException)
            {
                MessageBox.Show(ciPersonalTextBox.Text + nombresTextBox.Text + apellidoPatTextBox.Text);
                MessageBox.Show("NO SE ACTUALIZARON LOS DATOS", "Error");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {}

        /******************************
         * ELIMINA UN REGISTRO DE LA DB
         ******************************/
        private Boolean borrar()
        {
            try
            {
                strCmd = "delete from recursosHumanos WHERE idCliente='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["idCliente"].Value.ToString() + "'" + "AND CiPersonal='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CiPersonal"].Value.ToString() + "'";
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

        /*****************
         * BOTON ELIMINAR
         *****************/
        private void button3_Click(object sender, EventArgs e)
        { }

        private void button4_Click(object sender, EventArgs e)
        { }


        private void button5_Click(object sender, EventArgs e)
        {}

        private void recursosHumanosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {}

        private void nombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void apellidoPatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void apellidoMatTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {}

        
        private void ciPersonalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {}

        private void sexoLabel_Click(object sender, EventArgs e)
        {}

        private void sexoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void idClienteLabel_Click(object sender, EventArgs e)
        {}

        private void idClienteTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void ciPersonalLabel_Click(object sender, EventArgs e)
        {}

        private void ciPersonalTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void nombresLabel_Click(object sender, EventArgs e)
        {}

        private void nombresTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void apellidoPatLabel_Click(object sender, EventArgs e)
        {}

        private void apellidoPatTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void apellidoMatLabel_Click(object sender, EventArgs e)
        {}

        private void apellidoMatTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void dirLabel_Click(object sender, EventArgs e)
        {}

        private void dirTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void profesLabel_Click(object sender, EventArgs e)
        {}

        private void profesTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void emailLabel_Click(object sender, EventArgs e)
        {}

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {}

        private void cargoLabel_Click(object sender, EventArgs e)
        {}

        private void cargoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void procedenciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void recursosHumanosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}
        
        /***********************************
         * SELECCIONA VALOR DEL DATAGRIDVIEW
         ***********************************/ 
        private void recursosHumanos_Load_1(object sender, EventArgs e)
        {
            cargarDatos();
            dataGridView1.DataSource = DT;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        
        /*****************
         * BOTON ELIMINAR
         *****************/
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar el siguente registro registro?\n\n"+"CI: "+ciPersonalTextBox.Text+"\n Nombres: "+nombresTextBox.Text+"\n Apellidos: "+apellidoPatTextBox.Text+" "+apellidoMatTextBox.Text+"\n Direccion: "+dirTextBox.Text+"\n Profesion: "+profesTextBox.Text+"\n Telefono: "+emailTextBox.Text+"\n Cargo: "+cargoComboBox.Text, "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                borrar();
                cargarDatos();
                dataGridView1.DataSource = DT;
                c = 0;
                limpiarTextBox();
                accion = ' ';
            }
        }

        private void recursosHumanosDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {}

        
        /***************
         * BOTON EDITAR
         ***************/
        private void button2_Click_1(object sender, EventArgs e)
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
            }
            else if (!(ciPersonalTextBox.Text == ""))
            {

                btnAgregar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.guardar;
                btnEditar.BackgroundImage = DEPRECIACION2._0.Properties.Resources.cancelar;
                btnEditar.Name = "Cancelar";
                btnEliminar.Visible = false;

                bloquearControladores(false);
                c = 2;
            }
            else
            {
                MessageBox.Show("Elija el elemento que desea editar");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {}

        public void limpiarTextBox()
        {
            ciPersonalTextBox.Text = "";
            nombresTextBox.Text = "";
            apellidoPatTextBox.Text = "";
            apellidoMatTextBox.Text = "";
            dirTextBox.Text = "";
            profesTextBox.Text = "";
            emailTextBox.Text = "";
            ciPersonalTextBox.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /************************************
         * RECUPERA VALORES DEL DATAGRIDVIEW 
         * A LOS TEXTBOX'S RESPECTIVOS
         ************************************/
        private void recursosHumanosDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editando = true;
                ciPersonalTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CiPersonal"].Value.ToString();
                nombresTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Nombres"].Value.ToString();
                apellidoPatTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ApellidoPat"].Value.ToString();
                apellidoMatTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["ApellidoMat"].Value.ToString();
                dirTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Dir"].Value.ToString();
                profesTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Profes"].Value.ToString();
                emailTextBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Email"].Value.ToString();
                cargoComboBox.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Cargo"].Value.ToString();

            }
        }

        /*******************************************
         * VALIDANDO NUMEROS EN TEXTBOX CI PERSONAL
         *******************************************/
        private void ciPersonalTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /************************************
         * VALIDANDO LETRAS EN TEXTBOX NOMBRE
         ************************************/
        private void nombresTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        /************************************************
         * VALIDANDO LETRAS EN TEXTBOX APELLIDO PATERNO
         ************************************************/
        private void apellidoPatTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        /***********************************************
         * VALIDANDO LETRAS EN TEXTBOX APELLIDO MATERNO
         **********************************************/
        private void apellidoMatTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        /*******************************************
         * VALIDANDO NUMEROS ENTEROS EN TELEFONO
         ****************************************/
        private void emailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        

    }
}
