﻿using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }
        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloader.Setup(x => x.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.False);
        }
        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");
            Assert.That(result, Is.True);
        }
    }
}
