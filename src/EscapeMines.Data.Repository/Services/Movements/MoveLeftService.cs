﻿using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Interfaces;
using EscapeMines.Data.Contracts.Models;
using System;

namespace EscapeMines.Data.Repository.Services.Movements
{
    public class MoveLeftService : IMoveService
    {
        public bool IsValidMove(Move move)
        {
            return move == Contracts.Enums.Move.L;
        }

        public void Move(GameSetting game)
        {
            Direction[] directions = (Direction[])Enum.GetValues(typeof(Direction));
            int newPos = Array.IndexOf(directions, game.InitialPosition.Movement) - 1;
            game.InitialPosition.Movement = (newPos == -1) ? directions[directions.Length - 1] : directions[newPos];
        }
    }
}