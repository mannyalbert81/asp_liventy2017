using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
using Negocio;


namespace Presentacion
{
    public partial class contAvocoConocimientoSeleccion : System.Web.UI.Page
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
            string _identificacion_clientes_1 = "";
            string _identificacion_clientes_2 = "";
            string _identificacion_clientes_3 = "";

            string _identificacion_garantes = "";
            string _identificacion_garantes_1 = "";
            string _identificacion_garantes_2 = "";
            string _identificacion_garantes_3 = "";


            string _id_estados_procesales_juicios = "";
            string _id_provincias = "";
            string _id_secretario = "";
            int _id_rol = 0;

            DateTime _fecha_avoco = DateTime.Now;
            DateTime _fecha_avoco_razones = DateTime.Now;
            DateTime _fecha_razon = DateTime.Now;

            string _razon_avoco = "0";

            string where1 = "";
            string where2 = "";
            string where3 = "";
            string where4 = "";
            string where5 = "";
            string where6 = "";
            string where7 = "";
            string where8 = "";

            string where9 = "";
            string where10 = "";
            string where11 = "";
            string where12 = "";
            string where13 = "";
            string where14 = "";
            string where15 = "";
            string where16 = "";

            if (!String.IsNullOrEmpty(Request.QueryString["id_rol"]))
            {
                _id_rol = Convert.ToInt32(Request.QueryString["id_rol"]);


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

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_1"]))
            {
                _identificacion_clientes_1 = Request.QueryString["identificacion_clientes_1"];

                where9 = "  AND clientes.identificacion_clientes_1 = '" + _identificacion_clientes_1 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_2"]))
            {
                _identificacion_clientes_2 = Request.QueryString["identificacion_clientes_2"];

                where10 = "  AND clientes.identificacion_clientes_2 = '" + _identificacion_clientes_2 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_clientes_3"]))
            {
                _identificacion_clientes_3 = Request.QueryString["identificacion_clientes_3"];

                where11 = "  AND clientes.identificacion_clientes_3 = '" + _identificacion_clientes_3 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes"]))
            {
                _identificacion_garantes = Request.QueryString["identificacion_garantes"];

                where12 = "  AND clientes.identificacion_garantes = '" + _identificacion_garantes + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_1"]))
            {
                _identificacion_garantes_1 = Request.QueryString["identificacion_garantes_1"];

                where13 = "  AND clientes.identificacion_garantes_1 = '" + _identificacion_garantes_1 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_2"]))
            {
                _identificacion_garantes_2 = Request.QueryString["identificacion_garantes_2"];

                where14 = "  AND clientes.identificacion_garantes_2 = '" + _identificacion_garantes_2 + "'       ";

            }

            if (!String.IsNullOrEmpty(Request.QueryString["identificacion_garantes_3"]))
            {
                _identificacion_garantes_3 = Request.QueryString["identificacion_garantes_3"];

                where15 = "  AND clientes.identificacion_garantes_3 = '" + _identificacion_garantes_3 + "'       ";

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



            if (!String.IsNullOrEmpty(Request.QueryString["fecha_avoco"]))
            {

                string fecha = Request.QueryString["fecha_avoco"];
                string hora = Request.QueryString["hora_avoco"];

                if (fecha != "0")
                {
                    _fecha_avoco = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_avoco_razones = Convert.ToDateTime(fecha + " " + hora);
                    _fecha_razon = Convert.ToDateTime(fecha);
                }



            }

            if (!String.IsNullOrEmpty(Request.QueryString["razon_avoco"]))
            {


                if (Request.QueryString["razon_avoco"] != "")
                {
                    _razon_avoco = Request.QueryString["razon_avoco"];
                }

            }

            if (!String.IsNullOrEmpty(Request.QueryString["fecha_desde"]))
            {
                string fecha_desde = Request.QueryString["fecha_desde"];
                string fecha_hasta = Request.QueryString["fecha_hasta"];

                where16 += " AND  DATE(juicios.fecha_ultima_providencia) BETWEEN '" + fecha_desde + "' AND '" + fecha_hasta + "'";
            }





            string _nombre_impulsor_anterior = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_impulsor_anterior"]))
            {


                if (Request.QueryString["nombre_impulsor_anterior"] != "")
                {
                    _nombre_impulsor_anterior = Request.QueryString["nombre_impulsor_anterior"];
                }
                else {
                    _nombre_impulsor_anterior = "S/N";
                }

            }


            string _nombre_secretario_anterior = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_secretario_anterior"]))
            {


                if (Request.QueryString["nombre_secretario_anterior"] != "")
                {
                    _nombre_secretario_anterior = Request.QueryString["nombre_secretario_anterior"];
                }
                else {
                    _nombre_secretario_anterior = "S/N";
                }

            }



            string _numero_liquidacion = "";
            if (!String.IsNullOrEmpty(Request.QueryString["numero_liquidacion"]))
            {


                if (Request.QueryString["numero_liquidacion"] != "")
                {
                    _numero_liquidacion = Request.QueryString["numero_liquidacion"];
                }
                else {
                    _numero_liquidacion = "S/N";
                }

            }

            DateTime _fecha_auto_pago = DateTime.Now;
            
            if (!String.IsNullOrEmpty(Request.QueryString["fecha_auto_pago"]))
            {

                string fecha1 = Request.QueryString["fecha_auto_pago"];
               
                if (fecha1 != "0")
                {
                    _fecha_auto_pago = Convert.ToDateTime(fecha1);
                  
                }



            }




            string _nombre_documento = "";
            if (!String.IsNullOrEmpty(Request.QueryString["nombre_archivo_avoco"]))
            {


                if (Request.QueryString["nombre_archivo_avoco"] != "")
                {
                    _nombre_documento = Request.QueryString["nombre_archivo_avoco"];
                }
                else {
                    _nombre_documento = "AVOCO" + "001";
                }

            }

            


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
                              "clientes.sexo_garantes_3,titulo_credito.imagen_qr";
            string tablas = " public.clientes, public.titulo_credito, public.juicios, public.asignacion_secretarios_view, public.estados_procesales_juicios, public.provincias, public.ciudad";
            string where = " clientes.id_clientes = titulo_credito.id_clientes AND clientes.id_provincias = provincias.id_provincias AND titulo_credito.id_titulo_credito = juicios.id_titulo_credito AND asignacion_secretarios_view.id_ciudad = ciudad.id_ciudad AND juicios.id_estados_procesales_juicios = estados_procesales_juicios.id_estados_procesales_juicios AND asignacion_secretarios_view.id_abogado = titulo_credito.id_usuarios ";
            String where_to = "";

            //para pruebas
            //where = where + " AND juicios.id_juicios = 3933";
            //termina pruebas

            where_to = where + where1 + where2 + where3 + where4 + where5 + where6 + where7 + where8 + where9 + where10 + where11 + where12 + where13 + where14 + where15 + where16 + "";


            int _tipo_avoco = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["tipo_avoco"]))
            {
                _tipo_avoco = Convert.ToInt32(Request.QueryString["tipo_avoco"]);
                if (_tipo_avoco > 0)
                {


                    if (_tipo_avoco == 1)
                    {


                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoPago_Total ObjRep = new Reporte.rptProvidenciaAvocoConocimientoPago_Total();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                        ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));




                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

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

                    if (_tipo_avoco == 2)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoProceso_Coactivo ObjRep = new Reporte.rptProvidenciaAvocoConocimientoProceso_Coactivo();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_numero_liquidacion", _numero_liquidacion);
                        ObjRep.SetParameterValue("_fecha_auto_pago", _fecha_auto_pago.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

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

                    if (_tipo_avoco == 3)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoAvoco_Suspension ObjRep = new Reporte.rptProvidenciaAvocoConocimientoAvoco_Suspension();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);
                        ObjRep.SetParameterValue("_fecha_razon", _fecha_razon.ToString("dddd, dd \"de\" MMMM \"de\" yyyy", ci));


                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

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

                    if (_tipo_avoco == 4)
                    {
                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimiento ObjRep = new Reporte.rptProvidenciaAvocoConocimiento();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                        //ObjRep.SetParameterValue("_nombre_impulsor_anterior", _nombre_impulsor_anterior);
                        //ObjRep.SetParameterValue("_nombre_secretario_anterior", _nombre_secretario_anterior);


                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento/");

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

                    if (_tipo_avoco == 5)
                    {


                        Datas.dtProvidenciaSuspension dtInforme = new Datas.dtProvidenciaSuspension();

                        NpgsqlDataAdapter daInforme = new NpgsqlDataAdapter();
                        daInforme = AccesoLogica.Select_reporte(columnas, tablas, where_to);
                        daInforme.Fill(dtInforme, "juicios");
                        int reg = dtInforme.Tables[1].Rows.Count;
                        Reporte.rptProvidenciaAvocoConocimientoleyes ObjRep = new Reporte.rptProvidenciaAvocoConocimientoleyes();


                        ObjRep.SetDataSource(dtInforme.Tables[1]);

                        CultureInfo ci = new CultureInfo("es-EC");

                        ObjRep.SetParameterValue("_fecha_avoco", _fecha_avoco.ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_fecha_avoco_razones", _fecha_avoco_razones.AddMinutes(5).ToString("dddd, dd \"de\" MMMM \"de\" yyyy\", a las\" HH:mm", ci));
                        ObjRep.SetParameterValue("_razon_avoco", _razon_avoco);
                       

                        CrystalReportViewer1.DataBind();

                        ObjRep.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        ObjRep.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        DiskFileDestinationOptions objDiskOpt = new DiskFileDestinationOptions();
                        string pathToFiles = Server.MapPath("~/Documentos/Avoco_Conocimiento");

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



          


        }
    }
}