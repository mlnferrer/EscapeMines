using EscapeMines.Data.Contracts.Enums;
using System.Collections.Generic;

namespace EscapeMines.Data.Contracts.Models
{
    public class GameSetting
    {
        public Grid Grid { get; set; }

        public InitialPosition InitialPosition { get; set; }

        public IEnumerable<Position> Mines { get; set; }

        public Position Exit { get; set; }

        public IEnumerable<IEnumerable<Move>> Moves { get; set; }
    }
}
