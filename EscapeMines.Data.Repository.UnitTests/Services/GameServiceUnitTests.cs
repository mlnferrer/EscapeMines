using System;
using System.Collections.Generic;
using EscapeMines.Data.Contracts;
using EscapeMines.Data.Contracts.Exceptions;
using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Interfaces.Services.Factory;
using EscapeMines.Data.Contracts.Models;
using EscapeMines.Data.Repository.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EscapeMines.Data.Repository.UnitTests.Services.Movements
{
    [TestClass]
    public class GameServiceUnitTests
    {
        private readonly Mock<IGridService> _gridServiceMock = new Mock<IGridService>();
        private readonly Mock<IPositionService> _positionServiceMock = new Mock<IPositionService>();
        private readonly Mock<ITurtleService> _turtleServiceMock = new Mock<ITurtleService>();

        private GameService CreateService()
        {
            return new GameService(this._gridServiceMock.Object, this._positionServiceMock.Object, this._turtleServiceMock.Object);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresGridService()
        {
            new GameService(null, _positionServiceMock.Object, _turtleServiceMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresPositionServiceMock()
        {
            new GameService(this._gridServiceMock.Object, null, _turtleServiceMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresTurtleServiceMock()
        {
            new GameService(this._gridServiceMock.Object, this._positionServiceMock.Object, null);
        }

        [TestMethod]
        public void TestLoadMethod()
        {
            _gridServiceMock.Setup(x => x.GetGrid()).Returns(new Grid() { Width = 5, Height = 4 });
            _positionServiceMock.Setup(x => x.GetMinePositions()).Returns(new List<Position>()
            {
                new Position() { X = 1, Y = 1 },
                new Position() { X = 3, Y = 1 },
                new Position() { X = 1, Y = 3 }
            });

            _positionServiceMock.Setup(x => x.GetInitialPosition()).Returns(new InitialPosition() 
            { 
                Position = new Position() { X = 0, Y = 1 }, 
                Movement = Contracts.Enums.Direction.N 
            });

            _positionServiceMock.Setup(x => x.GetExit()).Returns(new Position()
            {
                X = 4,
                Y = 2
            });

            _positionServiceMock.Setup(x => x.GetMovement()).Returns(new List<List<Contracts.Enums.Move>>
            {
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M }
            });


            var service = new GameService(this._gridServiceMock.Object, this._positionServiceMock.Object, this._turtleServiceMock.Object);
            GameSetting gameSettingMock = service.Load();

            this._gridServiceMock.Verify(x => x.GetGrid(), Times.Once);
            this._positionServiceMock.Verify(x => x.GetMinePositions(), Times.Once);
            this._positionServiceMock.Verify(x => x.GetExit(), Times.Once);
            this._positionServiceMock.Verify(x => x.GetInitialPosition(), Times.Once);
            this._positionServiceMock.Verify(x => x.GetMovement(), Times.Once);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExitException))]
        public void ExitException()
        {
            _gridServiceMock.Setup(x => x.GetGrid()).Returns(new Grid() { Width = 5, Height = 4 });
            _positionServiceMock.Setup(x => x.GetMinePositions()).Returns(new List<Position>()
            {
                new Position() { X = 1, Y = 1 },
                new Position() { X = 3, Y = 1 },
                new Position() { X = 1, Y = 3 }
            });

            _positionServiceMock.Setup(x => x.GetInitialPosition()).Returns(new InitialPosition()
            {
                Position = new Position() { X = 4, Y = 2 },
                Movement = Contracts.Enums.Direction.N
            });

            _positionServiceMock.Setup(x => x.GetExit()).Returns(new Position()
            {
                X = 4,
                Y = 2
            });

            _positionServiceMock.Setup(x => x.GetMovement()).Returns(new List<List<Contracts.Enums.Move>>
            {
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M }
            });


            var service = new GameService(this._gridServiceMock.Object, this._positionServiceMock.Object, this._turtleServiceMock.Object);
            service.Load();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidMineException))]
        public void MineException()
        {
            _gridServiceMock.Setup(x => x.GetGrid()).Returns(new Grid() { Width = 5, Height = 4 });
            _positionServiceMock.Setup(x => x.GetMinePositions()).Returns(new List<Position>()
            {
                new Position() { X = 1, Y = 1 },
                new Position() { X = 3, Y = 1 },
                new Position() { X = 1, Y = 3 }
            });

            _positionServiceMock.Setup(x => x.GetInitialPosition()).Returns(new InitialPosition()
            {
                Position = new Position() { X = 3, Y = 1 },
                Movement = Contracts.Enums.Direction.N
            });

            _positionServiceMock.Setup(x => x.GetExit()).Returns(new Position()
            {
                X = 4,
                Y = 2
            });

            _positionServiceMock.Setup(x => x.GetMovement()).Returns(new List<List<Contracts.Enums.Move>>
            {
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.M },
                new List<Contracts.Enums.Move>() { Contracts.Enums.Move.R, Contracts.Enums.Move.R, Contracts.Enums.Move.M, Contracts.Enums.Move.M, Contracts.Enums.Move.L, Contracts.Enums.Move.M }
            });


            var service = new GameService(this._gridServiceMock.Object, this._positionServiceMock.Object, this._turtleServiceMock.Object);
            service.Load();
        }
    }
}
