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
    public partial class contOficios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            string _id_juicios = "";
            string _identificador_oficios = "";


            string where1 = "";
            string where2 = "";


            if (!String.IsNullOrEmpty(Request.QueryString["id_juicios"]))
            {

                _id_juicios = Request.QueryString["id_juicios"];
                if (_id_juicios != "0")
                {
                    where1 = "  AND oficios.id_juicios = '" + _id_juicios + "'       ";
                }

            }


            if (!String.IsNullOrEmpty(Request.QueryString["identificador_oficios"]))
            {
                _identificador_oficios = Request.QueryString["identificador_oficios"];
                if (_identificador_oficios != "0")
                {
                    
                    where2 = "  AND oficios.identificador = '" + _identificador_oficios + "'       ";
                }
            }


            string columnas = "asignacion_secretarios_view.impulsores, asignacion_secretarios_view.cargo_impulsores,"+
            " asignacion_secretarios_view.sexo_impulsores, asignacion_secretarios_view.secretarios,"+
            " asignacion_secretarios_view.cargo_secretarios, asignacion_secretarios_view.sexo_secretarios,"+
            " oficios.cuerpo_oficios, jui_tc.imagen_qr";
            string tablas = "public.asignacion_secretarios_view INNER JOIN public.oficios" +
                    " ON oficios.id_usuario_registra_oficios = asignacion_secretarios_view.id_abogado"+
                    " INNER JOIN (SELECT jui.id_juicios, tc.imagen_qr"+
                    " FROM juicios jui INNER JOIN titulo_credito tc"+
                    " ON jui.id_titulo_credito = tc.id_titulo_credito) jui_tc"+
                    " ON jui_tc.id_juicios = oficios.id_juicios";
            string where = " 1=1";

            //para pruebas
           //where = where + " AND oficios.id_juicios = 4117";
            //termina pruebas
            String where_to = "";
            where_to = where + where1 + where2 + "";

            string _nombre_documento = "OFICIO" + _identificador_oficios;
            //where = where + where_to;


            Datas.dtOficios dtInforme = new Datas.dtOficios();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas,tablas,where_to);
            daInforme.Fill(dtInforme, "oficios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptOficios ObjRep = new Reporte.rptOficios();


            ObjRep.SetDataSource(dtInforme.Tables[1]);
            //CrystalReportViewer1.ReportSource = ObjRep;
            
            
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