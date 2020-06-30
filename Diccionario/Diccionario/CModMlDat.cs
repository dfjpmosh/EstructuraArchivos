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
     * de los datos de la organizacion multilista
     */
    public partial class CModMlDat : Form
    {
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private long cab, dirA;
        private string nomsec;
        private bool enc = false, existe = false, vacio=false;
        long[] ar;

        public CModMlDat()
        {
            InitializeComponent();
        }

        /* Este metodo es el encargo de 
         * empaquetar los los datos capturados
         * y escribirlos en el archivo
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            int i, indA = 0, des;
            cab = -1;
            existe = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            long dirAr;
            vacio = false;

            arch = new CArchivo();
            LE = new List<CEntidad>();
            LE = arch.abrirArchivo(nomsec, cab);
            LA = new List<CAtributo>();
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);
            ar = new long[LA.Count];
            for ( i = 0; i < ar.Count(); i++)
                ar[i] = -1;

            if (LE[indE].AptDatos == -1)
            {
                dirAr = arch.Direccion(nomsec);
                arch.EscribetablaHash(ar, nomsec, ar.Count(), dirAr);   //Escribe el arreglo que apunta al primer bloque
                LE[indE].AptDatos = dirAr;
                arch.EscribeEntidad(LE[indE]);
                vacio = true;
                InsertaBloque();
            }
            else
            {
                InsertaBloque();
            }
        }

        /* Este metodo es el encargado 
         * escribir el bloque en el archivo
         * y modificar los apuntadores
         */
        private void InsertaBloque()
        {
            int i, indA = 0, des;
            cab = -1;
            bool encB = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            bloque = new CBloque(tam);
            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                bloque.empaqueta("-1", "long", 8);
            }
            bloque.Dir = bloque.Direccion(nomsec);

            ar = arch.LeeTablaHash(nomsec, LA.Count, LE[indE].AptDatos);
            if (vacio)
            {
                for (i = 0; i < LA.Count; i++)
                    ar[i] = bloque.Dir;
                arch.EscribetablaHash(ar, nomsec, LA.Count, LE[indE].AptDatos);
            }
            else
            {
                for (i = 0; i < LA.Count; i++)
                {
                    encB = false;
                    aux.Bloque = arch.LeeBloque(nomsec, tam, ar[i]);
                    aux.Dir = ar[i];
                    aux.Des = bloque.Des = 0;
                    for (int j = 0; j < i; j++)
                    {
                        switch (LA[j].TipoDato)
                        {
                            case "int": aux.Des += 4; break;
                            case "float": aux.Des += 8; break;
                            case "char": aux.Des += 2; break;
                            case "bool": aux.Des += 1; break;
                            case "string": aux.Des += (LA[j].Tamaño * 2); break;
                        }
                        aux.Des += 8;
                    }
                    des = bloque.Des = aux.Des;
                    if (aux.comparaTo(bloque, LA[i].TipoDato) == 1)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                    {
                        bloque.Des = 0;
                        for (int j = 0; j <= i; j++)
                        {
                            switch (LA[j].TipoDato)
                            {
                                case "int": bloque.Des += 4; break;
                                case "float": bloque.Des += 8; break;
                                case "char": bloque.Des += 2; break;
                                case "bool": bloque.Des += 1; break;
                                case "string": bloque.Des += (LA[j].Tamaño * 2); break;
                            }
                            bloque.Des += 8;
                        }
                        bloque.Des -= 8;
                        bloque.Siguiente = aux.Dir;
                        bloque.empaqueta(Convert.ToString(bloque.Siguiente), "long", 8);
                        arch.EscribeBloque(bloque);
                        ar[i] = bloque.Dir;
                        arch.EscribetablaHash(ar, nomsec, LA.Count, LE[indE].AptDatos);
                    }
                    else
                    {
                        aux.Des = 0;
                        for (int j = 0; j <= i; j++)
                        {
                            switch (LA[j].TipoDato)
                            {
                                case "int": aux.Des += 4; break;
                                case "float": aux.Des += 8; break;
                                case "char": aux.Des += 2; break;
                                case "bool": aux.Des += 1; break;
                                case "string": aux.Des += (LA[j].Tamaño * 2); break;
                            }
                            aux.Des += 8;
                        }
                        aux.Des -= 8;
                        aux.Siguiente = aux.sacaLong(8);
                        while (aux.Siguiente != -1 && !encB)
                        {
                            ant.Bloque = aux.Bloque;
                            ant.Dir = aux.Dir;
                            ant.Siguiente = aux.Siguiente;
                            aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                            aux.Dir = ant.Siguiente;
                            des = 0;
                            for (int j = 0; j < i; j++)
                            {
                                switch (LA[j].TipoDato)
                                {
                                    case "int": des += 4; break;
                                    case "float": des += 8; break;
                                    case "char": des += 2; break;
                                    case "string": des += (LA[j].Tamaño * 2); break;
                                    case "boolean": des += 1; break;
                                }
                                des += 8;
                            }
                            bloque.Des = aux.Des = des;
                            switch (aux.comparaTo(bloque, LA[i].TipoDato))
                            {
                                case 0:
                                    existe = true; //Encontro a un numero igual
                                    MessageBox.Show("La Clave ya Existe");
                                    break;
                                case 1:
                                    encB = true; //Encontro a un numero mañor que el
                                    break;
                            }
                            if (existe)
                                break;
                            if (encB && !existe)//Si esta en true inserta el numero antes
                            {
                                des = 0;
                                for (int j = 0; j <= i; j++)
                                {
                                    switch (LA[j].TipoDato)
                                    {
                                        case "int": des += 4; break;
                                        case "float": des += 8; break;
                                        case "char": des += 2; break;
                                        case "string": des += (LA[j].Tamaño * 2); break;
                                        case "boolean": des += 1; break;
                                    }
                                    des += 8;
                                }
                                ant.Des = bloque.Des = des - 8;
                                bloque.Siguiente = aux.Dir;
                                bloque.empaqueta(Convert.ToString(bloque.Siguiente), "long", 8);
                                arch.EscribeBloque(bloque);
                                ant.Siguiente = bloque.Dir;
                                ant.empaqueta(Convert.ToString(ant.Siguiente), "long", 8);
                                arch.EscribeBloque(ant);
                            }

                            des = 0;
                            for (int j = 0; j <= i; j++)
                            {
                                switch (LA[j].TipoDato)
                                {
                                    case "int": des += 4; break;
                                    case "float": des += 8; break;
                                    case "char": des += 2; break;
                                    case "string": des += (LA[j].Tamaño * 2); break;
                                    case "boolean": des += 1; break;
                                }
                                des += 8;
                            }
                            aux.Des = des - 8;
                            aux.Siguiente = aux.sacaLong(8);
                        }
                        if (!encB)
                        {
                            des = 0;
                            for (int j = 0; j <= i; j++)
                            {
                                switch (LA[j].TipoDato)
                                {
                                    case "int": des += 4; break;
                                    case "float": des += 8; break;
                                    case "char": des += 2; break;
                                    case "string": des += (LA[j].Tamaño * 2); break;
                                    case "boolean": des += 1; break;
                                }
                                des += 8;
                            }
                            aux.Des = bloque.Des = des - 8;
                            aux.Siguiente = bloque.Dir;
                            aux.empaqueta(Convert.ToString(aux.Siguiente), "long", 8);
                            arch.EscribeBloque(aux);
                        }
                    }
                }
            }
            if (!existe)
                arch.EscribeBloque(bloque);
        }

        /*Este metodo retorna y captura el tamaño del bloque*/
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /*Este metodo retorna y captura el indice de la entidad seleccionada*/
        public int IndEnt
        {
            get { return indE; }
            set { indE = value; }
        }

        /*Este metodo retorna y captura el nombre del archivo con el que se va a trabajar*/
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /*Este metodo retorna y captura la direccion del atributo*/
        public long DirA
        {
            get { return dirA; }
            set { dirA = value; }
        }

        /*Este metodo impide que se cierre el form 
         * si a un no se completan las celdas
         */
        private void CModSDat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (existe)
                e.Cancel = true;
        }

        /* Este metodo valida que todas las celdas
         * del dataGrid este rellenas
         * si es asi activa el boton de guardar
         * de lo contrario lo mantiene desactivado
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b = true;

            arch = new CArchivo();
            LE = new List<CEntidad>();
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
