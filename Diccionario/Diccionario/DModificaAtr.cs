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
    /* Esta clase carga los datos 
     * del atributo para que puedan
     * ser modificados por el esuario
     */
    public partial class DModificaAtr : Form
    {
        private CArchivo ar;
        private List<CEntidad> le;
        private List<CAtributo> la;
        public int tc;
        private List<string> ListaTD;
        public string na, t;
        public long ca = -1;

        public DModificaAtr()
        {
            InitializeComponent();
        }

        /* Este metodo se encarga de actualizar
         * el radiobutton control de la clave esterna
         * y activa el control combobox de de la entidades
         */
        private void rbClaveExt_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Enabled = true;
            cbTipo.Text = t;
            cbTipo.Enabled = false;
            tc = 2;
        }

        /* Este metodo se encarga de actualizar
         * el radiobutton control de la clave primaria
         */
        private void rbClavePrim_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Enabled = false;
            cbTipo.Enabled = true;
            tc = 1;
        }

        /* Este metodo se encarga de actualizar
         * el radiobutton control ninguna clave
         */
        private void rbCalveNin_CheckedChanged(object sender, EventArgs e)
        {
            cbEntExt.Enabled = false;
            cbTipo.Enabled = true;
            tc = 0;
        }

        /* Este metodo retorna y captura el tipo de clave*/
        public int TipoClave
        {
            get { return tc; }
            set { tc = value; }
        }

        /* Este metodo carga los datos del atributo
         * seleccionado en el dialogo para que puedan 
         * ser modificados
         */
        private void DModificaAtr_Load(object sender, EventArgs e)
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

            le = ar.abrirArchivo(na, ca);
            foreach (CEntidad corre in le)
            {
                cbEntExt.Items.Add(corre.Nombre);
            }
            foreach (CEntidad correE in le)
            {
                if (correE.Nombre == tbEntSel.Text)
                {
                    la = ar.abrirArchivoAtributo(na, correE);
                    foreach (CAtributo correA in la)
                    {
                        if (correA.Nombre == tbAtrSel.Text)
                        {
                            tbNom.Text = correA.Nombre;
                            cbTipo.Text = correA.TipoDato;
                            if (cbTipo.Text == "string")
                            {
                                tbTam.Text = Convert.ToString(correA.Tamaño);
                                tbTam.Enabled = true;
                            }
                            else
                                tbTam.Enabled = false;
                            switch (correA.TipoClave)
                            {
                                case 0:
                                    rbCalveNin.Checked = true;
                                    tc = 0;
                                break;
                                case 1:
                                    rbClavePrim.Checked = true;
                                    tc = 1;
                                break;
                                case 2:
                                    rbClaveExt.Checked = true;
                                    tc = 2;
                                    t = cbTipo.Text = correA.TipoDato;
                                    foreach(CEntidad cEA in le)
                                    {
                                        if(cEA.Direccion == correA.AptEntidad)
                                        {
                                            cbEntExt.Text = cEA.Nombre;
                                        }
                                    }
                                break;
                            }
                        }
                    }
                }
            }
        }

        /* Este metodo captura el indice de 
         * la entidad externa seleccionada
         * busca la entida y si atributo con 
         * clave primaria y retorna el tipo dato 
         * sino cuento con clave primaria retorna null
         */
        private void cbEntExt_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;

            i = cbEntExt.SelectedIndex;
            le = ar.abrirArchivo(na, ca);
            la = ar.abrirArchivoAtributo(na, le[i]);
            foreach (CAtributo correA in la)
            {
                if (correA.TipoClave == 1)
                {
                    t = cbTipo.Text = correA.TipoDato;
                    break;
                }
                else
                    cbTipo.Text = "NULL";
            }
        }

        /* Este metodo impide
         * que se cierre el dialogo
         * si aun no se rellenan todos los campos
         */
        private void DModificaAtr_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                if (tbNom.Text == "" || tbNom.Text == " " || tbNom.Text == "  " || tbNom.Text == "   "
                    || cbTipo.Text == "")
                {
                    e.Cancel = true;
                    MessageBox.Show("Rellene Todos Los Campos");
                }
        }

        /* Este metodo se encarga de validar
         * si el tipo de datos es string
         * si es asi activo un control para que
         * el usuario pueda ingresar el tamaño
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
