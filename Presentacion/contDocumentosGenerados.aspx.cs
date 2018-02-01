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
    public partial class contDocumentosGenerados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            string columnas = "";
            string tablas = "";
            string where = "";
            String where_to = "";

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
            try { parametros.id_rol = Convert.ToInt32(Request.QueryString["id_rol"]); } catch (Exception) { parametros.id_rol = 0; }
            try { parametros.id_ciudad = Convert.ToInt32(Request.QueryString["id_ciudad"]); } catch (Exception) { parametros.id_ciudad = 0; }


            parametros.documento = Request.QueryString["documento"];
            parametros.tipo_documento = Request.QueryString["tipo_documento"];
            parametros.firma = Request.QueryString["firma"];


          //// ROL DE CORDINADOR


            if (parametros.id_rol == 23)
            {
                switch (parametros.documento)
                {
                    case "AC":

                        columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial,ep.nombre_estados_procesales_juicios, ac.firmado_secretario, ac.id_avoco_conocimiento AS \"id_documento\" , ac.nombre_documento AS \"nombre_doc\", ac.ruta_documento AS \"ruta_doc\" ,ju.fecha_emision_juicios,ju.fecha_ultima_providencia ,ju.descripcion_estado_procesal, ac.modificado, ac.creado AS \"fecha_creado\" ";
                        where = "1=1 AND ac.eliminado_documento='false'";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "7")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 7";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "12")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 12";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        break;





                    case "OF":

                        columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, of.id_oficios AS \"id_documento\", of.nombre_oficio AS \"nombre_doc\", of.ruta_oficio AS \"ruta_doc\", ju.fecha_emision_juicios, ju.fecha_ultima_providencia, ju.descripcion_estado_procesal, of.modificado, of.firmado_secretario, of.creado AS \"fecha_creado\" ";
                        tablas = " juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN oficios of  ON of.id_juicios = ju.id_juicios";
                        where = "1=1";


                        if (!String.IsNullOrEmpty(parametros.firma))
                        {
                            where_to += " AND of.firmado_secretario='" + parametros.firma + "'";
                        }
                        if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                        {
                            where_to += " AND  DATE(of.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                        }

                        break;



                    case "PR":

                        columnas = " ju.regional, tc.id_titulo_credito, ju.id_juicios, tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, pr.id_providencias AS \"id_documento\", pr.firmado_secretario, pr.nombre_archivo_providencias AS \"nombre_doc\", pr.ruta_providencias AS \"ruta_doc\",ju.fecha_emision_juicios,ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, ju.descripcion_estado_procesal, pr.modificado, ju.fecha_ultima_providencia, pr.creado AS \"fecha_creado\"";
                        where = "1=1 AND pr.eliminado_documento='false'";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PL")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 2";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PS")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 1";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PCP")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 3";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PCPAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 9";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PRES")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 4";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PRESAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 8";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PEMCUBAN")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 5";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PLMCD")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 6";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PLMCF")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 7";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        break;

                }





                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND ju.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND tc.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND cl.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_1))
                {
                    where_to += " AND cl.identificacion_clientes_1 = '" + parametros.identificacion_clientes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_2))
                {
                    where_to += " AND cl.identificacion_clientes_2 = '" + parametros.identificacion_clientes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_3))
                {
                    where_to += " AND cl.identificacion_clientes_3 = '" + parametros.identificacion_clientes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.identificacion_garantes))
                {
                    where_to += " AND cl.identificacion_garantes = '" + parametros.identificacion_garantes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_1))
                {
                    where_to += " AND cl.identificacion_garantes_1 = '" + parametros.identificacion_garantes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_2))
                {
                    where_to += " AND cl.identificacion_garantes_2 = '" + parametros.identificacion_garantes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_3))
                {
                    where_to += " AND cl.identificacion_garantes_3 = '" + parametros.identificacion_garantes_3 + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND ep.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_abogado > 0)
                {
                    where_to += " AND asv.id_abogado=" + parametros.id_abogado + "";
                }
                if (parametros.id_secretario > 0)
                {
                    where_to += " AND asv.id_secretario=" + parametros.id_secretario + "";
                }
                if (parametros.id_ciudad > 0)
                {
                    where_to += " AND asv.id_ciudad=" + parametros.id_ciudad + "";
                }




            }








            ///// ROL DE SECRETARIO

            if (parametros.id_rol == 5)
            {
                switch (parametros.documento)
                {
                    case "AC":

                         columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial,ep.nombre_estados_procesales_juicios, ac.firmado_secretario, ac.id_avoco_conocimiento AS \"id_documento\" , ac.nombre_documento AS \"nombre_doc\", ac.ruta_documento AS \"ruta_doc\" ,ju.fecha_emision_juicios,ju.fecha_ultima_providencia ,ju.descripcion_estado_procesal, ac.modificado, ac.creado AS \"fecha_creado\" ";
                         where= "1=1 AND ac.eliminado_documento='false' AND asv.id_secretario=" + parametros.id_secretario + "";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma+"'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "7") {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 7";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "12")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 12";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        break;





                    case "OF":

                        columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, of.id_oficios AS \"id_documento\", of.nombre_oficio AS \"nombre_doc\", of.ruta_oficio AS \"ruta_doc\", ju.fecha_emision_juicios, ju.fecha_ultima_providencia, ju.descripcion_estado_procesal, of.modificado, of.firmado_secretario, of.creado AS \"fecha_creado\" ";
                        tablas = " juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN oficios of  ON of.id_juicios = ju.id_juicios";
                        where = "1=1 AND asv.id_secretario=" + parametros.id_secretario + "";

                          
                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND of.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(of.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                       
                      break;



                    case "PR":

                        columnas = " ju.regional, tc.id_titulo_credito, ju.id_juicios, tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, pr.id_providencias AS \"id_documento\", pr.firmado_secretario, pr.nombre_archivo_providencias AS \"nombre_doc\", pr.ruta_providencias AS \"ruta_doc\",ju.fecha_emision_juicios,ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, ju.descripcion_estado_procesal, pr.modificado, ju.fecha_ultima_providencia, pr.creado AS \"fecha_creado\"";
                        where = "1=1 AND pr.eliminado_documento='false' AND asv.id_secretario='" + parametros.id_secretario + "'";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PL")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 2";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PS")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 1";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PCP")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 3";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PCPAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 9";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PRES")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 4";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PRESAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 8";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PEMCUBAN")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 5";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PLMCD")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 6";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PLMCF")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 7";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        break;

                }




              
                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND ju.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND tc.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND cl.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_1))
                {
                    where_to += " AND cl.identificacion_clientes_1 = '" + parametros.identificacion_clientes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_2))
                {
                    where_to += " AND cl.identificacion_clientes_2 = '" + parametros.identificacion_clientes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_3))
                {
                    where_to += " AND cl.identificacion_clientes_3 = '" + parametros.identificacion_clientes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.identificacion_garantes))
                {
                    where_to += " AND cl.identificacion_garantes = '" + parametros.identificacion_garantes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_1))
                {
                    where_to += " AND cl.identificacion_garantes_1 = '" + parametros.identificacion_garantes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_2))
                {
                    where_to += " AND cl.identificacion_garantes_2 = '" + parametros.identificacion_garantes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_3))
                {
                    where_to += " AND cl.identificacion_garantes_3 = '" + parametros.identificacion_garantes_3 + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND ep.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
                if (parametros.id_abogado > 0)
                {
                    where_to += " AND asv.id_abogado=" + parametros.id_abogado + "";
                }
               
                if (parametros.id_provincias > 0)
                {
                    where_to += " AND pv.id_provincias=" + parametros.id_provincias + "";
                }


            }






            ///// ROL DE IMPULSOR


            if (parametros.id_rol == 3)
            {
                switch (parametros.documento)
                {
                    case "AC":

                        columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial,ep.nombre_estados_procesales_juicios, ac.firmado_secretario, ac.id_avoco_conocimiento AS \"id_documento\" , ac.nombre_documento AS \"nombre_doc\", ac.ruta_documento AS \"ruta_doc\" ,ju.fecha_emision_juicios,ju.fecha_ultima_providencia ,ju.descripcion_estado_procesal, ac.modificado, ac.creado AS \"fecha_creado\" ";
                        where = "1=1 AND ac.eliminado_documento='false' AND asv.id_abogado=" + parametros.id_abogado + "";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "7")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 7";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "12")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN avoco_conocimiento ac  ON ac.id_juicios = ju.id_juicios AND ac.tipo_avoco = 12";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND ac.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(ac.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        break;





                    case "OF":

                        columnas = "ju.regional,tc.id_titulo_credito,ju.id_juicios,tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, of.id_oficios AS \"id_documento\", of.nombre_oficio AS \"nombre_doc\", of.ruta_oficio AS \"ruta_doc\", ju.fecha_emision_juicios, ju.fecha_ultima_providencia, ju.descripcion_estado_procesal, of.modificado, of.firmado_secretario, of.creado AS \"fecha_creado\" ";
                        tablas = " juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = ju.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN oficios of  ON of.id_juicios = ju.id_juicios";
                        where = "1=1 AND asv.id_abogado=" + parametros.id_abogado + "";


                        if (!String.IsNullOrEmpty(parametros.firma))
                        {
                            where_to += " AND of.firmado_secretario='" + parametros.firma + "'";
                        }
                        if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                        {
                            where_to += " AND  DATE(of.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                        }

                        break;



                    case "PR":

                        columnas = " ju.regional, tc.id_titulo_credito, ju.id_juicios, tc.numero_titulo_credito, ju.numero_juicios, cl.identificacion_clientes, cl.nombres_clientes, asv.id_abogado, asv.impulsores, asv.id_secretario, asv.secretarios, pr.id_providencias AS \"id_documento\", pr.firmado_secretario, pr.nombre_archivo_providencias AS \"nombre_doc\", pr.ruta_providencias AS \"ruta_doc\",ju.fecha_emision_juicios,ju.cuantia_inicial, ep.nombre_estados_procesales_juicios, ju.descripcion_estado_procesal, pr.modificado, ju.fecha_ultima_providencia, pr.creado AS \"fecha_creado\"";
                        where = "1=1 AND pr.eliminado_documento='false' AND asv.id_abogado=" + parametros.id_abogado + "";

                        if (parametros.tipo_documento == "ALL")
                        {
                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  ";

                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PL")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 2";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PS")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 1";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        else if (parametros.tipo_documento == "PCP")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 3";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PCPAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 9";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PRES")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 4";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PRESAVOC")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 8";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PEMCUBAN")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 5";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }

                        else if (parametros.tipo_documento == "PLMCD")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 6";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }


                        else if (parametros.tipo_documento == "PLMCF")
                        {

                            tablas = "juicios ju INNER JOIN  titulo_credito tc ON tc.id_titulo_credito = ju.id_titulo_credito INNER JOIN clientes cl ON cl.id_clientes = tc.id_clientes INNER JOIN provincias pv ON pv.id_provincias = cl.id_provincias INNER JOIN estados_procesales_juicios ep ON ep.id_estados_procesales_juicios = ju.id_estados_procesales_juicios INNER JOIN asignacion_secretarios_view asv ON asv.id_abogado = tc.id_usuarios INNER JOIN providencias pr  ON pr.id_juicios = ju.id_juicios INNER JOIN tipo_providencias tpr ON tpr.id_tipo_providencias = pr.id_tipo_providencias  AND pr.id_tipo_providencias = 7";


                            if (!String.IsNullOrEmpty(parametros.firma))
                            {
                                where_to += " AND pr.firmado_secretario='" + parametros.firma + "'";
                            }
                            if (!String.IsNullOrEmpty(parametros.fecha_desde) && !String.IsNullOrEmpty(parametros.fecha_hasta))
                            {
                                where_to += " AND  DATE(pr.creado) BETWEEN '" + parametros.fecha_desde + "' AND '" + parametros.fecha_hasta + "'";
                            }
                        }
                        break;

                }





                if (!String.IsNullOrEmpty(parametros.juicio_referido_titulo_credito))
                {
                    where_to += " AND ju.juicio_referido_titulo_credito = '" + parametros.juicio_referido_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.numero_titulo_credito))
                {
                    where_to += " AND tc.numero_titulo_credito = '" + parametros.numero_titulo_credito + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes))
                {
                    where_to += " AND cl.identificacion_clientes = '" + parametros.identificacion_clientes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_1))
                {
                    where_to += " AND cl.identificacion_clientes_1 = '" + parametros.identificacion_clientes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_2))
                {
                    where_to += " AND cl.identificacion_clientes_2 = '" + parametros.identificacion_clientes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_clientes_3))
                {
                    where_to += " AND cl.identificacion_clientes_3 = '" + parametros.identificacion_clientes_3 + "'";
                }

                if (!String.IsNullOrEmpty(parametros.identificacion_garantes))
                {
                    where_to += " AND cl.identificacion_garantes = '" + parametros.identificacion_garantes + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_1))
                {
                    where_to += " AND cl.identificacion_garantes_1 = '" + parametros.identificacion_garantes_1 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_2))
                {
                    where_to += " AND cl.identificacion_garantes_2 = '" + parametros.identificacion_garantes_2 + "'";
                }
                if (!String.IsNullOrEmpty(parametros.identificacion_garantes_3))
                {
                    where_to += " AND cl.identificacion_garantes_3 = '" + parametros.identificacion_garantes_3 + "'";
                }

                if (parametros.id_estados_procesales_juicios > 0)
                {
                    where_to += " AND ep.id_estados_procesales_juicios=" + parametros.id_estados_procesales_juicios + "";
                }
               

                if (parametros.id_provincias > 0)
                {
                    where_to += " AND pv.id_provincias=" + parametros.id_provincias + "";
                }

            }



            

            where = where + where_to;
           

            Datas.dtDocumentosGenerados dtInforme = new Datas.dtDocumentosGenerados();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where);
            daInforme.Fill(dtInforme, "juicios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptDocumentosGenerado ObjRep = new Reporte.rptDocumentosGenerado();
            ObjRep.SetDataSource(dtInforme.Tables[1]);
            CrystalReportViewer1.ReportSource = ObjRep;
            CrystalReportViewer1.DataBind();


        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }
    }
}