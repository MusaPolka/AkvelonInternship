using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace DownloaderTask
{
    internal class Program
    {
        
        static void Main(string[] args)
        {


            var client = new WebClient();
            var responseString = client.DownloadString("https://jsonplaceholder.typicode.com/photos");


            //Console.WriteLine(responseString);
        }
    }
}
