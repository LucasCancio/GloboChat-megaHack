using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace GloboChat.Apresentacao.Aplicativo.Services
{
    public class ServiceBase
    {
        protected const string URI_GloboChatAPI = "http://localhost:44347/api/";
        public string GetData(string uri, string type, List<string[]> Headers = null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Method = "GET";
                request.ContentType = $"application/{type}; charset=utf-8";
                if (Headers != null)
                {
                    foreach (var header in Headers)
                    {
                        request.Headers.Add(header[0], header[1]);
                    }
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }


            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream, System.Text.Encoding.Default))
                {
                    var obj = reader.ReadToEnd();
                    return obj;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string PostData(string uri, string type, string data="", List<string[]> Headers = null)
        {
            var dataResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(data);
                request.Method = "POST";
                request.ContentType = $"application/{type}; charset=utf-8";
                request.Accept = type;

                if (Headers != null)
                {
                    foreach (var header in Headers)
                    {
                        request.Headers.Add(header[0], header[1]);
                    }
                }

                request.ContentLength = requestBytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();

                HttpWebResponse res = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
                data = sr.ReadToEnd();

                sr.Close();
                res.Close();

                byte[] bytes = Encoding.Default.GetBytes(data);
                dataResult = Encoding.UTF8.GetString(bytes);
                return dataResult;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream, System.Text.Encoding.Default))
                {
                    dynamic msg = "";
                    data = reader.ReadToEnd();
                    byte[] bytes = Encoding.Default.GetBytes(data);
                    dataResult = Encoding.UTF8.GetString(bytes);

                    if (type.Contains("json"))
                    {
                        msg = JsonConvert.DeserializeObject(dataResult);
                    }
                    else
                    {
                        StringReader stringReader = new StringReader(dataResult);
                        XmlSerializer serializer = new XmlSerializer(typeof(object));
                        msg = (object)serializer.Deserialize(stringReader);
                    }
                    return "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private string SendInformation(HttpWebRequest request) {
            var dataResult = "";
            var data ="";
            try
            {  
                HttpWebResponse res = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.UTF8);
                data = sr.ReadToEnd();

                sr.Close();
                res.Close();

                byte[] bytes = Encoding.Default.GetBytes(data);
                dataResult = Encoding.UTF8.GetString(bytes);

                return dataResult;
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream, System.Text.Encoding.Default))
                {
                    dynamic msg = "";
                    data = reader.ReadToEnd();
                    byte[] bytes = Encoding.Default.GetBytes(data);
                    dataResult = Encoding.UTF8.GetString(bytes);
                    msg = JsonConvert.DeserializeObject(dataResult);   

                    return "";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
