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

namespace T3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int draws, loop = 1, max;
        bool result;
        lottoNumberGen lNG = new lottoNumberGen();
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);
        }

        private void lottoButton_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 0;
            comboBox.IsDropDownOpen = false;
        }

        private void vikingButton_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 1;
            comboBox.IsDropDownOpen = false;
        }
        private void euroButton_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 2;
            comboBox.IsDropDownOpen = false;
        }

        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            int choise;
            result = int.TryParse(drawTextBox.Text, out draws);
            if (result)
            {
                choise = comboBox.SelectedIndex;
                do
                {
                    numbersTextBlock.Text += "\nRow " + loop + ": ";
                    switch (choise)
                    {
                        case 0: max = 39;
                            numbersTextBlock.Text += lNG.generateLotto(max, 7);
                            break;
                        case 1: max = 48;
                            numbersTextBlock.Text += lNG.generateLotto(max, 6);
                            break;
                        case 2: max = 50;
                            numbersTextBlock.Text += lNG.generateLotto(max, 5);
                            numbersTextBlock.Text += lNG.generateStars();
                            break;
                    }

                    loop++;
                    draws--;
                } while (draws > 0);
            }
            else
            {
                numbersTextBlock.Text = "Give a number";
                loop = 1;
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numbersTextBlock.Text = "";
            loop = 1;
        }
    }
}
