using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace CodeReviewNotifier.Helper
{
    public class RequestHelper
    {
        public static string GetRequest(string url, string basicAuth = "")
        {
            string reponseAsString = "";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                if (!String.IsNullOrWhiteSpace(basicAuth))
                {
                    request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + basicAuth);
                }

                var response = (HttpWebResponse)request.GetResponse();
                reponseAsString = ConvertResponseToString(response);
            }
            catch (Exception ex)
            {
                reponseAsString += "ERROR: " + ex.Message;
            }

            return reponseAsString;
        }

        public static string PostRequest()
        {
            //Wa pa
            return "";
        }

        public static string ConvertResponseToString(HttpWebResponse response)
        {
            string result = "";
            result += new StreamReader(response.GetResponseStream()).ReadToEnd();
            return result;
        }
    }
}
