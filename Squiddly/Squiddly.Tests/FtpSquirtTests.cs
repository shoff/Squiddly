using Squiddly.Domain;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Zatoichi.Common.UnitTest;
using AutoFixture;

namespace Squiddly.Tests
{
    using Domain.Squirts;

    public class FtpSquirtTests : BaseTest
    {
        private readonly CancellationToken token;
        private readonly FtpSquirt ftpSquirt;

        public FtpSquirtTests()
        {
            var creds = new NetworkCredential(@"ftp.zatoichi.test|steve", @"H@cker22");
            this.ftpSquirt = new FtpSquirt("zatoichi", "ftp.zatoichi.test|steve", "H@cker22");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            this.token = cancellationTokenSource.Token;
        }

        [Fact]
        public async Task UploadAsync_Sends_Folder_To_Server()
        {
            var progress = this.fixture.Create<Progress<UploadProgress>>();
            var folder = AppDomain.CurrentDomain.BaseDirectory + "\\UploadFolder";
            await this.ftpSquirt.UploadFolderAsync(folder, "/", this.token, progress);

        }
    }
}
