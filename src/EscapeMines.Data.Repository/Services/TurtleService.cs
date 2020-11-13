using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Interfaces.Services.Factory;
using EscapeMines.Data.Contracts.Models;
using System;

namespace EscapeMines.Data.Repository.Services
{
    public class TurtleService : ITurtleService
    {
        private readonly IMoveFactory _moveFactory;

        public TurtleService(IMoveFactory moveFactory)
        {
            _moveFactory = moveFactory ?? throw new ArgumentNullException(nameof(moveFactory));
        }

        public void MovePosition(Move move, GameSetting game)
        {
            _moveFactory.CreateMove(move).Move(game);
        }
    }
}
