using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Clases
{
    public class ParametrosRpt
    {

        public string nombre_secretatio { get; set; }

        public string juicio_referido_titulo_credito { get; set; }
        public string numero_titulo_credito { get; set; }
        public string identificacion_clientes { get; set; }
        public string identificacion_clientes_1 { get; set; }
        public string identificacion_clientes_2 { get; set; }
        public string identificacion_clientes_3 { get; set; }

        public string identificacion_garantes { get; set; }
        public string identificacion_garantes_1 { get; set; }
        public string identificacion_garantes_2 { get; set; }
        public string identificacion_garantes_3 { get; set; }
        public int lote_juicios { get; set; }

        public int id_provincias { get; set; }
        public int id_abogado { get; set; }

        public int id_juicios { get; set; }
        public int id_estados_procesales_juicios { get; set; }
        public int id_secretario { get; set; }
        public int id_ciudad { get; set; }
        public int id_rol { get; set; }

        public int id_origen_juicio { get; set; }

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
        public string comprarado_fomento { get; set;  }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }

        public int id_tipo_restructuracion { get; set; }
        public string levantamiento_medida { get; set; }
        public string archivado_restructuracion { get; set; }


        


    }
}