using System;
using System.Windows;

namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FigureRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            side1Label.Visibility = Visibility.Collapsed;
            side1TextBox.Visibility = Visibility.Collapsed;
            side2Label.Visibility = Visibility.Collapsed;
            side2TextBox.Visibility = Visibility.Collapsed;
            side3Label.Visibility = Visibility.Collapsed;
            side3TextBox.Visibility = Visibility.Collapsed;
            radiusLabel.Visibility = Visibility.Collapsed;
            radiusTextBox.Visibility = Visibility.Collapsed;

            if (rectangleRadioButton.IsChecked == true)
            {
                side1Label.Visibility = Visibility.Visible;
                side1TextBox.Visibility = Visibility.Visible;
                side2Label.Visibility = Visibility.Visible;
                side2TextBox.Visibility = Visibility.Visible;
            }
            else if (circleRadioButton.IsChecked == true)
            {
                radiusLabel.Visibility = Visibility.Visible;
                radiusTextBox.Visibility = Visibility.Visible;
            }
            else if (triangleRadioButton.IsChecked == true)
            {
                side1Label.Visibility = Visibility.Visible;
                side1TextBox.Visibility = Visibility.Visible;
                side2Label.Visibility = Visibility.Visible;
                side2TextBox.Visibility = Visibility.Visible;
                side3Label.Visibility = Visibility.Visible;
                side3TextBox.Visibility = Visibility.Visible;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double perimeter = 0;
            string errorMessage = string.Empty;

            if (!rectangleRadioButton.IsChecked.Value && !circleRadioButton.IsChecked.Value && !triangleRadioButton.IsChecked.Value)
            {
                errorMessage = "Не выбран тип фигуры.";
            }
            else if ((rectangleRadioButton.IsChecked == true && (string.IsNullOrEmpty(side1TextBox.Text) || string.IsNullOrEmpty(side2TextBox.Text))) ||
                     (triangleRadioButton.IsChecked == true && (string.IsNullOrEmpty(side1TextBox.Text) || string.IsNullOrEmpty(side2TextBox.Text) || string.IsNullOrEmpty(side3TextBox.Text))) ||
                     (circleRadioButton.IsChecked == true && string.IsNullOrEmpty(radiusTextBox.Text)))
            {
                errorMessage = "Не все поля заполнены.";
            }
            else
            {
                try
                {
                    if (rectangleRadioButton.IsChecked == true)
                    {
                        double side1 = Convert.ToDouble(side1TextBox.Text);
                        double side2 = Convert.ToDouble(side2TextBox.Text);
                        perimeter = 2 * (side1 + side2);
                    }
                    else if (triangleRadioButton.IsChecked == true)
                    {
                        double side1 = Convert.ToDouble(side1TextBox.Text);
                        double side2 = Convert.ToDouble(side2TextBox.Text);
                        double side3 = Convert.ToDouble(side3TextBox.Text);
                        perimeter = side1 + side2 + side3;
                    }
                    else if (circleRadioButton.IsChecked == true)
                    {
                        double radius = Convert.ToDouble(radiusTextBox.Text);
                        perimeter = 2 * Math.PI * radius;
                    }
                    resultLabel.Content = "Периметр = " + perimeter;
                }
                catch (FormatException)
                {
                    errorMessage = "Введены неверные данные.";
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
