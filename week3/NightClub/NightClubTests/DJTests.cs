using NightClub.Enums;
using NightClub.Models;
using System;
using Xunit;

namespace NightClubTests
{
    public class DJTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(100)]
        public void CreatePlayList_MustCreateValidNumOfTracks(int count)
        {
            DJ dj = new DJ(count);
            TrackList trackList = new TrackList();
            dj.CreatePlayList(trackList);

            var actual = trackList.Tracks.Count;

            var expected = count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreatePlayList_ShouldChangeTrack()
        {
            DJ dj = new DJ(10);
            TrackList trackList = new TrackList();
            dj.CreatePlayList(trackList);

            dj.ChangeTrack(trackList);

            var actual = trackList.Tracks.Count;

            var expected = 9;

            Assert.Equal(expected, actual);
        }
    }
}
