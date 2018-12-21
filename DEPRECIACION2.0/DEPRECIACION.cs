using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEPRECIACION2._0
{
    public partial class DEPRECIACION : Form
    {
        private SqlConnection sqlCon;
        private SqlCommand sqlCmd;
        private String strCmd;
        private DataTable dt;
        private SqlDataAdapter sqlDa;
        private Boolean editando;
        private DataTable dt1;
        private DataTable dt2;
        private DataTable dt3;

        public DEPRECIACION()
        {
            InitializeComponent();

            try
            {
                /* OBTENEMOS LA CONEXION CON LA BD*/
                sqlCon = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True; MultipleActiveResultSets=true");
                sqlCon.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo conectar con la base de datos");
                Application.Exit();
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {}

        /********************************
         * SELECCIONA TABLA DEPRECIACION
         *********************************/
        private void actualizarTabla()
        {
            dt = new DataTable();
            strCmd = "select * from depreciacion";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
        }

        private void actualizarTabla1()
        {
            dt2 = new DataTable();
            strCmd = "select * from recursosHumanos";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt2);
        }

        private void DEPRECIACION_Load(object sender, EventArgs e)
        {
            actualizarTabla();
            dataGridView1.DataSource = dt;
            
        }

        private void idActivoFijoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
