using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Diccionario
{
    /* Esta clase es la encargada de capturar
     * los datos empaquetarlos y escibir el bloque
     * en el archivo. Este metod es parte de la organizacion
     * secuencial
     */
    public partial class CIngreDat : Form
    {
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private long cab;
        private string nomsec, cad;
        private bool enc = false, existe=false;

        public CIngreDat()
        {
            InitializeComponent();

        }
        
        /* Este metodo inicializa las varibles
         * y carga las listas de entidades y atributos
         * que seran utilizadas.
         */
        private void CIngreDat_Load(object sender, EventArgs e)
        {
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);
        }
        
        /* Este metodo es el encargado de empaquetar los datos capturados
         * checa que el bloque no se repita en el archivo
         * y los escribe en el archivo modificando los apuntadores 
         * de los demas bloques
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            int i, indA = 0, des;
            cab = -1;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
            
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
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        existe = true; //Encontro a un numero igual
                        MessageBox.Show("La Clave ya Existe");
                    }
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
                            case 0:
                                existe = true; //Encontro a un numero igual
                                MessageBox.Show("La Clave ya Existe");
                                break;
                            case 1:
                                enc = true; //Encontro a un numero mañor que el
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
            if(!existe)
                arch.EscribeBloque(bloque);
        }

        /* Este metodo retorna y captura el tamaño */
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

        /* Este metodo retorna y captura el nombre del archivo con que se va a trabajar */
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo valida que todas las celdas este rellenadas
         * de ser así habilita el boton de guardar,
         * de lo contrario lo mantiene deshabilitado
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b=true;
            
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
