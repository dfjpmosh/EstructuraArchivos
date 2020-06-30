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
    /* Esta clase es la encargada de capturar 
     * y guardar los datos en el archivo
     */
    public partial class CIngDatHE : Form
    {
        private CIndiceSI In;
        private List<CIndiceSI> LI;
        private CArchivo arch;
        private CBloque bloque;
        private int tam, indE;
        private List<CAtributo> LA;
        private List<CEntidad> LE;
        private List<CCubetaH> LC;
        private long cab, cabIn;
        private string nomhas;
        private bool encI = false, encB = false, existe = false, bloInser = false;
        private long claveprim, clavetabla, clavecubeta;
        private string cad;
        private char[] acp, ach;
        private int NT, NC, ND;
        private long[] ar;

        /* Este contructor inicializa los componenetes y la cabecera*/
        public CIngDatHE()
        {
            InitializeComponent();
            cab = -1;
        }

        private void CIngDatHE_Load(object sender, EventArgs e)
        {
            
        }

        /* Este metodo iniciliza las variables
         * estrae la listas del archivo que seran usadas
         * y manda a llamar a inserta tabla
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            int i;
            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LI = new List<CIndiceSI>();
            LC = new List<CCubetaH>();
            ar = new long[NT];
            
            LE = arch.abrirArchivo(nomhas, cab);
            if (indE < LE.Count)
            {
                LA = arch.abrirArchivoAtributo(nomhas, LE[indE]);
                LI = arch.abrirArchivoIndice(nomhas, LE[indE]);
            }
            for (i = 0; i < LA.Count; i++)
                if (LA[i].TipoClave == 1)
                {
                    claveprim = Convert.ToInt32(dgvIngreDat[i, 0].Value); //Solo es para enteros, implementar los demas tipos
                    break;
                }

            cad = claveprim.ToString();
            acp = cad.ToCharArray();
            funcionHashTabla();
            funcionHashCubeta();

            insertaEnTabla();
        }

        /* Este metodo por medio de la clave primaria
         * calcula la posicion que le corresponde al indice
         * en la tabla
         */
        private void funcionHashTabla()
        {
            int m, i;
            char[] aux = new char[ND];
            string saux;

            if (acp.Length >= ND)
            {
                m = (acp.Length - (acp.Length / 2)) - 1;
                for (i = 0; i < ND; i++)
                {
                    aux[i] = acp[m + i];
                }
                saux = new string(aux);
                clavetabla = Int32.Parse(saux);
            }
            else 
            {
                saux = new string(acp);
                clavetabla = Int32.Parse(saux);
            }

            clavetabla = clavetabla % NC;
        }

        /* Este metodo por medio de la clave primaria
         * calcula posicion que le corresponde en la cubeta
        */
        private void funcionHashCubeta()
        {
            int i;

            char[] aux = new char[ND];
            string saux;

            if (acp.Length >= ND)
            {
                for (i = 0; i < ND; i++)
                {
                    aux[i] = acp[(acp.Length) - (ND - i)];
                }
                saux = new string(aux);
                clavecubeta = Int32.Parse(saux);
            }
            else
            {
                saux = new string(acp);
                clavecubeta = Int32.Parse(saux);
            }

            clavecubeta = clavecubeta % NC;

        }

        /* Este metodo es el encargado de insertar 
         * el indice en la tabla y manda
         * a llamar al metodo de inserta en cubeta
         */
        public void insertaEnTabla()
        {
            int i;
            long dir;
            
            if (LE[indE].AptDatos == -1)
            {
                dir = arch.Direccion(nomhas);
                for (i = 0; i < NT; i++)
                    ar[i] = -1;
                LE[indE].AptDatos = dir;
                arch.EscribeEntidad(LE[indE]);
                arch.EscribetablaHash(ar, nomhas, NT, dir);
                ar[clavetabla] = insertaEnCubeta(); //direccion de la cubeta
                arch.EscribetablaHash(ar, nomhas, NT, dir);
            }
            else
            {
                ar = arch.LeeTablaHash(nomhas, NT, LE[indE].AptDatos);
                if (encuentraDato(ar[clavetabla]) == false)
                {
                    ar[clavetabla] = insertaEnCubeta();
                    arch.EscribetablaHash(ar, nomhas, NT, LE[indE].AptDatos);
                }
            }
        }

        /* Este metodo es el encargado de
         * inserta en la cubeta y manda
         * a llamar al metodo inserta bloque
         * retorna la direccion de la cubeta
         */
        private long insertaEnCubeta()
        {
            int i, c;
            long dir;
            CCubetaH cubeta;

            if (ar[clavetabla] == -1)
            {
                dir = arch.Direccion(nomhas);
                cubeta = new CCubetaH(NC, dir);
                arch.EscribeCubeta(cubeta, nomhas);
                cubeta.AptBloque[clavecubeta] = InsertaBloque(cubeta, (int)clavecubeta); //insertar bloque
                LC.Add(cubeta);
                arch.EscribeCubeta(cubeta, nomhas);
            }
            else
            {
                dir = ar[clavetabla];
                LC = arch.abrirArchivoCubeta(nomhas, ar[clavetabla], NC);
                if (LC[0].AptBloque[clavecubeta] == -1)
                {
                    LC[0].AptBloque[clavecubeta] = InsertaBloque(LC[0], (int)clavecubeta); //insertar bloque
                    arch.EscribeCubeta(LC[0], nomhas);
                }
                else
                {
                    i = (int)clavecubeta;
                    c = 0;
                    while (!bloInser)
                    {
                        i++;
                        if (i == NC)
                            i = 0;
                        if (LC[c].AptBloque[i] == -1)
                        {
                            LC[c].AptBloque[i] = InsertaBloque(LC[c], i) ; //insertar bloque insertaBloque(LC[c].AptBloque[i])
                            arch.EscribeCubeta(LC[c], nomhas);
                            bloInser = true;
                            break;
                        }
                        if (i == clavecubeta)
                        {
                            if (LC[c].SigCubeta == -1)
                            {
                                dir = arch.Direccion(nomhas);
                                cubeta = new CCubetaH(NC, dir);
                                arch.EscribeCubeta(cubeta, nomhas);
                                LC[c].SigCubeta = cubeta.Direccion;
                                arch.EscribeCubeta(LC[c], nomhas);
                                cubeta.AptBloque[clavecubeta] = InsertaBloque(cubeta, i) ;//inserta bloque
                                arch.EscribeCubeta(cubeta, nomhas);
                                LC.Add(cubeta);
                                bloInser = true;
                                break;
                            }
                            else
                            {
                                c++;
                                i = (int)clavecubeta;
                            }
                        }
                            
                    }
                }
            }
            
            return LC[0].Direccion;
        }

        /* Este metodo es el encargado de
         * insertar el bloque con los datos
         * y lo escribe en el archivo
         * regresa la dirección del bloque
         */
        private long InsertaBloque(CCubetaH cub, int indice)
        {
            int i, indA = 0, des;
            cab = -1;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
            }
            bloque.Dir = bloque.Direccion(nomhas);

            cub.AptBloque[indice] = bloque.Dir;
            arch.EscribeBloque(bloque);
            arch.EscribeCubeta(cub, nomhas);
            return cub.AptBloque[indice];
        }

        /* Este metodo recibe la direccion de la lista de cubetas
         * y compara segun la clave primaria que el bloque que se
         * va a insertar no exista en el archivo.
         * Si existe regresa true
         * Si No existe regresa false
         */
        private bool encuentraDato(long dirLC)
        {
            int indD = dgvIngreDat.CurrentRow.Index, i;
            int indA = 0, des;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque auxbloque = new CBloque(tam);

            for (i = 0; i < LA.Count(); i++)
            {
                auxbloque.empaqueta(dgvIngreDat[i, 0].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
            }

            if (dirLC != -1)
            {
                LC = arch.abrirArchivoCubeta(nomhas, dirLC, NC);
                foreach (CCubetaH cua in LC)
                {
                    for (i = 0; i < NC; i++)
                    {
                        if (cua.AptBloque[i] != -1)
                        {
                            aux.Bloque = arch.LeeBloque(nomhas, tam, cua.AptBloque[i]);
                            aux.Dir = cua.AptBloque[i];
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

                            des = auxbloque.Des = aux.Des;
                            if (aux.comparaTo(auxbloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                            {
                                enc = true;
                                MessageBox.Show("Ya existe un dato con la misma clave primaria");
                                break;
                            }
                        }
                    }
                }
            }

            return enc;

        }

        /* Este metodo retorna o captura el tamaño*/
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /* Este metodo retorna o captura el indice de la entidad seleccionada*/
        public int IndEnt
        {
            get { return indE; }
            set { indE = value; }
        }

        /* Este metodo retorna o captura el nombre del archivo con el que se esta trabajando*/
        public string NomHas
        {
            get { return nomhas; }
            set { nomhas = value; }
        }

        /* Este metodo retorna o captura el apuntador a la cabecera del indice*/
        public long CabIn
        {
            get { return cabIn; }
            set { cabIn = value; }
        }

        /* Este metodo retorna o captura el tamaño de la tabla de indices*/
        public int NTabla
        {
            get { return NT; }
            set { NT = value; }
        }

        /* Este metodo retorna o captura el tamaño de la cubeta*/
        public int NCubeta
        {
            get { return NC; }
            set { NC = value; }
        }

        /* Este metodo retorna o captura el numero de digitos 
         * con los que se trabajara para calcular la posicion en la tabla y la cubeta
         * donde se insertara el dato.
         */
        public int NDigitos
        {
            get { return ND; }
            set { ND = value; }
        }

        /* Este metodo valida que todas las celdas del dataGrid contengas datos
         * si es así activa el boton de guardar 
         * de lo contrario lo desactiva
         */
        private void dgvIngreDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            bool b = true;

            arch = new CArchivo();
            LE = arch.abrirArchivo(nomhas, cab);
            if (indE < LE.Count)
            {
                LA = arch.abrirArchivoAtributo(nomhas, LE[indE]);
                LI = arch.abrirArchivoIndice(nomhas, LE[indE]);
            }

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
