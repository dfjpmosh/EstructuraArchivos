using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Diccionario
{
    /* Esta clase es la encargada de empaquetar los datos
     * y hacer operaciones con los bloques
     */
    class CBloque
    {
        private int tam;
        private FileStream fs;
        private BinaryReader br;
        private byte[] bloque;
        private int desp = 0;
        private long dir, sig;
        private int datI;
        private long datL;
        private double datD;
        private char datC;
        private string dS;
        private Boolean dB;
        private CArchivo ar = new CArchivo();
        
        /* Este Constructor recibe el tamaño del bloque e inicializa las varibles */
        public CBloque(int t)
        {
            tam = t;
            sig = -1;
            bloque = new byte[t];

            empaquetaSig(sig);
        }

        /* Este metodo recibe el apuntador a siguiente del bloque y lo empaqueta para que pueda ser guardado*/
        public void empaquetaSig(long s)
        {
            byte[] bloque1 = new byte[10];

            bloque1 = BitConverter.GetBytes(s);
            for (int i = 0; i < bloque1.Length; i++)
                bloque[i + (bloque.Length - 8)] = bloque1[i];
        }

        /* Este metodo recibe el dato en forma de cadena y el tipo
         segun el tipo lo convierte a su tipo y lo convierte a bits y los empaqueta 
         y avanza el apuntador segun el tamaño del tipo*/
        public void empaqueta(string datS, string tipo)
        {
            int cont = 0;
            byte[] bloque1 = new byte[10];

            switch (tipo)
            {
                case "long"://INT
                    datL = Convert.ToInt64(datS);
                    bloque1 = BitConverter.GetBytes(datL);
                    break;
                case "int"://INT
                    datI = Convert.ToInt32(datS);
                    bloque1 = BitConverter.GetBytes(datI);
                    break;
                case "float"://float
                    datD = Convert.ToDouble(datS);
                    bloque1 = BitConverter.GetBytes(datD);
                    break;
                case "char": //char
                    datC = Convert.ToChar(datS);
                    bloque1 = BitConverter.GetBytes(datC);
                    break;
                case "string": //String
                    for (int j = 0; j < datS.Length; j++)
                    {
                        bloque1 = BitConverter.GetBytes(datS[j]);
                        for (int i = 0; i < bloque1.Length; i++)
                            bloque[i + desp] = bloque1[i];
                        desp += bloque1.Length;
                        cont += bloque1.Length;
                    }
                    desp += 60 - cont; //AAAAAAAAcheca ese desplasemiento siempres es el mismo
                    break;
               
            }
            if (tipo != "string")
            {
                for (int i = 0; i < bloque1.Length; i++)
                    bloque[i + desp] = bloque1[i];
                desp += bloque1.Length;
            }
        }

        /* Este metodo recibe el dato en forma de cadena y el tipo
         segun el tipo lo convierte a su tipo y lo convierte a bits y los empaqueta 
         y avanza el apuntador segun el tamaño del tipo*/
        public void empaqueta(string datS, string tipo, int tamc)
        {
            int cont = 0;
            byte[] bloque1 = new byte[10];

            switch (tipo)
            {
                case "long"://INT
                    datL = Convert.ToInt64(datS);
                    bloque1 = BitConverter.GetBytes(datL);
                    break;
                case "int"://INT
                    datI = Convert.ToInt32(datS);
                    bloque1 = BitConverter.GetBytes(datI);
                    break;
                case "float"://float
                    datD = Convert.ToDouble(datS);
                    bloque1 = BitConverter.GetBytes(datD);
                    break;
                case "char": //char
                    datC = Convert.ToChar(datS);
                    bloque1 = BitConverter.GetBytes(datC);
                    break;
                case "string": //String
                    for (int j = 0; j < datS.Length; j++)
                    {
                        bloque1 = BitConverter.GetBytes(datS[j]);
                        for (int i = 0; i < bloque1.Length; i++)
                            bloque[i + desp] = bloque1[i];
                        desp += bloque1.Length;
                        cont += bloque1.Length;
                    }
                    desp += (tamc*2) - cont; //AAAAAAAAcheca ese desplasemiento siempres es el mismo
                    break;

            }
            if (tipo != "string")
            {
                for (int i = 0; i < bloque1.Length; i++)
                    bloque[i + desp] = bloque1[i];
                desp += bloque1.Length;
            }
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public int sacaInt(int tm)
        {
            datI = BitConverter.ToInt32(bloque, desp);//Tamaño de Entero 4 bits
            desp += 4;

            return datI;
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public long sacaLong(int tm)
        {
            datL = BitConverter.ToInt64(bloque, desp);//Tamaño de Largo 8 bits
            desp += 8;

            return datL;
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public double sacaFloat(int tm)
        {
            datD = BitConverter.ToDouble(bloque, desp);
            desp += 8;

            return datD;
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public char sacaChar(int tm)
        {
            datC = BitConverter.ToChar(bloque, desp);
            desp += 2;

            return datC;
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public string sacaString(int tm)
        {
            int cont = 0;
            char d;
            char[] c = new char[tm];
            int j = 0;

            d = BitConverter.ToChar(bloque, desp); //Tamaño de Caracter 2 bits
            while (d != '\0')
            {
                c[j] = d;//Se Llena el arreglo de caracteres
                desp += 2;//Se incrementa el indice
                d = BitConverter.ToChar(bloque, desp);//Se toma el siguiente caracter del arreglo de bits
                j++;
                cont += 2;
            }
            dS = new string(c);
            desp += (tm*2) - cont;
            /*dS = BitConverter.ToString(bloque, desp, tm);
            desp += tm*2;
            */
            return dS;
        }

        /* Este metodo recibe el tamaño segun el tipo 
         * y desempaqueta el dato y lo regresa segun el tipo y la posicion del seplazamiento
         */
        public Boolean sacaBool(int tm)
        {
            dB = BitConverter.ToBoolean(bloque, desp);
            desp += 1;

            return dB;
        }

        /* Este metodo desempaqueta el la direccion del siguente bloque
         */
        public void sacaSiguiente()
        {
            sig = BitConverter.ToInt64(bloque, bloque.Length - 8);
        }

        /* Este metodo recibe el nombre del archivo y calcula la dirección que
         * le corresponde en el archivo al bloque
         */
        public long Direccion(string nom)
        {
            fs = new FileStream(nom, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            Dir = fs.Seek(0, SeekOrigin.End);
            br.Close();
            fs.Close();

            return dir;
        }

        /* Este metodo recibe el bloque y el tipo de dato 
         * segun el desplazamiento de los bloque extrae el dato segun el tipo y
         * retorna si es mayor, igual o menor que el bloque que lo invoca
         */
        public int comparaTo(CBloque b, string ti)
        {
            int desau = b.Des;
            switch (ti)
            {
                case "int":
                    this.datI = sacaInt(4);
                    b.DatI = b.sacaInt(4);
                    if (datI > b.DatI)
                        return 1;
                    if (datI == b.DatI)
                        return 0;
                    if (datI < b.DatI)
                        return -1;
                break;
                case "float":
                    this.datD = sacaFloat(8);
                    b.DatD = b.sacaFloat(8);
                    if (datD > b.DatD)
                        return 1;
                    if (datD == b.DatD)
                        return 0;
                    if (datD < b.DatD)
                        return -1;
                break;
                case "char":
                    this.datC = sacaChar(2);
                    b.DatC = b.sacaChar(2);
                    if (datC.CompareTo(b.DatC) == 1)
                        return 1;
                    if (datC.CompareTo(b.DatC) == 0)
                        return 0;
                    if (datC.CompareTo(b.DatC) == -1)
                        return -1;
                break;
                case "string":
                    this.dS = sacaString(tam * 2);
                    b.DS = b.sacaString(b.Tam * 2);
                    if (dS.CompareTo(b.DS) == 1)
                        return 1;
                    if (dS.CompareTo(b.DS) == 0)
                        return 0;
                    if (dS.CompareTo(b.DS) == -1)
                        return -1;
                break;
            }
            return 2;
        }

        /* Este metodo retorna o captura al arreglo de bytes del bloque*/
        public byte[] Bloque
        {
            get { return bloque; }
            set { bloque = value; }
        }

        /* Este metodo retorna o captura la direccón del bloque*/
        public long Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        /* Este metodo retorna o captura el tamaño del bloque*/
        public int Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        /* Este metodo retorna o captura el desplazamiento del bloque*/
        public int Des
        {
            get { return desp; }
            set { desp = value; }
        }

        /* Este metodo retorna o captura el apuntador al siguente bloque del bloque*/
        public long Siguiente
        {
            get { return sig; }
            set { sig = value; }
        }

        /* Este metodo retorna o captura el Dato entero del bloque*/
        public int DatI
        {
            get { return datI; }
            set { datI = value; }
        }

        /* Este metodo retorna o captura el dato double del bloque*/
        public double DatD
        {
            get { return datD; }
            set { datD = value; }
        }

        /* Este metodo retorna o captura el dato char del bloque*/
        public char DatC
        {
            get { return datC; }
            set { datC = value; }
        }

        /* Este metodo retorna o captura el dato booleano del bloque*/
        public Boolean DB
        {
            get { return dB; }
            set { dB = value; }
        }

        /* Este metodo retorna o captura el dato de tipo cadena del bloque*/
        public string DS
        {
            get { return dS; }
            set { dS = value; }
        }
    }
}
