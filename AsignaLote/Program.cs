using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Negocio;
using System.Data;

namespace AsignaLote
{
    class Program
    {
        static void Main(string[] args)
        {
            BuscaJuicios();
        }


        public static void BuscaJuicios()
        {

            string columnas = " id_usuarios";
            string tablas = "usuarios";
            string where = " id_usuarios > 0  ORDER BY id_usuarios  ";

            string columnasJuicios = " id_usuarios, id_juicios ";
            string tablasJuicios = "juicios";


            int _lote = 1;
            int _juicio = 1;

            int _id_usuarios = 0;
            int _id_juicios = 0;
            DataTable dtUsuarios = AccesoLogica.Select(columnas, tablas, where);
            int regReg = dtUsuarios.Rows.Count;
            if (regReg > 0)
            {

                foreach (DataRow renglonSub in dtUsuarios.Rows)
                {
                    _id_usuarios = Convert.ToInt32(renglonSub["id_usuarios"].ToString());
                    _lote = 1;


                    string whereJuicios = " id_usuarios = '" + _id_usuarios + "'  ORDER BY id_juicios  ";

                    DataTable dtJuicios = AccesoLogica.Select(columnasJuicios, tablasJuicios, whereJuicios);

                    int regRegJuicios = dtJuicios.Rows.Count;

                    Console.WriteLine("Total Juicios : " + _juicio);
                    if (regRegJuicios > 0)
                    {

                        foreach (DataRow renglonSubJuicios in dtJuicios.Rows)
                        {


                            _id_juicios = Convert.ToInt32(renglonSubJuicios["id_juicios"].ToString());

                            if (_juicio <= 100 )
                            {

                                AccesoLogica.Update("juicios", "lote_juicios = '" + _lote + "' ", "id_juicios = '" + _id_juicios + "' ");
                                Console.WriteLine("Usuario : " + _id_usuarios);
                                Console.WriteLine("Juicio : " + _juicio + "  Lote : " + _lote  );

                                Console.WriteLine("*****************************");

                                if (_juicio == 100)
                                {
                                    _juicio = 0;
                                    _lote++;
                                }
                            }

                            _juicio++;

                        }

                    }
                }




            }


        }





    }
}
