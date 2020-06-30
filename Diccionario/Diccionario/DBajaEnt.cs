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
     * la entidad seleccionada
     * si el usuario acepta se borra la entidad
     * y si contiene atributos los elimina
     * y se modifican los apuntadores
     */
    public partial class DBajaEnt : Form
    {
        public DBajaEnt()
        {
            InitializeComponent();
        }

        private void cbEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DBajaEnt_Load(object sender, EventArgs e)
        {

        }
    }
}
