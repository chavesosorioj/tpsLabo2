using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;

namespace Chaves.Juliana._2D.TP4
{
    public partial class FrmPrincipal : Form
    {
        Aeropuerto aeropuerto;
        Pasaje auxPasaje;
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.aeropuerto = new Aeropuerto();
            this.auxPasaje = new Pasaje();
        }
        /// <summary>
        /// Inicializa el formulario comprar pasaje.
        /// En caso que haya resultado DialogResult.Ok se agrega el pasaje ingresado a la listaPasajes del aeropuerto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComprarPasajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmCompraPasaje frmPasaje = new FrmCompraPasaje();
            if((frmPasaje.ShowDialog() == DialogResult.OK))
            {
                MessageBox.Show(frmPasaje.AuxPasaje.DatosPasaje(), "Datos del pasaje", MessageBoxButtons.OK);

            }
            try
            {
                this.aeropuerto += frmPasaje.AuxPasaje;  // agrego el pasaje a la lista
            }
            catch (Exception )
            {
                throw new PasajeNoCargadoException();
            }

        }
        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirYaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMostrar mostrarPasajes = new FrmMostrar();
             mostrarPasajes.DataPasajes.DataSource = PasajeDAO.GetPasajes();
            mostrarPasajes.ShowDialog();
        }

        private void mostrarPasajesCompradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.auxPasaje.ProvinciaMasVendido(this.aeropuerto.ListaPasajes),"Mas vendido", MessageBoxButtons.OK);
        }
    }
}
