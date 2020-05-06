using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explore.Ui.Tables
{
    public class TableService
    {
        public Task<Model> Load()
        {
            var rows = CreateRows(5, 7);
            var columns = CreateColumns(rows);

            return Task.FromResult(new Model(rows, columns));
        }

        private static IReadOnlyList<Model.Column> CreateColumns(IReadOnlyList<Model.Row> rows)
        {
            return new List<Model.Column>();
        }

        private static IReadOnlyList<Model.Row> CreateRows(int rowCount, int cellsPerRow)
        {
            return Enumerable
                .Range(1, rowCount)
                .Select(_ => CreateRow(_, Enumerable.Range(1, cellsPerRow))).ToList();
        }

        private static Model.Row CreateRow(int rowNumber, IEnumerable<int> cells)
        {
            return new Model.Row(cells.Select(_ => new Model.Cell($"{rowNumber}.{_}")).ToList());
        }
    }
}