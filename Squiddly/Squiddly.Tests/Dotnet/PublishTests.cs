namespace Squiddly.Tests.Dotnet
{
    using System;
    using System.IO;
    using Infrastructure.Dotnet;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;
    using Zatoichi.Common.UnitTest;

    public class PublishTests : BaseTest
    {
        private readonly Mock<IProgressFactory> progressFactory;
        private readonly Mock<IProgress<CmdProgress>> progress;
        private readonly Mock<ILogger<Build>> logger;

        public PublishTests()
        {
            this.progressFactory = new Mock<IProgressFactory>();
            this.progress = new Mock<IProgress<CmdProgress>>();

            this.progressFactory.Setup(p => p.Build()).Returns(this.progress.Object);
            this.logger = new Mock<ILogger<Build>>();
        }

        [Fact]
        public void Publish_Uses_Sln_File_If_None_Is_Given()
        {
            using (var publish = new Publish(this.logger.Object, this.progressFactory.Object))
            {
                publish.Output = "C:\\dev\\Zatoichi\\Zatoichi.Common.Infrastructure\\published";

                // Hackerooni
                var dr = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent;
                publish.Execute(dr.FullName);
            }
        }
    }
}