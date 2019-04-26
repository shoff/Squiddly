
using ChaosMonkey.Guards;
using Squiddly.Domain;
using System;
using System.Collections.Generic;

namespace Squiddly
{
    using Domain.Squirts;

    internal static class SquirtParser
    {
        private static readonly Dictionary<string, Func<ISquirtable>> squirts = new Dictionary<string, Func<ISquirtable>>
        {
            // Only squirt we have right now
            { "FTPSQUIRT", (()=> new FtpSquirt()) }
        };


        public static ISquirtable GetSquirt(string[] args)
        {
            Guard.IsNotNull(args, nameof(args));
            Guard.IsNotEmpty(args, nameof(args));
            Guard.IsGreaterThan( args.Length, 3, nameof(args));

            var squirt = squirts[args[0].ToUpperInvariant()].Invoke();
            return squirt;
        }
    }
}
