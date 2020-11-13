using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Interfaces;
using EscapeMines.Data.Contracts.Interfaces.Services.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeMines.Data.Repository.Services.Factory
{
    public class MoveFactory : IMoveFactory
    {
        private readonly IEnumerable<IMoveService> _moveServices;

        public MoveFactory(IEnumerable<IMoveService> moveServices)
        {
            _moveServices = moveServices ?? throw new ArgumentNullException(nameof(moveServices));
        }

        public IMoveService CreateMove(Move move)
        {
            return _moveServices.Single(item => item.IsValidMove(move));
        }
    }
}
