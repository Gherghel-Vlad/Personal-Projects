using MitulPesterii.Pages;
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
using System.Windows.Threading;

namespace MitulPesterii
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public delegate void timerTick();
        DispatcherTimer ticks = new DispatcherTimer();
        timerTick tick;


        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);

            this.SizeChanged += MainWindow_SizeChanged;

            DesprePlaton.Click += Button_Click;
            Film.Click += Button_Click;
            Fragment.Click += Button_Click;
            Palarii.Click += Button_Click;
            Dictionar.Click += Button_Click;
            Evaluare.Click += Button_Click;


            ticks.Interval = TimeSpan.FromSeconds(1);
            ticks.Tick += ticks_Tick;
            tick = new timerTick(changeStatus);
            ticks.Start();



        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowSize.MainWindowWidth = this.Width;
            MainWindowSize.MainWindowHeight = this.Height;
        }


        /// <summary>
        /// Creating the "PRESSED" effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(DesprePlaton))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 0.75;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = false;
                Film.IsEnabled = true;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = true;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                ContentFrame.NavigationService.Navigate(new Uri("Pages/DesprePlatonPage.xaml", UriKind.Relative));
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));

            }
            if (sender.Equals(Film))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 1;
                Film.Opacity = 0.75;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = false;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = true;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                ContentFrame.NavigationService.Navigate(new Uri("Pages/Film.xaml", UriKind.Relative));
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));
            }
            if (sender.Equals(Fragment))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 0.75;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = true;
                Fragment.IsEnabled = false;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = true;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));
                ContentFrame.NavigationService.Navigate(new Uri("Pages/Fragment.xaml", UriKind.Relative));
            }
            if (sender.Equals(Palarii))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 0.75;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 1;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = true;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = false;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = true;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));
                ContentFrame.NavigationService.Navigate(new Uri("Pages/Palarii.xaml", UriKind.Relative));
            }
            if (sender.Equals(Dictionar))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 0.75;
                Evaluare.Opacity = 1;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = true;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = false;
                Evaluare.IsEnabled = true;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));
                ContentFrame.NavigationService.Navigate(new Uri("Pages/Dictionar.xaml", UriKind.Relative)); 
            }
            if (sender.Equals(Evaluare))
            {
                #region Button's opacity
                DesprePlaton.Opacity = 1;
                Film.Opacity = 1;
                Fragment.Opacity = 1;
                Palarii.Opacity = 1;
                Dictionar.Opacity = 1;
                Evaluare.Opacity = 0.75;
                #endregion
                #region Button's enabled
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = true;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = false;
                #endregion
                await Animations.SlideAndFadeOutAFrameToRight(ContentFrame, 0.8, MainWindowSize.MainWindowWidth);
                MainGrid.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/OldPaperBackgroundForVideo.png", UriKind.Absolute)));
                ContentFrame.NavigationService.Navigate(new Uri("Pages/Evaluare.xaml", UriKind.Relative));
            }
        }

        /// <summary>
        /// Creating the animation for the ScrollViewer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AppWindow_Loaded(object sender, RoutedEventArgs e)
        {

            double n, offset;

            // Calculating from how far does it have to come the animations
            n = (double)2 / 7;
            offset = MainWindowSize.MainWindowWidth * n;

            await Animations.SlideAndFadeInFromLeftScrollViewer(SV, 1, offset);
        }

        /// <summary>
        /// Changes the buttons property IsEnabled depending on the property from MenuButtonsIsEnabled
        /// </summary>
        private void changeStatus()
        {

            if (MenuButtonsEnabled.CanPressMenuButtons)
            {
                DesprePlaton.IsEnabled = true;
                Film.IsEnabled = true;
                Fragment.IsEnabled = true;
                Palarii.IsEnabled = true;
                Dictionar.IsEnabled = true;
                Evaluare.IsEnabled = true;
            }
            else
            {
                DesprePlaton.IsEnabled = false;
                Film.IsEnabled = false;
                Fragment.IsEnabled = false;
                Palarii.IsEnabled = false;
                Dictionar.IsEnabled = false;
                Evaluare.IsEnabled = false;
            }
        }

        void ticks_Tick(object sender, object e)
        {
            Dispatcher.Invoke(tick);
        }
    }
}
