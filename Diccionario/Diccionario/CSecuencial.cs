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
    /* Esta clase esta encargada de mostrar
     * entidades y sus bloques de datos,
     * controla el alta, baja y modificacion de los datos
     */
    public partial class CSecuencial : Form
    {
        private CBloque bloque;
        private List<CEntidad> LE;
        private List<CAtributo> LA;
        private List<CAtributo> laux;
        private string nomsec;
        private CArchivo arch;
        private long cab = -1;
        private int inddgvE, indEnEx;
        private int indE, tam;
        
        public CSecuencial()
        {
            InitializeComponent();
        }

        /* Este metodo inicializa las variables
         * y carga la lista de entidades y las
         * muestra en el dataGrid de entidades
         */
        private void CSecuencial_Load(object sender, EventArgs e)
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

        /* Este metodo retorna y captura el nombre del archivo con el que se trabajara*/
        public string NomSec
        {
            get { return nomsec; }
            set { nomsec = value; }
        }

        /* Este metodo se encarga de actualizar
         * el dataGrid de datos, segun la entidad
         * seleccionada
         */
        private void dgvES_SelectionChanged(object sender, EventArgs e)
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
                        case "string": tam += (corre.Tamaño*2);
                                txt = new DataGridViewTextBoxColumn();
                                txt.HeaderText = corre.Nombre;
                                txt.Name = corre.Nombre;
                                txt.ValueType = typeof(string);
                                txt.MaxInputLength = corre.Tamaño;
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

            if (LE[inddgvE].AptDatos != -1)
            {
                bloque = new CBloque(tam);
                bloque.Dir = LE[inddgvE].AptDatos;
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
                    }
                    bloque.sacaSiguiente();
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

        /* Este metodo incializa las variables
         * del nuevo dialogo y lo carga para que
         * el usuario pueda ingresar datos
         * de ser necesario llama al metodo entidadExterna
         */
        private void bGuardar_Click(object sender, EventArgs e)
        {
            CIngreDat idat = new CIngreDat();

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
                        case "string": tam += (corre.Tamaño*2);
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
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                dgvES.Rows.Clear();
                CSecuencial_Load(sender, e);
                dgvES_SelectionChanged(sender, e);
            }
        }

        /* Este metodo se encarga de crear un combobox
         * y lo llena con los datos que con tiene la entidad
         * externa del atributo y lo retorna
         */
        private DataGridViewComboBoxColumn datoEntExt(CAtributo a)
        {
            DataGridViewComboBoxColumn co = new DataGridViewComboBoxColumn();
            CBloque bl;
            int t=0, des=0, datI, ts=0;
            string tipo="";
            double datD;
            char datC;
            string dS;
            bool b, bandF=true;

            foreach (CEntidad ce in LE)
            {
                if (ce.Direccion == a.AptEntidad)
                {
                    if (ce.AptDatos != -1)
                    {
                        laux = new List<CAtributo>();
                        laux = arch.abrirArchivoAtributo(nomsec, ce);
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
                                case "int"      : t += 4;           break;
                                case "float"    : t += 8;           break;
                                case "char"     : t += 2;           break;
                                case "string"   : t += ca.Tamaño*2; break;
                                case "boolean"  : t += 1;           break;
                            }
                        }
                        t += 8;
                        bl = new CBloque(t);
                        bl.Bloque = arch.LeeBloque(nomsec, t, ce.AptDatos);
                        bl.Dir = ce.AptDatos;
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
                                bl.Bloque = arch.LeeBloque(nomsec, t, bl.Siguiente);
                                bloque.Dir = bl.Siguiente;
                            }
                        }

                    }
                    break;
                }
            }
    
            return co;
        }

        /* Este metodo se encarga de empaquetar los datos del 
         * reglon seleccionado en el dataGrid de los datos
         * hace una busqueda en el archivo del bloque, cuando
         * lo encuentra modifica los apuntadores
         */
        private void bBajaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);

            bloque = new CBloque(tam);
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato);
            }

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

            bloque.Des = aux.Des;
            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
            {
                aux.sacaSiguiente();
                LE[indE].AptDatos = aux.Siguiente;
                arch.EscribeEntidad(LE[indE]);
            }
            else
            {
                aux.sacaSiguiente();
                while (aux.Siguiente != -1 && !enc)
                {
                    ant.Bloque = aux.Bloque;
                    ant.Dir = aux.Dir;
                    ant.sacaSiguiente();
                    aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                    aux.Dir = ant.Siguiente;
                    bloque.Des = aux.Des = 0;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        enc = true;
                        aux.sacaSiguiente();
                        ant.Siguiente = aux.Siguiente;
                        ant.empaquetaSig(ant.Siguiente);
                        arch.EscribeBloque(ant);
                    }
                    aux.sacaSiguiente();
                }
            }
            dgvES.Rows.Clear();
            CSecuencial_Load(sender, e);
            dgvES_SelectionChanged(sender, e);
        }

        /* Este metodo se encarga de empaquetar los datos del 
         * reglon seleccionado del dataGrid de datos,
         * recorre el archivo, al encontrarlo llama
         * al metodo de cargaModifica
         */
        private void bModificaDato_Click(object sender, EventArgs e)
        {
            int indD = dgvDS.CurrentRow.Index, i;
            int indA = 0, des;
            cab = -1;
            Boolean enc = false;
            CBloque aux = new CBloque(tam);
            CBloque ant = new CBloque(tam);
                        
            bloque = new CBloque(tam);
            if (indE < LE.Count)
                LA = arch.abrirArchivoAtributo(nomsec, LE[indE]);

            for (i = 0; i < LA.Count(); i++)
            {
                bloque.empaqueta(dgvDS[i, indD].Value.ToString(), LA[i].TipoDato);
            }

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
            if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)  //1 si aux>bloque  0 si aux==bloque -1 aux<bloque
            {
                //Aqui se manda a llamar
                cargaModifica(aux, sender, e);
            }
            else
            {
                aux.sacaSiguiente();
                while (aux.Siguiente != -1 && !enc)
                {
                    ant.Bloque = aux.Bloque;
                    ant.Dir = aux.Dir;
                    ant.sacaSiguiente();
                    aux.Bloque = arch.LeeBloque(nomsec, tam, ant.Siguiente);
                    aux.Dir = ant.Siguiente;
                    bloque.Des = aux.Des = des;
                    if (aux.comparaTo(bloque, LA[indA].TipoDato) == 0)
                    {
                        enc = true;
                        cargaModifica(aux, sender, e);
                    }
                    aux.sacaSiguiente();
                }
            }
            
        }
        
        /* Este metodo carga el dialogo con los datos recuperados
         * para que puedan ser modificado
         */
        private void cargaModifica(CBloque b, object sender, EventArgs e)
        {
            int i;
            tam = 0;
            CModSDat idat = new CModSDat();
            idat.NomSec = nomsec;
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
                            txt.MaxInputLength = LA[i].Tamaño;
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

            
            idat.Tam = tam;
            idat.NomSec = nomsec;
            idat.IndEnt = inddgvE;
            if (idat.ShowDialog() == DialogResult.OK)
            {
                bBajaDato_Click(sender, e);
                dgvES.Rows.Clear();
                CSecuencial_Load(sender, e);
                dgvES_SelectionChanged(sender, e);
            }
        }

    }
}

