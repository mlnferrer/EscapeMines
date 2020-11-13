using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Models;
using System.Collections.Generic;

namespace EscapeMines.Data.Contracts.Interfaces.Services
{
    public interface IPositionService
    {
        IEnumerable<Position> GetMinePositions();

        Position GetExit();

        InitialPosition GetInitialPosition();

        IEnumerable<IEnumerable<Move>> GetMovement();
    }
}
