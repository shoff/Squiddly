namespace Squiddly.Infrastructure
{
    using Polly;

    public interface ICommandResult<TResult>
    {
        bool Succeeded { get; }
        PolicyResult<TResult> Result { get; }
    }
}