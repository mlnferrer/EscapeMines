using EscapeMines.Data.Contracts.Interfaces.FileParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EscapeMines.Data.Repository.FileParser
{
    public class FileParserService : IFileParserService
    {
        private readonly string settings = Properties.Resources.game_settings;

        public IEnumerable<string> GetMovements(int skip)
        {
            return settings.Split(new[] { Environment.NewLine },
                                StringSplitOptions.RemoveEmptyEntries).ToList().Skip(skip - 1);

        }

        public string GetDataFromRow(int skip)
        {
            return settings.Split(new[] { Environment.NewLine },
                              StringSplitOptions.RemoveEmptyEntries).ToList().Skip(skip - 1).First();
        }
    }
}
