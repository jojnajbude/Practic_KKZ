using System;

namespace prac2_console
{
    internal class Program
    {
        static void task1(int[,] array)
        {
            bool rowHasNegative = false;
            int product = 1;
            int j = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                while (j < array.GetLength(1) && !rowHasNegative)
                {
                    if (array[i, j] < 0)
                        rowHasNegative = true;
                    else
                        product *= array[i, j]; 

                    j++;
                }
                if (!rowHasNegative)
                {
                    Console.WriteLine($"The product of row #{i+1}: {product}");
                    product = 1;
                }
                j = 0;
                rowHasNegative = false;
            }
        }

        static void task2(int[,] array)
        {
            int maxLength = 0;
            int maxNumber = 0;
            int Row = 0;

            int currentNumber;
            int currentLength = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    currentNumber = array[i,j];
                    for (int k = 0; k < 3; k++)
                    {
                        if (currentNumber == array[i,k])
                        {
                            currentLength++;
                        }
                    }
                    if (currentLength>maxLength)
                    {
                        maxLength = currentLength;
                        maxNumber = array[i, j];
                        Row = i + 1;
                    }
                    currentLength = 0;
                }
            }

            Console.WriteLine($"Row with maximum sequence is #{Row}. Max squence is {maxLength}. Max number is {maxNumber}");
        }

        static void Main(string[] args)
        {
            int[,] array = { { 1, -3, 5 }, { 2, 1, 1 }, { 4, 4, 9 } };

            task1(array);

            task2(array);
        }
    }
}
