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
    /* Esta clase muestra un mensaje del atributo
     * con clave primaria de la entidad, 
     * este mensaje se muestra cuando la entidad ya contiene
     * un atributo con clave primaria y quiera dar de alta
     * otro dato con clave primario, si acepta
     * elimina la relacion del atributo con clave primaria
     * y crea uno nuevo
     */
    public partial class DMClaveP : Form
    {
        public DMClaveP()
        {
            InitializeComponent();
        }

        private void DMClaveP_Load(object sender, EventArgs e)
        {

        }
    }
}
