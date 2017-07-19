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
    public partial class contGraficas : System.Web.UI.Page
    {

        ParametrosRpt parametros = new ParametrosRpt();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {
            ReportDocument crystalReport = new ReportDocument();
            var dsGraficas = new Datas.dtGraficas();
            DataTable dt_Reporte1 = new DataTable();
            
            
            parametros.juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];
            parametros.numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
            parametros.identificacion_clientes = Request.QueryString["identificacion_clientes"];

            try{parametros.id_provincias = Convert.ToInt32(Request.QueryString["id_provincias"]); }catch (Exception) { parametros.id_provincias = 0; }
            try{parametros.id_abogado = Convert.ToInt32(Request.QueryString["id_abogado"]); } catch (Exception) { parametros.id_abogado = 0; }
            try{parametros.id_estados_procesales_juicios = Convert.ToInt32(Request.QueryString["id_estados_procesales_juicios"]); } catch (Exception) { parametros.id_estados_procesales_juicios = 0; }
            try{parametros.id_secretario = Convert.ToInt32(Request.QueryString["id_secretario"]); } catch (Exception) { parametros.id_secretario = 0; }
            try{parametros.id_ciudad = Convert.ToInt32(Request.QueryString["id_ciudad"]); } catch (Exception) { parametros.id_ciudad = 0; }
            try{parametros.id_rol = Convert.ToInt32(Request.QueryString["id_rol"]); } catch (Exception) { parametros.id_rol = 0; }


            
            string columnas = "COUNT(id_juicios) as total, estados_procesales_juicios.id_estados_procesales_juicios, estados_procesales_juicios.nombre_estados_procesales_juicios";
            string tablas = " public.juicios, public.estados_procesales_juicios, public.clientes, public.provincias, public.titulo_credito, public.asignacion_secretarios_view, public.ciudad";
            string where = " estados_procesales_juicios.id_estados_procesales_juicios = juicios.id_estados_procesales_juicios AND clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios AND titulo_credito.id_ciudad = ciudad.id_ciudad";
            string grupo = "estados_procesales_juicios.nombre_estados_procesales_juicios, estados_procesales_juicios.id_estados_procesales_juicios";
            string id = "estados_procesales_juicios.nombre_estados_procesales_juicios, id_estados_procesales_juicios";
            

           

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



               

            }
            if (parametros.id_rol == 23)
            {
                if (parametros.id_ciudad > 0)
                {
                    where_to += " AND ciudad.id_ciudad=" + parametros.id_ciudad + "";
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
      

            }


            where = where + where_to;
          
            dt_Reporte1 = AccesoLogica.Select(columnas, tablas, where, grupo, id);

           
            dsGraficas.Tables.Add(dt_Reporte1);
            
            
            string cadena = Server.MapPath("~/Reporte/rptGraficas.rpt");
            crystalReport.Load(cadena);
            crystalReport.SetDataSource(dsGraficas.Tables[1]);


            CrystalReportViewer1.ReportSource = crystalReport;


        }
    }
}