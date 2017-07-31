using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Clases
{
    public class ParametrosRpt
    {
 
        public string juicio_referido_titulo_credito { get; set; }
        public string numero_titulo_credito { get; set; }
        public string identificacion_clientes { get; set; }
        public int id_provincias { get; set; }
        public int id_abogado { get; set; }
        public int id_estados_procesales_juicios { get; set; }
        public int id_secretario { get; set; }
        public int id_ciudad { get; set; }
        public int id_rol { get; set; }

        public string cuerpo_oficios { get; set; }
        public string ruta_oficios { get; set; }
        public string nombre_archivo_oficios { get; set; }
        public DateTime fecha_levantamiento { get; set; }
        public DateTime hora_levantamiento { get; set; }

        public string razon_levantamiento { get; set; }
        public string numero_oficio { get; set; }
        public string dirigido_levantamiento { get; set; }
        public string ruta_providencias { get; set; }
        public string nombre_archivo_providencias { get; set; }

        public DateTime fecha_providencias { get; set; }
        public DateTime hora_providencias { get; set; }
        public string razon_providencias { get; set; }

    }
}