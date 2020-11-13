using EscapeMines.Data.Contracts.Enums;
using System.Collections.Generic;

namespace EscapeMines.Data.Contracts.Models
{
    public class FinalResult
    {
        public IEnumerable<Move> Moves { get; set; }

        public Result Result { get; set; }
    }
}
