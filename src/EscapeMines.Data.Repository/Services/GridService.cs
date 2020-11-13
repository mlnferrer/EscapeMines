using EscapeMines.Data.Contracts;
using EscapeMines.Data.Contracts.Interfaces.FileParser;
using EscapeMines.Data.Contracts.Models;
using System;

namespace EscapeMines.Data.Repository.Services
{
    public class GridService : IGridService
    {
        private readonly IFileParserService _fileParserService;

        public GridService(IFileParserService fileParserService)
        {
            _fileParserService = fileParserService ?? throw new ArgumentNullException(nameof(fileParserService));
        }

        public Grid GetGrid()
        {
            string[] grid = _fileParserService.GetDataFromRow(1).Split(' ');
            return new Grid() { Width = Convert.ToInt32(grid[0]), Height = Convert.ToInt32(grid[1]) };
        }
    }
}
