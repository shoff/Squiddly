namespace Squiddly.Domain
{
    using System;

    public abstract class CommandEvent
    {
        protected CommandEvent()
        {
            this.DateCreated = DateTime.UtcNow;
        }

        public abstract void Apply();

        public DateTime DateCreated { get; }
    }

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