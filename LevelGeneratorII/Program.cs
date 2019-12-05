using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelGeneratorII
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a width:");

                int cols = int.Parse(Console.ReadLine().ToString());

                Console.WriteLine("Enter a height:");

                int rows = int.Parse(Console.ReadLine().ToString());

                Table level = new Table(cols, rows);

                ModifyLevel(level);

                DisplayLevel(level);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        static void ModifyLevel(Table level)
        {
            int maxRowIndex = level.maxRows - 1;

            int heading1 = random.Next(3, 7);
            int gap = 0;
            int gapWidth = 7;
            bool usePlatforms = true;
            // Phase 1
            // Floor
            for (int x = 0; x < level.maxCols; x++)
            {
                if ((heading1 + x) % 10 > 8 && random.Next(0, 10) > 5)
                {
                    gapWidth = random.Next(1, 10);
                    gap = gapWidth;
                    usePlatforms = (gapWidth > 5);
                }

                if (gap > 0)
                {
                    if (gap > 1 && gap < gapWidth && usePlatforms)
                    {
                        level.Set(x, maxRowIndex - 4, 'P');

                        if((gap == 2 || gap == gapWidth - 1) && random.Next(0, 10) < 6)
                        {
                            level.Set(x, maxRowIndex - 4, '?');
                        }
                    }

                    gap--;

                    continue;
                }

                level.Set(x, maxRowIndex, 'b');
                level.Set(x, maxRowIndex - 1, 'b');
            }
        }

        static void DisplayLevel(Table level)
        {
            var levelRows = level.rows;

            Console.WriteLine("[");
            foreach (var i in levelRows)
            {
                Console.WriteLine($"    \"{i}\",");
            }
            Console.WriteLine("]");
        }
    }
}
