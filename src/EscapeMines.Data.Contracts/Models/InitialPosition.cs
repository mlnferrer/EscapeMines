using EscapeMines.Data.Contracts.Enums;

namespace EscapeMines.Data.Contracts.Models
{
    public class InitialPosition
    {
        public Position Position { get; set; }

        public Direction Movement { get; set; }
    }
}
