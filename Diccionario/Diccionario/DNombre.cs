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
    /* Esta clase se encarga de capturar
     * el nombre de la entidad que se va 
     * a dar de alta.
     * Tambien sirve para capturar el
     * nombre del nuevo archivo del diccionario
     * o archivo de alguna organizacion
     */
    public partial class DNombre : Form
    {
        public DNombre()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /* Este metodo impide que se cierre el dialogo
         * si aun no se rellenan todos los campos
         */
        private void DNombre_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.OK)
                if (tbNom.Text == "" || tbNom.Text == " " || tbNom.Text == "  " ||tbNom.Text == "   ")
                {
                    e.Cancel = true;
                    MessageBox.Show("Escriba un Nombre para la Entidad");
                }
        }

        private void DNombre_Load(object sender, EventArgs e)
        {

        }
    }
}
