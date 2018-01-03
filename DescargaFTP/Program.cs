using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using static System.Net.WebRequestMethods;

namespace DescargaFTP
{
    class Program
    {
        static void Main(string[] args)
        {
            Conecta();
        }


        public static  void Conecta()
        {

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://18.221.171.210");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("ftp_liventy", ".Romina.2012");
            FtpWebResponse response = null;

            try
            {
                response = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {

                Console.WriteLine("No se establecio conexion", ex.Message);
            }
            

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();

        }


    }


}
