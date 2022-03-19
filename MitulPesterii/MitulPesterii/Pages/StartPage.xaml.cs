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
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;

            this.DataContext = new StartPageViewModel();
            
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            double n, offset;

            // Calculating from how far does it have to come the animations
            n = (double)5 / 7;
            offset = MainWindowSize.MainWindowWidth * n;

            await Animations.SlideAndFadeInFromRight(this, 1, offset);
        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            await Animations.SlideAndFadeInFromRight(this, 1, Calculations.ContentFrameWidthFormula());
        }
    }
}
