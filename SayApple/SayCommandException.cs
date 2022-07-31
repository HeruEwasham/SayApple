using System;
using CliWrap;

namespace SayApple
{
    public class SayCommandException : Exception
    {
        public int ExitCode { get; }

        public DateTimeOffset StartTime { get; }

        public DateTimeOffset ExitTime { get; }

        public TimeSpan RunTime { get; }

        public string CommandStandardOutputResponse { get; }

        public string CommandStandardErrorResponse { get; }

        public SayCommandException(CommandResult result, string commandStandardOutputResponse, string commandStandardErrorResponse) : base("An error occured when say-command was run. Exit-code is " + result.ExitCode + ". See details in the SayCommandException for more information.")
        {
            ExitCode = result.ExitCode;
            StartTime = result.StartTime;
            ExitTime = result.ExitTime;
            RunTime = result.RunTime;
            CommandStandardOutputResponse = commandStandardOutputResponse;
            CommandStandardErrorResponse = commandStandardErrorResponse;
        }
    }
}

