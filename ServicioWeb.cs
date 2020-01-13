using System;
using System.IO;
using System.Net;
using System.Text;


namespace Ejemplo_INotifyPropertyChanged_Patentes
{
    public class ServicioWeb
    {
        public string  GetDatos(string valor,string tipo)
        {
           

            string url = " https://www.volanteomaleta.cl/"+tipo+"?term=";
            url = url + valor;

            HttpWebRequest webresult = (HttpWebRequest)WebRequest.Create(url);

            webresult.ContentType = "application/x-www-form-urlencoded";
            webresult.Method = "GET";

            Encoding encode = Encoding.GetEncoding("utf-8");
            HttpWebResponse webres = (HttpWebResponse)webresult.GetResponse();
            Stream reader = webres.GetResponseStream();
            StreamReader sreader = new StreamReader(reader, encode, true);


            string result = sreader.ReadToEnd();


            string[] stringSeparators = new string[] { "<tbody>" };
            string[] stringSeparators2 = new string[] { "</tbody>" };
            var result2 = result.Split(stringSeparators, StringSplitOptions.None);
            result2 = result2[1].Split(stringSeparators2, StringSplitOptions.None);

            return result2[0];
            

        }

    }
}
