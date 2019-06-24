namespace Squiddly.Domain.Dotnet
{
    public class CmdProgress
    {
        public CmdProgress(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}