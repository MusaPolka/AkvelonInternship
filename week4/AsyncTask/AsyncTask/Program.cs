using System;
using System.Threading.Tasks;

namespace AsyncTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Downloader downloader = new Downloader();
            await downloader.Download("https://file-examples.com/storage/fe1170c1cf625dc95987de5/2017/10/file_example_PNG_500kB.png", @"E:\downloads\1.png");
        }
    }
}
