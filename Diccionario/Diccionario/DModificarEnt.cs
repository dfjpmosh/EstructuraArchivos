using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diccionario
{
    /* Esta clase se encarga de mostrar
     * los datos de la entidad seleccionada
     * que sera modificada
     */
    public partial class DModificarEnt : Form
    {
        public DModificarEnt()
        {
            InitializeComponent();
        }

        /* Este metodo impide que
         * se cierre el dialogo
         * si faltan campos por rellenar
         */
        private void DModificarEnt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                if (tbNom.Text == "" || tbNom.Text == " " || tbNom.Text == "  " || tbNom.Text == "   ")
                {
                    e.Cancel = true;
                    MessageBox.Show("Escriba un Nombre para la Entidad");
                }
        }

        private void DModificarEnt_Load(object sender, EventArgs e)
        {

        }
    }
}
