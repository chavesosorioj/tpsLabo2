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
using Archivos;

namespace Chaves.Juliana._2D.TP4
{
    public partial class FrmCompraPasaje : Form
    {
        private Pasaje auxPasaje;
        private Pasajero auxPasajero;

        public Pasaje AuxPasaje
        {
            get {return this.auxPasaje; }
            set { this.auxPasaje = value; }
        }

        public Pasajero AuxPasajero { get => auxPasajero; set => auxPasajero = value; }

        public FrmCompraPasaje()
        {
            InitializeComponent();
        }

        private void FrmCompraPasaje_Load(object sender, EventArgs e)
        {
            CbxProvincias.DataSource = Enum.GetValues(typeof(Pasaje.EProvincia));
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones.ContieneLetras(this.TxtNombre.Text) && Validaciones.ContieneLetras(this.TxtApellido.Text)
                        && Validaciones.EsNumerico(this.TxtDni.Text) && this.CbxProvincias.SelectedIndex != -1)
                {
                    int.TryParse(this.TxtDni.Text, out int auxDni);
                    auxPasajero = new Pasajero(this.TxtNombre.Text, this.TxtApellido.Text, auxDni);
                    auxPasaje = new Pasaje(AuxPasajero, (Pasaje.EProvincia)this.CbxProvincias.SelectedItem);

                    this.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception) 
            {

                throw new PasajeNoCargadoException();
            }
        }

      
    }
}
