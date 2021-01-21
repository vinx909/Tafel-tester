using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tafel_tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string labelSelectNumberBetweenString = "Vul hat hoogste getal in dat gebruikt mag wording in de sommen";
        private const string buttonCreateTableTestString = "Maak sommen";
        private const string buttonCheckAnswersString = "laat score zien";
        private const string correctString = "Goed";
        private const string incorrectString = "Fout";
        private const string labelScoreString = "je hebt een ";
        private const string multiplySign = "*";
        private const string messageBoxEmptyInputString = "niet alles is ingevuld";
        private const string empty = "";

        private const int leftOfset = 50;
        private const int heightOfset = 10;
        private const int rowheight = 20;
        private const int parsefailpushtrough = 0;
        private Label labelTableRange;
        private TextBox textBoxTableRange;
        private Button buttonCreateTableTest;

        private TableTester tester;

        //private Label labelTableRange;
        private TextBox textBoxSelectNumberBetween;
        //private Button buttonCreateTableTest;
        private List<Label> labelsSums;
        private List<TextBox> textBoxesAnswers;
        private List<Label> labelsCorrect;
        private Button buttonCheckAnswers;
        //private Label labelScore;

        public MainWindow()
        {
            InitializeComponent();
            tester = new TableTester();

            setUpTest();

            textboxUpperrange.Text = empty;
            createComponents();
            updateLocations();
        }

        private void emptyEverything()
        {
            labelSum0.Content = empty;
            labelSum1.Content = empty;
            labelSum2.Content = empty;
            labelSum3.Content = empty;
            labelSum4.Content = empty;
            textBoxSum0.Text = empty;
            textBoxSum1.Text = empty;
            textBoxSum2.Text = empty;
            textBoxSum3.Text = empty;
            textBoxSum4.Text = empty;
        }

        private void setUpTest()
        {
            emptyEverything();

            labelSumCorrect0.Visibility = Visibility.Hidden;
            labelSumCorrect1.Visibility = Visibility.Hidden;
            labelSumCorrect2.Visibility = Visibility.Hidden;
            labelSumCorrect3.Visibility = Visibility.Hidden;
            labelSumCorrect4.Visibility = Visibility.Hidden;

            labelScore.Visibility = Visibility.Hidden;
        }

        private void createComponents()
        {
            /*
            labelTableRange = new Label();
            labelTableRange.Content = labelSelectNumberBetweenString;
            renamedGrid.Children.Add(labelTableRange);

            textBoxTableRange = new TextBox();
            renamedGrid.Children.Add(textBoxTableRange);

            buttonCreateTableTest = new Button();
            buttonCreateTableTest.Content = buttonCreateTableTestString;
            buttonCreateTableTest.Click += createTest;
            renamedGrid.Children.Add(buttonCreateTableTest);
            */

            labelsSums = new List<Label>();
            textBoxesAnswers = new List<TextBox>();
            labelsCorrect = new List<Label>();

            /*
            buttonCheckAnswers = new Button();
            buttonCheckAnswers.Content = buttonCheckAnswersString;
            buttonCheckAnswers.Click += showResults;
            renamedGrid.Children.Add(buttonCheckAnswers);

            labelScore = new Label();
            labelScore.Content = labelScoreString;
            renamedGrid.Children.Add(labelScore);
            */
        }


        private void updateLocations()
        {
            int row = 0;
            //labelTableRange
            //textBoxTableRange;
            row++;
            //buttonCreateTableTest;
            row++;
            int numberOfSums = tester.GetNumberOfTables();
            int[,] sums = tester.GetRandomTables();

            foreach(Label label in labelsSums)
            {
                renamedGrid.Children.Remove(label);
            }
            labelsSums.Clear();
            foreach (TextBox textBox in textBoxesAnswers)
            {
                renamedGrid.Children.Remove(textBox);
            }
            textBoxesAnswers.Clear();
            foreach (Label label in labelsCorrect)
            {
                renamedGrid.Children.Remove(label);
            }
            labelsCorrect.Clear();

            if (sums != null)
            {
                for (int i=0; i<numberOfSums; i++)
                {
                    Label newLabelSum = new Label();
                    newLabelSum.Content = sums[i, 0] + multiplySign + sums[i, 1];
                    renamedGrid.Children.Add(newLabelSum);
                    //newLabelSum
                    labelsSums.Add(newLabelSum);

                    TextBox newTextbox = new TextBox();
                    renamedGrid.Children.Add(newTextbox);
                    //newTextbox
                    textBoxesAnswers.Add(newTextbox);

                    Label newLabelCorrect = new Label();
                    renamedGrid.Children.Add(newLabelCorrect);
                    //newLabelCorrect
                    labelsSums.Add(newLabelCorrect);

                    row++;
                }
            }
            //buttonCheckAnswers
            row++;
            //labelScore
        }

        private void createTest(object sender, EventArgs e)
        {
            try
            {
                tester.CreateNewTables(tryParse(textboxUpperrange.Text));

                updateLocations();

                setUpTest();

                //*
                int[,] tables = tester.GetRandomTables();

                labelSum0.Content = tables[0, 0] + "x" + tables[0, 1];
                labelSum1.Content = tables[1, 0] + "x" + tables[1, 1];
                labelSum2.Content = tables[2, 0] + "x" + tables[2, 1];
                labelSum3.Content = tables[3, 0] + "x" + tables[3, 1];
                labelSum4.Content = tables[4, 0] + "x" + tables[4, 1];
                //*/
            }
            catch (emptyInputException)
            {
                MessageBox.Show(messageBoxEmptyInputString);
            }
        }

        private void showResults(object sender, EventArgs e)
        {
            try
            {
                int[] answers = new int[5];
            
                answers[0] = tryParse(textBoxSum0.Text);
                answers[1] = tryParse(textBoxSum1.Text);
                answers[2] = tryParse(textBoxSum2.Text);
                answers[3] = tryParse(textBoxSum3.Text);
                answers[4] = tryParse(textBoxSum4.Text);

                double[] results = tester.GetScore(answers);

                labelSumCorrect0.Visibility = Visibility.Visible;
                if (results[0] > 0)
                {
                    labelSumCorrect0.Content = correctString;
                }
                else
                {
                    labelSumCorrect0.Content = incorrectString;
                }
                labelSumCorrect1.Visibility = Visibility.Visible;
                if (results[1] > 0)
                {
                    labelSumCorrect1.Content = correctString;
                }
                else
                {
                    labelSumCorrect1.Content = incorrectString;
                }
                labelSumCorrect2.Visibility = Visibility.Visible;
                if (results[2] > 0)
                {
                    labelSumCorrect2.Content = correctString;
                }
                else
                {
                    labelSumCorrect2.Content = incorrectString;
                }
                labelSumCorrect3.Visibility = Visibility.Visible;
                if (results[3] > 0)
                {
                    labelSumCorrect3.Content = correctString;
                }
                else
                {
                    labelSumCorrect3.Content = incorrectString;
                }
                labelSumCorrect4.Visibility = Visibility.Visible;
                if (results[4] > 0)
                {
                    labelSumCorrect4.Content = correctString;
                }
                else
                {
                    labelSumCorrect4.Content = incorrectString;
                }

                labelScore.Visibility = Visibility.Visible;
                labelScore.Content = labelScoreString + results[5];
            }
            catch (emptyInputException)
            {
                MessageBox.Show(messageBoxEmptyInputString);
            }
        }

        private int tryParse(string text)
        {
            if (text.Equals(empty))
            {
                throw new emptyInputException();
            }
            try
            {
                return int.Parse(text);
            }
            catch
            {
                return parsefailpushtrough;
            }
        }

        Label test;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createTest(sender, e);

            test = new Label();
            test.Name = "name";
            test.Content = "testing testing 123";
            test.Margin = new Thickness(200, 200, 3, 3);
            test.Width = 50;
            test.Height = 50;
            test.HorizontalAlignment = HorizontalAlignment.Left;
            test.VerticalAlignment = VerticalAlignment.Top;
            test.Visibility = Visibility.Visible;
            renamedGrid.Children.Add(test);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showResults(sender, e);
        }

        private class emptyInputException : Exception{}
    }
}
