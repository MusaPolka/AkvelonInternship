using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Downloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string destinationFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Files";
            Downloader.Download("https://file-examples.com/storage/fe69f82402626533c98f608/2017/04/file_example_MP4_1920_18MG.mp4", destinationFolder, 10);

            Console.WriteLine();
            Console.WriteLine("Done");
        }
    }

}
