using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    /* Esta clase controla las varibles
     * de los indices para el amenejo 
     * de la organización secuencial.
     */
    class CIndiceSI
    {
        private int inicio; //inicio del indice
	    private int TAM;  // tamaño del rango
	    private long apDat; // apuntador a los bloques de los datos
	    private long sigInd; //apuntador al siguiente indice
	    private long dir;
	    private CBloque bAnt;
        private CArchivo arch;

        public CIndiceSI()
        {
        }

        /* Este constructor recibe la clave del indice
         * incializa la varibles y
         * calcula el valor del inicio del rango del indice.
         */
        public CIndiceSI(long claveIn)// el bloque ya viene escrito en archivo
	    {
		    TAM = 10; // tamaño del rango 
            inicio = (int)(claveIn - (claveIn % TAM));//calcula el inicio de del indice
            apDat = -1;
		    sigInd = -1;
		}

        /* Este metodo retorna o captura la direccion del indice*/
        public long Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        /* Este metodo retorna o captura el apuntador a datos del indice*/
        public long ApDat
        {
            get { return apDat; }
            set { apDat = value; }
        }

        /* Este metodo retorna o captura el apuntador al siguiente indice del indice*/
        public long SigInd
        {
            get { return sigInd; }
            set { sigInd = value; }
        }

        /* Este metodo retorna o captura el incio del rango del indice*/
        public int Inicio
        {
            get { return inicio; }
            set { inicio = value; }
        }

        /* Este metodo retorna o captura el tamaño del rango del indice*/
        public int TAMA
        {
            get { return TAM; }
            set { TAM = value; }
        }
    }
    
}
