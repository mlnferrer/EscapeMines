using EscapeMines.Data.Contracts;
using EscapeMines.Data.Contracts.Interfaces;
using EscapeMines.Data.Contracts.Interfaces.FileParser;
using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Interfaces.Services.Factory;
using EscapeMines.Data.Repository.FileParser;
using EscapeMines.Data.Repository.Services;
using EscapeMines.Data.Repository.Services.Factory;
using EscapeMines.Data.Repository.Services.Movements;
using SimpleInjector;
using System.Reflection;

namespace EscapeMines.ConsoleApp
{
    public class SimpleInjectorConfiguration
    {
        public static void Configure(Container container, SimpleInjector.Lifestyle lifeStyle)
        {
            container.Register<IFileParserService, FileParserService>(lifeStyle);
            container.Register<IGridService, GridService>(lifeStyle);
            container.Register<IPositionService, PositionService>(lifeStyle);
            container.Register<IGameService, GameService>(lifeStyle);
            container.Register<IMoveFactory, MoveFactory>(lifeStyle);
            container.Register<ITurtleService, TurtleService>(lifeStyle);
            container.Collection.Register(typeof(IMoveService), new[]
            {
                typeof(MoveForwardService),
                typeof(MoveLeftService),
                typeof(MoveRightService)
            });

        }
    }
}
