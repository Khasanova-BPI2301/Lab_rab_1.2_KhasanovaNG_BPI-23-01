using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using L_R_1._2_Khasanova_BPI_23_01.Classes;

namespace L_R_1._2_Khasanova_BPI_23_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Income { get; set; }
        public double Expense { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != "-")
            {
                e.Handled = true;
            }
        }

        private void SpaceValidationTextBox(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FullName = fullNameBox.Text.Trim();
                Age = int.Parse(ageBox.Text);
                Gender = genderBox.Text.Trim().ToUpper();
                Income = double.Parse(incomeBox.Text);
                Expense = double.Parse(expenseBox.Text);

                if (Gender != "М" && Gender != "Ж")
                {
                    resultText.Text = "Ошибка: пол должен быть 'М' или 'Ж'.";
                    return;
                }

                if (Income < 0 || Expense < 0)
                {
                    resultText.Text = "Ошибка: доход и расход не могут быть отрицательными.";
                    return;
                }

                Person person = null;
                string selectedType = (personTypeBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                switch (selectedType)
                {
                    case "Дошкольник":
                        person = new Preschooler(FullName, Age, Gender, Income, Expense);
                        break;

                    case "Школьник":
                        person = new Schoolchild(FullName, Age, Gender, Income, Expense);
                        break;

                    case "Студент":
                        person = new Student(FullName, Age, Gender, Income, Expense);
                        break;

                    case "Работающий":
                        person = new Worker(FullName, Age, Gender, Income, Expense);
                        break;
                    default:
                        resultText.Text = "Ошибка: выберите тип человека.";
                        return;
                }

                double avgIncome = person.GetAverageIncome();
                double avgExpense = person.GetAverageExpense();

                resultText.Text = $"{person.GetInfo()}\n" +
                    $"Средний доход в месяц: {avgIncome:F2} руб.\n" +
                    $"Средний расход в месяц: {avgExpense:F2} руб.";
            }

        }

    }
}