using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ejemplo_INotifyPropertyChanged_Patentes.Servicios
{
    public class ServicioWeb
    {


        #region Metodos

        public string GetDatos(string valor, string tipo)
        {


            string url = " https://www.volanteomaleta.cl/" + tipo + "?term=";
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


            string[] stringSeparators3 = new string[] { "<tr" };
          

            var result3 = result2[0].Split(stringSeparators3, StringSplitOptions.None);


            HtmlDocument doc = new HtmlDocument();

            var chunks = new List<string>();
           
            JObject o = new JObject();
           

            for (int i=1; i< result3.Length; i++)
            {
                doc.LoadHtml("<tr"+result3[i]);

                chunks = new List<string>();
                JArray array = new JArray();

                foreach (var item in doc.DocumentNode.DescendantNodesAndSelf())
                {
                    if (item.NodeType == HtmlNodeType.Text)
                    {
                        if (item.InnerText.Trim() != "")
                        {
                            array.Add(item.InnerText.Trim());
                        }
                    }
                }

                

                o.Add(i.ToString(), array);
               
            }

            string output = JsonConvert.SerializeObject(o.Values());

            return output;


        }


        #endregion

    }
}
