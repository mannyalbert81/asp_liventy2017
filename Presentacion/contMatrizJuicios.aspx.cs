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
    public partial class contMatrizJuicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            //var dsBalanceComprobacionDetallado = new Datas.dsBalanceComprobacionDetallado();

            
            parametros.juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];
            parametros.numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
            
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

            try { parametros.id_origen_juicio = Convert.ToInt32(Request.QueryString["id_origen_juicio"]); } catch (Exception) { parametros.id_origen_juicio = 0; }
            parametros.tipo_reporte = Request.QueryString["tipo_reporte"];
            parametros.numero_carton_jucios = Request.QueryString["numero_carton_jucios"];

            string columnas = "juicios.orden, juicios.regional, juicios.juicio_referido_titulo_credito, juicios.year_juicios, clientes.id_clientes, clientes.identificacion_clientes, clientes.nombres_clientes, clientes.nombre_garantes, provincias.id_provincias, provincias.nombre_provincias, titulo_credito.id_titulo_credito, titulo_credito.numero_titulo_credito, juicios.fecha_emision_juicios, juicios.cuantia_inicial, juicios.riesgo_actual, estados_procesales_juicios.id_estados_procesales_juicios, estados_procesales_juicios.nombre_estados_procesales_juicios, juicios.descripcion_estado_procesal, juicios.fecha_ultima_providencia, juicios.estrategia_seguir, juicios.observaciones, juicios.tipo_leyes, juicios.medida_cautelar, juicios.embargo_bienes, juicios.detalle_embargo_bienes, juicios.observacion, juicios.forma_pago, juicios.recuperacion_cobro_honorario_secretario, juicios.honorario_abogado_impulsor, juicios.honorario_depositario_judicial, juicios.honorario_perito_evaluador, juicios.gastos_movilizacion_alimentacion_perito, juicios.intereses_mora, juicios.gastos_procesales, juicios.capital, juicios.recuperacion_via_coactiva, juicios.intereses_normales, asignacion_secretarios_view.id_abogado, asignacion_secretarios_view.impulsores, asignacion_secretarios_view.id_secretario, asignacion_secretarios_view.secretarios, ciudad.id_ciudad, ciudad.nombre_ciudad, juicios.comprarado_fomento, juicios.id_origen_juicio, origen_juicio.nombre_origen_juicio, carton_juicuis.numero_carton_jucios";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad, public.origen_juicio, public.carton_juicuis";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios AND juicios.id_origen_juicio= origen_juicio.id_origen_juicio AND juicios.id_carton_juicios=carton_juicuis.id_carton_juicios";
            //string order_by = "juicios.numero_juicios";

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
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
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
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
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
               
                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
                }
            }

            if (parametros.tipo_reporte == "inventario_juicios")
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

                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
                }

                where = where + where_to;
                //para pruebas
                //try { where += " AND clientes.identificacion_clientes LIKE '" + Request.QueryString["p"].ToString()+"%'" ; } catch (Exception) { parametros.id_provincias = 0; }

                //termina pruebas

                Datas.dtProvidenciaSuspension2 dtInforme = new Datas.dtProvidenciaSuspension2();

                NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
                daInforme.Fill(dtInforme, "juicios");
                int reg = dtInforme.Tables[1].Rows.Count;
                Reporte.rptMatrizJuicios ObjRep = new Reporte.rptMatrizJuicios();
                ObjRep.SetDataSource(dtInforme.Tables[1]);
                //if (_where.ToString().Length > 0)
                CrystalReportViewer1.ReportSource = ObjRep;
                CrystalReportViewer1.DataBind();
            }

            if (parametros.tipo_reporte == "recuperacion_cartera")
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

                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
                }

                where = where + where_to;
                //para pruebas
                //try { where += " AND clientes.identificacion_clientes LIKE '" + Request.QueryString["p"].ToString()+"%'" ; } catch (Exception) { parametros.id_provincias = 0; }

                //termina pruebas

                Datas.dtProvidenciaSuspension2 dtInforme = new Datas.dtProvidenciaSuspension2();

                NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
                daInforme.Fill(dtInforme, "juicios");
                int reg = dtInforme.Tables[1].Rows.Count;
                Reporte.rptRecuperacionCartera ObjRep = new Reporte.rptRecuperacionCartera();
                ObjRep.SetDataSource(dtInforme.Tables[1]);
                //if (_where.ToString().Length > 0)
                CrystalReportViewer1.ReportSource = ObjRep;
                CrystalReportViewer1.DataBind();
            }
            if (parametros.tipo_reporte == "juicios_cancelados_archivados")
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

                if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                {
                    where_to += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND estados_procesales_juicios.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_origen_juicio > 0)
                {
                    where_to += " AND juicios.id_origen_juicio=" + parametros.id_origen_juicio + "";
                }
                if (!String.IsNullOrEmpty(parametros.numero_carton_jucios))
                {
                    where_to += " AND carton_juicuis.numero_carton_jucios like '" + parametros.numero_carton_jucios + "'";
                }

                where = where + where_to;
                //para pruebas
                //try { where += " AND clientes.identificacion_clientes LIKE '" + Request.QueryString["p"].ToString()+"%'" ; } catch (Exception) { parametros.id_provincias = 0; }

                //termina pruebas

                Datas.dtProvidenciaSuspension2 dtInforme = new Datas.dtProvidenciaSuspension2();

                NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
                daInforme.Fill(dtInforme, "juicios");
                int reg = dtInforme.Tables[1].Rows.Count;
                Reporte.rptJuiciosCanceladosArchivados ObjRep = new Reporte.rptJuiciosCanceladosArchivados();
                ObjRep.SetDataSource(dtInforme.Tables[1]);
                //if (_where.ToString().Length > 0)
                CrystalReportViewer1.ReportSource = ObjRep;
                CrystalReportViewer1.DataBind();
            }







        }



        protected void CrystalReportViewer1_Init1(object sender, EventArgs e)
        {

        }
    }
}