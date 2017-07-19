using CrystalDecisions.CrystalReports.Engine;
using Npgsql;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class contJuiciosEstadisticasaspx : System.Web.UI.Page
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

            string where1 = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            string where5 = "";
            string where6 = "";
            string where7 = "";
            string where8 = "";

            if (!String.IsNullOrEmpty(Request.QueryString["id_juicios"]))
            {

                _id_juicios = Request.QueryString["id_juicios"];
                where1 = "  AND juicios.id_juicios = '" + _id_juicios + "'       ";
            }
            if (!String.IsNullOrEmpty(Request.QueryString["id_abogado"]))
            {
                _id_juicios = Request.QueryString["id_abogado"];
                where2 = "  AND asignacion_secretarios_view.id_abogado = '" + _id_abogado + "'       ";
            }
            if (!String.IsNullOrEmpty(Request.QueryString["juicio_referido_titulo_credito"]))
            {
                _id_juicios = Request.QueryString["juicio_referido_titulo_credito"];
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
                where5 = "  AND juicios.id_estados_procesales_juicios = '" + _id_estados_procesales_juicios + "'       ";
            }

            if (!String.IsNullOrEmpty(Request.QueryString["numero_titulo_credito"]))
            {
                _numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
                where6 = "  AND titulo_credito.numero_titulo_credito = '" + _numero_titulo_credito + "'       ";
            }

            if (!String.IsNullOrEmpty(Request.QueryString["id_provincias"]))
            {
                _id_provincias = Request.QueryString["id_provincias"];
                where7 = "  AND juicios.id_provincias = '" + _id_provincias + "'       ";
            }


            if (!String.IsNullOrEmpty(Request.QueryString["id_secretario"]))
            {
                _id_secretario = Request.QueryString["id_secretario"];
                where8 = "  AND asignacion_secretarios_view = '" + _id_secretario + "'       ";
            }







            string columnas = "juicios.orden, juicios.regional, juicios.juicio_referido_titulo_credito, juicios.year_juicios, clientes.id_clientes, clientes.identificacion_clientes, clientes.nombres_clientes, clientes.nombre_garantes, provincias.id_provincias, provincias.nombre_provincias, titulo_credito.id_titulo_credito, titulo_credito.numero_titulo_credito, juicios.fecha_emision_juicios, juicios.cuantia_inicial, juicios.riesgo_actual, estados_procesales_juicios.id_estados_procesales_juicios, estados_procesales_juicios.nombre_estados_procesales_juicios, juicios.descripcion_estado_procesal, juicios.fecha_ultima_providencia, juicios.estrategia_seguir, juicios.observaciones, asignacion_secretarios_view.id_abogado, asignacion_secretarios_view.impulsores, asignacion_secretarios_view.id_secretario, asignacion_secretarios_view.secretarios, ciudad.id_ciudad, ciudad.nombre_ciudad";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND titulo_credito.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios AND juicios.orden < 2000 ";
            //string order_by = "juicios.numero_juicios";

            String where_to = "";
            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8;


            //where = where + where_to;


            Datas.dtProvidenciaSuspension2 dtInforme = new Datas.dtProvidenciaSuspension2();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
            daInforme.Fill(dtInforme, "juicios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptJuciosEstadisticas2 ObjRep = new Reporte.rptJuciosEstadisticas2();
            ObjRep.SetDataSource(dtInforme.Tables[1]);
            //if (_where.ToString().Length > 0)
            CrystalReportViewer1.ReportSource = ObjRep;
            CrystalReportViewer1.DataBind();
            


        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}