using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ClienteBO
    {
        //AQUI VAN LOS CAMPOS DE LA TABLA DE LA BASE DE DATOS
        //EJEMPLO
        //USER_ID NUMBER NOT NULL,
        //NOMBRE VARACHAR2(40) NOT NULL,
        //APELLIDO VARCHAR2(40) NOT NULL,
        //EMAIL VARCHAR2(40) NOT NULL,
        //TELEFONO NUMBER
        public string USER_ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CORREO { get; set; }
        public int TELEFONO { get; set; }

    }
}
