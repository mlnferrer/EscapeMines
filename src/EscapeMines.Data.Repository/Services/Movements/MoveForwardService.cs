using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Exceptions;
using EscapeMines.Data.Contracts.Interfaces;
using EscapeMines.Data.Contracts.Models;
using System;


namespace EscapeMines.Data.Repository.Services.Movements
{
    public class MoveForwardService : IMoveService
    {
        public bool IsValidMove(Move move)
        {
            return move == Contracts.Enums.Move.M;
        }

        public void Move(GameSetting game)
        {
            Position newPosition = new Position();

            switch(game.InitialPosition.Movement)
            {
                case Direction.N:
                    newPosition = new Position() { X = game.InitialPosition.Position.X, Y = game.InitialPosition.Position.Y - 1 };
                    break;
                case Direction.S:
                    newPosition = new Position() { X = game.InitialPosition.Position.X, Y = game.InitialPosition.Position.Y + 1 };
                    break;
                case Direction.E:
                    newPosition = new Position() { X = game.InitialPosition.Position.X + 1, Y = game.InitialPosition.Position.Y };
                    break;
                case Direction.W:
                    newPosition = new Position() { X = game.InitialPosition.Position.X - 1, Y = game.InitialPosition.Position.Y };
                    break;
                default:
                    throw new InvalidDirectionException();
            }

            bool isValidMove = newPosition.X >= 0 && newPosition.X <= game.Grid.Width 
                && newPosition.Y >= 0 && newPosition.Y <= game.Grid.Height;

            if(isValidMove)
            {
                game.InitialPosition.Position = newPosition;
            }
        }

    }
}
