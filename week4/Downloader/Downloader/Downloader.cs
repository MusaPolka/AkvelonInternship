using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Downloader
{
    public class Chunk
    {
        public long Start { get; set; }
        public long End { get; set; }
    }
    public static class Downloader
    {
        public static void Download(String fileUrl, String destinationFolderPath, int numberOfParallelDownloads = 0)
        {

            Uri uri = new Uri(fileUrl);

            string destinationFilePath = Path.Combine(destinationFolderPath, uri.Segments.Last());

            if (numberOfParallelDownloads <= 0)
            {
                numberOfParallelDownloads = Environment.ProcessorCount;
            }

            long fileSize = GetFileSize(fileUrl);

            if (File.Exists(destinationFilePath))
            {
                File.Delete(destinationFilePath);
            }

            Progress<double> progress = new Progress<double>();
            progress.ProgressChanged += Progress_ProgressChanged;

            using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Append))
            {
                ConcurrentDictionary<int, String> tempFilesDictionary = new ConcurrentDictionary<int, String>();

                List<Chunk> Chunks = CalculateChunks(numberOfParallelDownloads, fileSize);

                DateTime startTime = DateTime.Now;

                ParallelDownload(numberOfParallelDownloads, Chunks, fileUrl, tempFilesDictionary, progress);
  
                MergeFiles(tempFilesDictionary, destinationStream);
            }

            
        }

        private static void Progress_ProgressChanged(object sender, double e)
        {
            for (int i = 0; i < e; i++)
            {
                Console.Write("|");
            }
        }

        public static long GetFileSize(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "HEAD";
            long responseLength;
            using (WebResponse webResponse = webRequest.GetResponse())
            {
                responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));
            }

            return responseLength;
        }

        static List<Chunk> CalculateChunks(int numberOfParallelDownloads, long fileSize)
        {
            List<Chunk> Chunks = new List<Chunk>();
            for (int chunk = 0; chunk < numberOfParallelDownloads - 1; chunk++)
            {
                var chunks = new Chunk()
                {
                    Start = chunk * (fileSize / numberOfParallelDownloads),
                    End = ((chunk + 1) * (fileSize / numberOfParallelDownloads)) - 1
                };
                Chunks.Add(chunks);
            }

            Chunks.Add(new Chunk()
            {
                Start = Chunks.Any() ? Chunks.Last().End + 1 : 0,
                End = fileSize - 1
            });

            return Chunks;
        }

        static void ParallelDownload(int numberOfParallelDownloads, List<Chunk> Chunks, string fileUrl,
            ConcurrentDictionary<int, String> tempFilesDictionary, IProgress<double> progress)
        {
            int index = 0;
            Parallel.ForEach(Chunks, new ParallelOptions() { MaxDegreeOfParallelism = numberOfParallelDownloads }, chunk =>
            {
                HttpWebRequest httpWebRequest = HttpWebRequest.Create(fileUrl) as HttpWebRequest;
                httpWebRequest.Method = "GET";
                httpWebRequest.AddRange(chunk.Start, chunk.End);
                using (HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    String tempFilePath = Path.GetTempFileName();
                    using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.Write))
                    {
                        httpWebResponse.GetResponseStream().CopyTo(fileStream);
                        tempFilesDictionary.TryAdd((int)index, tempFilePath);
                    }
                }

                progress.Report(100 / numberOfParallelDownloads);
                
                index++;
            });
        }

        static void MergeFiles(ConcurrentDictionary<int, String> tempFilesDictionary,
            FileStream destinationStream)
        {
            foreach (var tempFile in tempFilesDictionary.OrderBy(b => b.Key))
            {
                byte[] tempFileBytes = File.ReadAllBytes(tempFile.Value);
                destinationStream.Write(tempFileBytes, 0, tempFileBytes.Length);
                File.Delete(tempFile.Value);
            }
        }

    }
}
