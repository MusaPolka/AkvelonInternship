using NightClub.Enums;
using NightClub.Models;
using System;
using Xunit;

namespace NightClubTests
{
    public class DancerModelTests
    {
        [Theory]
        [InlineData(TypeOfMusic.Rock, "Head for Rock")]
        [InlineData(TypeOfMusic.HardBass, "Elbow for Hardbass")]
        [InlineData(TypeOfMusic.Latino, "Hips for Latino")]
        public void DanceMove_MustReturnValidDanceMove(TypeOfMusic typeOfMusic, string expected)
        {
            Track track = new Track();
            track.MusicType = typeOfMusic;

            Dancer dancer = new Dancer();
            var actual = dancer.DanceMove(track);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(0)]
        [InlineData(100)]
        public void DancerList_CreateDancer_MustCreateValidNumOfDancers(int count)
        {
            DancerList dancerList = new DancerList(count);
            dancerList.CreateDancers();

            var actual = dancerList.Dancers.Count;

            Assert.Equal(count, actual);
        }

        [Fact]
        public void DancerList_CreateDancer_MustThrowArgumentException()
        {
            DancerList dancerList = new DancerList(-1);

            var expected = typeof(ArgumentException);

            Assert.Throws(expected, dancerList.CreateDancers);
        }
    }
}
