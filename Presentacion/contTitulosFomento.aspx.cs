using CrystalDecisions.CrystalReports.Engine;
using Negocio;
using Npgsql;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class contTitulosFomento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            //var dsBalanceComprobacionDetallado = new Datas.dsBalanceComprobacionDetallado();

            
            parametros.nombre_secretatio = Request.QueryString["nombre_secretatio"];
            
            string columnas = "numero_titulo_credito_fomento, identificacion_cliente, nombre_abg_secretario";
            string tablas = " titulo_credito_fomento";
            string where = " encontrado = 'FALSE'";
            
           
            String where_to = "";
            if (!String.IsNullOrEmpty(parametros.nombre_secretatio))
            {
                where_to += " AND titulo_credito_fomento.nombre_abg_secretario='" + parametros.nombre_secretatio + "'";
            }
           

            where = where + where_to;

          

            Datas.dtTitulosFomento dtInforme = new Datas.dtTitulosFomento();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
            daInforme.Fill(dtInforme, "titulo_credito_fomento");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptTituloFomento ObjRep = new Reporte.rptTituloFomento();
            ObjRep.SetDataSource(dtInforme.Tables[1]);
            //if (_where.ToString().Length > 0)
            CrystalReportViewer1.ReportSource = ObjRep;
            CrystalReportViewer1.DataBind();
            
            

        }

       

        protected void CrystalReportViewer1_Init1(object sender, EventArgs e)
        {

        }
    }
}