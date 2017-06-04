using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bing_Image.Classes
{
    public static class CheckConnectionInternet
    {

        public static bool CheckForPing()
        {
            try 
            { 

                    Ping myPing = new Ping();
                    String host = "google.com";
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                    return (reply.Status == IPStatus.Success);

            }

            catch (Exception)
            {
                 return false;
            }
        }

        public static bool CheckForNetwork()
        {
            try
            {

                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
