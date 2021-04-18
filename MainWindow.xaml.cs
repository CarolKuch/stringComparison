using System.Windows;
using System.Windows.Input;
namespace zad2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string firstUsersString = "";
        private string secondUsersString = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            firstUsersString = FirstTextBox.Text;
            secondUsersString = SecondTextBox.Text;
            WordsComparer wordsComparer = new WordsComparer(firstUsersString, secondUsersString);
            AnswerTextLabel.Content = wordsComparer.describeDifferencesBetweenWords();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_DELETE(object sender, RoutedEventArgs e)
        {
            FirstTextBox.Text = "";
            SecondTextBox.Text = "";
            AnswerTextLabel.Content = "";
        }
    }
}
