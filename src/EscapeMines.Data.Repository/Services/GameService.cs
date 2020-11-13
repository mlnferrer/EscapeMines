using EscapeMines.Data.Contracts;
using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Exceptions;
using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeMines.Data.Repository.Services
{
    public class GameService : IGameService
    {
        private readonly IGridService _gridService;
        private readonly IPositionService _positionService;
        private readonly ITurtleService _turtleService;

        public GameService(IGridService gridService, IPositionService positionService, ITurtleService turtleService)
        {
            _gridService = gridService ?? throw new ArgumentNullException(nameof(gridService));
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _turtleService = turtleService ?? throw new ArgumentNullException(nameof(turtleService));
        }

        public GameSetting Load()
        {
            
            //Get Grid Settings
            Grid grid = _gridService.GetGrid();

            //Get Mine Positions
            IEnumerable<Position> minePositions = _positionService.GetMinePositions();

            //Get Exit Point
            Position exit = _positionService.GetExit();

            //Get Turtle's initial position 
            InitialPosition initialPosition = _positionService.GetInitialPosition();

            //Movements in Grid
            IEnumerable<IEnumerable<Move>> moves = _positionService.GetMovement();

            if (initialPosition.Position.X == exit.X && initialPosition.Position.Y == exit.Y)
            {
                throw new InvalidExitException();
            }

            foreach (var item in minePositions)
            {
                if (item.X == initialPosition.Position.X && item.Y == initialPosition.Position.Y)
                {
                    throw new InvalidMineException();
                }
            }

            return new GameSetting()
            {
                Grid = grid,
                Mines = minePositions,
                Exit = exit,
                InitialPosition = initialPosition,
                Moves = moves
            };

            
            
        }

        public IEnumerable<FinalResult> Start(GameSetting game)
        {
            List<FinalResult> results = new List<FinalResult>();

            Result result;

            Position firstPosition = new Position() { X = game.InitialPosition.Position.X, Y = game.InitialPosition.Position.Y };
            Direction firstMove = game.InitialPosition.Movement;

            foreach(var move in game.Moves)
            {
                result = Result.InDanger;
                game.InitialPosition.Position = firstPosition;
                game.InitialPosition.Movement = firstMove;

                foreach(var item in move)
                {
                    _turtleService.MovePosition(item, game);

                    result = GetNewResult(game);

                    if(result != Result.InDanger)
                    {
                        break;
                    }
                }

                results.Add(new FinalResult() { Moves = move, Result = result });
            }

            return results;
        }

        public Result GetNewResult(GameSetting game)
        {
            Result newResult = Result.InDanger;

            bool isMine = game.Mines.Any(mine => mine.X == game.InitialPosition.Position.X && mine.Y == game.InitialPosition.Position.Y);

            if(isMine)
            {
                newResult = Result.Mine;
            } else
            {
                bool isExit = game.InitialPosition.Position.X == game.Exit.X && game.InitialPosition.Position.Y == game.Exit.Y;

                if(isExit)
                {
                    newResult = Result.Success;
                }
            }

            return newResult;
        }
    }
}
