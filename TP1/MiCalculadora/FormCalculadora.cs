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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Text = "Calculadora de Juliana Chaves Osorio 2º D";
            this.labelResultado.Text = "0";
            this.cbxOperaciones.Text = "/";
            this.BtnOperar.Text = "Operar";
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnCerrar.Text = "Cerrar";
            this.BtnConvertirABinario.Text = "Convertir a Binario";
            this.BtnConvertirADecimal.Text = "Convertir a Decimal";
            
        }
        //******************************************************* EVENTOS
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            this.labelResultado.Text = Operar(this.textBox1.Text,this.textBox2.Text,this.cbxOperaciones.Text).ToString();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero auxNumero = new Numero();
            string retorno = auxNumero.DecimalBinario(this.labelResultado.Text);
            this.labelResultado.Text = retorno;
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero auxNumero = new Numero();
            string retorno = auxNumero.BinarioDecimal(this.labelResultado.Text);
            this.labelResultado.Text = retorno;

        }


        //******************************************************** METODOS
        private void Limpiar()
        {
            this.textBox1.Text = " ";
            this.textBox2.Text = " ";
            this.cbxOperaciones.Text = "/";
            this.labelResultado.Text = "0";
        }
        

        private static double Operar(string num1, string num2, string operador)
        {
            double retorno;
            Numero auxNum1 = new Numero(num1);
            Numero auxNum2= new Numero(num2);

            retorno = Calculadora.Operar(auxNum1, auxNum2, operador);

            return retorno;
        }

     }
}
