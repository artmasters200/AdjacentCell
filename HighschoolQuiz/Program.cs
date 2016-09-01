using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighschoolQuiz
{
    class Program
    {
        static int[,] matrix = new int[4, 3];
        static char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8' };
        static List<string> combinations = new List<string>();
        static void Main(string[] args)
        {
            var unusedCells = MarkCellsUnsuseables();

            //validate first
            if (matrix.Length != numbers.Length + unusedCells)
                Console.WriteLine("Inputs does not match the grid");

            GetAllCombinations();

            //test
            //PopulateMatrix("12574836");
            //var haveNearNumbers1 = HaveNearNumbers();
            //Debug.WriteLine("12574836" + " " + haveNearNumbers1);


            foreach (var combination in combinations)
            {
                PopulateMatrix(combination);
                var haveNearNumbers = HaveNearNumbers();
                //Debug.WriteLine(combination + " " + haveNearNumbers);
                //Console.WriteLine(combination + " " + haveNearNumbers);

                if (!haveNearNumbers)
                {
                    DisplayGrid();
                }
            }


            Console.ReadLine();
        }

        static void DisplayGrid()
        {
            Console.WriteLine("");

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    var number = matrix[y, x];

                    if (number == -1)
                        number = 0;

                    if (x == matrix.GetLength(1) - 1)
                    {
                        Console.WriteLine(number);

                    }
                    else
                    {
                        Console.Write(number);
                    }
                }
            }
            Console.WriteLine("");

        }

        static int MarkCellsUnsuseables()
        {
            //unusables
            matrix[0, 0] = -1; //A
            matrix[0, 2] = -1; //C
            matrix[3, 0] = -1; //J
            matrix[3, 2] = -1; //L

            return 4;
        }

        static void GetAllCombinations(string letters = "")
        {
            //Debug.WriteLine(letters);
            if (letters.Length < numbers.Length)
            {
                foreach (var number in numbers)
                {
                    if (letters.Contains(number))
                        continue;

                    GetAllCombinations(letters+number);
                }
            }
            else
            {
                combinations.Add(letters);
            }
        }

        static void PopulateMatrix(string numbers)
        {
            //i could check if the H-cell is 8 or 1 but that was just a filter. I just want to get all the possible combinations for fun!
            int i = 0;
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] == -1)
                        continue;

                    matrix[y, x] = Convert.ToInt32(numbers[i].ToString());
                    i++;
                }
            }
            //matrix[0, 1] = 4; //B

            //matrix[1, 0] = 6; //D
            //matrix[1, 1] = 2; //E
            //matrix[1, 2] = 7; //F

            //matrix[2, 0] = 3; //G
            //matrix[2, 1] = 8; //H
            //matrix[2, 2] = 5; //I

            //matrix[3, 1] = 1; //K
        }

        static bool HaveNearNumbers()
        {
            var haveNearNumbers = false;

            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    if (matrix[y, x] == -1)
                        continue;

                    haveNearNumbers = CheckNearNumbersInRange(y, x);
                    if (haveNearNumbers)
                        return true;
                }
            }

            return haveNearNumbers;
        }

        static bool CheckNearNumbersInRange(int curY, int curX)
        {
            var haveNearNumbers = false;
            var currentValue = matrix[curY, curX];

            for (int y = curY - 1; y <= curY + 1; y++)
            {
                if (y < 0 || matrix.GetLength(0)-1 < y)
                    continue;

                for (int x = curX - 1; x <= curX + 1; x++)
                {

                    if (x < 0 || matrix.GetLength(1)-1 < x)
                        continue;

                    if ((y == curY && x == curX) || matrix[y, x] == -1)
                        continue;

                    var matrixValue = matrix[y, x];

                    if (currentValue+1 == matrixValue || currentValue-1 == matrixValue)
                    {
                        return true;
                    }
                }
            }

            return haveNearNumbers;
        }
    }
}
