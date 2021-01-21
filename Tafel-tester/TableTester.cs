using System;
using System.Collections.Generic;
using System.Text;

namespace Tafel_tester
{
    class TableTester
    {
        private const string exceptionDifferentMountAnswersTables = "the amount of answer doesn't equal the amount of questions";
        private int numberOfTables = 5;
        private const int mininalTableOption = 1;
        private Random random;
        private int[,] randomTables;

        public TableTester()
        {
            random = new Random();
            randomTables = new int[numberOfTables,2];
        }

        public int[,] CreateNewTables(int upperrange)
        {
            
            List<int[]> options = new List<int[]>();
            for(int a = 1; a <= upperrange; a++)
            {
                for(int b = a; b <= upperrange; b++)
                {
                    int[] newOption = { a, b };
                    options.Add(newOption);
                }
            }

            numberOfTables = Math.Min(numberOfTables, options.Count);
            randomTables = new int[numberOfTables, 2];
            for(int i=0; i < randomTables.GetLength(0); i++)
            {
                if (options.Count == 0)
                {
                    break;
                }
                int randomIndex = random.Next(options.Count);
                randomTables[i, 0] = options[randomIndex][0];
                randomTables[i, 1] = options[randomIndex][1];
                options.RemoveAt(randomIndex);
            }
            return randomTables;
            
            /*
            randomTables = new int[numberOfTables, 2];
            for(int i = 0; i < randomTables.GetLength(0); i++)
            {
                randomTables[i, 0] = i + 1;
                randomTables[i, 1] = random.Next(1, upperrange + 1);
            }
            return randomTables;
            */
        }

        public int GetNumberOfTables()
        {
            return numberOfTables;
        }

        public int[,] GetRandomTables()
        {
            if (randomTables != null)
            {
                return randomTables;
            }
            else
            {
                return null;
            }
        }

        public double[] GetScore(int[] answers)
        {
            if (answers.Length == numberOfTables)
            {
                double correctAnswers = 0;
                List<double> answerCollector = new List<double>();
                for(int i=0; i < numberOfTables; i++)
                {
                    if (answers[i] == randomTables[i, 0] * randomTables[i, 1])
                    {
                        answerCollector.Add(1);
                        correctAnswers++;
                    }
                    else
                    {
                        answerCollector.Add(0);
                    }
                }
                answerCollector.Add(10 * correctAnswers / numberOfTables);
                return answerCollector.ToArray();
            }
            else
            {
                throw new Exception(exceptionDifferentMountAnswersTables);
            }
        }
    }
}
