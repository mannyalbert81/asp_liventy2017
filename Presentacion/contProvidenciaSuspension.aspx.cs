using CrystalDecisions.CrystalReports.Engine;
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
            string _identificacion_clientes = "";
            string _id_estados_procesales_juicios = "";
            string _id_provincias = "";
            string _id_secretario = "";

           

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



            if (!String.IsNullOrEmpty(Request.QueryString["fecha_providencias"]))
            {

                string fecha = Request.QueryString["fecha_providencias"];
                string hora = Request.QueryString["hora_providencias"];

                if (fecha != "0")
                {
                    _fecha_providencias = Convert.ToDateTime(fecha +" "+hora);
                    _fecha_providencias_razones = Convert.ToDateTime(fecha + " " + hora);
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
                              " clientes.nombre_clientes_1, clientes.identificacion_clientes_2, nombre_clientes_2, "+
                              "identificacion_clientes_3, clientes.nombre_clientes_3, identificacion_garantes_1, "+
                              "nombre_garantes_1, clientes.identificacion_garantes_2, nombre_garantes_2, "+
                              "identificacion_garantes_3, clientes.nombre_garantes_3, correo_clientes, correo_clientes_1, "+
                              "correo_clientes_2, clientes.correo_clientes_3, clientes.direccion_clientes_1, "+
                              "clientes.direccion_clientes_2, clientes.direccion_clientes_3, clientes.cantidad_clientes, "+
                              "clientes.cantidad_garantes,clientes.sexo_clientes, clientes.sexo_clientes_1,clientes.sexo_clientes_3,"+
                              "clientes.sexo_clientes_2,clientes.sexo_garantes, clientes.sexo_garantes_1,clientes.sexo_garantes_2,"+ 
                              "clientes.sexo_garantes_3";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND titulo_credito.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios ";

            //para pruebas
            //where = where + " AND juicios.id_juicios = 22310";
            //termina pruebas
            String where_to = "";
            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8;
            
            string _nombre_documento = "PS"+_id_juicios + _id_abogado + _juicio_referido_titulo_credito + _numero_titulo_credito + _identificacion_clientes + _id_estados_procesales_juicios;
            //where = where + where_to;


            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
            daInforme.Fill(dtInforme, "juicios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptProvidenciaSuspension ObjRep = new Reporte.rptProvidenciaSuspension();

            
            ObjRep.SetDataSource(dtInforme.Tables[1]);
            CultureInfo ci = new CultureInfo("es-EC");

            ObjRep.SetParameterValue("_fecha_providencias", _fecha_providencias.ToString("f",ci));
            ObjRep.SetParameterValue("_fecha_providencias_razones", _fecha_providencias_razones.AddMinutes(20).ToString("f", ci));
            ObjRep.SetParameterValue("_razon_providencias", _razon_providencias);

            //CrystalReportViewer1.DataBind();

            ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
            string pathToFiles = Server.MapPath("~/providencias/");

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

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {



        }

        

    }
}