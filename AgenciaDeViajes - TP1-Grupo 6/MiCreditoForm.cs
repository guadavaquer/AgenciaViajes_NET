using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgenciaDeViajes
{
    public partial class MiCreditoForm : Form
    {
        private Agencia miAgenciaDeViajes;

        public MiCreditoForm(Agencia agenciaDeViajes)
        {
            InitializeComponent();
            this.miAgenciaDeViajes = agenciaDeViajes;

            double? miCredito = miAgenciaDeViajes.obtenerCredito();

            //Valor de miCredito en textbox
            txtCreditoActual.Text = miCredito.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtRecarga.Text = null;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtRecarga.Text))
            {
                bool exitoCarga = miAgenciaDeViajes.cargarCredito(Convert.ToDouble(txtRecarga.Text));
                if (exitoCarga)
                {
                    double creditoActualizado = Convert.ToDouble(txtCreditoActual.Text) + Convert.ToDouble(txtRecarga.Text);

                    txtCreditoActual.Text = creditoActualizado.ToString();
                    btnCancelar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se realizo la recarga", "Mi credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
