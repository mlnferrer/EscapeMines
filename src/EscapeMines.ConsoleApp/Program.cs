using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace EscapeMines.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            var lifeStyle = Lifestyle.Singleton;

            SimpleInjectorConfiguration.Configure(container, lifeStyle);

            container.Verify();

            var gameService = container.GetInstance<IGameService>();

            //Initial Escape Mines
            GameSetting game = gameService.Load();

            //Start
            IEnumerable<FinalResult> finalResults = gameService.Start(game);

            foreach(var result in finalResults)
            {
                Console.WriteLine(result.Result.ToString());
                Console.WriteLine();
            }
        }
    }
}
