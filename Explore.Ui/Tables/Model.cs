using System.Collections.Generic;

namespace Explore.Ui.Tables
{
    public class Model
    {
        public Model(IReadOnlyList<Row> rows, IReadOnlyList<Column> columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public IReadOnlyList<Row> Rows { get; }
        public IReadOnlyList<Column> Columns { get; }

        public class Row
        {
            public Row(IReadOnlyList<Cell> cells)
            {
                Cells = cells;
            }

            public IReadOnlyList<Cell> Cells { get; }
        }

        public class Column
        {
            public Column(IReadOnlyList<Cell> cells)
            {
                Cells = cells;
            }

            public IReadOnlyList<Cell> Cells { get; }
        }

        public class Cell
        {
            public Cell(string content)
            {
                Content = content;
            }

            public string Content { get; }
        }
    }
}