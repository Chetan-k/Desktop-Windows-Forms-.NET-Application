using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTUtil
{

    public class REST
    {
        private string baseUri;
        public REST(string bU)
        {
            this.baseUri = bU;
        }

        #region getRESTData
        //our method for retriving REST data... (json)
        public string getJSON(string url)
        {
            //now moved the baseUri to an instance variable of the class
            //string baseUri = "http://ist.rit.edu/api";
            //connect to the api
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri + url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                WebResponse err = ex.Response;
                using (Stream responseStream = err.GetResponseStream())
                {
                    StreamReader r = new StreamReader(responseStream, Encoding.UTF8);
                    string errorText = r.ReadToEnd();
                    //log the error...
                }
                throw;
            }


        }
        #endregion

        //What if we wanted to have an XML call as well?
        public string GETXML(string uri)
        {
            //not written...
            return "";
        }

    }

}
