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

namespace RGBSzinkevero
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender,
            RoutedPropertyChangedEventArgs<double> e)
        {
            FrissitSzin();
        }

        private void FrissitSzin()
        {
            int r = (int)sliderR.Value;
            int g = (int)sliderG.Value;
            int b = (int)sliderB.Value;

            tbR.Text = $"R: {r}";
            tbG.Text = $"G: {g}";
            tbBl.Text = $"B: {b}";

            tbRGB.Text = $"RGB({r}, {g}, {b})";
            tbHex.Text = $"#{r:X2}{g:X2}{b:X2}";
       
            var szinR = Color.FromRgb((byte)r, 0, 0);
            var szinG = Color.FromRgb(0, (byte)g, 0);
            var szinB = Color.FromRgb(0, 0, (byte)b);

            rectR.Fill = new SolidColorBrush(szinR);
            rectG.Fill = new SolidColorBrush(szinG);
            rectB.Fill = new SolidColorBrush(szinB);

            var vegSzin = Color.FromRgb((byte)r, (byte)g, (byte)b);
            previewCanvas.Background = new SolidColorBrush(vegSzin);
        }
         
        private void Check_Changed(object sender, RoutedEventArgs e)
        {
            tbHex.Visibility = checkHex.IsChecked == true
                ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            sliderR.Value = 0;
            sliderG.Value = 0;
            sliderB.Value = 0;
        }

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            sliderR.Value = rnd.Next(0, 256);
            sliderG.Value = rnd.Next(0, 256);
            sliderB.Value = rnd.Next(0, 256);
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(tbHex.Text);
            MessageBox.Show("HEX kód másolva: " + tbHex.Text);
        }
    }
}