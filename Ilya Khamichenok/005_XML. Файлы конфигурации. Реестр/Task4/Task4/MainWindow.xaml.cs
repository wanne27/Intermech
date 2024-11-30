using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        public MainWindow()
        {
            this.Loaded += MainWindow_Loaded;
            InitializeComponent();            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(IsTextAllowed(texbox1.Text))
            {
                text1.FontSize = Double.Parse(texbox1.Text);
            }
        }

        private void FillFontComboBox(ComboBox comboBoxFonts)
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                comboBoxFonts.Items.Add(fontFamily.Source);
            }

            comboBoxFonts.SelectedIndex = 0;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            FillFontComboBox(comboBoxFont);
            var setting = SaveSetting.GetSettingFromRegistry();
            colorPicker1.SelectedColor = (Color)ColorConverter.ConvertFromString(setting["colorPicker1"]);
            colorPicker2.SelectedColor = (Color)ColorConverter.ConvertFromString(setting["colorPicker2"]);
            texbox1.Text = setting["texbox1"];
            comboBoxFont.Text = setting["comboBoxFont"];
        }

        private void comboBoxFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox senderComboBox = (ComboBox)sender;
            if (senderComboBox.SelectedIndex > 0)
            {
                text1.FontFamily = new FontFamily(senderComboBox.SelectedItem.ToString());
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = e.NewValue;
            text1.Background = new SolidColorBrush(Color.FromRgb(color.Value.R, color.Value.G, color.Value.B));
        }

        private void ColorPicker_SelectedColorChanged2(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            var color = e.NewValue;
            text1.Foreground = new SolidColorBrush(Color.FromRgb(color.Value.R, color.Value.G, color.Value.B));
        }

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var setting = new Dictionary<string,string>();
            setting.Add("colorPicker1", colorPicker1.SelectedColor.ToString());
            setting.Add("colorPicker2", colorPicker2.SelectedColor.ToString());
            setting.Add("texbox1", texbox1.Text);
            setting.Add("comboBoxFont", comboBoxFont.Text);

            SaveSetting.SaveSettingToConfigFile(setting);
            SaveSetting.SaveSettingToRegistry(setting);
        }
    }
}