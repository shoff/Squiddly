namespace Squiddly.Messages
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
}