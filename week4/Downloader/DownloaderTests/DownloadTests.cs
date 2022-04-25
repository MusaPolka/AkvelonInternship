using Downloader;
using System;
using System.Net;
using Xunit;

namespace DownloaderTests
{
    public class DownloadTests
    {
        [Fact]
        public void getFileSize_ShouldReturnRightSize()
        {
            var actualLength = Downloader.Downloader.GetFileSize("https://file-examples.com/storage/fe69f82402626533c98f608/2017/04/file_example_MP4_1920_18MG.mp4") / 1000000;

            long expectedLength = 17;

            Assert.Equal(expectedLength, actualLength);
        }
    }
}
