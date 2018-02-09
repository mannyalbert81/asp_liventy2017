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
using System.Drawing;
using MessagingToolkit.QRCode.Codec;

namespace Presentacion
{
    public partial class contOficiosGraficas : System.Web.UI.Page
    {
        ParametrosRpt parametros = new ParametrosRpt();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

            ReportDocument crystalReport = new ReportDocument();
            var dsGraficas = new Datas.dtOficiosGraficas();
            DataTable dt_Reporte1 = new DataTable();


            parametros.juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];
            parametros.numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
            parametros.identificacion_clientes = Request.QueryString["identificacion_clientes"];
            parametros.fecha_desde = Request.QueryString["fecha_desde"];
            parametros.fecha_hasta = Request.QueryString["fecha_hasta"];

            try { parametros.id_provincias = Convert.ToInt32(Request.QueryString["id_provincias"]); } catch (Exception) { parametros.id_provincias = 0; }
            try { parametros.id_abogado = Convert.ToInt32(Request.QueryString["id_abogado"]); } catch (Exception) { parametros.id_abogado = 0; }
            try { parametros.id_estados_procesales_juicios = Convert.ToInt32(Request.QueryString["id_estados_procesales_juicios"]); } catch (Exception) { parametros.id_estados_procesales_juicios = 0; }
            try { parametros.id_secretario = Convert.ToInt32(Request.QueryString["id_secretario"]); } catch (Exception) { parametros.id_secretario = 0; }
            try { parametros.id_ciudad = Convert.ToInt32(Request.QueryString["id_ciudad"]); } catch (Exception) { parametros.id_ciudad = 0; }
            try { parametros.id_rol = Convert.ToInt32(Request.QueryString["id_rol"]); } catch (Exception) { parametros.id_rol = 0; }

            string _numero_titulo_credito = "";


            string columnas = "SUM(providencias.cantidad_oficios_generados) as total, tipo_providencias.nombre_tipo_providencias";
            string tablas = " public.providencias, public.juicios, public.estados_procesales_juicios, public.clientes, public.provincias, public.titulo_credito, public.asignacion_secretarios_view, public.tipo_providencias";
            string where = "providencias.id_juicios = juicios.id_juicios AND estados_procesales_juicios.id_estados_procesales_juicios = juicios.id_estados_procesales_juicios AND provincias.id_provincias = clientes.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND titulo_credito.id_clientes = clientes.id_clientes AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios AND tipo_providencias.id_tipo_providencias = providencias.id_tipo_providencias AND providencias.eliminado_documento = 'false' AND genero_oficio = 'true'";
            string grupo = "tipo_providencias.nombre_tipo_providencias";
            string id = "tipo_providencias.nombre_tipo_providencias";




            String where_to = "";


            if (parametros.id_rol == 3)
            {


                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_abogado > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_abogado=" + parametros.id_abogado + "";
                }
                if (parametros.id_provincias > 0)
                {
                    where_to += " AND provincias.id_provincias=" + parametros.id_provincias + "";
                }
                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND juicios.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND titulo_credito.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND clientes.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(providencias.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }


            }

            if (parametros.id_rol == 5)
            {
                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_abogado > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_abogado=" + parametros.id_abogado + "";
                }
                if (parametros.id_secretario > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_secretario=" + parametros.id_secretario + "";
                }
                if (parametros.id_provincias > 0)
                {
                    where_to += " AND provincias.id_provincias=" + parametros.id_provincias + "";
                }
                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND juicios.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND titulo_credito.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND clientes.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(providencias.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }




            }
            if (parametros.id_rol == 23)
            {
                if (parametros.id_ciudad > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_ciudad=" + parametros.id_ciudad + "";
                }
                if (parametros.id_abogado > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_abogado=" + parametros.id_abogado + "";
                }
                if (parametros.id_secretario > 0)
                {
                    where_to += " AND asignacion_secretarios_view.id_secretario=" + parametros.id_secretario + "";
                }

                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND juicios.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND titulo_credito.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND clientes.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(providencias.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }


            }


            where = where + where_to;

            dt_Reporte1 = AccesoLogica.Select(columnas, tablas, where, grupo, id);



            dsGraficas.Tables.Add(dt_Reporte1);


            string cadena = Server.MapPath("~/Reporte/rptGraficasOficios.rpt");
            crystalReport.Load(cadena);
            crystalReport.SetDataSource(dsGraficas.Tables[1]);


            CrystalReportViewer1.ReportSource = crystalReport;



        }
    }
}