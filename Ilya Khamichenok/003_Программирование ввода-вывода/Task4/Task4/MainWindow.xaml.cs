using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

        public MainWindow()
        {
            this.Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("D:\\TestStore.txt", FileMode.OpenOrCreate, isoStore))
            {
                using (StreamWriter writer = new StreamWriter(isoStream))
                {
                    writer.WriteLine(colorPicker1.SelectedColor);
                }
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = e.NewValue;
            label1.Background = new SolidColorBrush(Color.FromRgb(color.Value.R, color.Value.G, color.Value.B));
            label1.Content = color.Value.ToString();                  
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("D:\\TestStore.txt", FileMode.OpenOrCreate, isoStore))
            {
                using (StreamReader reader = new StreamReader(isoStream))
                {
                    var colorText = reader.ReadToEnd();
                    var color = (Color)ColorConverter.ConvertFromString(colorText);
                    label1.Background = new SolidColorBrush(color);
                    label1.Content = colorText;
                }
            }          
        }

    }
}