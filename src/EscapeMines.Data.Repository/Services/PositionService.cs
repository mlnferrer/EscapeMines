using EscapeMines.Data.Contracts.Enums;
using EscapeMines.Data.Contracts.Interfaces.FileParser;
using EscapeMines.Data.Contracts.Interfaces.Services;
using EscapeMines.Data.Contracts.Models;
using System;
using System.Collections.Generic;

namespace EscapeMines.Data.Repository.Services
{
    public class PositionService : IPositionService
    {
        private readonly IFileParserService _fileParserService;

        public PositionService(IFileParserService fileParserService)
        {
            _fileParserService = fileParserService ?? throw new ArgumentNullException(nameof(fileParserService));
        }

        public Position GetExit()
        {
            string[] exit = _fileParserService.GetDataFromRow(3).Split(' ');
            return new Position() { X = Convert.ToInt32(exit[0]), Y = Convert.ToInt32(exit[1]) };
        }

        public IEnumerable<Position> GetMinePositions()
        {
            string[] mines = _fileParserService.GetDataFromRow(2).Split(' ');

            List<Position> positions = new List<Position>();

            foreach(var item in mines)
            {
                string[] mine = item.Split(',');

                positions.Add(new Position() { X = Convert.ToInt32(mine[0]), Y = Convert.ToInt32(mine[1]) });
            }

            return positions;
        }

        public InitialPosition GetInitialPosition()
        {
            string[] position = _fileParserService.GetDataFromRow(4).Split(' ');
            int x = Convert.ToInt32(position[0]);
            int y = Convert.ToInt32(position[1]);

            Direction direction = (Direction)Enum.Parse(typeof(Direction), position[2]);

            return new InitialPosition()
            {
                Movement = direction,
                Position = new Position() { X = x, Y = y }
            };
        }

        public IEnumerable<IEnumerable<Move>> GetMovement()
        {
            List<List<Move>> moves = new List<List<Move>>();

            IEnumerable<string> linesInText = _fileParserService.GetMovements(5);
            
            foreach(var lines in linesInText)
            {
                List<Move> row = new List<Move>();
                var data = lines.Split(' ');

                foreach(var item in data)
                {
                    row.Add((Move)Enum.Parse(typeof(Move), item));
                }

                moves.Add(row);
            }

            return moves;
        }
    }
}
