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
    public partial class RUBROS2 : Form
    {

        /*****************************
         * COMANDO BASICOS PARA LA BD
         *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DA;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private String strCmd;
        private Boolean editando;
        private string nn;

        public RUBROS2()
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

        // CARGAR BD
        private void cargarDatos()
        {
            obtConexion();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "Select *from rubro";
            DA = new SqlDataAdapter(CommandText, sql_con);
            DS.Reset();
            DA.Fill(DS);
            DT = DS.Tables[0];
            dataGridView1.DataSource = DT;
            sql_con.Close();
        }

        /********************************
         * VALIDA QUE TODOS LOS CAMPOS 
         * NO ESTEN VACIOS
         *********************************/
        private Boolean camposCompletos()
        {
            if (txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("Falta completar el campo Descripción");
                return false;
            }
            else if (txtAnios.Text.Equals(""))
            {
                MessageBox.Show("Seleccione año de vida util");
                return false;
            }else
                return true;
        }

        /************************
         * INSERTA DATOS A LA BD
         ************************/ 
        private Boolean guardar()
        {
            try
            {
                strCmd = "INSERT INTO rubro (descripcion,vida_util,Porc_DEPRECIACION) VALUES ('" + txtDescripcion.Text + "'," + txtAnios.Text + "," + txtCoeficiente.Text + ")";
                ejecutarConsulta(strCmd);
                limpiarTextBox();
                MessageBox.Show("REGISTRO INSERTADO EXITOSAMENTE", "Aviso");
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show(txtDescripcion.Text + txtAnios.Text + txtCoeficiente.Text);
                MessageBox.Show("ERROR: REGISTRO NO INSERTADO", "Error");
                return false;
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
                    strCmd = "UPDATE rubro SET descripcion='" + txtDescripcion.Text + "',vida_util=" + txtAnios.Text + ",Porc_DEPRECIACION=" + txtCoeficiente.Text + " WHERE id_rubro=" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id_rubro"].Value.ToString() + "";
                    ejecutarConsulta(strCmd);
                    limpiarTextBox();
                    MessageBox.Show("REGISTRO EDITADO EXITOSAMENTE", "Aviso");
                    editando = false;
                }
                return true;

            }
            catch (SqlException)
            {
                MessageBox.Show(txtDescripcion.Text + txtAnios.Text + txtCoeficiente.Text);
                MessageBox.Show("ERROR: NO SE ACTUALIZARON LOS DATOS", "Error");
                return false;
                // throw;
            }
        }

        /******************************
         * ELIMINA UN REGISTRO DE LA DB
         ******************************/
        private Boolean borrar()
        {
            try
            {
                strCmd = "DELETE FROM rubro WHERE descripcion='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["descripcion"].Value.ToString() + "'" + "AND id_rubro='" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id_rubro"].Value.ToString() + "'";
                ejecutarConsulta(strCmd);
                limpiarTextBox();
                MessageBox.Show("ELIMINADO CORRECTAMENTE", "AVISO");
                return true;
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUDO ELIMINAR EL REGISTRO", "Error");
                return false;
            }
        }


        /************************************
         * BUSCA UN RUBRO POR LA DESCRIPCION
         ************************************/
        private void buscar()
        {
            DT = new DataTable();
            strCmd = "SELECT * FROM rubro WHERE descripcion='" + txtDescripcion.Text + "'";
            sql_cmd = new SqlCommand(strCmd, sql_con);
            DA = new SqlDataAdapter(sql_cmd);
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
        }


        /***********************************
         * SELECCIONA VALOR DEL DATAGRIDVIEW
         ***********************************/ 
        private void RUBROS2_Load(object sender, EventArgs e)
        {
            cargarDatos();
            dataGridView1.DataSource = DT;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        /*******************
         * BOTON PARA BUSCAR
         *******************/
        private void button2_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtAnios_Validating(object sender, CancelEventArgs e)
        {
            int valor;
            string texto=txtAnios.Text;
            bool ok = int.TryParse(texto, out valor);
            /*
            if (!ok)
            {
                //MessageBox.Show("ERROR: VALOR INCORRECTO!");
                txtAnios.Items.Clear();
            } */           
        }

        private void button5_Click(object sender, EventArgs e)
        {}

        /******************************************
         * LIMPIA LOS TEXTBOX'S LUEGO DE UN EVENTO
         ******************************************/
        public void limpiarTextBox()
        {
            txtDescripcion.Clear();
            txtAnios.SelectedIndex = 0;
            txtCoeficiente.Clear();
            btnAgregar.Focus();
        }

        private void pxbAgregar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtAnios.Text = "";
            txtCoeficiente.Text = "";
            txtDescripcion.Focus();
        }

        public void bloquearControladores(bool i)
        {
            if (i == true)
            {
                //Bloqueando
                txtDescripcion.ReadOnly = true;
                txtAnios.Enabled = false;
            }
            else
            {
                //Desbloqueandp
                txtAnios.Enabled = true;
                txtDescripcion.ReadOnly = false;
            }
        }

        char accion = ' ';
        int c = 0;
        /*****************
         * BOTON GUARDAR
         *****************/
        private void pxbGuardar_Click(object sender, EventArgs e)
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
                            if (MessageBox.Show("VERIFIQUE QUE TODOS LOS CAMPOS ESTEN CORRECTOS \n ¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        /******************
         * BOTON ELIMINAR
         *****************/
        private void pxbEliminar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar el siguente registro registro?\n\n"+"Descripcion: " + txtDescripcion.Text +"\n"+"Años de Vida util: "+txtAnios.Text+"\n"+"Coeficiente de Depreciacion: "+txtCoeficiente.Text, "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    borrar();
                    cargarDatos();
                    dataGridView1.DataSource = DT;
                }
            }
            else
            {
                MessageBox.Show("Seleccione el dato que quiere eliminar");
            }

        }

        /*****************
         * BOTON EDITAR
         *****************/
        private void pxbEditar_Click(object sender, EventArgs e)
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
            else if (!(txtDescripcion.Text == ""))
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

        private void pxbCancelar_Click(object sender, EventArgs e)
        { }

        private void label9_Click(object sender, EventArgs e)
        {}

        private void label8_Click(object sender, EventArgs e)
        {}

        private void label7_Click(object sender, EventArgs e)
        {}

        private void label6_Click(object sender, EventArgs e)
        {}

        private void label10_Click(object sender, EventArgs e)
        {}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            REGISTRO abrir = new REGISTRO();
            abrir.Show();
        }

        /************************************
         * RECUPERA VALORES DEL DATAGRIDVIEW 
         * A LOS TEXTBOX'S RESPECTIVOS
         ************************************/
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editando = true;
                txtDescripcion.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["descripcion"].Value.ToString();
                txtAnios.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["vida_util"].Value.ToString();
                txtCoeficiente.Text = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["Porc_DEPRECIACION"].Value.ToString();

            }
        }

        private void txtAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vidaUtil = int.Parse(txtAnios.Text);

            switch (vidaUtil)
            {
                case 0: nn = " "; 
                    break;
                case 4: nn = "25";
                    break;
                case 5: nn = "20";
                    break;
                case 8: nn = "12.5";
                    break;
                case 10: nn = "10";
                    break;
                case 20: nn = "5";
                    break;
                case 40: nn = "2.5";
                    break;
            }
            txtCoeficiente.Text = nn.ToString();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
        }
    }
}
