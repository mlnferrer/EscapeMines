using System;


namespace EscapeMines.Data.Contracts.Exceptions
{
    [Serializable]
    public class InvalidDirectionException: Exception
    {
        public InvalidDirectionException() : base("Direction is not accepted.") { }
    }
}
