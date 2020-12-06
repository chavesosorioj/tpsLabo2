using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chaves.Juliana._2D.TP4
{
    public partial class FrmMostrar : Form
    {
        public DataGridView DataPasajes
        {
            get { return this.DgwPasajes; }
        }
        public FrmMostrar()
        {
            InitializeComponent();
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            this.Text = "Estado de los pasajes en la base";
            this.DgwPasajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DgwPasajes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
