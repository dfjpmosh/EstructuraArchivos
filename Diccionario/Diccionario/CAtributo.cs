using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    /* Esta clase es la encarga de crear los atributos
     */
    class CAtributo
    {
        private string nom;
        private long dir;
        private long aptEntExt;
        private long aptAtr;
        private int tipoClave; //(Primaria, Externa, Ninguna)
        private int tam; //si es de tipo string
        private string tipoDato; //tipo (int, float, string)
        
        /* Este constructor inicializa las variables de la
         * clase
         */
        public CAtributo()
        {
            nom = "";
            dir = -1;
            aptEntExt = -1;
            aptAtr = -1;
            tipoClave = 0;
            tipoDato = "";
        }

        /* Este metodo captura y retorna el nombre del atributo
         */
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }

        /* Este metodo captura y retorna la direccion que le corresponde en el archivo al atributo*/
        public long Direccion
        {
            get { return dir; }
            set { dir = value; }
        }

        /* Este metodo captura y retorna el apundatador de la entidad externa que contiene el atributo
         */
        public long AptEntidad
        {
            get { return aptEntExt; }
            set { aptEntExt = value; }
        }

        /* Este metodo captura y retorna al apuntador al siguiente atributo
         */
        public long AptAtributo
        {
            get { return aptAtr; }
            set { aptAtr = value; }
        }

        /* Este metodo captura y retorna el tipo de clave que contiene el atributo
         */
        public int TipoClave
        {
            get { return tipoClave; }
            set { tipoClave = value; }
        }

        /* Este metodo captura y retorna el tipo de dato que contiene el atributo
         */
        public string TipoDato
        {
            get { return tipoDato; }
            set { tipoDato = value; }
        }

        /* Este metodo captura y retorna el tamaño segun el tipo de datos que contiene
         */
        public int Tamaño
        {
            get { return tam; }
            set { tam = value; }
        }
    }
}
