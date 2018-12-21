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
    class crearDbTablas
    {
        /*****************************
         * COMANDO BASICOS PARA LA BD
         *****************************/
        private SqlConnection sql_con;
        private SqlCommand sql_cmd;
        private SqlDataAdapter DA;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private DataTable DT1 = new DataTable();

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

        public void creacion()
        {
            string str = "";
            sql_con = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            str = "if not exists (select *from master.dbo.sysdatabases where name='sis325') begin CREATE DATABASE sis325 end";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Base de datos creada");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error: No se creo la base de datos");
            }


            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'ubicacion') CREATE TABLE ubicacion(id_ubicacion int IDENTITY(1,1) NOT NULL,area varchar(50) ,descripcionUbicacion varchar(50) PRIMARY KEY(id_ubicacion))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Tabla ubicacion creada");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error: No se creo la tabla ubicacion");
            }


            obtConexion();
            str = " if not exists (select *from sysobjects where type= 'U' and name = 'rubro') CREATE TABLE rubro([id_rubro] [int] IDENTITY(10000,10000) NOT NULL, [descripcion] [varchar](50) NULL, [vida_util] [int] NULL, [Porc_DEPRECIACION] [float] NULL, [total] [float] NULL, PRIMARY KEY (id_rubro))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla rubro creada");
            }
            catch (SqlException)
            {
                MessageBox.Show("Error: No se creo la tabla rubro");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'recursosHumanos') CREATE TABLE recursosHumanos(	[idCliente] [int] IDENTITY(1,1) NOT NULL,[CiPersonal] [varchar](50) NOT NULL,[Nombres] [varchar](50) NOT NULL,[ApellidoPat] [varchar](50) NULL,[ApellidoMat] [varchar](50) NULL,[Sexo] [char](1) NULL,[Dir] [varchar](50) NULL,[Profes] [varchar](50) NULL,[Email] [varchar](50) NULL,[Cargo] [varchar](50) NULL,[procedencia] [varchar](4) NOT NULL,PRIMARY KEY(idCliente))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //   MessageBox.Show("Tabla recursos humanos creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla recursosHumanos");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'activoFijo') CREATE TABLE activoFijo([ID_ACTIVO] [int] IDENTITY(1,1) NOT NULL,[ID_RUBRO] [int] NULL,[CODIGO_ACTIVO] [int] NULL,[DESCRIPCION] [VARCHAR](500) NULL,[MARCA] [varchar](200) NULL,[PROCEDENCIA] [varchar](200) NULL,[COLOR] [varchar](200) NULL,[FECHA_COMPRA] [datetime] NULL,[VALOR_COMPRA] [float] NULL,[ESTADO] [varchar](25) NULL,PRIMARY KEY (ID_ACTIVO),FOREIGN KEY (ID_RUBRO) references RUBRO(ID_RUBRO))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla ACTIVOS FIJOS creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla activoFijo");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'registro') CREATE TABLE registro(	[idRegistro] [int] IDENTITY(1,1) NOT NULL,[idActivoFijo] [int] NOT NULL,[idPersonal] [int] NOT NULL,[idUbicacion] [int] NOT NULL,[fechaRegistro] [datetime] NULL,[InicioUFV] [FLOAT] NULL,[finalUFV] [FLOAT] NULL,PRIMARY KEY (idRegistro),foreign key(idActivoFijo) references activofijo(id_activo),foreign key (idPersonal) references recursosHumanos(idCliente),FOREIGN KEY (idUbicacion) references ubicacion(id_ubicacion))";
            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                 //MessageBox.Show("Tabla registro creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla registro");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'depreciacion') CREATE TABLE depreciacion([id_depreciacion] [int] IDENTITY(1,1) NOT NULL,[id_registro] [int] NOT NULL,[valorIncremento] [float] NULL,[valorActual] [float] NULL,[depInicial] [float] NULL,[depIncremento] [float] NULL,[depActual] [float] NULL,[depGestion] [float] NULL,[depAcumulada] [float] NULL,[totalDepreciacionAcumulada] [float] NULL,[calculoDepreciacion] [float] NULL,PRIMARY KEY(id_depreciacion),FOREIGN KEY(id_registro)REFERENCES registro(idRegistro))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla depreciacion creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla depreciacion");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'usuario') CREATE TABLE usuarios(	[idUsuario] [int] IDENTITY(1,1) NOT NULL,[CiPersona] [varchar](50) NOT NULL, [usuario] [varchar](50) NULL, [contraseña] [varchar](50) NULL, [confirContraseña] [varchar](50) NULL, PRIMARY KEY(idUsuario));";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla depreciacion creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla USUARIO");
            }

            obtConexion();
            str = "if not exists (select *from sysobjects where type= 'U' and name = 'iniciarSesion') CREATE TABLE iniciarSesion([id_registro_usuario] [int] IDENTITY(1,1) NOT NULL,[NombreUsuario] [text] NULL,	[Contraseña] [text] NULL,	PRIMARY KEY (id_registro_usuario)) ";
            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla depreciacion creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla USUARIO");
            }
            
            obtConexion();
            str = " INSERT INTO usuarios(CiPersona,usuario,contraseña) VALUES ('11111111','admin','admin')";
            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla depreciacion creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla USUARIO");
            }

            obtConexion();
            str = "CREATE TRIGGER [dbo].[TR_usuario] ON usuarios FOR INSERT  AS DECLARE @idUsuario INT, @usuario varchar(50), @CANT INT SET @usuario =(SELECT usuario FROM INSERTED) SET @CANT=(SELECT COUNT(idUsuario) FROM usuarios WHERE idUsuario=@idUsuario)  if(@CANT>1)  begin  rollback tran end";
            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //    MessageBox.Show("Tabla depreciacion creada");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo la tabla USUARIO");
            }

            obtConexion();
            str = "CREATE TRIGGER [dbo].[TR_CODAF] ON [dbo].[activoFijo] FOR INSERT AS DECLARE @ID_ACTIVO INT, @ID_RUBRO INT, @CANT INT,@total FLOAT SET @ID_ACTIVO =(SELECT ID_ACTIVO FROM INSERTED) SET @ID_RUBRO =(SELECT ID_RUBRO FROM INSERTED) SET @CANT=(SELECT COUNT (ID_ACTIVO) FROM activoFijo WHERE ID_RUBRO=@ID_RUBRO) set @total =(select sum(VALOR_COMPRA)FROM activoFijo WHERE ID_RUBRO=@ID_RUBRO) UPDATE activoFijo SET CODIGO_ACTIVO= @ID_RUBRO+ @CANT WHERE  ID_ACTIVO= @ID_ACTIVO AND ID_RUBRO=@ID_RUBRO UPDATE rubro set total = @total where ID_RUBRO=@ID_RUBRO SELECT * FROM rubro SELECT * FROM activoFijo";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //   MessageBox.Show("Trigger creado correctament");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo el trigger TR_CODAF");
            }

            obtConexion();
            str = "create TRIGGER TR_DESR ON rubro FOR INSERT AS  DECLARE  @des VARCHAR (50), @id_rubro int, @cont int SET @id_rubro = (SELECT id_rubro FROM INSERTED) SET @des =(SELECT descripcion from INSERTED) set @cont =(select count(id_rubro) from rubro where descripcion=@des) IF(@cont>1) BEGIN  RAISERROR('EL RUBRO CON LA DESCRIPCION INDICADA, YA EXISTE...',2,16) ROLLBACK TRAN END";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Trigger creado correctament");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo el trigger TR_DESR");
            }


            obtConexion();
            str = "create TRIGGER TR_CI_PERSONAL ON recursosHumanos FOR INSERT, UPDATE AS  DECLARE  @CI_PER VARCHAR (50), @idCliente int, @cont int  SET @CI_PER  = (SELECT CiPersonal FROM INSERTED) SET @idCliente =(SELECT idCliente from INSERTED) set @cont =(select count(idCliente) from recursosHumanos where CiPersonal=@CI_PER) IF(@cont>1) BEGIN RAISERROR('EL PERSONAL CON CI INDICADA, YA ESTA REGISTRADO...',2,16) ROLLBACK TRAN END";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Trigger creado correctament");
            }
            catch (SqlException)
            {
              //  MessageBox.Show("Error: No se creo el trigger TR_CI_PERSONAL");
            }

            obtConexion();
            str = "CREATE TRIGGER TR_RUBRO ON rubro FOR INSERT AS DECLARE @id INT, @des varchar(50) , @vidautil INT,@total int SET @id =(SELECT id_rubro FROM INSERTED) SET @des=(SELECT descripcion FROM INSERTED) SET @vidautil =(select vida_util from inserted) set @total=(select count(id_rubro) from rubro) UPDATE rubro SET Porc_DEPRECIACION =100/@vidautil, total=  @total WHERE id_rubro=@id";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Trigger creado correctament");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo el trigger TR_RUBRO");
            }
            //MessageBox.Show("Todo fue creado correctamente");
            obtConexion();
            str = "CREATE trigger [dbo].[tr_registro] on [dbo].[registro] for insert as declare @ir_registro int, @id_activo int, @fecha datetime, @i FLOAT,@f FLOAT,@vc FLOAT, @V_INCREMENTO FLOAT,@dif_m FLOAT, @v_act float,@a_vidautil int, @cof float,@DEP_GESTION FLOAT set @ir_registro=(select idRegistro from inserted) set @id_activo=(select idActivoFijo from inserted) set @fecha=(select fechaRegistro from inserted) set @i=(select InicioUFV from inserted) set @f=(select finalUFV from inserted) set @vc=(select VALOR_COMPRA FROM activoFijo WHERE ID_ACTIVO=@id_activo) set @cof=@f-@i  set @V_INCREMENTO=(@vc*@cof) set @v_act =(@vc+@V_INCREMENTO) set @dif_m=12-(select day(@fecha)) set @a_vidautil=(select rubro.vida_util from rubro inner join activoFijo on activoFijo.ID_RUBRO=rubro.id_rubro where activoFijo.ID_ACTIVO= @id_activo ) SET @DEP_GESTION =(@v_act/@a_vidautil)/12*@dif_m insert into depreciacion (id_registro,valorIncremento,valorActual,depInicial,depIncremento,depActual,depGestion,depAcumulada,totalDepreciacionAcumulada,calculoDepreciacion) values (@ir_registro,@V_INCREMENTO, @v_act,0,0,0,@v_act/@a_vidautil, @v_act/@a_vidautil,@v_act/@a_vidautil,@vc-(@v_act/@a_vidautil))";

            sql_cmd = new SqlCommand(str, sql_con);
            try
            {
                sql_con.Open();
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
                //MessageBox.Show("Trigger creado correctament");
            }
            catch (SqlException)
            {
                //MessageBox.Show("Error: No se creo el trigger TR_RUBRO");
            }
        }
    }
}
