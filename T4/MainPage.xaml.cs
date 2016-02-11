using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string result, buttonString;
        double num;
        Size minSize = new Size(800, 500);
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = minSize;
            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;          
        }

        //public void SetPreferredMinSize(Size minSize)

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result = resultTextBox.Text;
            if(result == "0")
            {
                result = result.Substring(0, result.Length - 1);
            }
            buttonString = (((Button)sender).Content).ToString();
            result += buttonString;
            resultTextBox.Text = result;
        }

        private void commaButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultTextBox.Text;
            result += ".";
            resultTextBox.Text = result;
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultTextBox.Text;
            Double.TryParse(result, out num);
            if ((bool)tempRadioButton.IsChecked)
            {
                if (num > 100)
                {
                    errorTextBlock.Text = "Error: Temperature too high!";
                }
                else if (num < 0)
                {
                    errorTextBlock.Text = "Error: Temperature too low!";
                }
                else
                {
                    tempTextBlock.Text = num.ToString("0.00");
                    errorTextBlock.Text = "";
                }
            }
            else
            {
                if (num > 120)
                {
                    errorTextBlock.Text = "Error: Humidity too high!";
                }
                else if (num < 0)
                {
                    errorTextBlock.Text = "Error: Humidity too low!";
                }
                else
                {
                    humiTextBlock.Text = num.ToString("0.00");
                    errorTextBlock.Text = "";
                }
            }
            resultTextBox.Text = "0";
        }
        private void exButton_Click(object sender, RoutedEventArgs e)
        {
            result = resultTextBox.Text;
            result = result.Substring(0, result.Length - 1);
            if(result == "")
            {
                result = "0";
            }
            resultTextBox.Text = result;
        }
    }
}
