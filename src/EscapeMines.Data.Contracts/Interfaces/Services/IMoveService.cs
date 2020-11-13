using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Models;

namespace EscapeMines.Data.Contracts.Interfaces
{
    public interface IMoveService
    {
        bool IsValidMove(Move move);

        void Move(GameSetting game);
    }
}
