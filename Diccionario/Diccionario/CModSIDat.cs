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
     * de controlar la modificacion de los datos
     * en la organizacion Seciencial Indexada
     */
    public partial class CModSIDat : Form
    {
        private CIndiceSI In;
        private List<CIndiceSI> LI;
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private long cab, cabIn;
        private string nomsec;
        private bool encI = false, encB = false, existe = false, alta;
        private long claveInd;

        public CModSIDat()
        {
            InitializeComponent();
            cab = -1;
        }

        /* Este metodo captura los datos
         * y los empaqueta y controla la tabla de indices
         * y llama al metodo insertaBloque
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            int i;
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LI = new List<CIndiceSI>();

            LE = arch.abrirArchivo(nomsec, cab);
            if (indE < LE.Count)
            {
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);
                LI = arch.abrirArchivoIndice(nomsec, LE[indE]);
            }
            for (i = 0; i < LA.Count; i++)
                if (LA[i].TipoClave == 1)
                {
                    claveInd = Convert.ToInt32(dgvIngreDat[i, 0].Value); //Solo es para enteros, implementar los demas tipos
                    break;
                }

            In = new CIndiceSI(claveInd);
            In.Dir = arch.Direccion(nomsec);
            if (LE[indE].AptDatos == -1)
            {
                arch.EscribeIndiceSI(In);
                LE[indE].AptDatos = In.Dir;
                arch.EscribeEntidad(LE[indE]);
                InsertaBloque(In);
            }
            else
            {
                foreach (CIndiceSI ci in LI)
                {
                    if (ci.Inicio == In.Inicio)
                    {
                        InsertaBloque(ci);
                        encI = true; //si no lo encontro hay que insertarlo terminando el foreach
                        break;
                    }
                }

                if (!encI)
                {
                    if (In.Inicio < LI[0].Inicio)
                    {
                        In.SigInd = LE[indE].AptDatos;
                        arch.EscribeIndiceSI(In);
                        LE[indE].AptDatos = In.Dir;
                        arch.EscribeEntidad(LE[indE]);
                        InsertaBloque(In);
                    }
                    if (In.Inicio > LI[LI.Count - 1].Inicio)
                    {
                        arch.EscribeIndiceSI(In);
                        LI[LI.Count - 1].SigInd = In.Dir;
                        arch.EscribeIndiceSI(LI[LI.Count - 1]);
                        InsertaBloque(In);
                    }
                    else
                    {
                        for (i = 1; i < LI.Count; i++)
                        {
                            if (In.Inicio < LI[i].Inicio)
                            {
                                In.SigInd = LI[i].Dir;
                                arch.EscribeIndiceSI(In);
                                LI[i - 1].SigInd = In.Dir;
                                arch.EscribeIndiceSI(LI[i - 1]);
                                InsertaBloque(In);
                            }
                        }
                    }
                }
            }
        }

        /* Este metodo es el encargo de escribir
         * en el archivo el bloque y modicar los
         * apuntadores
         */
        private void InsertaBloque(CIndiceSI indice)
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

            if (indice.ApDat == -1)
            {
                indice.ApDat = bloque.Dir;
                arch.EscribeIndiceSI(indice);
            }
            else
            {
                aux.Bloque = arch.LeeBloque(nomsec, tam, indice.ApDat);
                aux.Dir = indice.ApDat;
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
                    bloque.Siguiente = indice.ApDat;
                    bloque.empaquetaSig(bloque.Siguiente);
                    arch.EscribeBloque(bloque);
                    indice.ApDat = bloque.Dir;
                    arch.EscribeIndiceSI(indice);
                }
                else
                {
                    bloque.Des = aux.Des = des;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        existe = true; //Encontro a un numero igual
                        MessageBox.Show("La Clave ya Existe");
                        alta = false;
                    }
                    aux.sacaSiguiente();
                    while (aux.Siguiente != -1 && !encB)
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
                                alta = false;
                            break;
                            case 1:
                                encB = true; //Encontro a un numero mañor que el
                            break;
                        }
                        if (existe)
                            break;
                        if (encB && !existe)//Si esta en true inserta el numero antes
                        {
                            bloque.Siguiente = aux.Dir;
                            bloque.empaquetaSig(bloque.Siguiente);
                            ant.Siguiente = bloque.Dir;
                            ant.empaquetaSig(ant.Siguiente);
                            arch.EscribeBloque(ant);
                        }
                        aux.sacaSiguiente();
                    }
                    if (!encB && !existe)
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

        /*Este metodo retorna y captura el tamaño del bloque*/
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /*Este metodo retorna y captura si se dio de alta el bloque*/
        public bool Alta
        {
            get { return alta; }
            set { alta = value; }
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

        /*Este metodo retorna y captura la cabecera del indice*/
        public long CabIn
        {
            get { return cabIn; }
            set { cabIn = value; }
        }

        /* Este metodo es el encargado
         * de validar que todas las celdas del dataGrid
         * es rellenadas
         * si es así se activa el boton guardar
         * de lo contrario lo mantiene desactivado
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
