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
    /* Esta clase es la encargada
     * de controlar la modificacion 
     * de los datos de la organizacion Secuencial
     */
    public partial class CModSDat : Form
    {
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private long cab, dirA;
        private string nomsec;
        private bool enc = false, existe=false;

        public CModSDat()
        {
            InitializeComponent();
            
        }

        private void CModSDat_Load(object sender, EventArgs e)
        {
            
        }
        
        /* Este metodo es el encargado de empaquetar los datos
         * y comparar que no se repita el bloque en el archivo
         * y lo escribe en el archivo y modifica los apuntadores
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            int i, indA = 0, des;
            cab = -1;
            existe = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
            
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);
            
            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato);
            }

            bloque.Dir = bloque.Direccion(nomsec);

            if (LE[indE].AptDatos == -1)
            {
                LE[indE].AptDatos = bloque.Dir;
                arch.EscribeEntidad(LE[indE]);
            }
            else
            {
                aux.Bloque = arch.LeeBloque(nomsec, tam, LE[indE].AptDatos);
                aux.Dir = LE[indE].AptDatos;
                aux.Des = 0;
                foreach (CAtributo ca in LA)
                {
                    if (ca.TipoClave == 1)
                        break;
                    switch (ca.TipoDato)
                    {
                        case "int":
                            aux.Des += 4;
                            break;
                        case "float":
                            aux.Des += 8;
                            break;
                        case "char":
                            aux.Des += 2;
                            break;
                        case "boolean":
                            aux.Des += 1;
                            break;
                        case "string":
                            aux.Des += (ca.Tamaño * 2);
                            break;
                    }
                    indA++;
                }

                des = bloque.Des = aux.Des;
                if (aux.comparaTo(bloque, LA[indA].TipoDato) == 1)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                {
                    bloque.Siguiente = LE[indE].AptDatos;
                    bloque.empaquetaSig(bloque.Siguiente);
                    arch.EscribeBloque(bloque);
                    LE[indE].AptDatos = bloque.Dir;
                    arch.EscribeEntidad(LE[indE]);
                }
                else
                {
                    bloque.Des = aux.Des = des;
                    /*if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        existe = true; //Encontro a un numero igual
                        MessageBox.Show("La Clave ya Existe");
                    }//esto*/
                    aux.sacaSiguiente();
                    while (aux.Siguiente != -1 && !enc)
                    {
                        ant.Bloque = aux.Bloque;
                        ant.Dir = aux.Dir;
                        ant.sacaSiguiente();
                        aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                        aux.Dir = ant.Siguiente;
                        bloque.Des = aux.Des = des;
                        switch (aux.comparaTo(bloque, LA[indA].TipoDato))
                        {
                            /*case 0:
                                existe = true; //Encontro a un numero igual
                                MessageBox.Show("La Clave ya Existe");
                            break;//*/
                            case 1:
                                enc = true; //Encontro a un numero mayor que el
                            break;
                        }
                        if (existe)
                            break;
                        if (enc && !existe)
                        {
                            bloque.Siguiente = aux.Dir;
                            bloque.empaquetaSig(bloque.Siguiente);
                            ant.Siguiente = bloque.Dir;
                            ant.empaquetaSig(ant.Siguiente);
                            arch.EscribeBloque(ant);
                        }
                        aux.sacaSiguiente();
                    }
                    if (!enc && !existe)
                    {
                        aux.Siguiente = bloque.Dir;
                        aux.empaquetaSig(aux.Siguiente);
                        arch.EscribeBloque(aux);
                    }
                }
            }
            if (!existe)
                arch.EscribeBloque(bloque);
        }

        /* Este metodo retorna y captura el tamaño del bloque*/
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /* Este metodo retorna y captura el indice de la entidad seleccionada*/
        public int IndEnt
        {
            get { return indE; }
            set { indE = value; }
        }

        /* Este metodo retorna y captura el nombre del archivo con el que se va a trabajar*/
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo retorna y captura la direccion del atributo*/
        public long DirA
        {
            get { return dirA; }
            set { dirA = value; }
        }

        /* Este metodo impide que se cierre la forma
         * si aun no se completa el alta de datos
         */
        private void CModSDat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (existe)
                e.Cancel = true;
        }

        /* Este metodo valida que 
         * todas las celdas del dataGrid este rellenas
         * si es así activa el boton de guardar
         * de los controrio mantiene el boton desactivado
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b = true;
            
            arch = new CArchivo();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count; i++)
            {
                if (dgvIngreDat[i, 0].Value == null)
                    b = false;
            }

            if (b)
                bGuardar.Enabled = true;
        }
       
    }
}
