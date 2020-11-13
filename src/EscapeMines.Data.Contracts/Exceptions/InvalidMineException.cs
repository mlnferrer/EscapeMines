using System;

namespace EscapeMines.Data.Contracts.Exceptions
{
    [Serializable]
    public class InvalidMineException : Exception
    {
        public InvalidMineException() : base("Turtle's starting position can't be in a mine.") { }
    }
}
