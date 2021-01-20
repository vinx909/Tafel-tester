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
        private const string selectNumberBetweenString = "Vul hat hoogste getal in dat gebruikt mag wording in de sommen";
        private const string buttonCreateTableTestString = "Maak sommen";
        private const string correctString = "Goed";
        private const string incorrectString = "Fout";
        private const string scoreTextString = "je hebt een ";
        private const string empty = "";

        private const int leftOfset = 50;
        private const int heightOfset = 10;
        private const int rowheight = 20;
        private const int parsefailpushtrough = 0;
        private Label labelTableRange;
        private TextBox textBoxTableRange;
        private Button buttonCreateTableTest;

        private TableTester tester;

        public MainWindow()
        {
            InitializeComponent();
            tester = new TableTester();

            setUpTest();

            textboxUpperrange.Text = empty;
            //createComponents();
            //updateLocations();
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

        /*
private void createComponents()
{
   labelTableRange = new Label();
   labelTableRange.Content = selectNumberBetweenString;
   grid.Children.Add(labelTableRange);
   Canvas.SetLeft(labelTableRange, leftOfset);

   textBoxTableRange = new TextBox();
   grid.Children.Add(textBoxTableRange);
   Canvas.SetLeft(textBoxTableRange, leftOfset + labelTableRange.Width);

   buttonCreateTableTest = new Button();
   buttonCreateTableTest.Content = buttonCreateTableTestString;
   buttonCreateTableTest.Click += createTest;
   grid.Children.Add(buttonCreateTableTest);
   Canvas.SetLeft(buttonCreateTableTest, leftOfset);
}


private void updateLocations()
{
   int row = 0;
   Canvas.SetTop(labelTableRange, heightOfset);
   Canvas.SetTop(textBoxTableRange, heightOfset);
   row++;
   Canvas.SetTop(buttonCreateTableTest, heightOfset + row * rowheight);
}
*/

        private int updateQuestionfields()
        {
            throw new NotImplementedException(); ;
        }
        private void createTest(object sender, EventArgs e)
        {
            setUpTest();

            tester.CreateNewTables(tryParse(textboxUpperrange.Text));
            int[,] tables = tester.GetRandomTables();

            labelSum0.Content = tables[0, 0] + "x" + tables[0, 1];
            labelSum1.Content = tables[1, 0] + "x" + tables[1, 1];
            labelSum2.Content = tables[2, 0] + "x" + tables[2, 1];
            labelSum3.Content = tables[3, 0] + "x" + tables[3, 1];
            labelSum4.Content = tables[4, 0] + "x" + tables[4, 1];
        }

        private void showResults(object sender, EventArgs e)
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
            labelScore.Content = scoreTextString + results[5];
        }

        private int tryParse(string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch
            {
                return parsefailpushtrough;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createTest(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showResults(sender, e);
        }
    }
}
