using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnErrorMessage()
        {
            _fileReader.Setup(x => x.Read("video.txt")).Returns(""); //setter value of mock object
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideos_ReturnEmptyString()
        {
            _repository.Setup(x => x.GetUnprocessedVideos()).Returns(new List<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ReturnStringIds()
        {
            _repository.Setup(x => x.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video{ Id = 1 },
                new Video{ Id = 2 },
                new Video{ Id = 3 }
            });
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
