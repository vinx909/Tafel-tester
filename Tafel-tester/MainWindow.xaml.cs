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
        private const string labelSelectNumberBetweenString = "Vul het hoogste getal in dat gebruikt mag wording in de sommen";
        private const string labelSelectNumberOfTablesString = "Vul het aantal sommen in";
        private const string buttonCreateTableTestString = "Maak sommen";
        private const string buttonCheckAnswersString = "laat score zien";
        private const string correctString = "Goed";
        private const string incorrectString = "Fout";
        private const string labelScoreString = "je hebt een ";
        private const string multiplySign = "*";
        private const string messageBoxEmptyInputString = "niet alles is ingevuld";
        private const string empty = "";
        private readonly char[] allowedNumbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        private const int labelTableRangeWidth = 360;
        private const int textBoxTableRangeWidth = 50;
        private const int labelSelectNumberOfTablesWidth = 150;
        private const int textBoxNumberOfTablesWidth = 50;
        private const int buttonCreateTableTestWidth = 90;
        private const int buttonCheckAnswersWidth = 90;
        private const int labelScoreWidth = 300;

        private const int labelSumWidth = 50;
        private const int textboxWidth = 80;
        private const int labelCorrectWidth = 100;

        private const int widthOfset = 10;
        private const int heightOfset = 10;
        private const int rowheight = 30;
        private const int parsefailpushtrough = 0;

        private TableTester tester;

        private Label labelTableRange;
        private TextBox textBoxTableRange;
        private Label labelSelectNumberOfTables;
        private TextBox textBoxNumberOfTables;
        private Button buttonCreateTableTest;
        private List<Label> labelsSums;
        private List<TextBox> textBoxesAnswers;
        private List<Label> labelsCorrect;
        private Button buttonCheckAnswers;
        private Label labelScore;

        public MainWindow()
        {
            InitializeComponent();
            tester = new TableTester();

            createComponents();
            updateLocations();
        }

        private void createComponents()
        {
            labelTableRange = new Label();
            labelTableRange.Name = nameof(labelTableRange);
            labelTableRange.Content = labelSelectNumberBetweenString;
            labelTableRange.SetValue(Grid.ColumnSpanProperty, 2);
            labelTableRange.Width = labelTableRangeWidth;
            labelTableRange.Height = rowheight;
            labelTableRange.HorizontalAlignment = HorizontalAlignment.Left;
            labelTableRange.VerticalAlignment = VerticalAlignment.Top;
            renamedGrid.Children.Add(labelTableRange);

            textBoxTableRange = new TextBox();
            textBoxTableRange.Name = nameof(textBoxTableRange);
            textBoxTableRange.SetValue(Grid.ColumnSpanProperty, 2);
            textBoxTableRange.Width = textBoxTableRangeWidth;
            textBoxTableRange.Height = rowheight;
            textBoxTableRange.HorizontalAlignment = HorizontalAlignment.Left;
            textBoxTableRange.VerticalAlignment = VerticalAlignment.Top;
            textBoxTableRange.TextChanged += numberOnlyTextbox;
            renamedGrid.Children.Add(textBoxTableRange);

            labelSelectNumberOfTables = new Label();
            labelSelectNumberOfTables.Name = nameof(labelSelectNumberOfTables);
            labelSelectNumberOfTables.Content = labelSelectNumberOfTablesString;
            labelSelectNumberOfTables.SetValue(Grid.ColumnSpanProperty, 2);
            labelSelectNumberOfTables.Width = labelSelectNumberOfTablesWidth;
            labelSelectNumberOfTables.Height = rowheight;
            labelSelectNumberOfTables.HorizontalAlignment = HorizontalAlignment.Left;
            labelSelectNumberOfTables.VerticalAlignment = VerticalAlignment.Top;
            renamedGrid.Children.Add(labelSelectNumberOfTables);

            textBoxNumberOfTables = new TextBox();
            textBoxNumberOfTables.Name = nameof(textBoxNumberOfTables);
            textBoxNumberOfTables.SetValue(Grid.ColumnSpanProperty, 2);
            textBoxNumberOfTables.Width = textBoxNumberOfTablesWidth;
            textBoxNumberOfTables.Height = rowheight;
            textBoxNumberOfTables.HorizontalAlignment = HorizontalAlignment.Left;
            textBoxNumberOfTables.VerticalAlignment = VerticalAlignment.Top;
            textBoxNumberOfTables.TextChanged += numberOnlyTextbox;
            renamedGrid.Children.Add(textBoxNumberOfTables);

            buttonCreateTableTest = new Button();
            buttonCreateTableTest.Name = nameof(buttonCreateTableTest);
            buttonCreateTableTest.Content = buttonCreateTableTestString;
            buttonCreateTableTest.SetValue(Grid.ColumnSpanProperty, 2);
            buttonCreateTableTest.Width = buttonCreateTableTestWidth;
            buttonCreateTableTest.Height = rowheight;
            buttonCreateTableTest.HorizontalAlignment = HorizontalAlignment.Left;
            buttonCreateTableTest.VerticalAlignment = VerticalAlignment.Top;
            buttonCreateTableTest.Click += createTest;
            renamedGrid.Children.Add(buttonCreateTableTest);

            labelsSums = new List<Label>();
            textBoxesAnswers = new List<TextBox>();
            labelsCorrect = new List<Label>();

            buttonCheckAnswers = new Button();
            buttonCheckAnswers.Name = nameof(buttonCheckAnswers);
            buttonCheckAnswers.Content = buttonCheckAnswersString;
            buttonCheckAnswers.SetValue(Grid.ColumnSpanProperty, 2);
            buttonCheckAnswers.Width = buttonCheckAnswersWidth;
            buttonCheckAnswers.Height = rowheight;
            buttonCheckAnswers.HorizontalAlignment = HorizontalAlignment.Left;
            buttonCheckAnswers.VerticalAlignment = VerticalAlignment.Top;
            buttonCheckAnswers.Visibility = Visibility.Hidden;
            buttonCheckAnswers.Click += showResults;
            renamedGrid.Children.Add(buttonCheckAnswers);

            labelScore = new Label();
            labelScore.Name = nameof(labelScore);
            labelScore.Content = labelScoreString;
            labelScore.SetValue(Grid.ColumnSpanProperty, 2);
            labelScore.Width = labelScoreWidth;
            labelScore.Height = rowheight;
            labelScore.HorizontalAlignment = HorizontalAlignment.Left;
            labelScore.VerticalAlignment = VerticalAlignment.Top;
            labelScore.Visibility = Visibility.Hidden;
            renamedGrid.Children.Add(labelScore);
        }


        private void updateLocations()
        {
            int row = 0;
            labelTableRange.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
            textBoxTableRange.Margin = new Thickness(widthOfset + labelTableRange.Width, heightOfset + rowheight * row, 0, 0);
            row++;

            labelSelectNumberOfTables.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
            textBoxNumberOfTables.Margin = new Thickness(widthOfset + labelSelectNumberOfTables.Width, heightOfset + rowheight * row, 0, 0);
            row++;

            buttonCreateTableTest.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
            row++;

            int numberOfSums = tester.GetNumberOfTables();
            int[,] sums = tester.GetRandomTables();
            emptyLists();

            if (sums != null)
            {
                for (int i = 0; i < numberOfSums; i++)
                {
                    Label newLabelSum = new Label();
                    newLabelSum.Content = sums[i, 0] + multiplySign + sums[i, 1];
                    newLabelSum.Name = nameof(newLabelSum) + i;
                    newLabelSum.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
                    newLabelSum.SetValue(Grid.ColumnSpanProperty, 2);
                    newLabelSum.Width = labelSumWidth;
                    newLabelSum.Height = rowheight;
                    newLabelSum.HorizontalAlignment = HorizontalAlignment.Left;
                    newLabelSum.VerticalAlignment = VerticalAlignment.Top;
                    renamedGrid.Children.Add(newLabelSum);
                    labelsSums.Add(newLabelSum);

                    TextBox newTextbox = new TextBox();
                    newTextbox.TextChanged += numberOnlyTextbox;
                    renamedGrid.Children.Add(newTextbox);
                    newTextbox.Name = nameof(newTextbox)+i;
                    newTextbox.Margin = new Thickness(widthOfset + newLabelSum.Width, heightOfset + rowheight * row, 0, 0);
                    newTextbox.SetValue(Grid.ColumnSpanProperty, 2);
                    newTextbox.Width = textboxWidth;
                    newTextbox.Height = rowheight;
                    newTextbox.HorizontalAlignment = HorizontalAlignment.Left;
                    newTextbox.VerticalAlignment = VerticalAlignment.Top;
                    newTextbox.TextChanged += numberOnlyTextbox;
                    textBoxesAnswers.Add(newTextbox);

                    Label newLabelCorrect = new Label();
                    renamedGrid.Children.Add(newLabelCorrect);
                    newLabelCorrect.Name = nameof(newLabelCorrect) + i;
                    newLabelCorrect.Margin = new Thickness(widthOfset + newLabelSum.Width + newTextbox.Width, heightOfset + rowheight * row, 0, 0);
                    newLabelCorrect.SetValue(Grid.ColumnSpanProperty, 2);
                    newLabelCorrect.Width = labelCorrectWidth;
                    newLabelCorrect.Height = rowheight;
                    newLabelCorrect.HorizontalAlignment = HorizontalAlignment.Left;
                    newLabelCorrect.VerticalAlignment = VerticalAlignment.Top;
                    newLabelCorrect.Visibility = Visibility.Hidden;
                    labelsCorrect.Add(newLabelCorrect);

                    row++;
                }
            }
            buttonCheckAnswers.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
            row++;
            labelScore.Margin = new Thickness(widthOfset, heightOfset + rowheight * row, 0, 0);
        }

        private void emptyLists()
        {
            foreach (Label label in labelsSums)
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
        }

        private void createTest(object sender, EventArgs e)
        {
            try
            {
                buttonCheckAnswers.Visibility = Visibility.Visible;

                int numberOfTables = tryParse(textBoxNumberOfTables.Text);
                if (numberOfTables > 0)
                {
                    tester.SetNumberOfTables(numberOfTables);
                }
                tester.CreateNewTables(tryParse(textBoxTableRange.Text));

                updateLocations();
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
                int[] answers = new int[tester.GetNumberOfTables()];

                for (int i = 0; i < answers.Length; i++)
                {
                    answers[i] = tryParse(textBoxesAnswers[i].Text);
                }
            
                double[] results = tester.GetScore(answers);

                for(int i=0; i < labelsCorrect.Count; i++)
                {
                    labelsCorrect[i].Visibility = Visibility.Visible;
                    if (results[i] > 0)
                    {
                        labelsCorrect[i].Content = correctString;
                    }
                    else
                    {
                        labelsCorrect[i].Content = incorrectString;
                    }
                }

                labelScore.Visibility = Visibility.Visible;
                labelScore.Content = labelScoreString + results[results.Length-1];
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

        private void numbersOnlyTextbox(TextBox textBox)
        {
            char[] text = textBox.Text.ToCharArray();
            string redone = "";
            foreach(char character in text)
            {
                foreach(char number in allowedNumbers)
                {
                    if (character == number)
                    {
                        redone += character;
                        break;
                    }
                }
            }
            textBox.Text = redone;
        }
        private void numberOnlyTextbox(object sender, TextChangedEventArgs e)
        {
            if (typeof(TextBox).IsInstanceOfType(sender))
            {
                numbersOnlyTextbox((TextBox)sender);
            }
        }

        private class emptyInputException : Exception{}
    }
}
