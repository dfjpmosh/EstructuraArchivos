using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Diccionario
{
    /* Este clase es la encargada de dar
     * manteniento al diccionario y a las organizaciones
     */
    class CMantenimiento
    {
        List<CEntidad> le = new List<CEntidad>();
        List<CEntidad> leaux = new List<CEntidad>();
        List<CAtributo> la = new List<CAtributo>();
        CArchivo ar = new CArchivo();
        CArchivo nuevo = new CArchivo();
        string nom;
        long ca = -1;
        FileStream fs;
        BinaryReader br;

        /* Este metodo es el encargo de dar
         * mantenimiento al diccionario
         */
        public void mantenimientoDic(string na)
        {
            nom = na.Substring(0, na.Length - 4) + ".tmp";
            File.Copy(na, nom);
            File.Delete(na);

            nuevo.Nombre = na;
            nuevo.Crear_Archivo(ca);
            nuevo.Escribecab(8);
            le = ar.abrirArchivo(nom, ca);
            foreach (CEntidad correE in le)
            {
                fs = new FileStream(na, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                correE.Direccion = fs.Seek(0, SeekOrigin.End);
                br.Close();
                fs.Close();
                nuevo.EscribeEntidad(correE);
            }
            le[le.Count-1].AptEntidad = -1;
            nuevo.EscribeEntidad(le[le.Count - 1]);
            for (int i = 0; i < le.Count - 1; i++)
            {
                le[i].AptEntidad = le[i+1].Direccion;
                nuevo.EscribeEntidad(le[i]);
            }

            foreach (CEntidad correE in le)
            {
                la = ar.abrirArchivoAtributo(nom, correE);
                foreach (CAtributo correA in la)
                {
                    fs = new FileStream(na, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    correA.Direccion = fs.Seek(0, SeekOrigin.End);
                    br.Close();
                    fs.Close();
                    nuevo.EscribeAtributo(correA);
                }
                la[la.Count - 1].AptAtributo = -1;
                nuevo.EscribeAtributo(la[la.Count - 1]);
                correE.AptAtributo = la[0].Direccion;
                nuevo.EscribeEntidad(correE);
                for (int i = 0; i < la.Count - 1; i++)
                {
                    la[i].AptAtributo = la[i + 1].Direccion;
                    nuevo.EscribeAtributo(la[i]);
                }
            }
            
            long c = -1;
            long enext;
            string nomee;
            leaux = nuevo.abrirArchivo(na, c);
            le = ar.abrirArchivo(nom, ca);
            foreach (CEntidad ce in leaux)
            {
                la = nuevo.abrirArchivoAtributo(na, ce);

                foreach (CAtributo coa in la)
                    if (coa.AptEntidad != -1)
                    {
                        enext = coa.AptEntidad;
                        foreach (CEntidad cee in le)
                            if (enext == cee.Direccion)
                            {
                                nomee = cee.Nombre;
                                foreach (CEntidad coe in leaux)
                                    if (nomee == coe.Nombre)
                                    {
                                        coa.AptEntidad = coe.Direccion;
                                        nuevo.EscribeAtributo(coa);
                                    }
                            }
                    }
            }

            File.Delete(nom);
            MessageBox.Show("Mantenimiento Terminado");
        }
    }
    
}
