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
            var columns = new List<Column>();

            var rowIndex = 0;
            foreach (Model.Row row in rows)
            {
                var columnIndex = 0;
                foreach (Model.Cell cell in row.Cells)
                {
                    var column = columns.ElementAtOrDefault(columnIndex);
                    if (column == null)
                    {
                        column = new Column();
                        columns.Add(column);
                    }

                    column.Cells.Add(cell);

                    columnIndex++;
                }

                rowIndex++;
            }

            return columns.Select(_ => new Model.Column(_.Cells)).ToList();
        }

        private class Column
        {
            public List<Model.Cell> Cells { get; } = new List<Model.Cell>();
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