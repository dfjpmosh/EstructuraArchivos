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
    /* esta clase es la interfaz
     * para que el usuario poder ingresar datos y 
     * organizarlos en la forma hash
     */
    public partial class CHash : Form
    {
        private CBloque bloque;
        private List<CEntidad> LE;
        private List<CAtributo> LA;
        private List<CCubetaH> LC;
        private List<CAtributo> laux;
        private string nomhas;
        private CArchivo arch;
        private long cab = -1;
        private int inddgvE, indEnEx, inddgvI, inddgvIT;
        private int indE, tam;
        private int NT = 9, NC = 3, ND = 1;
        private long[] tabla;
        
        /* Este metodo carga los componenetes del Form*/
        public CHash()
        {
            InitializeComponent();
        }

        /* Este metodo carga e inicializa las variable de la clase
         * carga la lista de entidades
         */
        private void CHash_Load(object sender, EventArgs e)
        {
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LC = new List<CCubetaH>();
            //LI = new List<CIndiceSI>();
            tabla = new long[NT];
            arch = new CArchivo();
            cab = -1;
            inddgvE = 0;

            LE = arch.abrirArchivo(nomhas, cab);
            foreach (CEntidad corre in LE)
            {
                dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
            }

        }

        /* Este metodo limpia y repinta el datagrid de indices segun 
         * la entidad seleccionada
         */
        private void dgvES_SelectionChanged(object sender, EventArgs e)
        {
            dgvIS.Rows.Clear();
            dgvIS.Columns.Clear();
            dgvITS.Rows.Clear();
            dgvDS.Rows.Clear();
            
            indE = inddgvE = dgvES.CurrentRow.Index;

            if (inddgvE < LE.Count && LE[inddgvE].AptDatos != -1)
            {
                tabla = arch.LeeTablaHash(nomhas, NT, LE[inddgvE].AptDatos);
                foreach (long ci in tabla)
                {
                    dgvITS.Rows.Add(ci);
                }
            }
        }

        /* Este metodo limpia y repinta el dataGrid
         * de indices segun el indice de la tabla selecionado
         */
        private void dgvITS_SelectionChanged(object sender, EventArgs e)
        {
            int r=0, c=0;
            dgvIS.Rows.Clear();
            dgvIS.Columns.Clear();
            inddgvIT = dgvITS.CurrentRow.Index;

            if (inddgvE < LE.Count && LE[inddgvE].AptDatos != -1)
            {
                if (tabla[inddgvIT] != -1)
                {
                    LC = arch.abrirArchivoCubeta(nomhas, tabla[inddgvIT], NC);      
                    foreach (CCubetaH cu in LC)
                    {
                        dgvIS.Columns.Add("Cubeta "+(c+1), "Cubeta "+(c+1));
                        foreach (long ab in cu.AptBloque)
                        {
                            dgvIS.Rows.Add();
                            dgvIS[c, r].Value = ab;
                            r++;
                        }
                        c++;
                        r = 0;
                    }
                }
            }
        }

        /* Este metodo limpia y repinta el dataGrid de datos
         * segun el indice seleccionado
         */
        private void dgvIS_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txt;
            int iFA = 0;
            int datI;
            double datD;
            char datC;
            string dS;
            Boolean b = true, bandF = true;
            tam = 0;
            LA.Clear();
            dgvDS.Columns.Clear();
            dgvDS.Rows.Clear();

            inddgvI = dgvIS.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomhas, LE[inddgvE]);
                foreach (CAtributo corre in LA)
                {
                    switch (corre.TipoDato)
                    {
                        case "int": tam += 4;
                            txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = corre.Nombre;
                            txt.Name = corre.Nombre;
                            txt.ValueType = typeof(Int32);
                            txt.MaxInputLength = 7;
                            dgvDS.Columns.Add(txt);
                            break;
                        case "float": tam += 8;
                            txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = corre.Nombre;
                            txt.Name = corre.Nombre;
                            txt.ValueType = typeof(float);
                            txt.MaxInputLength = 7;
                            dgvDS.Columns.Add(txt);
                            break;
                        case "string": tam += (corre.Tamaño * 2);
                            txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = corre.Nombre;
                            txt.Name = corre.Nombre;
                            txt.ValueType = typeof(string);
                            txt.MaxInputLength = 7;
                            dgvDS.Columns.Add(txt);
                            break;
                        case "char": tam += 2;
                            txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = corre.Nombre;
                            txt.Name = corre.Nombre;
                            txt.ValueType = typeof(char);
                            txt.MaxInputLength = 7;
                            dgvDS.Columns.Add(txt);
                            break;
                        case "boolean": tam += 1;
                            txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = corre.Nombre;
                            txt.Name = corre.Nombre;
                            txt.ValueType = typeof(Boolean);
                            txt.MaxInputLength = 7;
                            dgvDS.Columns.Add(txt);
                            break;
                    }
                }
                tam += 8;
                DataGridViewTextBoxColumn di = new DataGridViewTextBoxColumn();
                di.HeaderText = "Direccion";
                di.Name = "Direccion";
                dgvDS.Columns.Add(di);
                DataGridViewTextBoxColumn si = new DataGridViewTextBoxColumn();
                si.HeaderText = "AptSigDatos";
                si.Name = "AptSigDatos";
                dgvDS.Columns.Add(si);
            }

            if (inddgvE < LE.Count && LE[inddgvE].AptDatos != -1)
            {
                //tabla = arch.LeeTablaHash(nomhas, NT, LE[inddgvE].AptDatos);

                if (tabla[inddgvIT] != -1)
                {
                    LC = arch.abrirArchivoCubeta(nomhas, tabla[inddgvIT], NC);
                    bloque = new CBloque(tam);
                    Point p = new Point();
                    p = dgvIS.CurrentCellAddress;
                    if (dgvIS[p.X, p.Y].Value != null)
                    {
                        bloque.Dir = Convert.ToInt64(dgvIS[p.X, p.Y].Value.ToString());
                        if (bloque.Dir != -1)
                        {
                            bloque.Bloque = arch.LeeBloque(nomhas, tam, bloque.Dir);
                            if (inddgvE < LE.Count)
                                LA = arch.abrirArchivoAtributo(nomhas, LE[inddgvE]);
                            while (bandF)
                            {
                                bloque.Des = 0;
                                dgvDS.Rows.Add();

                                for (int i = 0; i < LA.Count; i++)
                                {
                                    switch (LA[i].TipoDato)
                                    {
                                        case "int":
                                            datI = bloque.sacaInt(4);
                                            dgvDS.Rows[iFA].Cells[i].Value = datI;
                                            break;
                                        case "float":
                                            datD = bloque.sacaFloat(8);
                                            dgvDS.Rows[iFA].Cells[i].Value = datD;
                                            break;
                                        case "char":
                                            datC = bloque.sacaChar(2);
                                            dgvDS.Rows[iFA].Cells[i].Value = datC;
                                            break;
                                        case "string":
                                            dS = bloque.sacaString(LA[i].Tamaño);
                                            dgvDS.Rows[iFA].Cells[i].Value = dS;
                                            break;
                                        case "boolean":
                                            b = bloque.sacaBool(1);
                                            dgvDS.Rows[iFA].Cells[i].Value = b;
                                            break;
                                    }
                                }
                                bloque.Siguiente = -1;
                                dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 2].Value = bloque.Dir;
                                dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 1].Value = bloque.Siguiente;

                                if (bloque.Siguiente == -1)
                                {
                                    bandF = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        /* Este metod captura y retorna el nombre del archivo con el que se esta travajando
         */
        public string NomHas
        {
            get { return nomhas; }
            set { nomhas = value; }
        }

        /* Este metodos carga la interfaz para que el usuario puedo ingresar datos
         */
        private void bAltaDato_Click(object sender, EventArgs e)
        {
            CIngDatHE idat = new CIngDatHE();

            tam = 0;
            LA.Clear();
            idat.dgvIngreDat.Columns.Clear();
            idat.dgvIngreDat.Rows.Clear();

            indE = inddgvE = dgvES.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomhas, LE[inddgvE]);
                foreach (CAtributo corre in LA)
                {
                    switch (corre.TipoDato)
                    {
                        case "int": tam += 4;
                            if (corre.TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(Int32);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(Int32);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "float": tam += 8;
                            if (corre.TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(float);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(float);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "string": tam += (corre.Tamaño * 2);
                            if (corre.TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(string);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(string);
                                txt.MaxInputLength = corre.Tamaño;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "char": tam += 2;
                            if (corre.TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(char);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(char);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                        case "boolean": tam += 1;
                            if (corre.TipoClave == 2)
                            {
                                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                                combo = datoEntExt(corre);
                                combo.HeaderText = corre.Nombre;
                                combo.Name = corre.Nombre;
                                combo.ValueType = typeof(Boolean);
                                idat.dgvIngreDat.Columns.Add(combo);
                            }
                            else
                            {
                                DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(Boolean);
                                txt.MaxInputLength = 7;
                                idat.dgvIngreDat.Columns.Add(txt);
                            }
                            break;
                    }
                }
                tam += 8;
                idat.dgvIngreDat.Rows.Add();
            }

            idat.Tam = tam;
            idat.NomHas = nomhas;
            idat.NCubeta = NC;
            idat.NTabla = NT;
            idat.NDigitos = ND;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                dgvES.Rows.Clear();
                CHash_Load(sender, e);
                dgvES_SelectionChanged(sender, e);
            }
        }

        /* Este metodo recibe un atributo
         * y regresa un combo con los datos que contenta la entidad
         * con la que tiene relacion
         */
        private DataGridViewComboBoxColumn datoEntExt(CAtributo a)
        {
            DataGridViewComboBoxColumn co = new DataGridViewComboBoxColumn();
            CBloque bl;
            int t = 0, des = 0, datI, ts = 0, i, j;
            string tipo = "";
            double datD;
            char datC;
            string dS;
            bool b, bandF = true;
            long[] arAux;
            List<CCubetaH> lCA = new List<CCubetaH>();

            foreach (CEntidad ce in LE)
            {
                if (ce.Direccion == a.AptEntidad)
                {
                    if (ce.AptDatos != -1)
                    {
                        arAux = arch.LeeTablaHash(nomhas, NT, ce.AptDatos);
                        for (i = 0; i < NT; i++)
                        {
                            if (arAux[i] != -1)
                            {
                                lCA = arch.abrirArchivoCubeta(nomhas, arAux[i], NC);
                                foreach (CCubetaH cua in lCA)
                                {
                                    for (j = 0; j < NC; j++)
                                    {
                                        if (cua.AptBloque[j] != -1)
                                        {
                                            laux = new List<CAtributo>();
                                            laux = arch.abrirArchivoAtributo(nomhas, ce);
                                            des = t = 0;
                                            bandF = true;
                                            foreach (CAtributo ca in laux)
                                            {
                                                if (ca.TipoClave == 1)
                                                {
                                                    des = t;
                                                    tipo = ca.TipoDato;
                                                    ts = ca.Tamaño;
                                                }
                                                switch (ca.TipoDato)
                                                {
                                                    case "int": t += 4; break;
                                                    case "float": t += 8; break;
                                                    case "char": t += 2; break;
                                                    case "string": t += ca.Tamaño * 2; break;
                                                    case "boolean": t += 1; break;
                                                }
                                            }
                                            t += 8;
                                            bl = new CBloque(t);
                                            bl.Bloque = arch.LeeBloque(nomhas, t, cua.AptBloque[j]);
                                            bl.Dir = cua.AptBloque[j];
                                            while (bandF)
                                            {
                                                bl.Des = des;
                                                switch (tipo)
                                                {
                                                    case "int":
                                                        datI = bl.sacaInt(4);
                                                        co.Items.Add(datI);
                                                        break;
                                                    case "float":
                                                        datD = bl.sacaFloat(8);
                                                        co.Items.Add(datD);
                                                        break;
                                                    case "char":
                                                        datC = bl.sacaChar(2);
                                                        co.Items.Add(datC);
                                                        break;
                                                    case "string":
                                                        dS = bl.sacaString(ts);
                                                        co.Items.Add(dS);
                                                        break;
                                                    case "boolean":
                                                        b = bl.sacaBool(1);
                                                        break;
                                                }

                                                bl.sacaSiguiente();

                                                if (bl.Siguiente == -1)
                                                {
                                                    bandF = false;
                                                }
                                                else
                                                {
                                                    bl.Bloque = arch.LeeBloque(nomhas, t, bl.Siguiente);
                                                    bloque.Dir = bl.Siguiente;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //break;
                }
            }

            return co;
        }

        /* Este metodo busca el el dato que haya seleccionado el usuario
         * en el dataGrid de datos, al encontrarlo cambia los apuntadores
          */
        private void bBajaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LC = new List<CCubetaH>();
            

            LE = arch.abrirArchivo(nomhas, cab);
            if (indE < LE.Count && LE[indE].AptDatos != -1)
            {
                LA = arch.abrirArchivoAtributo(nomhas, LE[indE]);
                tabla = arch.LeeTablaHash(nomhas, NT, LE[indE].AptDatos);
                if (tabla[inddgvIT] != -1)
                {
                    LC = arch.abrirArchivoCubeta(nomhas, tabla[inddgvIT], NC);

                    bloque = new CBloque(tam);

                    for (i = 0; i < LA.Count(); i++)
                    {
                        bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato);
                    }

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

                                des = bloque.Des = aux.Des;
                                if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                                {
                                    cua.AptBloque[i] = -1;
                                    arch.EscribeCubeta(cua, nomhas);
                                }
                            }
                        }
                    }
                }
            }
            dgvES.Rows.Clear();
            CHash_Load(sender, e);
            dgvES_SelectionChanged(sender, e);
        }

        /* Este metodo busca el bloque de datos que el usuario selecciono
         * carga la interfaza con esos datos y da opcion al usuario de cambiarlos  
         * y guardarlos
         */
        private void bModificaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            arch = new CArchivo();
            bloque = new CBloque(tam);
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            LC = new List<CCubetaH>();


            LE = arch.abrirArchivo(nomhas, cab);
            if (indE < LE.Count && LE[indE].AptDatos != -1)
            {
                LA = arch.abrirArchivoAtributo(nomhas, LE[indE]);
                tabla = arch.LeeTablaHash(nomhas, NT, LE[indE].AptDatos);
                if (tabla[inddgvIT] != -1)
                {
                    LC = arch.abrirArchivoCubeta(nomhas, tabla[inddgvIT], NC);

                    bloque = new CBloque(tam);

                    for (i = 0; i < LA.Count(); i++)
                    {
                        bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato);
                    }

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

                                des = bloque.Des = aux.Des;
                                if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
                                {
                                    enc = true;
                                    cargaModifica(aux, sender, e);
                                }
                            }
                        }
                    }
                }
            }


        }

        /* Este metodo carga la interfaz de usuario con los datos 
         * que el usuario desee modificar
         */
        private void cargaModifica(CBloque b, object sender, EventArgs e)
        {
            int i;
            tam = 0;
            CModHsDat idat = new CModHsDat();
            idat.NomHas = nomhas;
            idat.IndEnt = inddgvE;
            for (i = 0; i < LA.Count; i++)
            {
                switch (LA[i].TipoDato)
                {
                    case "int": tam += 4;
                        if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(Int32);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(Int32);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "float": tam += 8;
                        if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(float);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(float);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "string": tam += (LA[i].Tamaño * 2);
                        if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(string);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(string);
                            txt.MaxInputLength = 30;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "char": tam += 2;
                        if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(char);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(char);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "boolean": tam += 1;
                        if (LA[i].TipoClave == 2)
                        {
                            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                            combo = datoEntExt(LA[i]);
                            combo.HeaderText = LA[i].Nombre;
                            combo.Name = LA[i].Nombre;
                            combo.ValueType = typeof(Boolean);
                            idat.dgvIngreDat.Columns.Add(combo);
                        }
                        else
                        {
                            DataGridViewTextBoxColumn txt = new DataGridViewTextBoxColumn();
                            txt.HeaderText = LA[i].Nombre;
                            txt.Name = LA[i].Nombre;
                            txt.ValueType = typeof(Boolean);
                            txt.MaxInputLength = 7;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                }
            }
            tam += 8;
            idat.dgvIngreDat.Rows.Add();
            //idat.DirA = b.Dir;
            b.Des = 0;
            for (i = 0; i < LA.Count; i++)
            {
                switch (LA[i].TipoDato)
                {
                    case "int":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaInt(4);
                        }
                        break;
                    case "float":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaFloat(8);
                        }
                        break;
                    case "string":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaString(LA[i].Tamaño);
                        }
                        break;
                    case "char":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaChar(2);
                        }
                        break;
                    case "boolean":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaBool(1);
                        }
                        break;
                }
            }

            bool alta = true;
            idat.Tam = tam;
            idat.NomHas = nomhas;
            idat.NCubeta = NC;
            idat.NTabla = NT;
            idat.NDigitos = ND;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                alta = idat.Alta;
                if (alta == true)
                {
                    bBajaDato_Click(sender, e);
                    dgvES.Rows.Clear();
                    CHash_Load(sender, e);
                    dgvES_SelectionChanged(sender, e);
                }
            }
        }

    }
}
