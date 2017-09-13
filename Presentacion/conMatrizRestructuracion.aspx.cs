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
    public partial class conMatrizRestructuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();


            //var dsBalanceComprobacionDetallado = new Datas.dsBalanceComprobacionDetallado();


            parametros.juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];
            parametros.numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
            parametros.comprarado_fomento = Request.QueryString["comprarado_fomento"];
            parametros.fecha_desde = Request.QueryString["fecha_desde"];
            parametros.fecha_hasta = Request.QueryString["fecha_hasta"];


            parametros.identificacion_clientes = Request.QueryString["identificacion_clientes"];
            parametros.identificacion_clientes_1 = Request.QueryString["identificacion_clientes_1"];
            parametros.identificacion_clientes_2 = Request.QueryString["identificacion_clientes_2"];
            parametros.identificacion_clientes_3 = Request.QueryString["identificacion_clientes_3"];

            parametros.identificacion_garantes = Request.QueryString["identificacion_garantes"];
            parametros.identificacion_garantes_1 = Request.QueryString["identificacion_garantes_1"];
            parametros.identificacion_garantes_2 = Request.QueryString["identificacion_garantes_2"];
            parametros.identificacion_garantes_3 = Request.QueryString["identificacion_garantes_3"];


            try { parametros.id_provincias = Convert.ToInt32(Request.QueryString["id_provincias"]); } catch (Exception) { parametros.id_provincias = 0; }
            try { parametros.id_abogado = Convert.ToInt32(Request.QueryString["id_abogado"]); } catch (Exception) { parametros.id_abogado = 0; }
            try { parametros.id_estados_procesales_juicios = Convert.ToInt32(Request.QueryString["id_estados_procesales_juicios"]); } catch (Exception) { parametros.id_estados_procesales_juicios = 0; }
            try { parametros.id_secretario = Convert.ToInt32(Request.QueryString["id_secretario"]); } catch (Exception) { parametros.id_secretario = 0; }
            try { parametros.id_ciudad = Convert.ToInt32(Request.QueryString["id_ciudad"]); } catch (Exception) { parametros.id_ciudad = 0; }
            try { parametros.id_rol = Convert.ToInt32(Request.QueryString["id_rol"]); } catch (Exception) { parametros.id_rol = 0; }



            string columnas =     "titulo_credito.numero_titulo_credito,"+ 
                                  "clientes.nombres_clientes,"+ 
                                  "provincias.nombre_provincias,"+ 
                                  "juicios_restructuracion.fecha_providencia_restructuracion,"+ 
                                  "asignacion_secretarios_view.secretarios,"+ 
                                  "asignacion_secretarios_view.impulsores,"+ 
                                  "tipo_restructuracion.nombre_tipo_restructuracion,"+ 
                                  "juicios.juicio_referido_titulo_credito,"+ 
                                  "juicios_restructuracion.levantamiento_medida,"+ 
                                  "juicios_restructuracion.archivado_restructuracion";
            string tablas = "  public.titulo_credito, public.juicios, public.clientes, public.juicios_restructuracion, public.provincias, public.asignacion_secretarios_view, public.tipo_restructuracion";
            string where = "titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND clientes.id_clientes = titulo_credito.id_clientes AND juicios_restructuracion.id_juicios = juicios.id_juicios AND provincias.id_provincias = clientes.id_provincias AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios AND tipo_restructuracion.id_tipo_restructuracion = juicios_restructuracion.id_tipo_restructuracion";

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
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_1))
                {
                    where_to += " AND clientes.identificacion_clientes_1 = '" + parametros.identificacion_clientes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_2))
                {
                    where_to += " AND clientes.identificacion_clientes_2 = '" + parametros.identificacion_clientes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_3))
                {
                    where_to += " AND clientes.identificacion_clientes_3 = '" + parametros.identificacion_clientes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.identificacion_garantes))
                {
                    where_to += " AND clientes.identificacion_garantes = '" + parametros.identificacion_garantes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_1))
                {
                    where_to += " AND clientes.identificacion_garantes_1 = '" + parametros.identificacion_garantes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_2))
                {
                    where_to += " AND clientes.identificacion_garantes_2 = '" + parametros.identificacion_garantes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_3))
                {
                    where_to += " AND clientes.identificacion_garantes_3 = '" + parametros.identificacion_garantes_3 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
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
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_1))
                {
                    where_to += " AND clientes.identificacion_clientes_1 = '" + parametros.identificacion_clientes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_2))
                {
                    where_to += " AND clientes.identificacion_clientes_2 = '" + parametros.identificacion_clientes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_3))
                {
                    where_to += " AND clientes.identificacion_clientes_3 = '" + parametros.identificacion_clientes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.identificacion_garantes))
                {
                    where_to += " AND clientes.identificacion_garantes = '" + parametros.identificacion_garantes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_1))
                {
                    where_to += " AND clientes.identificacion_garantes_1 = '" + parametros.identificacion_garantes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_2))
                {
                    where_to += " AND clientes.identificacion_garantes_2 = '" + parametros.identificacion_garantes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_3))
                {
                    where_to += " AND clientes.identificacion_garantes_3 = '" + parametros.identificacion_garantes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
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
                if (!String.IsNullOrEmpty(parametros.comprarado_fomento))
                {
                    where_to += " AND juicios.comprarado_fomento = '" + parametros.comprarado_fomento + "'";
                }
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
            }

            where = where + where_to;


            Datas.dtMatrizRestructuracion dtInforme = new Datas.dtMatrizRestructuracion();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
            daInforme.Fill(dtInforme, "juicios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptMatrizRestructuracion ObjRep = new Reporte.rptMatrizRestructuracion();
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