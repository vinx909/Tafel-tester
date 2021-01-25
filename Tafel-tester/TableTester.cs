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
        private const int amountOfNumbersMultiplying = 2;
        private Random random;
        private int[,] randomTables;

        public TableTester()
        {
            random = new Random();
        }

        public int[,] CreateNewTables(int upperrange)
        {
            
            List<int[]> options = new List<int[]>();
            for(int a = mininalTableOption; a <= upperrange; a++)
            {
                for(int b = a; b <= upperrange; b++)
                {
                    int[] newOption = { a, b };
                    options.Add(newOption);
                }
            }

            randomTables = new int[Math.Min(numberOfTables, options.Count), amountOfNumbersMultiplying];
            for(int index=0; index < randomTables.GetLength(0); index++)
            {
                if (options.Count == 0)
                {
                    break;
                }
                int randomIndex = random.Next(options.Count);
                for(int i = 0; i < randomTables.GetLength(1); i++)
                {
                    randomTables[index, i] = options[randomIndex][i];
                }
                options.RemoveAt(randomIndex);
            }
            return randomTables;
        }

        public int GetNumberOfTables()
        {
            if (randomTables != null)
            {
                return Math.Min(numberOfTables,randomTables.GetLength(0));
            }
            else
            {
                return 0;
            }
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
            if (answers.Length == GetNumberOfTables())
            {
                double correctAnswers = 0;
                List<double> answerCollector = new List<double>();
                for(int i=0; i < answers.Length; i++)
                {
                    int answer = 1;
                    for(int answerIndex=0; answerIndex < randomTables.GetLength(1); answerIndex++)
                    {
                        answer *= randomTables[i,answerIndex];
                    }
                    if (answers[i] == answer)
                    {
                        answerCollector.Add(1);
                        correctAnswers++;
                    }
                    else
                    {
                        answerCollector.Add(0);
                    }
                }
                answerCollector.Add(10 * correctAnswers / GetNumberOfTables());
                return answerCollector.ToArray();
            }
            else
            {
                throw new Exception(exceptionDifferentMountAnswersTables);
            }
        }

        internal void SetNumberOfTables(int numberOfTables)
        {
            this.numberOfTables = numberOfTables;
        }
    }
}
