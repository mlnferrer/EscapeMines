using EscapeMines.Data.Contracts.Models;
using System.Collections.Generic;

namespace EscapeMines.Data.Contracts.Interfaces.Services
{
    public interface IGameService
    {
        GameSetting Load();

        IEnumerable<FinalResult> Start(GameSetting game);
    }
}
