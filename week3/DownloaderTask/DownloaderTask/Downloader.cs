using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DownloaderTask
{
    
    public class Downloader
    {
        public string DownloadString(string url)
        {
            using var client = new WebClient();

            var responseString = client.DownloadString(url);
            

            return responseString;
        }

        public List<Photo> GetPhotosModel()
        {
            var responseString = DownloadString("https://jsonplaceholder.typicode.com/photos");

            dynamic json = JObject.Parse(responseString);

            List<Photo> photos = new List<Photo>();

            foreach (var item in json)
            {
                Photo photo = new Photo()
                {
                    albumId = item.albumId,
                    id = item.id,
                    title = item.title,
                    url = item.url,
                    thumbnailUrl = item.thumbnailUrl
                };
                photos.Add(photo);
            }

            return photos;
        }

        public void DownloadPhotos()
        {

        }
    }
}
