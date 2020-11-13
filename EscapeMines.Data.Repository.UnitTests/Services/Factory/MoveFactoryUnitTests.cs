using System;
using System.Collections.Generic;
using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Interfaces;
using EscapeMines.Data.Repository.Services.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EscapeMines.Data.Repository.UnitTests.Services.Factory
{
    [TestClass]
    public class MoveFactoryUnitTests
    {
        private readonly Mock<IEnumerable<IMoveService>> _moveServiceMock = new Mock<IEnumerable<IMoveService>>();

        private MoveFactory CreateFactory()
        {
            return new MoveFactory(this._moveServiceMock.Object);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequiresMoveService()
        {
            new MoveFactory(null);
        }
    }
}
