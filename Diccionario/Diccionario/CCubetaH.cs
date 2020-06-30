using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    /* Esta clase se encarga de hacer operaciones con las
     * cubetas de la organización hash estatica
     */
    class CCubetaH
    {
        private  long[] aptBloque;  //direcciones a bloques
	    private long sigCubeta;   // direccion de la siguiente cubeta en archivo
	    private int tamCubeta;  //tama?o de la cubeta
	    private long dir;//Direcci?n de la cubeta
	    private int cont;

        /* Este constructor recibe el tamaño y la direccón
         * de la cubeta; crea el arreglo e inicializa las variables
         */
	    public CCubetaH(int tam, long direccion)
	    {
            int i;

		    tamCubeta = tam;
		    sigCubeta = -1;
		    aptBloque = new long[tamCubeta];
		    dir = direccion;
		    for(i=0; i<tamCubeta; i++)
		    {
			    aptBloque[i] = -1;
		    }		
		    
            cont = 0;
	    }

        /* Este constructor recibe el tamaño y la direccón
         * de la cubeta; crea el arreglo e inicializa las variables
         */
        public CCubetaH(long direccion, int tam)
        {
            int i;
            tamCubeta = tam;
            dir = direccion;

            for (i = 0; i < tamCubeta; i++)
            {
                aptBloque[i] = -1;
            }	
        }

        /* Este metodo retorna o captura el arreglo de long del bloque*/
        public long[] AptBloque
        {
            get { return aptBloque; }
            set { aptBloque = value; }
        }

        /* Este metodo retorna o captura el apuntador a las siguiente cubeta*/
        public long SigCubeta
        {
            get { return sigCubeta; }
            set { sigCubeta = value; }
        }

        /* Este metodo retorna o captura el contador de la cubeta*/
        public int Cont
        {
            get { return cont; }
            set { cont = value; }
        }

        /* Este metodo retorna o captura la direccion de la cubeta*/
        public long Direccion
        {
            get { return dir; }
            set { dir = value; }
        }

        /* Este metodo retorna o captura el tamaño de la cubeta*/
        public int Tam
        {
            get { return tamCubeta; }
            set { tamCubeta = value; }
        }
    }
}
