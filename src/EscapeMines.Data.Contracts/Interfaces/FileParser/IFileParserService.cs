using System.Collections.Generic;

namespace EscapeMines.Data.Contracts.Interfaces.FileParser
{
    public interface IFileParserService
    {
        string GetDataFromRow(int skip);

        IEnumerable<string> GetMovements(int skip);
    }
}
