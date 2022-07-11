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

namespace WpfCustomControlsLearn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


           // Console.WriteLine("Hello World");


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < solidColorBrushes.Count; i++)
            {
                ((MainGrid.Children[1] as StackPanel).Children[i] as TextBox).Text = new Random().NextDouble().ToString();
            }
        }

        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < solidColorBrushes.Count; i++)
            {
                ((MainGrid.Children[0] as StackPanel).Children[i] as TextBlock).Foreground = solidColorBrushes[i];
            }
            for (int i = 0; i < solidColorBrushes.Count; i++)
            {
                ((MainGrid.Children[1] as StackPanel).Children[i] as TextBox).SelectionBrush = solidColorBrushes[i];
                ((MainGrid.Children[1] as StackPanel).Children[i] as TextBox).Foreground = solidColorBrushes[i];
            }
            GetColors(GetLength());
        }

        private static void GetColors(int length)
        {
            Random random = new Random();
            var result = new List<SolidColorBrush>{ };
            for (int i = 0; i < length; i++)
            {
                result.Add(new SolidColorBrush(
                Color.FromRgb(
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255),
                    (byte)random.Next(0, 255)
                )));
            }
            solidColorBrushes = result;
        }

        private int GetLength()
        {
            int length = 0;
            foreach (var control in (MainGrid.Children[0] as StackPanel).Children)
            {
                if (control is TextBlock)
                {
                    length++;
                }
            }
            return length;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            GetColors(GetLength());
        }

        private static List<SolidColorBrush> solidColorBrushes;
    }
}
