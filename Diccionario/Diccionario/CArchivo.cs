using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;



namespace Diccionario
{
    /* En esta clase se manejan las operaciones con el archivo
     * se abre y se cierra dependiendo lo que vaya a escribir o leer
     */
    class CArchivo
    {
        private FileStream fs;
        private BinaryWriter bw;
        private BinaryReader br;
        private string nom;
        private bool band;

        /*Esta función crea un archivo para poder hacer operaciones con el
         */
        public void Crear_Archivo(long cab)
        {
            fs = new FileStream(nom, FileMode.Create, FileAccess.Write);
            fs.Seek(0, SeekOrigin.Begin);

            bw = new BinaryWriter(fs);
            bw.Write(cab);

            bw.Close();
            fs.Close();
        }

        /*Captura y regresa el nombre del archivo con el que se va a trabajar
         */
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }

        /*Escribe la cabecera del archivo
         */
        public void Escribecab(long cab)
        {
            FileStream fs = new FileStream(nom, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(0, SeekOrigin.Begin);
            escribeBin.Write(cab);

            escribeBin.Close();
            fs.Close();
        }

        /*Este metodo se encarga de abrir el archivo y
         * escribir o sobrescribir la entidad se se modifico
         */
        public void EscribeEntidad(CEntidad ent)
        {
            FileStream fs = new FileStream(nom, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(ent.Direccion, SeekOrigin.Begin);
            escribeBin.Write(ent.Direccion);
            escribeBin.Write(ent.Nombre);
            escribeBin.Write(ent.AptEntidad);
            escribeBin.Write(ent.AptAtributo);
            escribeBin.Write(ent.AptDatos);

            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo abre el archivo y regresa una lista con todas
         * las entidades.
         */
        public List<CEntidad> abrirArchivo(string nombre, long ca)
        {
            nom = nombre;
            long tam;
            band = false;
            List<CEntidad> lE = new List<CEntidad>();

            try
            {
                fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                tam = br.BaseStream.Seek(0, SeekOrigin.End);
                fs.Seek(0, SeekOrigin.Begin);
                ca = br.ReadInt64();

                br.BaseStream.Seek(ca, SeekOrigin.Begin);
                while (!band)
                {
                    CEntidad ent = new CEntidad();
                    ent.Direccion = br.ReadInt64();
                    ent.Nombre = br.ReadString();
                    ent.AptEntidad = br.ReadInt64();
                    ent.AptAtributo = br.ReadInt64();
                    ent.AptDatos = br.ReadInt64();
                    lE.Add(ent);

                    if (ent.AptEntidad == -1)
                    {
                        band = true;
                    }
                    else
                    {
                        fs.Seek(ent.AptEntidad, SeekOrigin.Begin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                //MessageBox.Show("El Archivo No Se Puede Abrir");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
            
            return lE;
        }

        /* Este metodo recibe una entidad  
         * y regresa una lista con los atributos de dicha entidad
         */
        public List<CAtributo> abrirArchivoAtributo(string nombre, CEntidad ent) //ca es el AptAtrb de la entidad
        {
            nom = nombre;
            band = false;
            List<CAtributo> lA = new List<CAtributo>();

            try
            {
                fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                br.BaseStream.Seek(ent.AptAtributo, SeekOrigin.Begin);
                while (!band)
                {
                    CAtributo atr = new CAtributo();
                    atr.Direccion = br.ReadInt64();
                    atr.Nombre = br.ReadString();
                    atr.AptAtributo = br.ReadInt64();
                    atr.AptEntidad = br.ReadInt64();
                    atr.TipoClave = br.ReadInt32();
                    atr.Tamaño = br.ReadInt32();
                    atr.TipoDato = br.ReadString();
                    lA.Add(atr);

                    if (atr.AptAtributo == -1)
                    {
                        band = true;
                    }
                    else
                    {
                        fs.Seek(atr.AptAtributo, SeekOrigin.Begin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                //MessageBox.Show("El Archivo No Existe");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
            return lA;
        }

        /* Este metodo recibe un atributo y lo escribe en el archivo
         */
        public void EscribeAtributo(CAtributo a)
        {
            FileStream fs = new FileStream(nom, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(a.Direccion, SeekOrigin.Begin);
            escribeBin.Write(a.Direccion);
            escribeBin.Write(a.Nombre);
            escribeBin.Write(a.AptAtributo);
            escribeBin.Write(a.AptEntidad);
            escribeBin.Write(a.TipoClave);
            escribeBin.Write(a.Tamaño);
            escribeBin.Write(a.TipoDato);

            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo recibe un bloque de datos y lo
         * escribe en el archivo segun los datos que contiene
         */
        public void EscribeBloque(CBloque b)
        {
            FileStream fs = new FileStream(nom, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(b.Dir, SeekOrigin.Begin);
            escribeBin.Write(b.Bloque);

            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo recibe el nombre de archivo, el tamaño del bloque y su direccion
         * con estos datos busca y lee el bloque y lo regresa
         */
        public byte[] LeeBloque(string Nombre, int tam, long dir)
        {
            byte[] b = new byte[tam];

            FileStream fs = new FileStream(Nombre, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            br.BaseStream.Seek(dir, SeekOrigin.Begin);
            b = br.ReadBytes(tam);
            br.Close();
            fs.Close();

            return b;
        }

        /* Este metodo regresa la ultima posicion del archivo
         * que seria la dirección del nuevo dato a escribir
         */
        public long Direccion(string nom)
        {
            long dir;

            fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            dir = fs.Seek(0, SeekOrigin.End);
            br.Close();
            fs.Close();

            return dir;
        }

        /* Este metod escribe un indice en el archivo de la 
         * organización secuencial indexada
         */
        public void EscribeIndiceSI(CIndiceSI i)
        {
            FileStream fs = new FileStream(nom, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(i.Dir, SeekOrigin.Begin);
            escribeBin.Write(i.Inicio);
            escribeBin.Write(i.SigInd);
            escribeBin.Write(i.ApDat);
            
            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo recibe el nombre del archivo y la entidad
         * retorna la lista de indicis que pertenece a la entidad
         */
        public List<CIndiceSI> abrirArchivoIndice(string nombre, CEntidad ent) //ca es el AptAtrb de la entidad
        {
            Boolean co = true;
            long dAux=0;
            nom = nombre;
            band = false;
            List<CIndiceSI> lI = new List<CIndiceSI>();

            try
            {
                fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                br.BaseStream.Seek(ent.AptDatos, SeekOrigin.Begin);
                while (!band)
                {
                    CIndiceSI ind = new CIndiceSI();
                    if(!co)
                        ind.Dir = dAux;
                    else
                    {
                        ind.Dir = ent.AptDatos;
                        co = false;
                    }
                    ind.Inicio = br.ReadInt32();
                    dAux = ind.SigInd = br.ReadInt64();
                    ind.ApDat = br.ReadInt64();
                    lI.Add(ind);

                    if (ind.SigInd == -1)
                    {
                        band = true;
                    }
                    else
                    {
                        fs.Seek(ind.SigInd, SeekOrigin.Begin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                //MessageBox.Show("El Archivo No Existe");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
            return lI;
        }

        /* Este metodo recibe un arreglo de long, el nombre del archivo, tamaño del arreglo y la direccion
         * donde sera escrito, esta información pertenece a la organización hash estatica.
         */
        public void EscribetablaHash(long[] ta, string Nombre, int tam, long dir)
        {
            FileStream fs = new FileStream(Nombre, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(dir, SeekOrigin.Begin);
            for(int i=0; i<tam; i++)
                escribeBin.Write(ta[i]);

            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo revibe el nombre del archivo, el tamaño del arreglo y la direccion 
         * de donde sera leido, este metodo abre el archivo y lee el arreglo de long y los retorna.
         */
        public long[] LeeTablaHash(string Nombre, int tam, long dir)
        {
            long[] ta = new long[tam];

            FileStream fs = new FileStream(Nombre, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            br.BaseStream.Seek(dir, SeekOrigin.Begin);
            for(int i=0; i<tam; i++)
                ta[i] = br.ReadInt64();
            br.Close();
            fs.Close();

            return ta;
        }

        /* Este metodo recibe una cubeta y el nombre del archivo
         * abre el archivo y escribe la cubete en la direccion que le corresponda
         */
        public void EscribeCubeta(CCubetaH cub, string Nombre)
        {
            FileStream fs = new FileStream(Nombre, FileMode.Open, FileAccess.Write);
            BinaryWriter escribeBin = new BinaryWriter(fs);

            fs.Seek(cub.Direccion, SeekOrigin.Begin);
            for (int i = 0; i < cub.Tam; i++)
                escribeBin.Write(cub.AptBloque[i]);
            escribeBin.Write(cub.SigCubeta);
            
            escribeBin.Close();
            fs.Close();
        }

        /* Este metodo recibe el nombre del archivo, la direccion, y el tamaño de la cubeta
         * abre el archivo y lee las cubetas y regrasa una lista de ellas.
         */
        public List<CCubetaH> abrirArchivoCubeta(string nombre, long dir, int tam) //ca es el AptAtrb de la entidad
        {
            nom = nombre;
            band = false;
            List<CCubetaH> lC = new List<CCubetaH>();

            try
            {
                fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                br.BaseStream.Seek(dir, SeekOrigin.Begin);
                while (!band)
                {
                    CCubetaH cub = new CCubetaH(tam, dir);
                    for (int i = 0; i < tam; i++)
                        cub.AptBloque[i] = br.ReadInt64();
                    cub.SigCubeta = br.ReadInt64();
                    lC.Add(cub);

                    if (cub.SigCubeta == -1)
                    {
                        band = true;
                    }
                    else
                    {
                        dir = cub.SigCubeta;
                        fs.Seek(cub.SigCubeta, SeekOrigin.Begin);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                //MessageBox.Show("El Archivo No Existe");
            }
            finally
            {
                br.Close();
                fs.Close();
            }
            return lC;
        }
    }
}
