using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Marvel{
    public class NetworkManager
    {
        public string GetJson(string url)
        {
            try
            {
                return new WebClient().DownloadString(url);
            }
            catch (WebException ex)
            {
                Console.WriteLine("An error occurred while downloading the JSON: " + ex.Message);
                throw;
            }
        }
    }
}