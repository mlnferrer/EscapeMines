using System;

namespace EscapeMines.Data.Contracts.Exceptions
{
    [Serializable]
    public class InvalidExitException : Exception
    {
        public InvalidExitException() : base("Turtle's starting position can't be at the exit")
        {

        }

    }
}
