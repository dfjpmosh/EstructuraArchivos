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
    /* Esta clase se encarga
     * de capturar los datos de
     * los atributos y los escribe en archivo
     */
    public partial class DAltaAtr : Form
    {
        private CArchivo ar;
        private List<CEntidad> le;
        private List<CAtributo> la;
        private int tc;
        private List<string> ListaTD;
        public string na;
        public long ca = -1;

        public DAltaAtr()
        {
            InitializeComponent();
        }

        /* Este metodo se encarga de inicializar
         * las variables y carga el combo de tipo 
         * de datos
         */
        private void DAltaAtr_Load(object sender, EventArgs e)
        {
            ListaTD = new List<string>();
            le = new List<CEntidad>();
            la = new List<CAtributo>();
            ar = new CArchivo();

            ListaTD.Add("int");
            ListaTD.Add("float");
            ListaTD.Add("char");
            ListaTD.Add("string");
            cbTipo.DataSource = ListaTD;
        }

        /* Este metodo se encarga
         * de actualizar el control
         * radiobutton de clave primaria
         */
        private void rbClavePrim_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Text = "";
            cbEntExt.Enabled = false; //Clave Primaria
            cbTipo.Enabled = true;
            tc = 1;
        }

        /* Este metodo se encarga
         * de actualizar el control
         * radiobutton de clave externa
         */
        private void rbClaveExt_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Enabled = true; //Clave Externa
            cbTipo.Text = "";
            cbTipo.Enabled = false;
            tc = 2;
        }

        /* Este metodo se encarga
         * de actualizar el control
         * radiobutton de ninguna clave
         */
        private void rbClaveNin_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Text = "";
            cbEntExt.Enabled = false; //Clave Ninguna
            cbTipo.Enabled = true;
            tc = 0;
        }

        /* Este metodo retorna y captura el tipo de clave*/
        public int TipoClave
        {
            get { return tc; }
            set { tc = value; }
        }

        /* Este metodo carga el combobox de entidades
         * con las entidades del archivo y activa el control
         */
        private void cbEntExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;

            i = cbEntExt.SelectedIndex;
            le = ar.abrirArchivo(na, ca);
            la = ar.abrirArchivoAtributo(na, le[i]);
            if(la.Count == 0)
                cbTipo.Text = "NULL";
            foreach(CAtributo correA in la)
            {
                if(correA.TipoClave == 1)
                {
                    cbTipo.Text = correA.TipoDato;
                    break;
                }
                else
                    cbTipo.Text = "NULL";
            }
        }

        /* Este metodo bloque que se cierre el dialogo
         * si aun no estar rellenos todos los campos
         */
        private void DAltaAtr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                    if (tbNom.Text == "" || tbNom.Text == " " || tbNom.Text == "  " || tbNom.Text == "   " 
                        || cbTipo.Text == "" )
                    {
                        e.Cancel = true;
                        MessageBox.Show("Rellene Todos Los Campos");
                    }
                
        }

        /* Este metodo valida el tipo de dato
         * si es string activa el control para 
         * que el usuario pueda ingresar el tamaño
         */
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.Text == "string")
                tbTam.Enabled = true;
            else
                tbTam.Enabled = false;
        }

        
    }
}
