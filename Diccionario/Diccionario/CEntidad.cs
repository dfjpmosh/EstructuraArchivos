using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diccionario
{
    /* Esta clase controla
     * la creacion de las entidades
     */
    class CEntidad
    {
        private string nom;
        private long dir;
        private long aptEnt;
        private long aptAtr;
        private long aptDat;

        /* Este constructor inicializa las variables de la clase*/
        public CEntidad()
        {
            dir = -1;
            aptEnt = -1;
            aptAtr = -1;
            aptDat = -1;
        }

        /* Este metod retorna o captura el nombre de la entidad*/
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }

        /* Este metod retorna o captura la direccion de la entidad*/
        public long Direccion
        {
            get { return dir; }
            set { dir = value; }
        }

        /* Este metod retorna o captura el apuntador a la siguente entidad de la entidad*/
        public long AptEntidad
        {
            get { return aptEnt; }
            set { aptEnt = value; }
        }

        /* Este metod retorna o captura el apuntador al atributo de la entidad*/
        public long AptAtributo
        {
            get { return aptAtr; }
            set { aptAtr = value; }
        }

        /* Este metod retorna o captura el apuntador a los datos de la entidad*/
        public long AptDatos
        {
            get { return aptDat; }
            set { aptDat = value; }
        }
    }
}
