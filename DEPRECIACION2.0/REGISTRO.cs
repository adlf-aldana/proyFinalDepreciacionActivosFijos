using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* LIBRERIA PARA LA BB*/
using System.Data.SqlClient;

namespace DEPRECIACION2._0
{
    public partial class REGISTRO : Form
    {
        /*****************************
         * COMANDO BASICOS PARA LA BD
         *****************************/
        private SqlConnection sqlCon;
        private SqlCommand sqlCmd;
        private String strCmd;
        private DataTable dt;
        private SqlDataAdapter sqlDa;
        private Boolean editando;
        private DataTable dt1;
        private DataTable dt2;
        private DataTable dt3;


        public REGISTRO()
        {
            InitializeComponent();

            try
            {
                sqlCon = new SqlConnection("Server=localhost;Database=sis325;Trusted_Connection=True; MultipleActiveResultSets=true");
                sqlCon.Open();
            }
            catch (SqlException)
            {
                MessageBox.Show("NO SE PUEDE CONECTAR CON LA BASE DE DATOS");
                Application.Exit();
            }

        }


        /****************************
         * ACTUALIZA EL DATAGRIDVIEW
         ****************************/
        private void actualizarTabla()
        {
            dt = new DataTable();
            strCmd = "select * from registro";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt);
        }

        /****************************
         * VALOR RECUPERA ACTIVO FIJO
         *****************************/
        private void actualizarTabla1()
        {
            dt1 = new DataTable();
            strCmd = "select * from activoFijo";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt1);
        }

        /****************************************
         * RECUPERA VALORES DE RECURSOS HUMANOS
         ****************************************/
        private void actualizarTabla2()
        {
            dt2 = new DataTable();
            strCmd = "select * from recursosHumanos";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt2);
        }
        
        /********************************
         * RECUPERA VALORES DE UBICACION
         *********************************/
        private void actualizarTabla3()
        {
            dt3 = new DataTable();
            strCmd = "select * from ubicacion";
            sqlCmd = new SqlCommand(strCmd, sqlCon);
            sqlDa = new SqlDataAdapter(sqlCmd);
            sqlDa.Fill(dt3);
        }

        private void REGISTRO_Load(object sender, EventArgs e)
        {
            actualizarTabla();
            registroDataGridView.DataSource = dt;
            actualizarTabla1();
            idActivoFijoComboBox.DisplayMember = "CODIGO_ACTIVO";
            idActivoFijoComboBox.ValueMember = "CODIGO_ACTIVO";
            
            idActivoFijoComboBox.DataSource = dt1;
            actualizarTabla2();
            idPersonalComboBox.DisplayMember = "CiPersonal";
            idPersonalComboBox.ValueMember = "CiPersonal";
            idPersonalComboBox.DataSource = dt2;
            actualizarTabla3();
            idUbicacionComboBox.DisplayMember = "area";
            idUbicacionComboBox.ValueMember = "area";
            idUbicacionComboBox.DataSource = dt3;
        }



        string respuesta;
        public string SeleccionaIdArea()
        {
            var query = "select id_ubicacion from ubicacion where area='" + idUbicacionComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["id_ubicacion"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }

        

        private void idUbicacionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = SeleccionaIdArea();

            DateTime fechahoy = new DateTime();
            fechahoy = DateTime.Today;
            label2.Text = fechahoy.ToShortDateString();

        }

       // string respuesta1;
        public string SeleccionaIdPersonal()
        {
            var query = "select Nombres from recursosHumanos where CiPersonal='" + idPersonalComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["Nombres"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }

        public string SeleccionaApellidoPat()
        {
            var query = "select ApellidoPat from recursosHumanos where CiPersonal='" + idPersonalComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["ApellidoPat"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }


        private void idPersonalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Nombre=SeleccionaIdPersonal();
            string Apellido=SeleccionaApellidoPat();

            label3.Text = Nombre + " " + Apellido;
            label7.Text = SeleccionaIdPersonal1();
        }

        public string SeleccionaIdActivo()
        {
            var query = "select DESCRIPCION from activoFijo where CODIGO_ACTIVO='" + idActivoFijoComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["DESCRIPCION"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }

        public string SeleccionaId()
        {
            var query = "select ID_ACTIVO from activoFijo where CODIGO_ACTIVO='" + idActivoFijoComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["ID_ACTIVO"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }


        private void idActivoFijoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = SeleccionaIdActivo();
            label6.Text = SeleccionaId();

        }

        public string SeleccionaIdPersonal1()
        {
            var query = "select idCliente from recursosHumanos where CiPersonal='" + idPersonalComboBox.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, sqlCon))
            {
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        respuesta = read["idCliente"].ToString();
                    }
                    return respuesta;
                }
                else
                {
                    throw new Exception("NO SE ENCONTRO EL DETERMINADO ACTIVO");
                }
            }
        }

        private Boolean camposCompletos()
        {
            if (inicioUFVTextBox.Text.Equals("") || finalUFVTextBox.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean guardar()
        {
            try
            {
       
                    strCmd = "insert into registro(idActivoFijo,idPersonal,idUbicacion,fechaRegistro,InicioUFV,finalUFV) VALUES (" + label6.Text + "," + label7.Text + "," + label4.Text + ",'" + label2.Text + "','" + UFVI + "','" + UFVF+ "')";
                    sqlCmd = new SqlCommand(strCmd, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("REGISTRO INSERTADO EXITOSAMENTE", "Aviso");
                    return true;
                
              
            }
            catch (SqlException)
            {
                MessageBox.Show("ERROR: NO SE INSERTO VALORES", "advertencia");
                return false;
            }
        }

        double UFVI = 0;
        double UFVF = 0;
        /****************
         * BOTON AGREGAR
         ****************/
        private void button1_Click(object sender, EventArgs e)
        {
            if (camposCompletos())
            {
                UFVI = Convert.ToDouble(inicioUFVTextBox.Text);
                UFVF = Convert.ToDouble(finalUFVTextBox.Text);



                if (UFVF > 1 && UFVF < 2 && UFVI > 1 && UFVI < 2)
                {
                    if (UFVF > UFVI)
                    {


                        guardar();
                        actualizarTabla();
                        registroDataGridView.DataSource = dt;
                        inicioUFVTextBox.Clear();
                        finalUFVTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("VALOR UFVF TIENE QUE SER MENOR AL VALOR UFVI ", "ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("VALORES DE LOS UFVS INCORRECTOS, VALORES TIENE QUE SER MAYOR A 1 Y NENOR QUE 2 ", "ERROR");

                }
           




               
            }
            else
            {
                MessageBox.Show("VERIFIQUE TODOS LOS CAMPOS DEBEN ESTAR CORRECTOS");
            }
        }

        private void inicioUFVTextBox_TextChanged(object sender, EventArgs e)
        {}

        /*******************
         * BOTON CANCELAR
         *******************/
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 abrir = new Form1();
            abrir.Show();
        }

        /*********************
         * BOTON NUEVO ACTIVO
         *********************/
        private void button2_Click(object sender, EventArgs e)
        {
            ACTIVOS abrir = new ACTIVOS();
            abrir.Show();
        }

        /**************
         * BOTON NUEVO
         **************/
        private void button3_Click(object sender, EventArgs e)
        {
            recursosHumanos abrir = new recursosHumanos();
            abrir.Show();
        }

        /***************************
         * BOTON NUEVO DEPARTAMENTO
         **************************/
        private void button4_Click(object sender, EventArgs e)
        {
            UBICACION abrir = new UBICACION();
            abrir.Show();
        }

        private void inicioUFVTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            BUSCAR_ACTIVO2 buscar = new BUSCAR_ACTIVO2();
            buscar.Show();
        }

        private void idPersonalComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            actualizarTabla2();
            idPersonalComboBox.DisplayMember = "CiPersonal";
            idPersonalComboBox.ValueMember = "CiPersonal";
            idPersonalComboBox.DataSource = dt2;
        }

        private void idActivoFijoComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            actualizarTabla1();
            idActivoFijoComboBox.DisplayMember = "CODIGO_ACTIVO";
            idActivoFijoComboBox.ValueMember = "CODIGO_ACTIVO";
            idActivoFijoComboBox.DataSource = dt1;
        }
    }
}
