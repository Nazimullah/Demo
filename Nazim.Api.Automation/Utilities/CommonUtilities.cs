using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nazim.Api.Automation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Nazim.Api.Automation.Utilities
{
    public class CommonUtilities
    {
        public static IList<T> DeserializeJSONResponse<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Nazim
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiUrl"></param>
        /// <returns></returns>
        public static IList<T> GetResponseForVpodAndPcfServices<T>(string apiUrl)
        {
            try
            {
                HttpStatusCode Status = Httpclient.GetRequestApiStatus(apiUrl);

                Assert.AreEqual(HttpStatusCode.OK, Status, "Api Not Responding.");

                IList<T> vpodResponse =
                    CommonUtilities.DeserializeJSONResponse<T>(
                    (Httpclient.GetRequest<T>(apiUrl)).Result);


                return vpodResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Nazim
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static dynamic ParseJsonToObject(string jsonText)
        {
            try
            {
                dynamic jsonObject;
                using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory +
                    @"Data\" + jsonText))
                {
                    jsonObject = JObject.Parse(r.ReadToEnd());
                }
                return jsonObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
