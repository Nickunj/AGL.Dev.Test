using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Web.Configuration;
using System.IO;

namespace AGL.DevTest.JSONWebserviceConsumer.Helper
{
    /// <summary>
    /// Webservice helper class
    /// </summary>
    public class ServiceHelper
    {

        /// <summary>
        /// This method takes web serbvice method name as a parameter and returns deserialised JSON object of type T
        /// </summary>
        /// <typeparam name="T">Generic object of type T</typeparam>
        /// <param name="webServiceMethod"> web service method name</param>
        /// <returns>Deserialised JSON object of type T</returns>
        public static T GetSerializedJsonDataFromWebService<T>(string webServiceMethod) where T : new()
        {
            //Get Webservice BaseUrl from config file and concat it with web service method name 
            var baseUrl = WebConfigurationManager.AppSettings["WebServiceURL"];
            var sourceUrl = Path.Combine(baseUrl, webServiceMethod);
                
            using (var webClient = new WebClient())
            {
                var jsonData = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    jsonData = webClient.DownloadString(sourceUrl);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
            }
        }
    }
}