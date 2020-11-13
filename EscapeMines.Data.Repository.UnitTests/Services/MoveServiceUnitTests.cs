using System;
using System.Collections.Generic;
using EscapeMines.Data.Contracts.Models;
using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Repository.Services.Movements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscapeMines.Data.Contracts.Exceptions;

namespace EscapeMines.Data.Repository.UnitTests.Services
{
    [TestClass]
    public class MoveServiceUnitTests
    {        
        private readonly MoveForwardService moveForwardService = new MoveForwardService();
        private readonly MoveLeftService moveLeftService = new MoveLeftService();
        private readonly MoveRightService moveRightService = new MoveRightService();

        private readonly GameSetting game = new GameSetting()
        {
            Grid = new Grid() { Width = 5, Height = 4 },
            Mines = new List<Position>()
            {
                new Position() { X = 1, Y = 1 },
                new Position() { X = 3, Y = 1 },
                new Position() { X = 1, Y = 3 }
            },
            InitialPosition = new InitialPosition() { Position = new Position() { X = 0, Y = 1 }, Movement = Direction.N },
            Exit = new Position() { X = 4, Y = 2 },
            Moves = new List<List<Move>>
            {
                new List<Move>() { Move.R, Move.M, Move.L, Move.M, Move.M },
                new List<Move>() { Move.R, Move.M, Move.M, Move.M },
                new List<Move>() { Move.R, Move.R, Move.M, Move.M, Move.L, Move.M }
            }
        };

        [DataTestMethod]
        [DataRow(Direction.N, 0, 0)]
        [DataRow(Direction.E, 1, 1)]
        [DataRow(Direction.W, 0, 1)]
        [DataRow(Direction.S, 0, 2)]
        public void MoveForwardTest(Direction direction, int x, int y)
        {
            game.InitialPosition.Movement = direction;
            moveForwardService.Move(game);

            Assert.AreEqual(x, game.InitialPosition.Position.X);
            Assert.AreEqual(y, game.InitialPosition.Position.Y);

        }

        [DataTestMethod]
        [DataRow(Direction.N, Direction.W)]
        [DataRow(Direction.E, Direction.N)]
        [DataRow(Direction.W, Direction.S)]
        [DataRow(Direction.S, Direction.E)]
        public void MoveLeftTest(Direction direction, Direction expectedDirection)
        {
            game.InitialPosition.Movement = direction;
            moveLeftService.Move(game);

            Assert.AreEqual(expectedDirection, game.InitialPosition.Movement);
        }

        [DataTestMethod]
        [DataRow(Direction.N, Direction.E)]
        [DataRow(Direction.E, Direction.S)]
        [DataRow(Direction.S, Direction.W)]
        [DataRow(Direction.W, Direction.N)]
        public void MoveRightTest(Direction direction, Direction expectedDirection)
        {
            game.InitialPosition.Movement = direction;
            moveRightService.Move(game);

            Assert.AreEqual(expectedDirection, game.InitialPosition.Movement);
        }
    }
}
