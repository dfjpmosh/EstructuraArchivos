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
     * las entidades, los atributos y los bloques de datos.
     * tambien se encarga de llamar a los metodos: alta, baja
     * y modificación.
     */
    public partial class CMultillave : Form
    {
        private CBloque bloque;
        private List<CEntidad> LE;
        private List<CAtributo> LA;
        private List<CAtributo> laux;
        private string nomsec;
        private CArchivo arch;
        private long cab = -1;
        private int inddgvE, inddgvA;
        private int indE, tam;
        private long[] ar;

        public CMultillave()
        {
            InitializeComponent();
        }

        /* Este metodo se encarga de incializar
         * las variables y carga la lista de entidades
         * y las muestra en el dataGrid de entidades
         */
        private void CMultillave_Load(object sender, EventArgs e)
        {
            LE = new List<CEntidad>();
            LA = new List<CAtributo>();
            arch = new CArchivo();
            cab = -1;
            inddgvE = 0;

            LE = arch.abrirArchivo(nomsec, cab);
            foreach (CEntidad corre in LE)
            {
                dgvES.Rows.Add(corre.Nombre, corre.Direccion, corre.AptEntidad, corre.AptAtributo, corre.AptDatos);
            }
        }

        /* Este metodo retorna y captura el nombre del archivo con el que se trabajara */
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo limpia y actualiza el dataGrid de atributos
         * segun la entidad que este seleccionada carga su lista de
         * atributos y los muestra
         */
        private void dgvES_SelectionChanged(object sender, EventArgs e)
        {
            LA.Clear();
            dgvA.Rows.Clear();
            dgvDS.Rows.Clear();
            dgvDS.Columns.Clear();

            inddgvE = dgvES.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(arch.Nombre, LE[inddgvE]);
                if(LE[inddgvE].AptDatos != -1)
                {
                    ar = new long[LA.Count];
                    ar = arch.LeeTablaHash(nomsec, LA.Count, LE[inddgvE].AptDatos);
                }
                foreach (CAtributo corre in LA)
                {
                    dgvA.Rows.Add(corre.Nombre, corre.Direccion, corre.AptAtributo, corre.AptEntidad, corre.TipoClave);
                }
            }

        }

        /* Este metodo se encarga de limpiar y actualizar
         * el dataGrid de los bloques de datos segun el atributo
         * seleccionado ordena los datos de forma asendente
         */
        private void dgvA_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn txt;
            int iFA = 0, des=0;
            int datI;
            double datD;
            char datC;
            string dS;
            Boolean b = true, bandF = true;
            tam = 0;
            dgvDS.Rows.Clear();
            dgvDS.Columns.Clear();
            inddgvA = dgvA.CurrentRow.Index;

            if (inddgvE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);

            foreach (CAtributo corre in LA)
            {
                switch (corre.TipoDato)
                {
                    case "int": tam += 4+8;
                        txt = new DataGridViewTextBoxColumn();
                        txt.HeaderText = corre.Nombre;
                        txt.Name = corre.Nombre;
                        txt.ValueType = typeof(Int32);
                        txt.MaxInputLength = 7;
                        dgvDS.Columns.Add(txt);
                        break;
                    case "float": tam += 8+8;
                        txt = new DataGridViewTextBoxColumn();
                        txt.HeaderText = corre.Nombre;
                        txt.Name = corre.Nombre;
                        txt.ValueType = typeof(float);
                        txt.MaxInputLength = 7;
                        dgvDS.Columns.Add(txt);
                        break;
                    case "string": tam += (corre.Tamaño * 2)+8;
                        txt = new DataGridViewTextBoxColumn();
                        txt.HeaderText = corre.Nombre;
                        txt.Name = corre.Nombre;
                        txt.ValueType = typeof(string);
                        txt.MaxInputLength = corre.Tamaño;
                        dgvDS.Columns.Add(txt);
                        break;
                    case "char": tam += 2+8;
                        txt = new DataGridViewTextBoxColumn();
                        txt.HeaderText = corre.Nombre;
                        txt.Name = corre.Nombre;
                        txt.ValueType = typeof(char);
                        txt.MaxInputLength = 7;
                        dgvDS.Columns.Add(txt);
                        break;
                    case "boolean": tam += 1+8;
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
            
            if (LE[inddgvE].AptDatos != -1)
            {
                
                ar = new long[LA.Count];
                ar = arch.LeeTablaHash(nomsec, LA.Count, LE[inddgvE].AptDatos);
                bloque = new CBloque(tam);
                bloque.Dir = ar[inddgvA];
                bloque.Bloque = arch.LeeBloque(nomsec, tam, bloque.Dir);
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);
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
                        if (inddgvA >= i)
                        {
                            des = bloque.Des;
                            //bloque.Des += 8;
                        }
                        bloque.Des += 8;
                    }
                    bloque.Des = des;
                    bloque.Siguiente = bloque.sacaLong(8);
                    dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 2].Value = bloque.Dir;
                    dgvDS.Rows[iFA].Cells[dgvDS.ColumnCount - 1].Value = bloque.Siguiente;

                    if (bloque.Siguiente == -1)
                    {
                        bandF = false;
                    }
                    else
                    {
                        bloque.Bloque = arch.LeeBloque(nomsec, tam, bloque.Siguiente);
                        bloque.Dir = bloque.Siguiente;
                        iFA++;
                    }
                }
            }
        }

        /* Este metodo se encarga de cargar y abrir el
         * dialogo para poder ingresar los datos.
         * si hay un atributo con clave externa carga los datos 
         * relacionados con ella en un combobox
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            CIngDatMll idat = new CIngDatMll();

            tam = 0;
            LA.Clear();
            idat.dgvIngreDat.Columns.Clear();
            idat.dgvIngreDat.Rows.Clear();

            indE = inddgvE = dgvES.CurrentRow.Index;

            if (LE.Count > 0)
            {
                if (inddgvE < LE.Count)
                    LA = arch.abrirArchivoAtributo(nomsec, LE[inddgvE]);
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
                tam += (8 * LA.Count) + 8;
                idat.dgvIngreDat.Rows.Add();
            }

            idat.Tam = tam;
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                dgvES.Rows.Clear();
                CMultillave_Load(sender, e);
                dgvES_SelectionChanged(sender, e);
            }
        }

        /* Este metodo recibe un atributo
         * con esta informacion crea un combobox e
         * inserta los datos con clave primaria de
         * la entidad con la que esta relacionada
         */
        private DataGridViewComboBoxColumn datoEntExt(CAtributo a)
        {
            DataGridViewComboBoxColumn co = new DataGridViewComboBoxColumn();
            CBloque bl;
            int t = 0, des = 0, datI, ts = 0, iA=0, cont = 0;
            string tipo = "";
            double datD;
            char datC;
            string dS;
            bool b, bandF = true;
            long[] arAux;

            foreach (CEntidad ce in LE)
            {
                if (ce.Direccion == a.AptEntidad)
                {
                    if (ce.AptDatos != -1)
                    {
                        laux = new List<CAtributo>();
                        laux = arch.abrirArchivoAtributo(nomsec, ce);
                        arAux = new long[laux.Count];
                        arAux = arch.LeeTablaHash(nomsec, laux.Count, ce.AptDatos);
                        foreach (CAtributo ca in laux)
                        {
                            if (ca.TipoClave == 1)
                            {
                                des = t;
                                tipo = ca.TipoDato;
                                ts = ca.Tamaño;
                                iA = cont;
                            }
                            switch (ca.TipoDato)
                            {
                                case "int": t += 4; break;
                                case "float": t += 8; break;
                                case "char": t += 2; break;
                                case "string": t += ca.Tamaño * 2; break;
                                case "boolean": t += 1; break;
                            }
                            cont++;
                            t += 8;
                        }
                        t += 8;
                        bl = new CBloque(t);
                        bl.Bloque = arch.LeeBloque(nomsec, t, arAux[iA]);
                        bl.Dir = arAux[iA];
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

                            bl.Des = 0;
                            for (int j = 0; j <= iA; j++)
                            {
                                switch (LA[j].TipoDato)
                                {
                                    case "int": bl.Des += 4; break;
                                    case "float": bl.Des += 8; break;
                                    case "char": bl.Des += 2; break;
                                    case "string": bl.Des += (LA[j].Tamaño * 2); break;
                                    case "boolean": bl.Des += 1; break;
                                }
                                bl.Des += 8;
                            }
                            bl.Des -= 8;
                            bl.Siguiente = bl.sacaLong(8);

                            if (bl.Siguiente == -1)
                            {
                                bandF = false;
                            }
                            else
                            {
                                bl.Bloque = arch.LeeBloque(nomsec, t, bl.Siguiente);
                                bl.Dir = bl.Siguiente;
                            }
                        }

                    }
                    break;
                }
            }

            return co;
        }

        /* Este metodo empaqueta los datos del reglon seleccionado
         * y se lo busca en el archivo, cuando es encontrado bloque
         * modifica los apuntadores y al final actualiza los datsGrid
         */
        private void bBajaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des=0;
            cab = -1;
            Boolean enc = false, encB = false, existe=false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            bloque = new CBloque(tam);
            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                bloque.empaqueta("-1", "long", 8);
            }

            foreach (CAtributo ca in LA)
            {
                if (ca.TipoClave == 1)
                    break;
                switch (ca.TipoDato)
                {
                    case "int":
                        des += 4;
                        break;
                    case "float":
                        des += 8;
                        break;
                    case "char":
                        des += 2;
                        break;
                    case "boolean":
                        des += 1;
                        break;
                    case "string":
                        des += (ca.Tamaño * 2);
                        break;
                }
                indA++;
                des += 8;
            }

            ar = new long[LA.Count];
            ar = arch.LeeTablaHash(nomsec, LA.Count, LE[inddgvE].AptDatos);

            aux.Bloque = arch.LeeBloque(nomsec, tam, ar[indA]);
            aux.Dir = ar[indA];
            
            bloque.Des = aux.Des = des;
            
            des = 0;
            for (int j = 0; j <= indA; j++)
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

            des = 0;
            for (int j = 0; j < indA; j++)
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
            aux.Des = bloque.Des = des;

            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
            {
                eliminaRel(ar, aux.Dir);
            }
            else
            {
                while (aux.Siguiente != -1 && !encB)
                {
                    aux.Bloque = arch.LeeBloque(nomsec, tam, aux.Siguiente);
                    aux.Dir = aux.Siguiente;
                    des = 0;
                    for (int j = 0; j < indA; j++)
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
                    aux.Des = bloque.Des = des;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        eliminaRel(ar, aux.Dir);
                        encB = true;
                    }
                    else
                    {
                        des = 0;
                        for (int j = 0; j <= indA; j++)
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
                }
            }
            bool v = true;
            for (i = 0; i < LA.Count; i++)
            {
                if (ar[i] != -1)
                    v = false;
            }
            if (v)
            {
                LE[inddgvE].AptDatos = -1;
                arch.EscribeEntidad(LE[inddgvE]);
            }

            dgvES.Rows.Clear();
            CMultillave_Load(sender, e);
            dgvES_SelectionChanged(sender, e);
        }

        /* Este metodo recibe un arreglo de apuntadores y su direccion del bloque a eliminar
         * con estos datos recorre bloque por bloque y si el apuntador a siguiente bloque 
         * es igual a la direccion modifica los apuntadores
         */
        private void eliminaRel(long[] ar, long dir)
        {
            int indA = 0, des = 0, i;
            Boolean enc = false, encB = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            for (i = 0; i < LA.Count; i++)
            {
                encB = false;

                aux.Bloque = arch.LeeBloque(nomsec,tam, ar[i]);
                aux.Dir = ar[i];
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

                if (ar[i] == dir)
                {
                    ar[i] = aux.Siguiente;
                    arch.EscribetablaHash(ar, nomsec, LA.Count, LE[inddgvE].AptDatos);
                }
                else
                {
                    while (aux.Siguiente != -1 && !encB)
                    {
                        ant.Bloque = aux.Bloque;
                        ant.Dir = aux.Dir;
                        ant.Siguiente = aux.Siguiente;
                        aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                        aux.Dir = ant.Siguiente;
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
                        aux.Des = ant.Des = des - 8;
                        aux.Siguiente = aux.sacaLong(8);
                        if (ant.Siguiente == dir)
                        {
                            ant.Siguiente = aux.Siguiente;
                            ant.empaqueta(Convert.ToString(ant.Siguiente), "long", 8);
                            arch.EscribeBloque(ant);
                            encB = true;
                        }

                    }
                }
             }
           
        }

        /* Este metodo se encarga de empaquetar los datos segun 
         * el reglon seleccionado y busca el bloque en el archivo
         * una vez encontrado llama al metodo cargaModifica
         */
        private void bModificaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des=0;
            cab = -1;
            Boolean enc = false, encB = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            bloque = new CBloque(tam);
            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato, LA[i].Tamaño);
                bloque.empaqueta("-1", "long", 8);
            }

            foreach (CAtributo ca in LA)
            {
                if (ca.TipoClave == 1)
                    break;
                switch (ca.TipoDato)
                {
                    case "int":
                        des += 4;
                        break;
                    case "float":
                        des += 8;
                        break;
                    case "char":
                        des += 2;
                        break;
                    case "boolean":
                        des += 1;
                        break;
                    case "string":
                        des += (ca.Tamaño * 2);
                        break;
                }
                indA++;
                des += 8;
            }

            ar = new long[LA.Count];
            ar = arch.LeeTablaHash(nomsec, LA.Count, LE[inddgvE].AptDatos);

            aux.Bloque = arch.LeeBloque(nomsec, tam, ar[indA]);
            aux.Dir = ar[indA];
            
            bloque.Des = aux.Des = des;
            
            des = 0;
            for (int j = 0; j <= indA; j++)
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

            des = 0;
            for (int j = 0; j < indA; j++)
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
            aux.Des = bloque.Des = des;

            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
            {
                cargaModifica(bloque, sender, e);
            }
            else
            {
                while (aux.Siguiente != -1 && !encB)
                {
                    aux.Bloque = arch.LeeBloque(nomsec, tam, aux.Siguiente);
                    aux.Dir = aux.Siguiente;
                    des = 0;
                    for (int j = 0; j < indA; j++)
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
                    aux.Des = bloque.Des = des;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        cargaModifica(bloque, sender, e);
                        encB = true;
                    }
                    else
                    {
                        des = 0;
                        for (int j = 0; j <= indA; j++)
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
                }
            }
        }

        /* Este metodo se encarga de cargar el nuevo dialogo
         * con los datos del bloque seleccionado para que 
         * puedan ser modificados
         */
        private void cargaModifica(CBloque b, object sender, EventArgs e)
        {
            int i;
            tam = 0;
            CModMlDat idat = new CModMlDat();
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;

            for (i = 0; i < LA.Count; i++)
            {
                switch (LA[i].TipoDato)
                {
                    case "int": tam += 4 + 8;
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
                    case "float": tam += 8 + 8;
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
                    case "string": tam += (LA[i].Tamaño * 2) + 8;
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
                            txt.MaxInputLength = LA[i].Tamaño;
                            idat.dgvIngreDat.Columns.Add(txt);
                        }
                        break;
                    case "char": tam += 2 + 8;
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
                    case "boolean": tam += 1 + 8;
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
            idat.DirA = b.Dir;
            b.Des = 0;
            for (i = 0; i < LA.Count; i++)
            {
                switch (LA[i].TipoDato)
                {
                    case "int":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaInt(4);
                            b.Des += 8;
                        }
                        break;
                    case "float":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaFloat(8);
                            b.Des += 8;
                        }
                        break;
                    case "string":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaString(LA[i].Tamaño);
                            b.Des += 8;
                        }
                        break;
                    case "char":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaChar(2);
                            b.Des += 8;
                        }
                        break;
                    case "boolean":
                        if (LA[i].TipoClave != 2)
                        {
                            idat.dgvIngreDat[i, 0].Value = b.sacaBool(1);
                            b.Des += 8;
                        }
                        break;
                }
            }


            idat.Tam = tam;
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                bBajaDato_Click(sender, e);
                dgvES.Rows.Clear();
                CMultillave_Load(sender, e);
                dgvES_SelectionChanged(sender, e);
            }
        }

    }
}
