﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Negocio;
using Npgsql;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class contProvidenciaSuspension : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            //var dsBalanceComprobacionDetallado = new Datas.dsBalanceComprobacionDetallado();
            string _id_juicios = "";
            string _id_abogado = "";
            string _juicio_referido_titulo_credito = "";
            string _numero_titulo_credito = "";
            
            string _id_estados_procesales_juicios = "";
            string _id_provincias = "";
            string _id_secretario = "";

            string _identificacion_clientes = "";
            string _identificacion_clientes_1 = "";
            string _identificacion_clientes_2 = "";
            string _identificacion_clientes_3 = "";

            string _identificacion_garantes = "";
            string _identificacion_garantes_1 = "";
            string _identificacion_garantes_2 = "";
            string _identificacion_garantes_3 = "";


            string _razon_providencias = "0";

            DateTime _fecha_providencias = DateTime.Now;
            DateTime _fecha_providencias_razones = DateTime.Now;
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


            if (!String.IsNullOrEmpty(Request.QueryString["razon_providencias"]))
            {

                
                if (Request.QueryString["razon_providencias"] != "0")
                {
                    _razon_providencias = Request.QueryString["razon_providencias"];
                }

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

            DateTime _fecha_razon = DateTime.Now;


            if (!String.IsNullOrEmpty(Request.QueryString["fecha_providencias"]))
            {

                string fecha = Request.QueryString["fecha_providencias"];
                string hora = Request.QueryString["hora_providencias"];

                if (fecha != "0")
                {
                    _fecha_providencias = Convert.ToDateTime(fecha +" "+hora);
                    _fecha_providencias_razones = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_razon = Convert.ToDateTime(fecha);
                }



            }

           



            if (!String.IsNullOrEmpty(Request.QueryString["fecha_desde"]))
            {
                string fecha_desde = Request.QueryString["fecha_desde"];
                string fecha_hasta = Request.QueryString["fecha_hasta"];

                where16 += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "'";
            }

            string _nombre_documento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_archivo_providencias"]))
            {


                if (Request.QueryString["nombre_archivo_providencias"] != "")
                {
                    _nombre_documento = Request.QueryString["nombre_archivo_providencias"];
                }
                else
                {
                    Random r = new Random();
                    int n = r.Next();
                    _nombre_documento = "PS" + "001" +n.ToString() ;
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



            string columnas = "juicios.id_juicios, juicios.juicio_referido_titulo_credito, clientes.identificacion_clientes, "+
                              "clientes.nombres_clientes, clientes.identificacion_garantes, clientes.nombre_garantes, "+
                              "provincias.nombre_provincias, titulo_credito.numero_titulo_credito, juicios.fecha_emision_juicios, "+
                              "juicios.cuantia_inicial, juicios.fecha_ultima_providencia, asignacion_secretarios_view.id_abogado, "+
                              "asignacion_secretarios_view.impulsores, asignacion_secretarios_view.id_secretario, "+
                              "asignacion_secretarios_view.secretarios, ciudad.id_ciudad, ciudad.nombre_ciudad , "+
                              "juicios.numero_juicios, asignacion_secretarios_view.cargo_secretarios, "+
                              "asignacion_secretarios_view.cargo_impulsores, asignacion_secretarios_view.sexo_secretarios, "+
                              "asignacion_secretarios_view.sexo_impulsores , clientes.identificacion_clientes_1, "+
                              " clientes.nombre_clientes_1, clientes.identificacion_clientes_2, nombre_clientes_2, " +
                              "identificacion_clientes_3, clientes.nombre_clientes_3, identificacion_garantes_1, "+
                              "nombre_garantes_1, clientes.identificacion_garantes_2, nombre_garantes_2, "+
                              "identificacion_garantes_3, clientes.nombre_garantes_3, correo_clientes, correo_clientes_1, "+
                              "correo_clientes_2, clientes.correo_clientes_3, clientes.direccion_clientes_1, "+
                              "clientes.direccion_clientes_2, clientes.direccion_clientes_3, clientes.cantidad_clientes, "+
                              "clientes.cantidad_garantes,clientes.sexo_clientes, clientes.sexo_clientes_1,clientes.sexo_clientes_3,"+
                              "clientes.sexo_clientes_2,clientes.sexo_garantes, clientes.sexo_garantes_1,clientes.sexo_garantes_2,"+
                              "clientes.sexo_garantes_3,titulo_credito.imagen_qr, " +
                                "asignacion_secretarios_view.liquidador, asignacion_secretarios_view.cargo_liquidador, asignacion_secretarios_view.iniciales_usuarios";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios ";

            //para pruebas
            //where = where + " AND juicios.id_juicios = 22310";
            //termina pruebas
            String where_to = "";
            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8 + where9 + where10 + where11 + where12 + where13 + where14 + where15 + where16 + "";

            //string _nombre_documento = "PS"+_id_juicios + _id_abogado + _juicio_referido_titulo_credito + _numero_titulo_credito + _identificacion_clientes + _id_estados_procesales_juicios;
            //where = where + where_to;


            if (_generar_oficio == "Si")
            {




                Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                daInforme.Fill(dtInforme, "juicios");
                int reg = dtInforme.Tables[1].Rows.Count;
                Reporte.rptProvidenciaSuspension_ConOficio ObjRep = new Reporte.rptProvidenciaSuspension_ConOficio();


                ObjRep.SetDataSource(dtInforme.Tables[1]);
                CultureInfo ci = new CultureInfo("es-EC");

                ObjRep.SetParameterValue("_fecha_providencias", _fecha_providencias.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                ObjRep.SetParameterValue("_fecha_providencias_razones", _fecha_providencias_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                ObjRep.SetParameterValue("_razon_providencias", _razon_providencias);
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


                ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                string pathToFiles = Server.MapPath("~/Documentos/Providencias_Suspension/");

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
            Reporte.rptProvidenciaSuspension ObjRep = new Reporte.rptProvidenciaSuspension();

            
            ObjRep.SetDataSource(dtInforme.Tables[1]);
            CultureInfo ci = new CultureInfo("es-EC");

            ObjRep.SetParameterValue("_fecha_providencias", _fecha_providencias.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
            ObjRep.SetParameterValue("_fecha_providencias_razones", _fecha_providencias_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
            ObjRep.SetParameterValue("_razon_providencias", _razon_providencias);
            ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));

            //CrystalReportViewer1.DataBind();

            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
            string pathToFiles = Server.MapPath("~/Documentos/Providencias_Suspension/");

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

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {



        }

        

    }
}