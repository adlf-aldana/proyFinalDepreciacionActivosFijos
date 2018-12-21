using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEPRECIACION2._0
{
    public partial class informeUbicacion : Form
    {
        public informeUbicacion()
        {
            InitializeComponent();
        }

        private void informeUbicacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sis325DataSet.ubicacion' Puede moverla o quitarla según sea necesario.
            this.ubicacionTableAdapter.Fill(this.sis325DataSet.ubicacion);

            this.reportViewer1.RefreshReport();
        }
    }
}
