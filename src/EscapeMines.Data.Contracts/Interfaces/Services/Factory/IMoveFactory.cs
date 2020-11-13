using EscapeMines.Data.Contracts.Enums;

namespace EscapeMines.Data.Contracts.Interfaces.Services.Factory
{
    public interface IMoveFactory
    {
        IMoveService CreateMove(Move move);
    }
}
