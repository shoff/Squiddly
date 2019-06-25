namespace Squiddly.Messages
{
    using System;

    public abstract class QueryEvent<T>
        where T : class
    {
        protected QueryEvent()
        {
            this.DateCreated = DateTime.UtcNow;
        }
        public abstract T Apply();
        public DateTime DateCreated { get; }

    }
}