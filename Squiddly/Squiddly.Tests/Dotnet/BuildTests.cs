namespace Squiddly.Tests.Dotnet
{
    using System;
    using System.IO;
    using Domain.Dotnet;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;
    using Zatoichi.Common.UnitTest;

    public class BuildTests : BaseTest
    {
        private readonly Mock<IProgressFactory> progressFactory;
        private readonly Mock<IProgress<CmdProgress>> progress;
        private readonly Mock<ILogger<Build>> logger;

        public BuildTests()
        {
            this.progressFactory = new Mock<IProgressFactory>();
            this.progress = new Mock<IProgress<CmdProgress>>();

            this.progressFactory.Setup(p => p.Build()).Returns(this.progress.Object);
            this.logger = new Mock<ILogger<Build>>();
        }

        [Fact]
        public void Build_Uses_Sln_File_If_None_Is_Given()
        {
            using (var build = new Build(this.logger.Object, this.progressFactory.Object))
            {
                build.ProjectFile = "KMS.Notifications.csproj";

                // Hackerooni
                var dr = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent;
                build.Execute(dr.FullName);
            }
        }
    }
}