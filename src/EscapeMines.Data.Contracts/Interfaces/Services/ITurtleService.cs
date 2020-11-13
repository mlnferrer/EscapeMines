using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Models;

namespace EscapeMines.Data.Contracts.Interfaces.Services
{
    public interface ITurtleService
    {
        void MovePosition(Move move, GameSetting game);
    }
}
