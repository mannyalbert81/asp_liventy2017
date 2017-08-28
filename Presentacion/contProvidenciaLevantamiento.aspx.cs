using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Negocio;
using Npgsql;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class contProvidenciaLevantamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument crystalReport = new ReportDocument();
            DataTable dt_Reporte1 = new DataTable();
            ParametrosRpt parametros = new ParametrosRpt();

            string _id_juicios = "";
            string _id_abogado = "";
            string _juicio_referido_titulo_credito = "";
            string _numero_titulo_credito = "";
            string _identificacion_clientes = "";
            string _id_estados_procesales_juicios = "";
            string _id_provincias = "";
            string _id_secretario = "";
            int _id_rol = 0;

            DateTime _fecha_avoco = DateTime.Now;
            DateTime _fecha_avoco_razones = DateTime.Now;

            string _razon_avoco = "0";

            string where1 = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            string where5 = "";
            string where6 = "";
            string where7 = "";
            string where8 = "";

            String where_to = "";

            parametros.juicio_referido_titulo_credito = Request.QueryString["juicio_referido_titulo_credito"];
            parametros.numero_titulo_credito = Request.QueryString["numero_titulo_credito"];
            parametros.identificacion_clientes = Request.QueryString["identificacion_clientes"];

            try { parametros.id_provincias = Convert.ToInt32(Request.QueryString["id_provincias"]); } catch (Exception) { parametros.id_provincias = 0; }
            try { parametros.id_abogado = Convert.ToInt32(Request.QueryString["id_abogado"]); } catch (Exception) { parametros.id_abogado = 0; }
            try { parametros.id_estados_procesales_juicios = Convert.ToInt32(Request.QueryString["id_estados_procesales_juicios"]); } catch (Exception) { parametros.id_estados_procesales_juicios = 0; }
            try { parametros.id_secretario = Convert.ToInt32(Request.QueryString["id_secretario"]); } catch (Exception) { parametros.id_secretario = 0; }
            try { parametros.id_ciudad = Convert.ToInt32(Request.QueryString["id_ciudad"]); } catch (Exception) { parametros.id_ciudad = 0; }
            try { parametros.id_rol = Convert.ToInt32(Request.QueryString["id_rol"]); } catch (Exception) { parametros.id_rol = 0; }

            string columnas = "juicios.id_juicios, juicios.juicio_referido_titulo_credito, clientes.identificacion_clientes, " +
                             "clientes.nombres_clientes, clientes.identificacion_garantes, clientes.nombre_garantes, " +
                             "provincias.nombre_provincias, titulo_credito.numero_titulo_credito, juicios.fecha_emision_juicios, " +
                             "juicios.cuantia_inicial, juicios.fecha_ultima_providencia, asignacion_secretarios_view.id_abogado, " +
                             "asignacion_secretarios_view.impulsores, asignacion_secretarios_view.id_secretario, " +
                             "asignacion_secretarios_view.secretarios, ciudad.id_ciudad, ciudad.nombre_ciudad , " +
                             "juicios.numero_juicios, asignacion_secretarios_view.cargo_secretarios, " +
                             "asignacion_secretarios_view.cargo_impulsores, asignacion_secretarios_view.sexo_secretarios, " +
                             "asignacion_secretarios_view.sexo_impulsores , clientes.identificacion_clientes_1, " +
                             " clientes.nombre_clientes_1, clientes.identificacion_clientes_2, nombre_clientes_2, " +
                             "identificacion_clientes_3, clientes.nombre_clientes_3, identificacion_garantes_1, " +
                             "nombre_garantes_1, clientes.identificacion_garantes_2, nombre_garantes_2, " +
                             "identificacion_garantes_3, clientes.nombre_garantes_3, correo_clientes, correo_clientes_1, " +
                             "correo_clientes_2, clientes.correo_clientes_3, clientes.direccion_clientes_1, " +
                             "clientes.direccion_clientes_2, clientes.direccion_clientes_3, clientes.cantidad_clientes, " +
                             "clientes.cantidad_garantes,clientes.sexo_clientes, clientes.sexo_clientes_1,clientes.sexo_clientes_3," +
                             "clientes.sexo_clientes_2,clientes.sexo_garantes, clientes.sexo_garantes_1,clientes.sexo_garantes_2," +
                             "clientes.sexo_garantes_3";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios ";


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
            

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_avoco"]))
            {

                string fecha = Request.QueryString["fecha_avoco"];
                string hora = Request.QueryString["hora_avoco"];

                if (fecha != "0")
                {
                    _fecha_avoco = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_avoco_razones = Convert.ToDateTime(fecha + " " + hora);
                }



            }

            if (!String.IsNullOrEmpty(Request.QueryString["razon_avoco"]))
            {


                if (Request.QueryString["razon_avoco"] != "0")
                {
                    _razon_avoco = Request.QueryString["razon_avoco"];
                }

            }
            
           
            //para pruebas
            where = where + " AND juicios.id_juicios = 22310";
            //termina pruebas

            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8;

            string _nombre_documento = "PL" + _id_juicios + _id_abogado + _juicio_referido_titulo_credito + _numero_titulo_credito + _identificacion_clientes + _id_estados_procesales_juicios;
            //where = where + where_to;

            //para el citador

            string columnascit = " u.id_usuarios,u.nombre_usuarios,r.id_rol,u.cargo_usuarios,u.sexo";
            string tablascit = " public.usuarios u INNER JOIN public.rol r ON u.id_rol = r.id_rol";
            string wherecit = " r.id_rol = 22";
            string nombrecitador = "";
            string leyendaCitador = "";
            string cargoCitador = "";
            string dirigidoA = "";
            

            DataTable dt_cit = new DataTable();

            try
            {
                dt_cit = AccesoLogica.Select(columnascit, tablascit, wherecit);
                nombrecitador = dt_cit.Rows[0][1].ToString();
                cargoCitador = dt_cit.Rows[0][3].ToString();

                if(dt_cit.Rows[0][4].ToString()=="M")
                {
                    leyendaCitador = " a el " + cargoCitador;
                }
                else if (dt_cit.Rows[0][4].ToString() == "F")
                {
                    leyendaCitador = " a la " + cargoCitador;
                }else
                {
                    leyendaCitador = " a el " + cargoCitador;
                }

            }
            catch (Exception )
            {
                nombrecitador = "";
            }
            
            Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

            NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
            daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
            daInforme.Fill(dtInforme, "juicios");
            int reg = dtInforme.Tables[1].Rows.Count;
            Reporte.rptProvidenciaLevantamiento ObjRep = new Reporte.rptProvidenciaLevantamiento();


            ObjRep.SetDataSource(dtInforme.Tables[1]);

            CultureInfo ci = new CultureInfo("es-EC");

            ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("f", ci));
            ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(20).ToString("f", ci));
            ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
            ObjRep.SetParameterValue("_citador", nombrecitador);
            ObjRep.SetParameterValue("_leyendaCitador", leyendaCitador); 
            ObjRep.SetParameterValue("_dirigido", dirigidoA);


            CrystalReportViewer1.DataBind();

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
    }
}