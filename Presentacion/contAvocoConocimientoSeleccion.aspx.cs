using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Npgsql;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace Presentacion
{
    public partial class contAvocoConocimientoSeleccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            string _id_juicios = "";
            string _id_abogado = "";
            string _juicio_referido_titulo_credito = "";
            string _numero_titulo_credito = "";

            string _identificacion_clientes = "";
            string _identificacion_clientes_1 = "";
            string _identificacion_clientes_2 = "";
            string _identificacion_clientes_3 = "";

            string _identificacion_garantes = "";
            string _identificacion_garantes_1 = "";
            string _identificacion_garantes_2 = "";
            string _identificacion_garantes_3 = "";


            string _id_estados_procesales_juicios = "";
            string _id_provincias = "";
            string _id_secretario = "";
            int _id_rol = 0;

            DateTime _fecha_avoco = DateTime.Now;
            DateTime _fecha_avoco_razones = DateTime.Now;
            DateTime _fecha_razon = DateTime.Now;

            string _razon_avoco = "0";

            

            string where1 = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            string where5 = "";
            string where6 = "";
            string where7 = "";
            string where8 = "";

            string where9 = "";
            string where10 = "";
            string where11 = "";
            string where12 = "";
            string where13 = "";
            string where14 = "";
            string where15 = "";
            string where16 = "";

            if (!String.IsNullOrEmpty(Request.QueryString["id_rol"]))
            {
                _id_rol = Convert.ToInt32(Request.QueryString["id_rol"]);


            }

            if (!String.IsNullOrEmpty(Request.QueryString["id_juicios"]))
            {

                _id_juicios = Request.QueryString["id_juicios"];
                if (_id_juicios != "0")
                {
                    where1 = "  AND juicios.id_juicios = '" + _id_juicios + "'       ";
                }

            }
            if (!String.IsNullOrEmpty(Request.QueryString["id_abogado"]))
            {
                _id_abogado = Request.QueryString["id_abogado"];
                if (_id_abogado != "0")
                {
                    where2 = "  AND asignacion_secretarios_view.id_abogado = '" + _id_abogado + "'       ";
                }

            }
            if (!String.IsNullOrEmpty(Request.QueryString["juicio_referido_titulo_credito"]))
            {
                _juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];

                where3 = "  AND juicios.juicio_referido_titulo_credito = '" + _juicio_referido_titulo_credito + "'       ";
            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes"]))
            {
                _identificacion_clientes = Request.QueryString["identificacion_clientes"];

                where4 = "  AND clientes.identificacion_clientes = '" + _identificacion_clientes + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_1"]))
            {
                _identificacion_clientes_1 = Request.QueryString["identificacion_clientes_1"];

                where9 = "  AND clientes.identificacion_clientes_1 = '" + _identificacion_clientes_1 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_2"]))
            {
                _identificacion_clientes_2 = Request.QueryString["identificacion_clientes_2"];

                where10 = "  AND clientes.identificacion_clientes_2 = '" + _identificacion_clientes_2 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_3"]))
            {
                _identificacion_clientes_3 = Request.QueryString["identificacion_clientes_3"];

                where11 = "  AND clientes.identificacion_clientes_3 = '" + _identificacion_clientes_3 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes"]))
            {
                _identificacion_garantes = Request.QueryString["identificacion_garantes"];

                where12 = "  AND clientes.identificacion_garantes = '" + _identificacion_garantes + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_1"]))
            {
                _identificacion_garantes_1 = Request.QueryString["identificacion_garantes_1"];

                where13 = "  AND clientes.identificacion_garantes_1 = '" + _identificacion_garantes_1 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_2"]))
            {
                _identificacion_garantes_2 = Request.QueryString["identificacion_garantes_2"];

                where14 = "  AND clientes.identificacion_garantes_2 = '" + _identificacion_garantes_2 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_3"]))
            {
                _identificacion_garantes_3 = Request.QueryString["identificacion_garantes_3"];

                where15 = "  AND clientes.identificacion_garantes_3 = '" + _identificacion_garantes_3 + "'       ";

            }


            if (!String.IsNullOrEmpty(Request.QueryString["id_estados_procesales_juicios"]))
            {
                _id_estados_procesales_juicios = Request.QueryString["id_estados_procesales_juicios"];
                if (_id_estados_procesales_juicios != "0")
                {
                    where5 = "  AND juicios.id_estados_procesales_juicios = '" + _id_estados_procesales_juicios + "'       ";
                }


            }

            if (!String.IsNullOrEmpty(Request.QueryString["numero_titulo_credito"]))
            {
                _numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
                where6 = "  AND titulo_credito.numero_titulo_credito = '" + _numero_titulo_credito + "'       ";
            }

            if (!String.IsNullOrEmpty(Request.QueryString["id_provincias"]))
            {
                _id_provincias = Request.QueryString["id_provincias"];
                if (_id_provincias != "0")
                {
                    where7 = "  AND clientes.id_provincias = '" + _id_provincias + "'       ";
                }


            }


            if (!String.IsNullOrEmpty(Request.QueryString["id_secretario"]))
            {
                _id_secretario = Request.QueryString["id_secretario"];
                if (_id_secretario != "0")
                {
                    where8 = "  AND asignacion_secretarios_view.id_secretario = '" + _id_secretario + "'       ";
                }

            }



            if (!String.IsNullOrEmpty(Request.QueryString["fecha_avoco"]))
            {

                string fecha = Request.QueryString["fecha_avoco"];
                string hora = Request.QueryString["hora_avoco"];

                if (fecha != "0")
                {
                    _fecha_avoco = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_avoco_razones = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_razon = Convert.ToDateTime(fecha);
                }



            }

            if (!String.IsNullOrEmpty(Request.QueryString["razon_avoco"]))
            {


                if (Request.QueryString["razon_avoco"] != "")
                {
                    _razon_avoco = Request.QueryString["razon_avoco"];
                }

            }

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_desde"]))
            {
                string fecha_desde = Request.QueryString["fecha_desde"];
                string fecha_hasta = Request.QueryString["fecha_hasta"];

                where16 += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "'";
            }





            string _nombre_impulsor_anterior = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_impulsor_anterior"]))
            {


                if (Request.QueryString["nombre_impulsor_anterior"] != "")
                {
                    _nombre_impulsor_anterior = Request.QueryString["nombre_impulsor_anterior"];
                }
                else {
                    _nombre_impulsor_anterior = "S/N";
                }

            }


            string _tipo_acto = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_acto"]))
            {


                if (Request.QueryString["tipo_acto"] != "")
                {
                    _tipo_acto = Request.QueryString["tipo_acto"];
                }
                else {
                    _tipo_acto = "S/N";
                }

            }
            string _tipo_ley = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_ley"]))
            {


                if (Request.QueryString["tipo_ley"] != "")
                {
                    _tipo_ley = Request.QueryString["tipo_ley"];
                }
                else
                {
                    _tipo_ley = "S/N";
                }

            }


            string _tipo_cartera = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cartera"]))
            {


                if (Request.QueryString["tipo_cartera"] != "")
                {
                    _tipo_cartera = Request.QueryString["tipo_cartera"];
                }
                else {
                    _tipo_cartera = "S/N";
                }

            }


            


            string _nombre_canton = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_canton"]))
            {


                if (Request.QueryString["nombre_canton"] != "")
                {
                    _nombre_canton = Request.QueryString["nombre_canton"];
                }
                else {
                    _nombre_canton = "S/N";
                }

            }

            


            string _cantidad_retener = "";
            if (!String.IsNullOrEmpty(Request.QueryString["cantidad_retener"]))
            {


                if (Request.QueryString["cantidad_retener"] != "")
                {
                    _cantidad_retener = Request.QueryString["cantidad_retener"];
                }
                else {
                    _cantidad_retener = "S/N";
                }

            }


            string _cantidad_retener_avoco_conocimiento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["cantidad_retener_avoco_conocimiento"]))
            {


                if (Request.QueryString["cantidad_retener_avoco_conocimiento"] != "")
                {
                    _cantidad_retener_avoco_conocimiento = Request.QueryString["cantidad_retener_avoco_conocimiento"];
                }
                else
                {
                    _cantidad_retener_avoco_conocimiento = "S/N";
                }

            }



            string _cuenta_retener = "";
            if (!String.IsNullOrEmpty(Request.QueryString["cuenta_retener"]))
            {


                if (Request.QueryString["cuenta_retener"] != "")
                {
                    _cuenta_retener = Request.QueryString["cuenta_retener"];
                }
                else
                {
                    _cuenta_retener = "S/N";
                }

            }

            string _nombre_entidad_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_entidad_cuenta"]))
            {


                if (Request.QueryString["nombre_entidad_cuenta"] != "")
                {
                    _nombre_entidad_cuenta = Request.QueryString["nombre_entidad_cuenta"];
                }
                else
                {
                    _nombre_entidad_cuenta = "S/N";
                }

            }

            string _direccion_juzgado = "";
            if (!String.IsNullOrEmpty(Request.QueryString["direccion_juzgado"]))
            {


                if (Request.QueryString["direccion_juzgado"] != "")
                {
                    _direccion_juzgado = Request.QueryString["direccion_juzgado"];
                }
                else {
                    _direccion_juzgado = "S/N";
                }

            }



            






            string _pie_oficios = "";
            if (!String.IsNullOrEmpty(Request.QueryString["pie_oficios"]))
            {


                if (Request.QueryString["pie_oficios"] != "")
                {
                    _pie_oficios = Request.QueryString["pie_oficios"];
                }
                else {
                    _pie_oficios = "S/N";
                }

            }

            

            string _impulsor_saliente_cambio_liquidador = "";
            if (!String.IsNullOrEmpty(Request.QueryString["impulsor_saliente_cambio_liquidador"]))
            {


                if (Request.QueryString["impulsor_saliente_cambio_liquidador"] != "")
                {
                    _impulsor_saliente_cambio_liquidador = Request.QueryString["impulsor_saliente_cambio_liquidador"];
                }
                else {
                    _impulsor_saliente_cambio_liquidador = "S/N";
                }

            }












            string _tipo_credito = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_credito"]))
            {


                if (Request.QueryString["tipo_credito"] != "")
                {
                    _tipo_credito = Request.QueryString["tipo_credito"];
                }
                else {
                    _tipo_credito = "Ninguno";
                }

            }


            string _remplaza_impulsor = "";
            if (!String.IsNullOrEmpty(Request.QueryString["remplaza_impulsor"]))
            {


                if (Request.QueryString["remplaza_impulsor"] != "")
                {
                    _remplaza_impulsor = Request.QueryString["remplaza_impulsor"];
                }
                else {
                    _remplaza_impulsor = "S/N";
                }

            }

            



            string _reemplazar = "";
            if (!String.IsNullOrEmpty(Request.QueryString["reemplazar"]))
            {


                if (Request.QueryString["reemplazar"] != "")
                {
                    _reemplazar = Request.QueryString["reemplazar"];
                }
                else {
                    _reemplazar = "0";
                }

            }



            


            string _nombre_secretario_anterior = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_secretario_anterior"]))
            {


                if (Request.QueryString["nombre_secretario_anterior"] != "")
                {
                    _nombre_secretario_anterior = Request.QueryString["nombre_secretario_anterior"];
                }
                else {
                    _nombre_secretario_anterior = "S/N";
                }

            }



            string _numero_liquidacion = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_liquidacion"]))
            {
                if (Request.QueryString["numero_liquidacion"] != "")
                {
                    _numero_liquidacion = Request.QueryString["numero_liquidacion"];
                }
                else {
                    _numero_liquidacion = "S/N";
                }
            }

            DateTime _fecha_auto_pago = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_auto_pago"]))
            {
                string fecha1 = Request.QueryString["fecha_auto_pago"];
               
                if (fecha1 != "0")
                {
                    _fecha_auto_pago = Convert.ToDateTime(fecha1);
                }
            }


            
            string _tipo_lev = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_lev"]))
            {
                if (Request.QueryString["tipo_lev"] != "")
                {
                    _tipo_lev = Request.QueryString["tipo_lev"];
                }
                else {
                    _tipo_lev = "S/N";
                }
            }

            string _agregar_disposicion = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion"]))
            {
                if (Request.QueryString["agregar_disposicion"] != "")
                {
                    _agregar_disposicion = Request.QueryString["agregar_disposicion"];
                }
                else {
                    _agregar_disposicion = "S/N";
                }
            }

            string _agregar_disposicion_1 = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion_1"]))
            {
                if (Request.QueryString["agregar_disposicion_1"] != "")
                {
                    _agregar_disposicion_1 = Request.QueryString["agregar_disposicion_1"];
                }
                else {
                    _agregar_disposicion_1 = "S/N";
                }
            }


            string _agregar_disposicion_2 = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion_2"]))
            {
                if (Request.QueryString["agregar_disposicion_2"] != "")
                {
                    _agregar_disposicion_2 = Request.QueryString["agregar_disposicion_2"];
                }
                else {
                    _agregar_disposicion_2 = "S/N";
                }
            }






            string _agregar_disposicion_pago_total = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion_pago_total"]))
            {
                if (Request.QueryString["agregar_disposicion_pago_total"] != "")
                {
                    _agregar_disposicion_pago_total = Request.QueryString["agregar_disposicion_pago_total"];
                }
                else {
                    _agregar_disposicion_pago_total = "S/N";
                }
            }

            string _agregar_disposicion_1_pago_total = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion_1_pago_total"]))
            {
                if (Request.QueryString["agregar_disposicion_1_pago_total"] != "")
                {
                    _agregar_disposicion_1_pago_total = Request.QueryString["agregar_disposicion_1_pago_total"];
                }
                else {
                    _agregar_disposicion_1_pago_total = "S/N";
                }
            }


            string _agregar_disposicion_2_pago_total = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["agregar_disposicion_2_pago_total"]))
            {
                if (Request.QueryString["agregar_disposicion_2_pago_total"] != "")
                {
                    _agregar_disposicion_2_pago_total = Request.QueryString["agregar_disposicion_2_pago_total"];
                }
                else {
                    _agregar_disposicion_2_pago_total = "S/N";
                }
            }



























            string _nombre_numero_documento_1 = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_numero_documento_1"]))
            {
                if (Request.QueryString["nombre_numero_documento_1"] != "")
                {
                    _nombre_numero_documento_1 = Request.QueryString["nombre_numero_documento_1"];
                }
                else {
                    _nombre_numero_documento_1 = "S/N";
                }
            }

            DateTime _fecha_documento_1 = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_documento_1"]))
            {
                string fecha_documento_1 = Request.QueryString["fecha_documento_1"];

                if (fecha_documento_1 != "0")
                {
                    _fecha_documento_1 = Convert.ToDateTime(fecha_documento_1);
                }
            }

            string _nombre_numero_documento_2 = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_numero_documento_2"]))
            {
                if (Request.QueryString["nombre_numero_documento_2"] != "")
                {
                    _nombre_numero_documento_2 = Request.QueryString["nombre_numero_documento_2"];
                }
                else {
                    _nombre_numero_documento_2 = "S/N";
                }
            }

            DateTime _fecha_documento_2 = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_documento_2"]))
            {
                string fecha_documento_2 = Request.QueryString["fecha_documento_2"];

                if (fecha_documento_2 != "0")
                {
                    _fecha_documento_2 = Convert.ToDateTime(fecha_documento_2);
                }
            }



            string _nombre_numero_documento_3 = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_numero_documento_3"]))
            {
                if (Request.QueryString["nombre_numero_documento_3"] != "")
                {
                    _nombre_numero_documento_3 = Request.QueryString["nombre_numero_documento_3"];
                }
                else {
                    _nombre_numero_documento_3 = "S/N";
                }
            }

            DateTime _fecha_documento_3 = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_documento_3"]))
            {
                string fecha_documento_3 = Request.QueryString["fecha_documento_3"];

                if (fecha_documento_3 != "0")
                {
                    _fecha_documento_3 = Convert.ToDateTime(fecha_documento_3);
                }
            }

            string _numero_oficio_medida_cuatelar_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_medida_cuatelar_discapacidad"]))
            {


                if (Request.QueryString["numero_oficio_medida_cuatelar_discapacidad"] != "")
                {
                    _numero_oficio_medida_cuatelar_discapacidad = Request.QueryString["numero_oficio_medida_cuatelar_discapacidad"];
                }
                else {
                    _numero_oficio_medida_cuatelar_discapacidad = "S/N";
                }

            }

            DateTime _fecha_oficio_medida_cuatelar_discapacidad = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_medida_cuatelar_discapacidad"]))
            {

                string fecha_medida_cuatelar_discapacidad = Request.QueryString["fecha_oficio_medida_cuatelar_discapacidad"];

                if (fecha_medida_cuatelar_discapacidad != "0")
                {
                    _fecha_oficio_medida_cuatelar_discapacidad = Convert.ToDateTime(fecha_medida_cuatelar_discapacidad);

                }



            }


            string _numero_liquidacion_medida_cuatelar_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_liquidacion_medida_cuatelar_discapacidad"]))
            {


                if (Request.QueryString["numero_liquidacion_medida_cuatelar_discapacidad"] != "")
                {
                    _numero_liquidacion_medida_cuatelar_discapacidad = Request.QueryString["numero_liquidacion_medida_cuatelar_discapacidad"];
                }
                else {
                    _numero_liquidacion_medida_cuatelar_discapacidad = "S/N";
                }

            }

            DateTime _fecha_liquidacion_medida_cuatelar_discapacidad = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_liquidacion_medida_cuatelar_discapacidad"]))
            {

                string fecha_liquidacion_medida_cuatelar_discapacidad = Request.QueryString["fecha_liquidacion_medida_cuatelar_discapacidad"];

                if (fecha_liquidacion_medida_cuatelar_discapacidad != "0")
                {
                    _fecha_liquidacion_medida_cuatelar_discapacidad = Convert.ToDateTime(fecha_liquidacion_medida_cuatelar_discapacidad);

                }



            }


            string _numero_solicitud_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_solicitud_discapacidad"]))
            {


                if (Request.QueryString["numero_solicitud_discapacidad"] != "")
                {
                    _numero_solicitud_discapacidad = Request.QueryString["numero_solicitud_discapacidad"];
                }
                else {
                    _numero_solicitud_discapacidad = "S/N";
                }

            }

            DateTime _fecha_solicitud_discapacidad = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_solicitud_discapacidad"]))
            {

                string fecha_solicitud_discapacidad = Request.QueryString["fecha_solicitud_discapacidad"];

                if (fecha_solicitud_discapacidad != "0")
                {
                    _fecha_solicitud_discapacidad = Convert.ToDateTime(fecha_solicitud_discapacidad);

                }



            }

            string _numero_conadis_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_conadis_discapacidad"]))
            {


                if (Request.QueryString["numero_conadis_discapacidad"] != "")
                {
                    _numero_conadis_discapacidad = Request.QueryString["numero_conadis_discapacidad"];
                }
                else
                {
                    _numero_conadis_discapacidad = "S/N";
                }

            }

    DateTime _fecha_conadis_discapacidad = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_conadis_discapacidad"]))
            {

                string fecha_conadis_discapacidad = Request.QueryString["fecha_conadis_discapacidad"];

                if (fecha_conadis_discapacidad != "0")
                {
                    _fecha_conadis_discapacidad = Convert.ToDateTime(fecha_conadis_discapacidad);

                }



            }

            string _porcentaje_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["porcentaje_discapacidad"]))
            {


                if (Request.QueryString["porcentaje_discapacidad"] != "")
                {
                    _porcentaje_discapacidad = Request.QueryString["porcentaje_discapacidad"];
                }
                else
                {
                    _porcentaje_discapacidad = "S/N";
                }

            }

            string _acta_validacion_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["acta_validacion_discapacidad"]))
            {


                if (Request.QueryString["acta_validacion_discapacidad"] != "")
                {
                    _acta_validacion_discapacidad = Request.QueryString["acta_validacion_discapacidad"];
                }
                else
                {
                    _acta_validacion_discapacidad = "S/N";
                }

            }

            string _numero_memorando_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_memorando_discapacidad"]))
            {


                if (Request.QueryString["numero_memorando_discapacidad"] != "")
                {
                    _numero_memorando_discapacidad = Request.QueryString["numero_memorando_discapacidad"];
                }
                else
                {
                    _numero_memorando_discapacidad = "S/N";
                }

            }

            DateTime _fecha_memorando_discapacidad = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_memorando_discapacidad"]))
            {

                string fecha_memorando_discapacidad = Request.QueryString["fecha_memorando_discapacidad"];

                if (fecha_memorando_discapacidad != "0")
                {
                    _fecha_memorando_discapacidad = Convert.ToDateTime(fecha_memorando_discapacidad);

                }



            }

            string _porcentaje_condonacion_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["porcentaje_condonacion_discapacidad"]))
            {


                if (Request.QueryString["porcentaje_condonacion_discapacidad"] != "")
                {
                    _porcentaje_condonacion_discapacidad = Request.QueryString["porcentaje_condonacion_discapacidad"];
                }
                else
                {
                    _porcentaje_condonacion_discapacidad = "S/N";
                }

            }

            string _porcentaje_restructuracion_discapacidad = "";
            if (!String.IsNullOrEmpty(Request.QueryString["porcentaje_restructuracion_discapacidad"]))
            {


                if (Request.QueryString["porcentaje_restructuracion_discapacidad"] != "")
                {
                    _porcentaje_restructuracion_discapacidad = Request.QueryString["porcentaje_restructuracion_discapacidad"];
                }
                else
                {
                    _porcentaje_restructuracion_discapacidad = "S/N";
                }

            }

            string _citado = "";
            if (!String.IsNullOrEmpty(Request.QueryString["citado"]))
            {


                if (Request.QueryString["citado"] != "")
                {
                    _citado = Request.QueryString["citado"];
                }
                else {
                    _citado = "S/N";
                }

            }


            string _disposicion_citar = "";
            if (!String.IsNullOrEmpty(Request.QueryString["disposicion_citar"]))
            {


                if (Request.QueryString["disposicion_citar"] != "")
                {
                    _disposicion_citar = Request.QueryString["disposicion_citar"];
                }
                else {
                    _disposicion_citar = "S/N";
                }

            }





            string _nombre_discapacitado = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_discapacitado"]))
            {


                if (Request.QueryString["nombre_discapacitado"] != "")
                {
                    _nombre_discapacitado = Request.QueryString["nombre_discapacitado"];
                }
                else {
                    _nombre_discapacitado = "S/N";
                }

            }



            string _numero_oficio_medida_cuatelar_fallecimiento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_medida_cuatelar_fallecimiento"]))
            {


                if (Request.QueryString["numero_oficio_medida_cuatelar_fallecimiento"] != "")
                {
                    _numero_oficio_medida_cuatelar_fallecimiento = Request.QueryString["numero_oficio_medida_cuatelar_fallecimiento"];
                }
                else {
                    _numero_oficio_medida_cuatelar_fallecimiento = "S/N";
                }

            }


            DateTime _fecha_oficio_medida_cuatelar_fallecimiento = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_medida_cuatelar_fallecimiento"]))
            {

                string fecha_oficio_medida_cuatelar_fallecimiento = Request.QueryString["fecha_oficio_medida_cuatelar_fallecimiento"];

                if (fecha_oficio_medida_cuatelar_fallecimiento != "0")
                {
                    _fecha_oficio_medida_cuatelar_fallecimiento = Convert.ToDateTime(fecha_oficio_medida_cuatelar_fallecimiento);

                }

            }


            string _numero_liquidacion_medida_cuatelar_fallecimiento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_liquidacion_medida_cuatelar_fallecimiento"]))
            {


                if (Request.QueryString["numero_liquidacion_medida_cuatelar_fallecimiento"] != "")
                {
                    _numero_liquidacion_medida_cuatelar_fallecimiento = Request.QueryString["numero_liquidacion_medida_cuatelar_fallecimiento"];
                }
                else {
                    _numero_liquidacion_medida_cuatelar_fallecimiento = "S/N";
                }

            }


            DateTime _fecha_liquidacion_medida_cuatelar_fallecimiento = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_liquidacion_medida_cuatelar_fallecimiento"]))
            {
                string fecha_liquidacion_medida_cuatelar_fallecimiento = Request.QueryString["fecha_liquidacion_medida_cuatelar_fallecimiento"];

                if (fecha_liquidacion_medida_cuatelar_fallecimiento != "0")
                {
                    _fecha_liquidacion_medida_cuatelar_fallecimiento = Convert.ToDateTime(fecha_liquidacion_medida_cuatelar_fallecimiento);
                }
            }


            string _numero_solicitud_fallecimiento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_solicitud_fallecimiento"]))
            {


                if (Request.QueryString["numero_solicitud_fallecimiento"] != "")
                {
                    _numero_solicitud_fallecimiento = Request.QueryString["numero_solicitud_fallecimiento"];
                }
                else {
                    _numero_solicitud_fallecimiento = "S/N";
                }

            }


            DateTime _fecha_solicitud_fallecimiento = DateTime.Now;
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_solicitud_fallecimiento"]))
            {
                string fecha_solicitud_fallecimiento = Request.QueryString["fecha_solicitud_fallecimiento"];

                if (fecha_solicitud_fallecimiento != "0")
                {
                    _fecha_solicitud_fallecimiento = Convert.ToDateTime(fecha_solicitud_fallecimiento);
                }
            }

            string _nombre_conyuge_sobreviviente = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_conyuge_sobreviviente"]))
            {


                if (Request.QueryString["nombre_conyuge_sobreviviente"] != "")
                {
                    _nombre_conyuge_sobreviviente = Request.QueryString["nombre_conyuge_sobreviviente"];
                }
                else {
                    _nombre_conyuge_sobreviviente = "S/N";
                }

            }



            string _correo_conyuge_sobreviviente = "";
            if (!String.IsNullOrEmpty(Request.QueryString["correo_conyuge_sobreviviente"]))
            {


                if (Request.QueryString["correo_conyuge_sobreviviente"] != "")
                {
                    _correo_conyuge_sobreviviente = Request.QueryString["correo_conyuge_sobreviviente"];
                }
                else {
                    _correo_conyuge_sobreviviente = "S/N";
                }

            }


            
            
            string _numero_oficio = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio"]))
            {


                if (Request.QueryString["numero_oficio"] != "")
                {
                    _numero_oficio = Request.QueryString["numero_oficio"];
                }
                else {
                    _numero_oficio = "S/N";
                }

            }

            DateTime _fecha_oficio = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio"]))
            {

                string fecha_OFI = Request.QueryString["fecha_oficio"];

                if (fecha_OFI != "0")
                {
                    _fecha_oficio = Convert.ToDateTime(fecha_OFI);

                }



            }



            

            string _numero_oficio_restructuracion = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_restructuracion"]))
            {


                if (Request.QueryString["numero_oficio_restructuracion"] != "")
                {
                    _numero_oficio_restructuracion = Request.QueryString["numero_oficio_restructuracion"];
                }
                else {
                    _numero_oficio_restructuracion = "S/N";
                }

            }

            DateTime _fecha_oficio_restructuracion = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_restructuracion"]))
            {

                string fecha_OFI_RES = Request.QueryString["fecha_oficio_restructuracion"];

                if (fecha_OFI_RES != "0")
                {
                    _fecha_oficio_restructuracion = Convert.ToDateTime(fecha_OFI_RES);

                }



            }



            string _numero_solicitud_restructuracion = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_solicitud_restructuracion"]))
            {


                if (Request.QueryString["numero_solicitud_restructuracion"] != "")
                {
                    _numero_solicitud_restructuracion = Request.QueryString["numero_solicitud_restructuracion"];
                }
                else {
                    _numero_solicitud_restructuracion = "S/N";
                }

            }

            DateTime _fecha_solicitud_restructuracion = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_solicitud_restructuracion"]))
            {

                string fecha_Soli_Res = Request.QueryString["fecha_solicitud_restructuracion"];

                if (fecha_Soli_Res != "0")
                {
                    _fecha_solicitud_restructuracion = Convert.ToDateTime(fecha_Soli_Res);

                }



            }



            string _acta_validacion_restructuracion = "";
            if (!String.IsNullOrEmpty(Request.QueryString["acta_validacion_restructuracion"]))
            {


                if (Request.QueryString["acta_validacion_restructuracion"] != "")
                {
                    _acta_validacion_restructuracion = Request.QueryString["acta_validacion_restructuracion"];
                }
                else {
                    _acta_validacion_restructuracion = "S/N";
                }

            }


            string _numero_oficio_embargo_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_embargo_cuenta"]))
            {


                if (Request.QueryString["numero_oficio_embargo_cuenta"] != "")
                {
                    _numero_oficio_embargo_cuenta = Request.QueryString["numero_oficio_embargo_cuenta"];
                }
                else {
                    _numero_oficio_embargo_cuenta = "S/N";
                }

            }

            DateTime _fecha_oficio_embargo_cuenta = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_embargo_cuenta"]))
            {

                string fecha_emb_cuen = Request.QueryString["fecha_oficio_embargo_cuenta"];

                if (fecha_emb_cuen != "0")
                {
                    _fecha_oficio_embargo_cuenta = Convert.ToDateTime(fecha_emb_cuen);

                }



            }

            
            string _referencia = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia"]))
            {
                if (Request.QueryString["referencia"] != "")
                {
                    _referencia = Request.QueryString["referencia"];
                }
                else {
                    _referencia = "S/N";
                }
            }


            string _tipo_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cuenta"]))
            {
              if (Request.QueryString["tipo_cuenta"] != "")
                {
                    _tipo_cuenta = Request.QueryString["tipo_cuenta"];
                }
                else {
                    _tipo_cuenta = "S/N";
                }
              }

            string _numero_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_cuenta"]))
            {
                if (Request.QueryString["numero_cuenta"] != "")
                {
                    _numero_cuenta = Request.QueryString["numero_cuenta"];
                }
                else {
                    _numero_cuenta = "S/N";
                }
            }

            string _nombre_banco = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_banco"]))
            {
                if (Request.QueryString["nombre_banco"] != "")
                {
                    _nombre_banco = Request.QueryString["nombre_banco"];
                }
                else {
                    _nombre_banco = "S/N";
                }
            }

            string _monto_retenido = "";
            if (!String.IsNullOrEmpty(Request.QueryString["monto_retenido"]))
            {
                if (Request.QueryString["monto_retenido"] != "")
                {
                    _monto_retenido = Request.QueryString["monto_retenido"];
                }
                else {
                    _monto_retenido = "S/N";
                }
            }

            string _nombre_titular_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_titular_cuenta"]))
            {
                if (Request.QueryString["nombre_titular_cuenta"] != "")
                {
                    _nombre_titular_cuenta = Request.QueryString["nombre_titular_cuenta"];
                }
                else {
                    _nombre_titular_cuenta = "S/N";
                }
            }

            string _identificacion_titular_cuenta = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_titular_cuenta"]))
            {
                if (Request.QueryString["identificacion_titular_cuenta"] != "")
                {
                    _identificacion_titular_cuenta = Request.QueryString["identificacion_titular_cuenta"];
                }
                else {
                    _identificacion_titular_cuenta = "S/N";
                }
            }


            string _depositario_judicial = "";
            if (!String.IsNullOrEmpty(Request.QueryString["depositario_judicial"]))
            {
                if (Request.QueryString["depositario_judicial"] != "")
                {
                    _depositario_judicial = Request.QueryString["depositario_judicial"];
                }
                else {
                    _depositario_judicial = "S/N";
                }
            }

            string _identificacion_depositario_judicial = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_depositario_judicial"]))
            {
                if (Request.QueryString["identificacion_depositario_judicial"] != "")
                {
                    _identificacion_depositario_judicial = Request.QueryString["identificacion_depositario_judicial"];
                }
                else {
                    _identificacion_depositario_judicial = "S/N";
                }
            }








            string _numero_oficio_embargo_cuenta_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_embargo_cuenta_2"]))
            {


                if (Request.QueryString["numero_oficio_embargo_cuenta_2"] != "")
                {
                    _numero_oficio_embargo_cuenta_2 = Request.QueryString["numero_oficio_embargo_cuenta_2"];
                }
                else {
                    _numero_oficio_embargo_cuenta_2 = "S/N";
                }

            }

            DateTime _fecha_oficio_embargo_cuenta_2 = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_embargo_cuenta_2"]))
            {

                string fecha_emb_cuen_2 = Request.QueryString["fecha_oficio_embargo_cuenta_2"];

                if (fecha_emb_cuen_2 != "0")
                {
                    _fecha_oficio_embargo_cuenta_2 = Convert.ToDateTime(fecha_emb_cuen_2);

                }



            }



            string _tipo_cuenta_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cuenta_2"]))
            {
                if (Request.QueryString["tipo_cuenta_2"] != "")
                {
                    _tipo_cuenta_2 = Request.QueryString["tipo_cuenta_2"];
                }
                else {
                    _tipo_cuenta_2 = "S/N";
                }
            }

            string _numero_cuenta_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_cuenta_2"]))
            {
                if (Request.QueryString["numero_cuenta_2"] != "")
                {
                    _numero_cuenta_2 = Request.QueryString["numero_cuenta_2"];
                }
                else {
                    _numero_cuenta_2 = "S/N";
                }
            }

            string _nombre_banco_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_banco_2"]))
            {
                if (Request.QueryString["nombre_banco_2"] != "")
                {
                    _nombre_banco_2 = Request.QueryString["nombre_banco_2"];
                }
                else {
                    _nombre_banco_2 = "S/N";
                }
            }

            string _monto_retenido_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["monto_retenido_2"]))
            {
                if (Request.QueryString["monto_retenido_2"] != "")
                {
                    _monto_retenido_2 = Request.QueryString["monto_retenido_2"];
                }
                else {
                    _monto_retenido_2 = "S/N";
                }
            }

            string _nombre_titular_cuenta_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_titular_cuenta_2"]))
            {
                if (Request.QueryString["nombre_titular_cuenta_2"] != "")
                {
                    _nombre_titular_cuenta_2 = Request.QueryString["nombre_titular_cuenta_2"];
                }
                else {
                    _nombre_titular_cuenta_2 = "S/N";
                }
            }

            string _identificacion_titular_cuenta_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_titular_cuenta_2"]))
            {
                if (Request.QueryString["identificacion_titular_cuenta_2"] != "")
                {
                    _identificacion_titular_cuenta_2 = Request.QueryString["identificacion_titular_cuenta_2"];
                }
                else {
                    _identificacion_titular_cuenta_2 = "S/N";
                }
            }


            string _depositario_judicial_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["depositario_judicial_2"]))
            {
                if (Request.QueryString["depositario_judicial_2"] != "")
                {
                    _depositario_judicial_2 = Request.QueryString["depositario_judicial_2"];
                }
                else {
                    _depositario_judicial_2 = "S/N";
                }
            }

            string _identificacion_depositario_judicial_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_depositario_judicial_2"]))
            {
                if (Request.QueryString["identificacion_depositario_judicial_2"] != "")
                {
                    _identificacion_depositario_judicial_2 = Request.QueryString["identificacion_depositario_judicial_2"];
                }
                else {
                    _identificacion_depositario_judicial_2 = "S/N";
                }
            }








            string _numero_oficio_embargo_cuenta_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_embargo_cuenta_3"]))
            {


                if (Request.QueryString["numero_oficio_embargo_cuenta_3"] != "")
                {
                    _numero_oficio_embargo_cuenta_3 = Request.QueryString["numero_oficio_embargo_cuenta_3"];
                }
                else {
                    _numero_oficio_embargo_cuenta_3 = "S/N";
                }

            }

            DateTime _fecha_oficio_embargo_cuenta_3 = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_embargo_cuenta_3"]))
            {

                string fecha_emb_cuen_3 = Request.QueryString["fecha_oficio_embargo_cuenta_3"];

                if (fecha_emb_cuen_3 != "0")
                {
                    _fecha_oficio_embargo_cuenta_3 = Convert.ToDateTime(fecha_emb_cuen_3);

                }



            }



            string _tipo_cuenta_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cuenta_3"]))
            {
                if (Request.QueryString["tipo_cuenta_3"] != "")
                {
                    _tipo_cuenta_3 = Request.QueryString["tipo_cuenta_3"];
                }
                else {
                    _tipo_cuenta_3 = "S/N";
                }
            }

            string _numero_cuenta_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_cuenta_3"]))
            {
                if (Request.QueryString["numero_cuenta_3"] != "")
                {
                    _numero_cuenta_3 = Request.QueryString["numero_cuenta_3"];
                }
                else {
                    _numero_cuenta_3 = "S/N";
                }
            }

            string _nombre_banco_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_banco_3"]))
            {
                if (Request.QueryString["nombre_banco_3"] != "")
                {
                    _nombre_banco_3 = Request.QueryString["nombre_banco_3"];
                }
                else {
                    _nombre_banco_3 = "S/N";
                }
            }

            string _monto_retenido_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["monto_retenido_3"]))
            {
                if (Request.QueryString["monto_retenido_3"] != "")
                {
                    _monto_retenido_3 = Request.QueryString["monto_retenido_3"];
                }
                else {
                    _monto_retenido_3 = "S/N";
                }
            }

            string _nombre_titular_cuenta_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_titular_cuenta_3"]))
            {
                if (Request.QueryString["nombre_titular_cuenta_3"] != "")
                {
                    _nombre_titular_cuenta_3 = Request.QueryString["nombre_titular_cuenta_3"];
                }
                else {
                    _nombre_titular_cuenta_3 = "S/N";
                }
            }

            string _identificacion_titular_cuenta_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_titular_cuenta_3"]))
            {
                if (Request.QueryString["identificacion_titular_cuenta_3"] != "")
                {
                    _identificacion_titular_cuenta_3 = Request.QueryString["identificacion_titular_cuenta_3"];
                }
                else {
                    _identificacion_titular_cuenta_3 = "S/N";
                }
            }


            string _depositario_judicial_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["depositario_judicial_3"]))
            {
                if (Request.QueryString["depositario_judicial_3"] != "")
                {
                    _depositario_judicial_3 = Request.QueryString["depositario_judicial_3"];
                }
                else {
                    _depositario_judicial_3 = "S/N";
                }
            }

            string _identificacion_depositario_judicial_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_depositario_judicial_3"]))
            {
                if (Request.QueryString["identificacion_depositario_judicial_3"] != "")
                {
                    _identificacion_depositario_judicial_3 = Request.QueryString["identificacion_depositario_judicial_3"];
                }
                else {
                    _identificacion_depositario_judicial_3 = "S/N";
                }
            }














            string _numero_oficio_embargo_cuenta_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_embargo_cuenta_4"]))
            {


                if (Request.QueryString["numero_oficio_embargo_cuenta_4"] != "")
                {
                    _numero_oficio_embargo_cuenta_4 = Request.QueryString["numero_oficio_embargo_cuenta_4"];
                }
                else {
                    _numero_oficio_embargo_cuenta_4 = "S/N";
                }

            }

            DateTime _fecha_oficio_embargo_cuenta_4 = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_embargo_cuenta_4"]))
            {

                string fecha_emb_cuen_4 = Request.QueryString["fecha_oficio_embargo_cuenta_4"];

                if (fecha_emb_cuen_4 != "0")
                {
                    _fecha_oficio_embargo_cuenta_4 = Convert.ToDateTime(fecha_emb_cuen_4);

                }



            }



            string _tipo_cuenta_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cuenta_4"]))
            {
                if (Request.QueryString["tipo_cuenta_4"] != "")
                {
                    _tipo_cuenta_4 = Request.QueryString["tipo_cuenta_4"];
                }
                else {
                    _tipo_cuenta_4 = "S/N";
                }
            }

            string _numero_cuenta_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_cuenta_4"]))
            {
                if (Request.QueryString["numero_cuenta_4"] != "")
                {
                    _numero_cuenta_4 = Request.QueryString["numero_cuenta_4"];
                }
                else {
                    _numero_cuenta_4 = "S/N";
                }
            }

            string _nombre_banco_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_banco_4"]))
            {
                if (Request.QueryString["nombre_banco_4"] != "")
                {
                    _nombre_banco_4 = Request.QueryString["nombre_banco_4"];
                }
                else {
                    _nombre_banco_4 = "S/N";
                }
            }

            string _monto_retenido_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["monto_retenido_4"]))
            {
                if (Request.QueryString["monto_retenido_4"] != "")
                {
                    _monto_retenido_4 = Request.QueryString["monto_retenido_4"];
                }
                else {
                    _monto_retenido_4 = "S/N";
                }
            }

            string _nombre_titular_cuenta_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_titular_cuenta_4"]))
            {
                if (Request.QueryString["nombre_titular_cuenta_4"] != "")
                {
                    _nombre_titular_cuenta_4 = Request.QueryString["nombre_titular_cuenta_4"];
                }
                else {
                    _nombre_titular_cuenta_4 = "S/N";
                }
            }

            string _identificacion_titular_cuenta_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_titular_cuenta_4"]))
            {
                if (Request.QueryString["identificacion_titular_cuenta_4"] != "")
                {
                    _identificacion_titular_cuenta_4 = Request.QueryString["identificacion_titular_cuenta_4"];
                }
                else {
                    _identificacion_titular_cuenta_4 = "S/N";
                }
            }


            string _depositario_judicial_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["depositario_judicial_4"]))
            {
                if (Request.QueryString["depositario_judicial_4"] != "")
                {
                    _depositario_judicial_4 = Request.QueryString["depositario_judicial_4"];
                }
                else {
                    _depositario_judicial_4 = "S/N";
                }
            }

            string _identificacion_depositario_judicial_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_depositario_judicial_4"]))
            {
                if (Request.QueryString["identificacion_depositario_judicial_4"] != "")
                {
                    _identificacion_depositario_judicial_4 = Request.QueryString["identificacion_depositario_judicial_4"];
                }
                else {
                    _identificacion_depositario_judicial_4 = "S/N";
                }
            }








            string _numero_oficio_embargo_cuenta_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_oficio_embargo_cuenta_5"]))
            {


                if (Request.QueryString["numero_oficio_embargo_cuenta_5"] != "")
                {
                    _numero_oficio_embargo_cuenta_5 = Request.QueryString["numero_oficio_embargo_cuenta_5"];
                }
                else {
                    _numero_oficio_embargo_cuenta_5 = "S/N";
                }

            }

            DateTime _fecha_oficio_embargo_cuenta_5 = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficio_embargo_cuenta_5"]))
            {

                string fecha_emb_cuen_5 = Request.QueryString["fecha_oficio_embargo_cuenta_5"];

                if (fecha_emb_cuen_5 != "0")
                {
                    _fecha_oficio_embargo_cuenta_5 = Convert.ToDateTime(fecha_emb_cuen_5);

                }



            }



            string _tipo_cuenta_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_cuenta_5"]))
            {
                if (Request.QueryString["tipo_cuenta_5"] != "")
                {
                    _tipo_cuenta_5 = Request.QueryString["tipo_cuenta_5"];
                }
                else {
                    _tipo_cuenta_5 = "S/N";
                }
            }

            string _numero_cuenta_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_cuenta_5"]))
            {
                if (Request.QueryString["numero_cuenta_5"] != "")
                {
                    _numero_cuenta_5 = Request.QueryString["numero_cuenta_5"];
                }
                else {
                    _numero_cuenta_5 = "S/N";
                }
            }

            string _nombre_banco_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_banco_5"]))
            {
                if (Request.QueryString["nombre_banco_5"] != "")
                {
                    _nombre_banco_5 = Request.QueryString["nombre_banco_5"];
                }
                else {
                    _nombre_banco_5 = "S/N";
                }
            }

            string _monto_retenido_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["monto_retenido_5"]))
            {
                if (Request.QueryString["monto_retenido_5"] != "")
                {
                    _monto_retenido_5 = Request.QueryString["monto_retenido_5"];
                }
                else {
                    _monto_retenido_5 = "S/N";
                }
            }

            string _nombre_titular_cuenta_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_titular_cuenta_5"]))
            {
                if (Request.QueryString["nombre_titular_cuenta_5"] != "")
                {
                    _nombre_titular_cuenta_5 = Request.QueryString["nombre_titular_cuenta_5"];
                }
                else {
                    _nombre_titular_cuenta_5 = "S/N";
                }
            }

            string _identificacion_titular_cuenta_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_titular_cuenta_5"]))
            {
                if (Request.QueryString["identificacion_titular_cuenta_5"] != "")
                {
                    _identificacion_titular_cuenta_5 = Request.QueryString["identificacion_titular_cuenta_5"];
                }
                else {
                    _identificacion_titular_cuenta_5 = "S/N";
                }
            }


            string _depositario_judicial_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["depositario_judicial_5"]))
            {
                if (Request.QueryString["depositario_judicial_5"] != "")
                {
                    _depositario_judicial_5 = Request.QueryString["depositario_judicial_5"];
                }
                else {
                    _depositario_judicial_5 = "S/N";
                }
            }

            string _identificacion_depositario_judicial_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_depositario_judicial_5"]))
            {
                if (Request.QueryString["identificacion_depositario_judicial_5"] != "")
                {
                    _identificacion_depositario_judicial_5 = Request.QueryString["identificacion_depositario_judicial_5"];
                }
                else {
                    _identificacion_depositario_judicial_5 = "S/N";
                }
            }



            string _escrito_presentado_por = "";
            if (!String.IsNullOrEmpty(Request.QueryString["escrito_presentado_por"]))
            {
                if (Request.QueryString["escrito_presentado_por"] != "")
                {
                    _escrito_presentado_por = Request.QueryString["escrito_presentado_por"];
                }
                else {
                    _escrito_presentado_por = "S/N";
                }
            }



            string _dispone_1 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_1"]))
            {
                if (Request.QueryString["dispone_1"] != "")
                {
                    _dispone_1 = Request.QueryString["dispone_1"];
                }
                else {
                    _dispone_1 = "S/N";
                }
            }

            string _dispone_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_2"]))
            {
                if (Request.QueryString["dispone_2"] != "")
                {
                    _dispone_2 = Request.QueryString["dispone_2"];
                }
                else {
                    _dispone_2 = "S/N";
                }
            }
            string _dispone_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_3"]))
            {
                if (Request.QueryString["dispone_3"] != "")
                {
                    _dispone_3 = Request.QueryString["dispone_3"];
                }
                else
                {
                    _dispone_3 = "S/N";
                }
            }
            string _dispone_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_4"]))
            {
                if (Request.QueryString["dispone_4"] != "")
                {
                    _dispone_4 = Request.QueryString["dispone_4"];
                }
                else
                {
                    _dispone_4 = "S/N";
                }
            }
            string _dispone_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_5"]))
            {
                if (Request.QueryString["dispone_5"] != "")
                {
                    _dispone_5 = Request.QueryString["dispone_5"];
                }
                else
                {
                    _dispone_5 = "S/N";
                }
            }
            string _dispone_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["dispone_6"]))
            {
                if (Request.QueryString["dispone_6"] != "")
                {
                    _dispone_6 = Request.QueryString["dispone_6"];
                }
                else
                {
                    _dispone_6 = "S/N";
                }
            }
            string _resolucion_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["resolucion_3"]))
            {
                if (Request.QueryString["resolucion_3"] != "")
                {
                    _resolucion_3 = Request.QueryString["resolucion_3"];
                }
                else
                {
                    _resolucion_3 = "S/N";
                }
            }
            string _resolucion_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["resolucion_4"]))
            {
                if (Request.QueryString["resolucion_4"] != "")
                {
                    _resolucion_4 = Request.QueryString["resolucion_4"];
                }
                else
                {
                    _resolucion_4 = "S/N";
                }
            }
            string _resolucion_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["resolucion_5"]))
            {
                if (Request.QueryString["resolucion_5"] != "")
                {
                    _resolucion_5 = Request.QueryString["resolucion_5"];
                }
                else
                {
                    _resolucion_5 = "S/N";
                }
            }
            string _resolucion_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["resolucion_6"]))
            {
                if (Request.QueryString["resolucion_6"] != "")
                {
                    _resolucion_6 = Request.QueryString["resolucion_6"];
                }
                else
                {
                    _resolucion_6 = "S/N";
                }
            }
            string _disponer_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["disponer_2"]))
            {
                if (Request.QueryString["disponer_2"] != "")
                {
                    _disponer_2 = Request.QueryString["disponer_2"];
                }
                else
                {
                    _disponer_2 = "S/N";
                }
            }
            string _disponer_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["disponer_3"]))
            {
                if (Request.QueryString["disponer_3"] != "")
                {
                    _disponer_3 = Request.QueryString["disponer_3"];
                }
                else
                {
                    _disponer_3 = "S/N";
                }
            }
            string _disponer_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["disponer_4"]))
            {
                if (Request.QueryString["disponer_4"] != "")
                {
                    _disponer_4 = Request.QueryString["disponer_4"];
                }
                else
                {
                    _disponer_4 = "S/N";
                }
            }
            string _disponer_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["disponer_5"]))
            {
                if (Request.QueryString["disponer_5"] != "")
                {
                    _disponer_5 = Request.QueryString["disponer_5"];
                }
                else
                {
                    _disponer_5 = "S/N";
                }
            }


            string _numero_solicitud = "S/N";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_solicitud"]))
            {


                if (Request.QueryString["numero_solicitud"] != "")
                {
                    _numero_solicitud = Request.QueryString["numero_solicitud"];
                }
                else {
                    _numero_solicitud = "S/N";
                }

            }

            DateTime _fecha_solicitud = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_solicitud"]))
            {

                string fecha_SOLI = Request.QueryString["fecha_solicitud"];

                if (fecha_SOLI != "0")
                {
                    _fecha_solicitud = Convert.ToDateTime(fecha_SOLI);

                }



            }









            string _nombre_documento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_archivo_avoco"]))
            {


                if (Request.QueryString["nombre_archivo_avoco"] != "")
                {
                    _nombre_documento = Request.QueryString["nombre_archivo_avoco"];
                }
                else {
                    _nombre_documento = "AVOCO" + "001";
                }

            }

            string _identificador_oficio = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio"]))
            {
                if (Request.QueryString["identificador_oficio"] != "")
                {
                    _identificador_oficio = Request.QueryString["identificador_oficio"];
                }
                else {
                    _identificador_oficio = "S/N";
                }
            }



            string _identificador_oficio_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_2"]))
            {
                if (Request.QueryString["identificador_oficio_2"] != "")
                {
                    _identificador_oficio_2 = Request.QueryString["identificador_oficio_2"];
                }
                else
                {
                    _identificador_oficio_2 = "S/N";
                }
            }
            string _identificador_oficio_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_3"]))
            {
                if (Request.QueryString["identificador_oficio_3"] != "")
                {
                    _identificador_oficio_3 = Request.QueryString["identificador_oficio_3"];
                }
                else
                {
                    _identificador_oficio_3 = "S/N";
                }
            }
            string _identificador_oficio_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_4"]))
            {
                if (Request.QueryString["identificador_oficio_4"] != "")
                {
                    _identificador_oficio_4 = Request.QueryString["identificador_oficio_4"];
                }
                else
                {
                    _identificador_oficio_4 = "S/N";
                }
            }
            string _identificador_oficio_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_5"]))
            {
                if (Request.QueryString["identificador_oficio_5"] != "")
                {
                    _identificador_oficio_5 = Request.QueryString["identificador_oficio_5"];
                }
                else
                {
                    _identificador_oficio_5 = "S/N";
                }
            }
            string _identificador_oficio_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_6"]))
            {
                if (Request.QueryString["identificador_oficio_6"] != "")
                {
                    _identificador_oficio_6 = Request.QueryString["identificador_oficio_6"];
                }
                else
                {
                    _identificador_oficio_6 = "S/N";
                }
            }
            string _identificador_oficio_7 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_7"]))
            {
                if (Request.QueryString["identificador_oficio_7"] != "")
                {
                    _identificador_oficio_7 = Request.QueryString["identificador_oficio_7"];
                }
                else
                {
                    _identificador_oficio_7 = "S/N";
                }
            }
            string _identificador_oficio_8 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficio_8"]))
            {
                if (Request.QueryString["identificador_oficio_8"] != "")
                {
                    _identificador_oficio_8 = Request.QueryString["identificador_oficio_8"];
                }
                else
                {
                    _identificador_oficio_8 = "S/N";
                }
            }
            string _entidad_va_oficio = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio"]))
            {
                if (Request.QueryString["entidad_va_oficio"] != "")
                {
                    _entidad_va_oficio = Request.QueryString["entidad_va_oficio"];
                }
                else {
                    _entidad_va_oficio = "S/N";
                }
            }

            string _entidad_va_oficio_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_2"]))
            {
                if (Request.QueryString["entidad_va_oficio_2"] != "")
                {
                    _entidad_va_oficio_2 = Request.QueryString["entidad_va_oficio_2"];
                }
                else
                {
                    _entidad_va_oficio_2 = "S/N";
                }
            }

            string _entidad_va_oficio_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_3"]))
            {
                if (Request.QueryString["entidad_va_oficio_3"] != "")
                {
                    _entidad_va_oficio_3 = Request.QueryString["entidad_va_oficio_3"];
                }
                else
                {
                    _entidad_va_oficio_3 = "S/N";
                }
            }

            string _entidad_va_oficio_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_4"]))
            {
                if (Request.QueryString["entidad_va_oficio_4"] != "")
                {
                    _entidad_va_oficio_4 = Request.QueryString["entidad_va_oficio_4"];
                }
                else
                {
                    _entidad_va_oficio_4 = "S/N";
                }
            }
            string _entidad_va_oficio_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_5"]))
            {
                if (Request.QueryString["entidad_va_oficio_5"] != "")
                {
                    _entidad_va_oficio_5 = Request.QueryString["entidad_va_oficio_5"];
                }
                else
                {
                    _entidad_va_oficio_5 = "S/N";
                }
            }
            string _entidad_va_oficio_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_6"]))
            {
                if (Request.QueryString["entidad_va_oficio_5"] != "")
                {
                    _entidad_va_oficio_6 = Request.QueryString["entidad_va_oficio_6"];
                }
                else
                {
                    _entidad_va_oficio_6 = "S/N";
                }
            }
            string _entidad_va_oficio_7 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_7"]))
            {
                if (Request.QueryString["entidad_va_oficio_7"] != "")
                {
                    _entidad_va_oficio_7 = Request.QueryString["entidad_va_oficio_7"];
                }
                else
                {
                    _entidad_va_oficio_7 = "S/N";
                }
            }
            string _entidad_va_oficio_8 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["entidad_va_oficio_8"]))
            {
                if (Request.QueryString["entidad_va_oficio_8"] != "")
                {
                    _entidad_va_oficio_8 = Request.QueryString["entidad_va_oficio_8"];
                }
                else
                {
                    _entidad_va_oficio_8 = "S/N";
                }
            }



           




            string _asunto = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto"]))
            {
                if (Request.QueryString["asunto"] != "")
                {
                    _asunto = Request.QueryString["asunto"];
                }
                else {
                    _asunto = "S/N";
                }
            }


            string _asunto_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_2"]))
            {
                if (Request.QueryString["asunto_2"] != "")
                {
                    _asunto_2 = Request.QueryString["asunto_2"];
                }
                else
                {
                    _asunto_2 = "S/N";
                }
            }


            string _asunto_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_3"]))
            {
                if (Request.QueryString["asunto_3"] != "")
                {
                    _asunto_3 = Request.QueryString["asunto_3"];
                }
                else
                {
                    _asunto_3 = "S/N";
                }
            }

            string _asunto_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_4"]))
            {
                if (Request.QueryString["asunto_4"] != "")
                {
                    _asunto_4 = Request.QueryString["asunto_4"];
                }
                else
                {
                    _asunto_4 = "S/N";
                }
            }
            string _asunto_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_5"]))
            {
                if (Request.QueryString["asunto_5"] != "")
                {
                    _asunto_5 = Request.QueryString["asunto_5"];
                }
                else
                {
                    _asunto_5 = "S/N";
                }
            }
            string _asunto_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_6"]))
            {
                if (Request.QueryString["asunto_6"] != "")
                {
                    _asunto_6 = Request.QueryString["asunto_6"];
                }
                else
                {
                    _asunto_6 = "S/N";
                }
            }
            string _asunto_7 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_7"]))
            {
                if (Request.QueryString["asunto_7"] != "")
                {
                    _asunto_7 = Request.QueryString["asunto_7"];
                }
                else
                {
                    _asunto_7 = "S/N";
                }
            }
            string _asunto_8 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["asunto_8"]))
            {
                if (Request.QueryString["asunto_8"] != "")
                {
                    _asunto_8 = Request.QueryString["asunto_8"];
                }
                else
                {
                    _asunto_8 = "S/N";
                }
            }



            string _referencia_oficios_tipo_lev = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev"] != "")
                {
                    _referencia_oficios_tipo_lev = Request.QueryString["referencia_oficios_tipo_lev"];
                }
                else
                {
                    _referencia_oficios_tipo_lev = "S/N";
                }
            }


            string _referencia_oficios_tipo_lev_2 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_2"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_2"] != "")
                {
                    _referencia_oficios_tipo_lev_2 = Request.QueryString["referencia_oficios_tipo_lev_2"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_2 = "S/N";
                }
            }

            string _referencia_oficios_tipo_lev_3 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_3"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_3"] != "")
                {
                    _referencia_oficios_tipo_lev_3 = Request.QueryString["referencia_oficios_tipo_lev_3"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_3 = "S/N";
                }
            }
            string _referencia_oficios_tipo_lev_4 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_4"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_4"] != "")
                {
                    _referencia_oficios_tipo_lev_4 = Request.QueryString["referencia_oficios_tipo_lev_4"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_4 = "S/N";
                }
            }
            string _referencia_oficios_tipo_lev_5 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_5"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_5"] != "")
                {
                    _referencia_oficios_tipo_lev_5 = Request.QueryString["referencia_oficios_tipo_lev_5"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_5 = "S/N";
                }
            }
            string _referencia_oficios_tipo_lev_6 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_6"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_6"] != "")
                {
                    _referencia_oficios_tipo_lev_6 = Request.QueryString["referencia_oficios_tipo_lev_6"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_6 = "S/N";
                }
            }
            string _referencia_oficios_tipo_lev_7 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_7"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_7"] != "")
                {
                    _referencia_oficios_tipo_lev_7 = Request.QueryString["referencia_oficios_tipo_lev_7"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_7 = "S/N";
                }
            }
            string _referencia_oficios_tipo_lev_8 = "";
            if (!String.IsNullOrEmpty(Request.QueryString["referencia_oficios_tipo_lev_8"]))
            {
                if (Request.QueryString["referencia_oficios_tipo_lev_8"] != "")
                {
                    _referencia_oficios_tipo_lev_8 = Request.QueryString["referencia_oficios_tipo_lev_8"];
                }
                else
                {
                    _referencia_oficios_tipo_lev_8 = "S/N";
                }
            }
            string _generar_oficio = "";
            if (!String.IsNullOrEmpty(Request.QueryString["generar_oficio"]))
            {
                if (Request.QueryString["generar_oficio"] != "")
                {
                    _generar_oficio = Request.QueryString["generar_oficio"];
                }
                else {
                    _generar_oficio = "S/N";
                }
            }





            DateTime _fecha_oficios = DateTime.Now;

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_oficios"]))
            {

                string fecha_OFI_RES145 = Request.QueryString["fecha_oficios"];

                if (fecha_OFI_RES145 != "0")
                {
                    _fecha_oficios = Convert.ToDateTime(fecha_OFI_RES145);

                }
                else
                {
                    _fecha_oficios = _fecha_razon;

                }



            }


            bool _texto_oficios = true;
            if (!String.IsNullOrEmpty(Request.QueryString["texto_oficios"]))
            {
                if (Request.QueryString["texto_oficios"] != "")
                {
                    if (Request.QueryString["texto_oficios"] == "NO")

                        _texto_oficios = false;
                }

            }



            string columnas = "juicios.id_juicios, juicios.juicio_referido_titulo_credito, clientes.identificacion_clientes, " +
                              "clientes.nombres_clientes, clientes.identificacion_garantes, clientes.nombre_garantes, " +
                              "provincias.nombre_provincias, titulo_credito.numero_titulo_credito, juicios.fecha_emision_juicios, " +
                              "juicios.cuantia_inicial, juicios.fecha_ultima_providencia, asignacion_secretarios_view.id_abogado, " +
                              "asignacion_secretarios_view.impulsores, asignacion_secretarios_view.id_secretario, " +
                              "asignacion_secretarios_view.secretarios, ciudad.id_ciudad, ciudad.nombre_ciudad, " +
                              "juicios.numero_juicios, asignacion_secretarios_view.cargo_secretarios, " +
                              "asignacion_secretarios_view.cargo_impulsores, asignacion_secretarios_view.sexo_secretarios, " +
                              "asignacion_secretarios_view.sexo_impulsores , clientes.identificacion_clientes_1, " +
                              " clientes.nombre_clientes_1, clientes.identificacion_clientes_2, nombre_clientes_2, " +
                              "identificacion_clientes_3, clientes.nombre_clientes_3, identificacion_garantes_1, " +
                              "nombre_garantes_1, clientes.identificacion_garantes_2, nombre_garantes_2, " +
                              "identificacion_garantes_3, clientes.nombre_garantes_3, correo_clientes, correo_clientes_1, " +
                              "correo_clientes_2, clientes.correo_clientes_3, clientes.direccion_clientes_1, " +
                              "clientes.direccion_clientes_2, clientes.direccion_clientes_3, clientes.cantidad_clientes, " +
                              "clientes.cantidad_garantes,clientes.sexo_clientes, clientes.sexo_clientes_1,clientes.sexo_clientes_3," +
                              "clientes.sexo_clientes_2,clientes.sexo_garantes, clientes.sexo_garantes_1,clientes.sexo_garantes_2," +
                              "clientes.sexo_garantes_3,titulo_credito.imagen_qr, " +
                              "asignacion_secretarios_view.liquidador, asignacion_secretarios_view.cargo_liquidador, asignacion_secretarios_view.iniciales_usuarios";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios ";
            String where_to = "";

            //para pruebas
            //where = where + " AND juicios.id_juicios = 3933";
            //termina pruebas

            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8 + where9 + where10 + where11 + where12 + where13 + where14 + where15 + where16 + "";


            int _tipo_avoco = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_avoco"]))
            {
                _tipo_avoco = Convert.ToInt32(Request.QueryString["tipo_avoco"]);
                if (_tipo_avoco > 0)
                {


                    if (_tipo_avoco == 1)
                    {
                        if (_generar_oficio == "Si")
                        {




                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoPago_Total_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoPago_Total_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                            ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                            ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                            ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                            ObjRep.SetParameterValue("_numero_oficio", _numero_oficio);
                            ObjRep.SetParameterValue("_fecha_oficio", _fecha_oficio.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_numero_solicitud", _numero_solicitud);
                            ObjRep.SetParameterValue("_fecha_solicitud", _fecha_solicitud.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                             ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                          
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);
                            ObjRep.SetParameterValue("_agregar_disposicion_pago_total", _agregar_disposicion_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_1_pago_total", _agregar_disposicion_1_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_2_pago_total", _agregar_disposicion_2_pago_total);


                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);

                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Pago_Total/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);

                        }
                        else{

                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoPago_Total ObjRep = new Reporte.rptProvidenciaAvocoConocimientoPago_Total();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                        ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        ObjRep.SetParameterValue("_numero_oficio", _numero_oficio);
                        ObjRep.SetParameterValue("_fecha_oficio", _fecha_oficio.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                        ObjRep.SetParameterValue("_numero_solicitud", _numero_solicitud);
                        ObjRep.SetParameterValue("_fecha_solicitud", _fecha_solicitud.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                        ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                        ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                        ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                        ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_agregar_disposicion_pago_total", _agregar_disposicion_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_1_pago_total", _agregar_disposicion_1_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_2_pago_total", _agregar_disposicion_2_pago_total);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);



                            CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Providencias_Pago_Total/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);

                        }
                    }







                    if (_tipo_avoco == 2)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoProceso_Coactivo ObjRep = new Reporte.rptProvidenciaAvocoConocimientoProceso_Coactivo();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                        ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);
                    }

                    if (_tipo_avoco == 3)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoAvoco_Suspension ObjRep = new Reporte.rptProvidenciaAvocoConocimientoAvoco_Suspension();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);
                    }

                    if (_tipo_avoco == 4)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimiento ObjRep = new Reporte.rptProvidenciaAvocoConocimiento();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        //ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        //ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);






                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);
                    }

                    if (_tipo_avoco == 5)
                    {


                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoleyes ObjRep = new Reporte.rptProvidenciaAvocoConocimientoleyes();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                       

                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);


                    }

                    if (_tipo_avoco == 6)
                    {

                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoAvoco ObjRep = new Reporte.rptProvidenciaAvocoConocimientoAvoco();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_tipo_credito", _tipo_credito);
                        ObjRep.SetParameterValue("_reemplazar", _reemplazar);

                        






                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);



                    }

                    if (_tipo_avoco == 7)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoNuevos_Procesos_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoNuevos_Procesos_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                            ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_reemplazar", _reemplazar);
                            ObjRep.SetParameterValue("_tipo_acto", _tipo_acto);
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);
                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                    
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_resolucion_3", _resolucion_3);
                            ObjRep.SetParameterValue("_resolucion_4", _resolucion_4);
                            ObjRep.SetParameterValue("_resolucion_5", _resolucion_5);
                            ObjRep.SetParameterValue("_resolucion_6", _resolucion_6);
                            ObjRep.SetParameterValue("_disponer_2", _disponer_2);
                            ObjRep.SetParameterValue("_disponer_3", _disponer_3);
                            ObjRep.SetParameterValue("_disponer_4", _disponer_4);
                            ObjRep.SetParameterValue("_disponer_5", _disponer_5);


                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else { 

                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoNuevos_Procesos ObjRep = new Reporte.rptProvidenciaAvocoConocimientoNuevos_Procesos();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_reemplazar", _reemplazar);
                        ObjRep.SetParameterValue("_tipo_acto", _tipo_acto);
                        ObjRep.SetParameterValue("_resolucion_3", _resolucion_3);
                        ObjRep.SetParameterValue("_resolucion_4", _resolucion_4);
                        ObjRep.SetParameterValue("_resolucion_5", _resolucion_5);
                        ObjRep.SetParameterValue("_resolucion_6", _resolucion_6);
                        ObjRep.SetParameterValue("_disponer_2", _disponer_2);
                        ObjRep.SetParameterValue("_disponer_3", _disponer_3);
                        ObjRep.SetParameterValue("_disponer_4", _disponer_4);
                        ObjRep.SetParameterValue("_disponer_5", _disponer_5);




                            CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);

                        }

                    }


                    if (_tipo_avoco == 8)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);

                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                          
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);


                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);





                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }

                       


                    }





                    if (_tipo_avoco == 9)
                    {
                        if (_generar_oficio == "Si")
                        {


                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoEmbargo_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoEmbargo_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            
                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta", _numero_oficio_embargo_cuenta);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta", _fecha_oficio_embargo_cuenta.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta", _tipo_cuenta);
                            ObjRep.SetParameterValue("_numero_cuenta", _numero_cuenta);
                            ObjRep.SetParameterValue("_nombre_banco", _nombre_banco);
                            ObjRep.SetParameterValue("_monto_retenido", _monto_retenido);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta", _nombre_titular_cuenta);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta", _identificacion_titular_cuenta);
                            ObjRep.SetParameterValue("_depositario_judicial", _depositario_judicial);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial", _identificacion_depositario_judicial);





                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_2", _numero_oficio_embargo_cuenta_2);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_2", _fecha_oficio_embargo_cuenta_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_2", _tipo_cuenta_2);
                            ObjRep.SetParameterValue("_numero_cuenta_2", _numero_cuenta_2);
                            ObjRep.SetParameterValue("_nombre_banco_2", _nombre_banco_2);
                            ObjRep.SetParameterValue("_monto_retenido_2", _monto_retenido_2);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_2", _nombre_titular_cuenta_2);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_2", _identificacion_titular_cuenta_2);
                            ObjRep.SetParameterValue("_depositario_judicial_2", _depositario_judicial_2);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_2", _identificacion_depositario_judicial_2);





                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_3", _numero_oficio_embargo_cuenta_3);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_3", _fecha_oficio_embargo_cuenta_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_3", _tipo_cuenta_3);
                            ObjRep.SetParameterValue("_numero_cuenta_3", _numero_cuenta_3);
                            ObjRep.SetParameterValue("_nombre_banco_3", _nombre_banco_3);
                            ObjRep.SetParameterValue("_monto_retenido_3", _monto_retenido_3);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_3", _nombre_titular_cuenta_3);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_3", _identificacion_titular_cuenta_3);
                            ObjRep.SetParameterValue("_depositario_judicial_3", _depositario_judicial_3);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_3", _identificacion_depositario_judicial_3);


                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_4", _numero_oficio_embargo_cuenta_4);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_4", _fecha_oficio_embargo_cuenta_4.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_4", _tipo_cuenta_4);
                            ObjRep.SetParameterValue("_numero_cuenta_4", _numero_cuenta_4);
                            ObjRep.SetParameterValue("_nombre_banco_4", _nombre_banco_4);
                            ObjRep.SetParameterValue("_monto_retenido_4", _monto_retenido_4);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_4", _nombre_titular_cuenta_4);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_4", _identificacion_titular_cuenta_4);
                            ObjRep.SetParameterValue("_depositario_judicial_4", _depositario_judicial_4);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_4", _identificacion_depositario_judicial_4);




                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_5", _numero_oficio_embargo_cuenta_5);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_5", _fecha_oficio_embargo_cuenta_5.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_5", _tipo_cuenta_5);
                            ObjRep.SetParameterValue("_numero_cuenta_5", _numero_cuenta_5);
                            ObjRep.SetParameterValue("_nombre_banco_5", _nombre_banco_5);
                            ObjRep.SetParameterValue("_monto_retenido_5", _monto_retenido_5);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_5", _nombre_titular_cuenta_5);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_5", _identificacion_titular_cuenta_5);
                            ObjRep.SetParameterValue("_depositario_judicial_5", _depositario_judicial_5);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_5", _identificacion_depositario_judicial_5);




                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                        
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);


                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Embargo_Cuenta_Bancaria/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else { 

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoEmbargo ObjRep = new Reporte.rptProvidenciaAvocoConocimientoEmbargo();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta", _numero_oficio_embargo_cuenta);
                        ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta", _fecha_oficio_embargo_cuenta.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_tipo_cuenta", _tipo_cuenta);
                        ObjRep.SetParameterValue("_numero_cuenta", _numero_cuenta);
                        ObjRep.SetParameterValue("_nombre_banco", _nombre_banco);
                        ObjRep.SetParameterValue("_monto_retenido", _monto_retenido);
                        ObjRep.SetParameterValue("_nombre_titular_cuenta", _nombre_titular_cuenta);
                        ObjRep.SetParameterValue("_identificacion_titular_cuenta", _identificacion_titular_cuenta);
                        ObjRep.SetParameterValue("_depositario_judicial", _depositario_judicial);

                        ObjRep.SetParameterValue("_identificacion_depositario_judicial", _identificacion_depositario_judicial);



                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_2", _numero_oficio_embargo_cuenta_2);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_2", _fecha_oficio_embargo_cuenta_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_2", _tipo_cuenta_2);
                            ObjRep.SetParameterValue("_numero_cuenta_2", _numero_cuenta_2);
                            ObjRep.SetParameterValue("_nombre_banco_2", _nombre_banco_2);
                            ObjRep.SetParameterValue("_monto_retenido_2", _monto_retenido_2);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_2", _nombre_titular_cuenta_2);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_2", _identificacion_titular_cuenta_2);
                            ObjRep.SetParameterValue("_depositario_judicial_2", _depositario_judicial_2);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_2", _identificacion_depositario_judicial_2);





                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_3", _numero_oficio_embargo_cuenta_3);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_3", _fecha_oficio_embargo_cuenta_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_3", _tipo_cuenta_3);
                            ObjRep.SetParameterValue("_numero_cuenta_3", _numero_cuenta_3);
                            ObjRep.SetParameterValue("_nombre_banco_3", _nombre_banco_3);
                            ObjRep.SetParameterValue("_monto_retenido_3", _monto_retenido_3);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_3", _nombre_titular_cuenta_3);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_3", _identificacion_titular_cuenta_3);
                            ObjRep.SetParameterValue("_depositario_judicial_3", _depositario_judicial_3);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_3", _identificacion_depositario_judicial_3);


                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_4", _numero_oficio_embargo_cuenta_4);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_4", _fecha_oficio_embargo_cuenta_4.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_4", _tipo_cuenta_4);
                            ObjRep.SetParameterValue("_numero_cuenta_4", _numero_cuenta_4);
                            ObjRep.SetParameterValue("_nombre_banco_4", _nombre_banco_4);
                            ObjRep.SetParameterValue("_monto_retenido_4", _monto_retenido_4);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_4", _nombre_titular_cuenta_4);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_4", _identificacion_titular_cuenta_4);
                            ObjRep.SetParameterValue("_depositario_judicial_4", _depositario_judicial_4);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_4", _identificacion_depositario_judicial_4);




                            ObjRep.SetParameterValue("_numero_oficio_embargo_cuenta_5", _numero_oficio_embargo_cuenta_5);
                            ObjRep.SetParameterValue("_fecha_oficio_embargo_cuenta_5", _fecha_oficio_embargo_cuenta_5.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_cuenta_5", _tipo_cuenta_5);
                            ObjRep.SetParameterValue("_numero_cuenta_5", _numero_cuenta_5);
                            ObjRep.SetParameterValue("_nombre_banco_5", _nombre_banco_5);
                            ObjRep.SetParameterValue("_monto_retenido_5", _monto_retenido_5);
                            ObjRep.SetParameterValue("_nombre_titular_cuenta_5", _nombre_titular_cuenta_5);
                            ObjRep.SetParameterValue("_identificacion_titular_cuenta_5", _identificacion_titular_cuenta_5);
                            ObjRep.SetParameterValue("_depositario_judicial_5", _depositario_judicial_5);
                            ObjRep.SetParameterValue("_identificacion_depositario_judicial_5", _identificacion_depositario_judicial_5);







                            CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Providencias_Embargo_Cuenta_Bancaria/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);
                        }

                    }




                    if (_tipo_avoco == 10)
                    {
                        if (_generar_oficio == "Si")
                        {



                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaLevantamientoEmbargoDiscapacidad_ConOficio ObjRep = new Reporte.rptProvidenciaLevantamientoEmbargoDiscapacidad_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                            ObjRep.SetParameterValue("_numero_oficio_medida_cuatelar_discapacidad", _numero_oficio_medida_cuatelar_discapacidad);
                            ObjRep.SetParameterValue("_fecha_oficio_medida_cuatelar_discapacidad", _fecha_oficio_medida_cuatelar_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_liquidacion_medida_cuatelar_discapacidad", _numero_liquidacion_medida_cuatelar_discapacidad);
                            ObjRep.SetParameterValue("_fecha_liquidacion_medida_cuatelar_discapacidad", _fecha_liquidacion_medida_cuatelar_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_discapacidad", _numero_solicitud_discapacidad);
                            ObjRep.SetParameterValue("_fecha_solicitud_discapacidad", _fecha_solicitud_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_discapacitado", _nombre_discapacitado);
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);

                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                     
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_numero_conadis_discapacidad", _numero_conadis_discapacidad);
                            ObjRep.SetParameterValue("_fecha_conadis_discapacidad", _fecha_conadis_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_porcentaje_discapacidad", _porcentaje_discapacidad);
                            ObjRep.SetParameterValue("_acta_validacion_discapacidad", _acta_validacion_discapacidad);
                            ObjRep.SetParameterValue("_numero_memorando_discapacidad", _numero_memorando_discapacidad);
                            ObjRep.SetParameterValue("_fecha_memorando_discapacidad", _fecha_memorando_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_porcentaje_condonacion_discapacidad", _porcentaje_condonacion_discapacidad);
                            ObjRep.SetParameterValue("_porcentaje_restructuracion_discapacidad", _porcentaje_restructuracion_discapacidad);

                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Levantamiento_Medida_Cautelar_Discapacidad/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else { 

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaLevantamientoEmbargoDiscapacidad ObjRep = new Reporte.rptProvidenciaLevantamientoEmbargoDiscapacidad();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        ObjRep.SetParameterValue("_numero_oficio_medida_cuatelar_discapacidad", _numero_oficio_medida_cuatelar_discapacidad);
                        ObjRep.SetParameterValue("_fecha_oficio_medida_cuatelar_discapacidad", _fecha_oficio_medida_cuatelar_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_numero_liquidacion_medida_cuatelar_discapacidad", _numero_liquidacion_medida_cuatelar_discapacidad);
                        ObjRep.SetParameterValue("_fecha_liquidacion_medida_cuatelar_discapacidad", _fecha_liquidacion_medida_cuatelar_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_numero_solicitud_discapacidad", _numero_solicitud_discapacidad);
                        ObjRep.SetParameterValue("_fecha_solicitud_discapacidad", _fecha_solicitud_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_nombre_discapacitado", _nombre_discapacitado);
                            ObjRep.SetParameterValue("_numero_conadis_discapacidad", _numero_conadis_discapacidad);
                            ObjRep.SetParameterValue("_fecha_conadis_discapacidad", _fecha_conadis_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_porcentaje_discapacidad", _porcentaje_discapacidad);
                            ObjRep.SetParameterValue("_acta_validacion_discapacidad", _acta_validacion_discapacidad);
                            ObjRep.SetParameterValue("_numero_memorando_discapacidad", _numero_memorando_discapacidad);
                            ObjRep.SetParameterValue("_fecha_memorando_discapacidad", _fecha_memorando_discapacidad.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_porcentaje_condonacion_discapacidad", _porcentaje_condonacion_discapacidad);
                            ObjRep.SetParameterValue("_porcentaje_restructuracion_discapacidad", _porcentaje_restructuracion_discapacidad);


                            CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Providencias_Levantamiento_Medida_Cautelar_Discapacidad/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);
                        }

                    }




                    if (_tipo_avoco == 11)
                    {
                        if (_generar_oficio == "Si")
                        {


                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaLevantamientoMedidaCautelarFallecimiento_ConOficio ObjRep = new Reporte.rptProvidenciaLevantamientoMedidaCautelarFallecimiento_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                            ObjRep.SetParameterValue("_numero_oficio_medida_cuatelar_fallecimiento", _numero_oficio_medida_cuatelar_fallecimiento);
                            ObjRep.SetParameterValue("_fecha_oficio_medida_cuatelar_fallecimiento", _fecha_oficio_medida_cuatelar_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_liquidacion_medida_cuatelar_fallecimiento", _numero_liquidacion_medida_cuatelar_fallecimiento);
                            ObjRep.SetParameterValue("_fecha_liquidacion_medida_cuatelar_fallecimiento", _fecha_liquidacion_medida_cuatelar_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_fallecimiento", _numero_solicitud_fallecimiento);
                            ObjRep.SetParameterValue("_fecha_solicitud_fallecimiento", _fecha_solicitud_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_conyuge_sobreviviente", _nombre_conyuge_sobreviviente);
                            ObjRep.SetParameterValue("_correo_conyuge_sobreviviente", _correo_conyuge_sobreviviente);
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);

                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_nombre_canton", _nombre_canton);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);



                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Levantamiento_Medida_Cautelar_Fallecimiento/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);



                        }
                        else { 

                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaLevantamientoMedidaCautelarFallecimiento ObjRep = new Reporte.rptProvidenciaLevantamientoMedidaCautelarFallecimiento();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        ObjRep.SetParameterValue("_numero_oficio_medida_cuatelar_fallecimiento", _numero_oficio_medida_cuatelar_fallecimiento);
                        ObjRep.SetParameterValue("_fecha_oficio_medida_cuatelar_fallecimiento", _fecha_oficio_medida_cuatelar_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_numero_liquidacion_medida_cuatelar_fallecimiento", _numero_liquidacion_medida_cuatelar_fallecimiento);
                        ObjRep.SetParameterValue("_fecha_liquidacion_medida_cuatelar_fallecimiento", _fecha_liquidacion_medida_cuatelar_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_numero_solicitud_fallecimiento", _numero_solicitud_fallecimiento);
                        ObjRep.SetParameterValue("_fecha_solicitud_fallecimiento", _fecha_solicitud_fallecimiento.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                        ObjRep.SetParameterValue("_nombre_conyuge_sobreviviente", _nombre_conyuge_sobreviviente);
                        ObjRep.SetParameterValue("_correo_conyuge_sobreviviente", _correo_conyuge_sobreviviente);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_nombre_canton", _nombre_canton);


                            CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Providencias_Levantamiento_Medida_Cautelar_Fallecimiento/");

                        objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                        ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                        ObjRep.Export();

                        dtInforme.Dispose();
                        daInforme.Dispose();

                        CrystalReportViewer1.Dispose();
                        ObjRep.Close();
                        ObjRep.Dispose();



                        byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", byteData.Length.ToString());
                        Response.BinaryWrite(byteData);

                        }
                    }







                    if (_tipo_avoco == 12)
                    {

                        

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoCambio_Liquidador ObjRep = new Reporte.rptProvidenciaAvocoConocimientoCambio_Liquidador();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_tipo_acto", _tipo_acto);
                            ObjRep.SetParameterValue("_escrito_presentado_por", _escrito_presentado_por);
                            ObjRep.SetParameterValue("_dispone_1", _dispone_1);
                            ObjRep.SetParameterValue("_dispone_2", _dispone_2);
                            ObjRep.SetParameterValue("_dispone_3", _dispone_3);
                            ObjRep.SetParameterValue("_dispone_4", _dispone_4);
                            ObjRep.SetParameterValue("_dispone_5", _dispone_5);
                            ObjRep.SetParameterValue("_dispone_6", _dispone_6);
                        ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);

                        



                        CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);

                        

                    }













                    if (_tipo_avoco == 13)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);

                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);


                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);





                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }




                    }



                    if (_tipo_avoco == 14)
                    {
                        if (_generar_oficio == "Si")
                        {




                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoPago_Total_AvocoConocimiento_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoPago_Total_AvocoConocimiento_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                            ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                            ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                            ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                            ObjRep.SetParameterValue("_numero_oficio", _numero_oficio);
                            ObjRep.SetParameterValue("_fecha_oficio", _fecha_oficio.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_numero_solicitud", _numero_solicitud);
                            ObjRep.SetParameterValue("_fecha_solicitud", _fecha_solicitud.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);
                            ObjRep.SetParameterValue("_agregar_disposicion_pago_total", _agregar_disposicion_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_1_pago_total", _agregar_disposicion_1_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_2_pago_total", _agregar_disposicion_2_pago_total);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);



                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Pago_Total/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);

                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoPago_Total_AvocoConocimiento ObjRep = new Reporte.rptProvidenciaAvocoConocimientoPago_Total_AvocoConocimiento();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                            ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                            ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                            ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                            ObjRep.SetParameterValue("_numero_oficio", _numero_oficio);
                            ObjRep.SetParameterValue("_fecha_oficio", _fecha_oficio.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_numero_solicitud", _numero_solicitud);
                            ObjRep.SetParameterValue("_fecha_solicitud", _fecha_solicitud.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_agregar_disposicion_pago_total", _agregar_disposicion_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_1_pago_total", _agregar_disposicion_1_pago_total);
                            ObjRep.SetParameterValue("_agregar_disposicion_2_pago_total", _agregar_disposicion_2_pago_total);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);



                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Pago_Total/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);

                        }
                    }








                    if (_tipo_avoco == 15)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_Quito_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_Quito_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);

                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);



                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_Quito ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRestructuracion_AvocoConocimiento_Quito();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_oficio_restructuracion", _numero_oficio_restructuracion);
                            ObjRep.SetParameterValue("_fecha_oficio_restructuracion", _fecha_oficio_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_numero_solicitud_restructuracion", _numero_solicitud_restructuracion);
                            ObjRep.SetParameterValue("_fecha_solicitud_restructuracion", _fecha_solicitud_restructuracion.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_acta_validacion_restructuracion", _acta_validacion_restructuracion);
                            ObjRep.SetParameterValue("_tipo_lev", _tipo_lev);

                            ObjRep.SetParameterValue("_nombre_numero_documento_1", _nombre_numero_documento_1);
                            ObjRep.SetParameterValue("_fecha_documento_1", _fecha_documento_1.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_2", _nombre_numero_documento_2);
                            ObjRep.SetParameterValue("_fecha_documento_2", _fecha_documento_2.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_nombre_numero_documento_3", _nombre_numero_documento_3);
                            ObjRep.SetParameterValue("_fecha_documento_3", _fecha_documento_3.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_agregar_disposicion", _agregar_disposicion);
                            ObjRep.SetParameterValue("_agregar_disposicion_1", _agregar_disposicion_1);
                            ObjRep.SetParameterValue("_agregar_disposicion_2", _agregar_disposicion_2);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);
                            ObjRep.SetParameterValue("_tipo_ley", _tipo_ley);




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Restructuracion/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }




                    }









                    if (_tipo_avoco == 16)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            
                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                             ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);
                            ObjRep.SetParameterValue("_cantidad_retener", _cantidad_retener);
                         

                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Fondos/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_cantidad_retener", _cantidad_retener);
                          




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Fondos/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }




                    }
                    if (_tipo_avoco == 20)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Cuentas_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Cuentas_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);
                            ObjRep.SetParameterValue("_cuenta_retener", _cuenta_retener);
                            ObjRep.SetParameterValue("_nombre_entidad_cuenta", _nombre_entidad_cuenta);
                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_disponer_5", _disponer_5);
                            ObjRep.SetParameterValue("_tipo_acto", _tipo_acto);




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Cuentas/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else
                        {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Cuentas ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Cuentas();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_cuenta_retener", _cuenta_retener);
                            ObjRep.SetParameterValue("_nombre_entidad_cuenta", _nombre_entidad_cuenta);
                            ObjRep.SetParameterValue("_disponer_5", _disponer_5);
                            ObjRep.SetParameterValue("_tipo_acto", _tipo_acto);




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Cuentas/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }




                    }




                    if (_tipo_avoco == 17)
                    {

                        if (_generar_oficio == "Si")
                        {
                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_AvocoConocimiento_ConOficio ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_AvocoConocimiento_ConOficio();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);
                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

                            ObjRep.SetParameterValue("_identificador_oficio", _identificador_oficio);
                            ObjRep.SetParameterValue("_entidad_va_oficio", _entidad_va_oficio);
                            ObjRep.SetParameterValue("_asunto", _asunto);


                            ObjRep.SetParameterValue("_identificador_oficio_2", _identificador_oficio_2);
                            ObjRep.SetParameterValue("_entidad_va_oficio_2", _entidad_va_oficio_2);
                            ObjRep.SetParameterValue("_identificador_oficio_3", _identificador_oficio_3);
                            ObjRep.SetParameterValue("_entidad_va_oficio_3", _entidad_va_oficio_3);
                            ObjRep.SetParameterValue("_identificador_oficio_4", _identificador_oficio_4);
                            ObjRep.SetParameterValue("_entidad_va_oficio_4", _entidad_va_oficio_4);
                            ObjRep.SetParameterValue("_identificador_oficio_5", _identificador_oficio_5);
                            ObjRep.SetParameterValue("_entidad_va_oficio_5", _entidad_va_oficio_5);
                            ObjRep.SetParameterValue("_identificador_oficio_6", _identificador_oficio_6);
                            ObjRep.SetParameterValue("_entidad_va_oficio_6", _entidad_va_oficio_6);
                            ObjRep.SetParameterValue("_identificador_oficio_7", _identificador_oficio_7);
                            ObjRep.SetParameterValue("_entidad_va_oficio_7", _entidad_va_oficio_7);
                            ObjRep.SetParameterValue("_identificador_oficio_8", _identificador_oficio_8);
                            ObjRep.SetParameterValue("_entidad_va_oficio_8", _entidad_va_oficio_8);

                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev", _referencia_oficios_tipo_lev);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_2", _referencia_oficios_tipo_lev_2);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_3", _referencia_oficios_tipo_lev_3);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_4", _referencia_oficios_tipo_lev_4);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_5", _referencia_oficios_tipo_lev_5);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_6", _referencia_oficios_tipo_lev_6);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_7", _referencia_oficios_tipo_lev_7);
                            ObjRep.SetParameterValue("_referencia_oficios_tipo_lev_8", _referencia_oficios_tipo_lev_8);
                            ObjRep.SetParameterValue("_pie_oficios", _pie_oficios);

                            ObjRep.SetParameterValue("_cantidad_retener_avoco_conocimiento", _cantidad_retener_avoco_conocimiento);
                            ObjRep.SetParameterValue("_direccion_juzgado", _direccion_juzgado);
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);


                            ObjRep.SetParameterValue("_fecha_oficios", _fecha_oficios.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_texto_oficios", _texto_oficios);
                            ObjRep.SetParameterValue("_tipo_cartera", _tipo_cartera);

                            ObjRep.SetParameterValue("_citado", _citado);
                            ObjRep.SetParameterValue("_disposicion_citar", _disposicion_citar);




                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Fondos/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);


                        }
                        else {

                            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();
                            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                            daInforme.Fill(dtInforme, "juicios");
                            int reg = dtInforme.Tables[1].Rows.Count;
                            Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_AvocoConocimiento ObjRep = new Reporte.rptProvidenciaAvocoConocimientoRetencion_Fondos_AvocoConocimiento();


                            ObjRep.SetDataSource(dtInforme.Tables[1]);

                            CultureInfo ci = new CultureInfo("es-EC");

                            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));
                            ObjRep.SetParameterValue("_cantidad_retener_avoco_conocimiento", _cantidad_retener_avoco_conocimiento);
                            ObjRep.SetParameterValue("_direccion_juzgado", _direccion_juzgado);
                            ObjRep.SetParameterValue("_referencia", _referencia);
                            ObjRep.SetParameterValue("_remplaza_impulsor", _remplaza_impulsor);
                            ObjRep.SetParameterValue("_impulsor_saliente_cambio_liquidador", _impulsor_saliente_cambio_liquidador);
                            ObjRep.SetParameterValue("_tipo_cartera", _tipo_cartera);
                            ObjRep.SetParameterValue("_citado", _citado);
                            ObjRep.SetParameterValue("_disposicion_citar", _disposicion_citar);





                            CrystalReportViewer1.DataBind();

                            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Retencion_Fondos/");

                            objDiskOpt.DiskFileName = pathToFiles + _nombre_documento + ".pdf";
                            ObjRep.ExportOptions.DestinationOptions = objDiskOpt;
                            ObjRep.Export();

                            dtInforme.Dispose();
                            daInforme.Dispose();

                            CrystalReportViewer1.Dispose();
                            ObjRep.Close();
                            ObjRep.Dispose();



                            byte[] byteData = System.IO.File.ReadAllBytes(objDiskOpt.DiskFileName);
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-length", byteData.Length.ToString());
                            Response.BinaryWrite(byteData);
                        }




                    }










                }

            }



          


        }
    }
}