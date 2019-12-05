using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelGeneratorII
{
    class Table
    {
        public readonly int maxRows;
        public readonly int maxCols;
        public readonly StringBuilder[] rows;

        public Table(int maxCols, int maxRows)
        {
            this.maxRows = maxRows;
            this.maxCols = maxCols;

            this.rows = new StringBuilder[maxRows];
            for (int i = 0; i < maxRows; i++)
            {
                this.rows[i] = new StringBuilder(new string(' ', maxCols));
            }
        }

        public void Set(int colIndex, int rowIndex, char value)
        {
            this.rows[rowIndex][colIndex] = value;
        }

        public char Get(int colIndex, int rowIndex)
        {
            return this.rows[rowIndex][colIndex];
        }
    }
}
