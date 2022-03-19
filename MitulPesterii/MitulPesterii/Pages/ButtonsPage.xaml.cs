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

namespace MitulPesterii.Pages
{
    /// <summary>
    /// Interaction logic for ButtonsPage.xaml
    /// </summary>
    public partial class ButtonsPage : Page
    {

        public ButtonsPage()
        {
            InitializeComponent();

            DesprePlaton.Click += Button_Click;
            Film.Click += Button_Click;
            Fragment.Click += Button_Click;
            Palarii.Click += Button_Click;
            Dictionar.Click += Button_Click;
            Evaluare.Click += Button_Click;
            

        }

        /// <summary>
        /// Marking the pressed button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(DesprePlaton))
            {
                DesprePlaton.Opacity = 0.75;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
            }
            if (sender.Equals(Film))
            {
                DesprePlaton.Opacity = 1;
                Film.Opacity = 0.75;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
            }
            if (sender.Equals(Fragment))
            {
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 0.75;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
            }
            if (sender.Equals(Palarii))
            {
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 0.75;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
            }
            if (sender.Equals(Dictionar))
            {
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 0.75;
                Evaluare.Opacity = 1;
            }
            if (sender.Equals(Evaluare))
            {
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 0.75;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            double n, offset;

            // Calculating from how far does it have to come the animations
            n = (double)2 / 7;
            offset = MainWindowSize.MainWindowWidth * n;

            await Animations.SlideAndFadeInFromLeft(this, 1, offset);
        }
    }
}
