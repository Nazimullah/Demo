using System.Net.Http;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace Nazim.Api.Automation
{
        public static class Httpclient
        {
            #region Constants

            // Header attributes
            private const string CONTENT_TYPE = "application/json";

            #endregion

            #region Get

            /// <summary>
            /// Get request
            /// </summary>
            /// <param name="webURL">URl for Get request</param>
            /// <returns>Response for Get request</returns>
            public static string GetRequest(string webURL)
            {
                HttpClient client = new HttpClient();
                return client.GetAsync(webURL).Result.Content.ReadAsStringAsync().Result;
            }

        /// <summary>
        /// StatusCode for Get request
        /// </summary>
        /// <param name="webURL">URl for Get request</param>
        /// <returns>HttpStatusCode for Get request URL</returns>
        public static HttpStatusCode GetRequestStatus(string webURL)
            {
                HttpClient client = new HttpClient();
                return client.GetAsync(webURL).Result.StatusCode;
            }

            #endregion

            #region Post

            /// <summary>
            /// POST Web Request
            /// </summary>
            /// <param name="webURL">Web URL/URI for Request</param>        
            /// <param name="requestParameter">Request Parameters</param>
            /// <param name="contentType">Can be XML/Json</param>
            /// <returns>Response for requested URL</returns>
            public static string PostRequest(string webURL, string requestParameter, string contentType = CONTENT_TYPE)
            {
                HttpClient client = new HttpClient();
                return client.PostAsync(webURL, new StringContent(requestParameter, Encoding.UTF8, contentType)).Result.Content.ReadAsStringAsync().Result;
            }

        public static HttpStatusCode GetRequestApiStatus(string apiUrl)
        {
            HttpClient client = new HttpClient();
            return client.GetAsync(apiUrl).Result.StatusCode;
        }
        /// <summary>
        /// POST Web Request
        /// </summary>
        /// <param name="webURL">Web URL/URI for Request</param>        
        /// <param name="requestParameter">Request Parameters</param>
        /// <param name="contentType">Can be XML/Json</param>
        /// <returns>Response for requested URL</returns>
        public static HttpResponseMessage PostRequest_RawResponse(string webURL, string requestParameter, string contentType = CONTENT_TYPE)
            {
                HttpClient client = new HttpClient();
                return client.PostAsync(webURL, new StringContent(requestParameter, Encoding.UTF8, contentType)).Result;
            }

            /// <summary>
            /// POST Web Request
            /// </summary>
            /// <param name="webURL">Web URL/URI for Request</param>
            /// <param name="requestParameter">Request Parameters</param>
            /// <param name="contentType">Can be XML/Json</param>
            /// <returns>HttpStatusCode for requested URL</returns>
            public static HttpStatusCode PostRequestStatus(string webURL, string requestParameter, string contentType = CONTENT_TYPE)
            {
                HttpClient client = new HttpClient();
                return client.PostAsync(webURL, new StringContent(requestParameter, Encoding.UTF8, contentType)).Result.StatusCode;
            }

            #endregion

            #region Delete

            /// <summary>
            /// Delete request
            /// </summary>
            /// <param name="webURL">URl for Delete request</param>
            /// <returns>Response for requested URL</returns>
            public static string DeleteRequest(string webURL)
            {
                HttpClient client = new HttpClient();
                return client.DeleteAsync(webURL).Result.Content.ReadAsStringAsync().Result;
            }

            /// <summary>
            /// StatusCode for Delete request
            /// </summary>
            /// <param name="webURL">URl for Delete request</param>
            /// <returns>HttpStatusCode for requested URL</returns>
            public static HttpStatusCode DeleteRequestStatus(string webURL)
            {
                HttpClient client = new HttpClient();
                return client.DeleteAsync(webURL).Result.StatusCode;
            }

            #endregion

            #region Put

            /// <summary>
            /// Put Web Request
            /// </summary>
            /// <param name="webURL">Web URL/URI for Request</param>        
            /// <param name="requestParameter">Request Parameters</param>
            /// <param name="contentType">Can be XML/Json</param>
            /// <returns>Response for requested URL</returns>
            public static string PutRequest(string webURL, string requestParameter, string contentType = CONTENT_TYPE)
            {
                HttpClient client = new HttpClient();
                return client.PutAsync(webURL, new StringContent(requestParameter, Encoding.UTF8, contentType)).Result.Content.ReadAsStringAsync().Result;
            }

            /// <summary>
            /// Put Web Request
            /// </summary>
            /// <param name="webURL">Web URL/URI for Request</param>        
            /// <param name="requestParameter">Request Parameters</param>
            /// <param name="contentType">Can be XML/Json</param>
            /// <returns>HttpStatusCode for requested URL</returns>
            public static HttpStatusCode PutRequestStatus(string webURL, string requestParameter, string contentType = CONTENT_TYPE)
            {
                HttpClient client = new HttpClient();
                return client.PutAsync(webURL, new StringContent(requestParameter, Encoding.UTF8, contentType)).Result.StatusCode;
            }

        public async static Task<string> GetRequest<T>(string apiAddress,
            IDictionary<string, string> parametersToAddInHTTPHeader = null,
             string contentType = "application/json",
             string applicationID = "ASQ")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                client.DefaultRequestHeaders.Add("applicationid", applicationID);

                if (parametersToAddInHTTPHeader != null)
                    parametersToAddInHTTPHeader.ToList().ForEach(x => { client.DefaultRequestHeaders.Add(x.Key, x.Value); });

                HttpResponseMessage response = client.GetAsync(apiAddress).Result;  // Blocking call!  
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public async static Task<string> GetRequest<T>(string apiAddress,
            string userName, string password, IDictionary<string, string> parametersToAddInHTTPHeader = null,
             string contentType = "application/json", string applicationID = "ASQ")
        {
            using (var client = new HttpClient())
            {

                var byteArray = Encoding.ASCII.GetBytes(userName + ":" + password);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
                client.DefaultRequestHeaders.Add("applicationid", applicationID);

                if (parametersToAddInHTTPHeader != null)
                    parametersToAddInHTTPHeader.ToList().ForEach(x => { client.DefaultRequestHeaders.Add(x.Key, x.Value); });

                HttpResponseMessage response = client.GetAsync(apiAddress).Result;  // Blocking call!  
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        #endregion

    }
    }
