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
    public partial class UBICACION : Form
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

        public UBICACION()
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
            string CommandText = "Select *from ubicacion";
            DB = new SqlDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            ubicacionDataGridView.DataSource = DT;
            sql_con.Close();
        }

        /***********************************
         * SELECCIONA VALOR DEL DATAGRIDVIEW
         ***********************************/ 
        private void UBICACION_Load(object sender, EventArgs e)
        {
            cargarDatos();
            ubicacionDataGridView.DataSource = DT;
            ubicacionDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ubicacionDataGridView.MultiSelect = false;
        }

         /********************************
         * VALIDA QUE TODOS LOS CAMPOS 
         * NO ESTEN VACIOS
         *********************************/
        private Boolean camposCompletos()
        {
            if (areaTextBox.Text.Equals("") || descripcionUbicacionTextBox.Text.Equals("") )
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
                strCmd = "INSERT INTO ubicacion (area, descripcionUbicacion) VALUES ('" + areaTextBox.Text + "','" + descripcionUbicacionTextBox.Text + "')";
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

        /*****************
         * BOTON GUARDAR
         ****************/
        private void button1_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                if (MessageBox.Show("¿Esta seguro que desea insertar el registro?", "Insertar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    guardar();
                    cargarDatos();
                    ubicacionDataGridView.DataSource = DT;
                }
            }
            else
            {
                MessageBox.Show("VERIFIQUE TODOS LOS CAMPOS DEBEN ESTAR COMPLETOS");
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
                    strCmd = "UPDATE ubicacion SET area='" + areaTextBox.Text + "',descripcionUbicacion='" + descripcionUbicacionTextBox.Text + "' WHERE id_ubicacion=" + ubicacionDataGridView.Rows[ubicacionDataGridView.SelectedRows[0].Index].Cells["id_ubicacion"].Value.ToString() + "";
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

        /****************
         * BOTON EDITAR
         ****************/
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea editar el registro?", "Editar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                editar();
                cargarDatos();
                ubicacionDataGridView.DataSource = DT;
            }
        }

        
        private void ubicacionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        /******************************
         * ELIMINA UN REGISTRO DE LA DB
         ******************************/
        private Boolean borrar()
        {
            try
            {
                strCmd = "DELETE FROM ubicacion WHERE area='" + ubicacionDataGridView.Rows[ubicacionDataGridView.SelectedRows[0].Index].Cells["area"].Value.ToString() + "'" + "AND id_ubicacion='" + ubicacionDataGridView.Rows[ubicacionDataGridView.SelectedRows[0].Index].Cells["id_ubicacion"].Value.ToString() + "'";
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
         ******************/
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea eliminar el registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                borrar();
                cargarDatos();
                ubicacionDataGridView.DataSource = DT;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        { }

        /******************************************
         * LIMPIA LOS TEXTBOX'S LUEGO DE UN EVENTO
         ******************************************/
        public void limpiarTextBox()
        {
            areaTextBox.Text = "";
            descripcionUbicacionTextBox.Text = "";
            areaTextBox.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { Close(); }

        /************************************
         * RECUPERA VALORES DEL DATAGRIDVIEW 
         * A LOS TEXTBOX'S RESPECTIVOS
         ************************************/
        private void ubicacionDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ubicacionDataGridView.SelectedRows.Count > 0)
            {
                editando = true;
                areaTextBox.Text = ubicacionDataGridView.Rows[ubicacionDataGridView.SelectedRows[0].Index].Cells["area"].Value.ToString();
                descripcionUbicacionTextBox.Text = ubicacionDataGridView.Rows[ubicacionDataGridView.SelectedRows[0].Index].Cells["descripcionUbicacion"].Value.ToString();
            }
        }

        
    }
}
