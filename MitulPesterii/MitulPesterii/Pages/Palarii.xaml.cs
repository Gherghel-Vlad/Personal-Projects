using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MitulPesterii.Pages
{
    /// <summary>
    /// Interaction logic for Palarii.xaml
    /// </summary>
    public partial class Palarii : Page
    {
        #region Texts

        private string whitehattext1 = "Salut! \nAlbul e culoarea mea! Spun doar adevărul! Sunt obiectivă și neutră.";
        private string whitehattext2 = "Secretul meu? \nSunt disciplinată, directă, mă concentrez strict pe problema discutată, relatez exact faptele.";

        private string blackhattext1 = "Salut! \nNegrul e culoarea mea! Te avertizez! Cred că greșești și ești cam pripit. ";
        private string blackhattext2 = "Secretul meu? \nSunt critică și în căutarea erorilor. Fii atent la pericole, sunt la tot pasul!";

        private string yellowhattext1 = "Salut! \nGalbenul e culoarea mea! Îți Ofer sugestii, propuneri, îți indic avantajele. ";
        private string yellowhattext2 = "Secretul meu? \nSunt plină de speranță! În toate găsesc ceva bun și valoros.";

        private string redhattext1 = "Salut! \nRoșul e culoarea mea! Spun tot ce simt, nu-mi pasă ce gândești!";
        private string redhattext2 = "Secretul meu? \nSunt impulsivă și focoasă, veselă sau furioasă, ";

        private string greenhattext1 = "Salut! \nVerdele e culoarea mea! Există mai multe soluții la problemă, adevărul nu e doar la mine, e la NOI! ";
        private string greenhattext2 = "Secretul meu? \nSunt Socrate al pălăriilor! Sunt creativ! ";

        private string bluehattext1 = "Salut! \nAlbastrul e culoarea mea! Sunt dirijorul pălăriilor, definesc problema și monitorizez activitatea.";
        private string bluehattext2 = "Secretul meu? \nSunt responsabilă, organizez întreaga activitate!";

        #endregion

        #region Properties

        // Helps with the timeslider
        public delegate void timerTick();
        DispatcherTimer ticks = new DispatcherTimer();
        timerTick tick;


        // Has all the hat buttons in it
        private List<Button> buttons;

        // The list that has all the video buttons
        private List<Button> videoButtons;

        // Keeps the last button pressed
        private Button lastButtonPressed;

        // The video time
        private TimeSpan videoTime = new TimeSpan(0, 0, 0, 0);
        private int ok = 0;

        // Total time of the video
        private TimeSpan totalTime;


        // This means how much does the first, second and third row hats have to go down
        private int firstRowHeight;
        private int secondRowHeight;
        private int thirdRowHeight;

        #endregion

        public Palarii()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;


            lastButtonPressed = new Button();
            buttons = new List<Button>();
            videoButtons = new List<Button>();

            // Adding the video buttons
            videoButtons.Add(PlayPauseBtn);
            videoButtons.Add(GoBackward);
            videoButtons.Add(GoForward);
            

            // Setting the video slides and everything
            VideoME.Position = new TimeSpan(0, 0, 0, 1);
            VideoME.Play();
            VideoME.Stop();
            TimeSlider.Value = 0;
            VolumSlider.Value = 1;
            VideoME.MediaOpened += VideoME_MediaOpened;

            // Adding the hat buttons
            buttons.Add(WhiteHatBtn);
            buttons.Add(BlackHatBtn);
            buttons.Add(RedHatBtn);
            buttons.Add(BlueHatBtn);
            buttons.Add(GreenHatBtn);
            buttons.Add(YellowHatBtn);

            lastButtonPressed = new Button();
            lastButtonPressed = null;

            LeftScrollGrid.Visibility = Visibility.Hidden;
            RightScrollGrid.Visibility = Visibility.Hidden;

            // This means how much does the first, second and third row hats have to go down
            firstRowHeight = 340;
            secondRowHeight = 125;
            thirdRowHeight = -75;

            // Adding the click movement for a hat button
            foreach (var btn in buttons)
            {
                btn.Click += Btn_Click;
            }

            // Helps with the timeslider to be responsive
            ticks.Interval = TimeSpan.FromSeconds(1);
            ticks.Tick += ticks_Tick;
            tick = new timerTick(changeStatus);
            ticks.Start();

        }

        private async void Btn_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation;
            DoubleAnimation heightAnimation;
            ThicknessAnimation thicknessAnimation;
            double n;
            double n2;
            Storyboard sb;
            Button btn = sender as Button;
            

            // Setting the Enabled property
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
            }


            // Setting the video
            VideoME.Source = new Uri(GetGirlVideoForButton(btn), UriKind.Relative);
            VideoME.Play();
            TimeSlider.Value = 0;
            VideoME.MediaOpened += VideoME_MediaOpened;
            PlayPauseImg.Source = new BitmapImage(new Uri("/Images/VideoIcons/PlayIcon.png", UriKind.Relative));
            ok = 0;
            videoTime = new TimeSpan(0, 0, 0, 0);

            // Setting the scrolls
            RightScrollGrid.Visibility = Visibility.Visible;
            LeftScrollGrid.Visibility = Visibility.Visible;
            RightScrollTB.Text = GetTextForRightScroll(btn);
            LeftScrollTB.Text = GetTextForLeftScroll(btn);

            // If there is an a hat already, make it so it goes back
            if (lastButtonPressed != null)
            {
                n = ((double)(8) / 10) * MainWindowSize.MainWindowWidth;
                n2 = ((double)(4) / 6) * n;

                sb = new Storyboard();

                // The width animation
                if (lastButtonPressed.Equals(WhiteHatBtn) || lastButtonPressed.Equals(YellowHatBtn) || lastButtonPressed.Equals(BlackHatBtn))
                {
                    widthAnimation = new DoubleAnimation()
                    {
                        Duration = TimeSpan.FromSeconds(1),
                        To = 0,
                        From = n2 / 2 + (((double)(1) / 6) * n) / 2,
                        AccelerationRatio = 0.9f
                    };
                }
                else
                {
                    widthAnimation = new DoubleAnimation()
                    {
                        Duration = TimeSpan.FromSeconds(1),
                        To = 0,
                        From = -(n2 / 2 + (((double)(1) / 6) * n) / 2),
                        AccelerationRatio = 0.9f
                    };
                }


                // The thickness animation
                thicknessAnimation = new ThicknessAnimation()
                {
                    Duration = TimeSpan.FromSeconds(1),
                    From = new Thickness(45),
                    To = new Thickness(25),
                    AccelerationRatio = 0.9f
                };

                // The height animation
                heightAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(1),
                    To = 0,
                    From = GetHeightMovementForButton(lastButtonPressed),
                    AccelerationRatio = 0.9f
                };

                // Adding the animations
                sb.Children.Add(widthAnimation);
                sb.Children.Add(heightAnimation);
                sb.Children.Add(thicknessAnimation);

                //Setting the animations
                Storyboard.SetTargetName(widthAnimation, GetNameOfTTForButton(lastButtonPressed));
                Storyboard.SetTargetName(heightAnimation, GetNameOfTTForButton(lastButtonPressed));
                Storyboard.SetTargetName(thicknessAnimation, lastButtonPressed.Name);

                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("X"));
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("Y"));
                Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Padding"));

                // Changing back to the girl with no hat and the button to be visible
                GirlImg.ImageSource = new BitmapImage(new Uri("Images/The girl/GirlNoHat.png", UriKind.Relative));
                lastButtonPressed.Visibility = Visibility.Visible;

                // Starting the animation
                sb.Begin(lastButtonPressed);
                
            }





            // Animating the button to go in the middle of the screen

            lastButtonPressed = btn;

            sb = new Storyboard();

            // Calculating the width for the animation
            n = ((double)(8) / 10) * MainWindowSize.MainWindowWidth;
            n2 = ((double)(4) / 6) * n;
            

            // THe width animation depending on where the button is
            if (btn.Equals(WhiteHatBtn) || btn.Equals(YellowHatBtn) || btn.Equals(BlackHatBtn))
            {
                widthAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(1),
                    From = 0,
                    To = n2 / 2 + (((double)(1) / 6) * n) / 2,
                    AccelerationRatio = 0.9f
                };
            }
            else
            {
                widthAnimation = new DoubleAnimation()
                {
                    Duration = TimeSpan.FromSeconds(1),
                    From = 0,
                    To = -(n2 / 2 + (((double)(1) / 6) * n) / 2),
                    AccelerationRatio = 0.9f
                };
            }

            // The height animation
            heightAnimation = new DoubleAnimation()
            {
                Duration = TimeSpan.FromSeconds(1),
                From = 0,
                To = GetHeightMovementForButton(btn),
                AccelerationRatio = 0.9f
            };

            thicknessAnimation = new ThicknessAnimation()
            {
                Duration = TimeSpan.FromSeconds(1),
                From = new Thickness(25),
                To = new Thickness(45),
                AccelerationRatio = 0.9f
            };

            // Adding the animations
            sb.Children.Add(widthAnimation);
            sb.Children.Add(heightAnimation);
            sb.Children.Add(thicknessAnimation);


            //Setting the animations
            Storyboard.SetTargetName(widthAnimation, GetNameOfTTForButton(btn));
            Storyboard.SetTargetName(heightAnimation, GetNameOfTTForButton(btn));
            Storyboard.SetTargetName(thicknessAnimation, btn.Name);

            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("X"));
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("Y"));
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Padding"));

            // Starting the animation
            sb.Begin(btn);

            // Waiting for the animation to finish
            await Task.Delay(1100);

            VideoME.Stop();
            // Changing the pic to the girl with the respective hat
            GirlImg.ImageSource = new BitmapImage(new Uri(GetGirlImageForButton(btn), UriKind.Relative));

            // Setting the Enabled property
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
            btn.IsEnabled = false;

            // Hide the button so that only the pic will be seen
            btn.Visibility = Visibility.Hidden;
        }



        #region Helpers


        //Helps with the timeslider
        void ticks_Tick(object sender, object e)
        {
            Dispatcher.Invoke(tick);
        }
        void changeStatus()
        {
            TimeSlider.Value = VideoME.Position.TotalSeconds;
        }


        /// <summary>
        /// Returns the height that needs a hat button go down
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public int GetHeightMovementForButton(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return firstRowHeight;
                case "BlueHatBtn":
                    return firstRowHeight;
                case "BlackHatBtn":
                    return secondRowHeight;
                case "GreenHatBtn":
                    return secondRowHeight;
                case "YellowHatBtn":
                    return thirdRowHeight;
                case "RedHatBtn":
                    return thirdRowHeight;
                default: return 50;
            }
        }

        /// <summary>
        /// Returns the path to the girl video that it needs to have
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public string GetGirlVideoForButton(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return "Videos/WhiteHatVideo.mp4";
                case "BlueHatBtn":
                    return "Videos/BlueHatVideo.mp4";
                case "BlackHatBtn":
                    return "Videos/BlackHatVideo.mp4";
                case "GreenHatBtn":
                    return "Videos/GreenHatVideo.mp4";
                case "YellowHatBtn":
                    return "Videos/YellowHatVideo.mp4";
                case "RedHatBtn":
                    return "Videos/RedHatVideo.mp4";
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Returns the path to the girl image that it needs to have
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public string GetGirlImageForButton(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return "Images/The girl/GirlWithWhiteHat.png";
                case "BlueHatBtn":
                    return "Images/The girl/GirlWithBlueHat.png";
                case "BlackHatBtn":
                    return "Images/The girl/GirlWithBlackHat.png";
                case "GreenHatBtn":
                    return "Images/The girl/GirlWithGreenHat.png";
                case "YellowHatBtn":
                    return "Images/The girl/GirlWithYellowHat.png";
                case "RedHatBtn":
                    return "Images/The girl/GirlWithRedHat.png";
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Returns the name as a string of a Translate Transform for a button
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public string GetNameOfTTForButton(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return "WhiteHatTT";
                case "BlueHatBtn":
                    return "BlueHatTT";
                case "BlackHatBtn":
                    return "BlackHatTT";
                case "GreenHatBtn":
                    return "GreenHatTT";
                case "YellowHatBtn":
                    return "YellowHatTT";
                case "RedHatBtn":
                    return "RedHatTT";
                default: return String.Empty;
            }
        }

          /// <summary>
        /// Returns the text for the left scroll based on the button sent
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public string GetTextForLeftScroll(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return whitehattext1;
                case "BlueHatBtn":
                    return bluehattext1;
                case "BlackHatBtn":
                    return blackhattext1;
                case "GreenHatBtn":
                    return greenhattext1;
                case "YellowHatBtn":
                    return yellowhattext1;
                case "RedHatBtn":
                    return redhattext1;
                default: return String.Empty;
            }
        }

        /// <summary>
        /// Returns the text for the right scroll based on the button sent
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        public string GetTextForRightScroll(Button btn)
        {
            switch (btn.Name)
            {
                case "WhiteHatBtn":
                    return whitehattext2;
                case "BlueHatBtn":
                    return bluehattext2;
                case "BlackHatBtn":
                    return blackhattext2;
                case "GreenHatBtn":
                    return greenhattext2;
                case "YellowHatBtn":
                    return yellowhattext2;
                case "RedHatBtn":
                    return redhattext2;
                default: return String.Empty;
            }
        }


        #endregion


        #region Video buttons 

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            videoTime = VideoME.Position;
            VideoME.Stop();
        }
        /// <summary>
        /// Sets the time of the video to go forward with 5 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoForward_Click(object sender, RoutedEventArgs e)
        {

            TimeSpan ts = new TimeSpan(0, 0, 0, 5);
            if (VideoME.Position < new TimeSpan(0, 0, 4, 16))
            {
                VideoME.Position += ts;
                videoTime += ts;
            }
        }

        /// <summary>
        /// Sets the time of the video to go backward with 5 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackward_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 5);
            if (VideoME.Position > new TimeSpan(0, 0, 0, 5))
            {
                VideoME.Position -= ts;
                videoTime -= ts;
            }
        }

        /// <summary>
        /// Connects te volume slider to the video's volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoME.Volume = (double)VolumSlider.Value;
        }

        /// <summary>
        /// Connects the time of the video with the time slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await Task.Delay(500);
            int SliderValue = (int)TimeSlider.Value;

            TimeSpan ts = new TimeSpan(0, 0, 0, SliderValue);
            VideoME.Position = ts;
            videoTime = ts;
        }

        /// <summary>
        /// Sets the functions for the play/pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayPauseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ok == 0)
            {
                PlayPauseImg.Source = new BitmapImage(new Uri("/Images/VideoIcons/StopIcon.png", UriKind.Relative));
                VideoME.Position = videoTime;
                VideoME.Play();
                ok = 1;
            }
            else
            {
                PlayPauseImg.Source = new BitmapImage(new Uri("/Images/VideoIcons/PlayIcon.png", UriKind.Relative));
                ok = 0;
                videoTime = VideoME.Position;
                VideoME.Pause();
            }
        }

        /// <summary>
        /// When the video has opened it sets everything related to time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoME_MediaOpened(object sender, RoutedEventArgs e)
        {
            if(VideoME.NaturalDuration.HasTimeSpan)
                totalTime = VideoME.NaturalDuration.TimeSpan;
            
            VideoME.Volume = (double)VolumSlider.Value;
            TimeSlider.Maximum = VideoME.NaturalDuration.TimeSpan.TotalSeconds;

            // Create a timer that will update the counters and the time slider
            //var timerVideoTime = new DispatcherTimer();
            //timerVideoTime.Interval = TimeSpan.FromSeconds(1);
            //timerVideoTime.Tick += new EventHandler(timer_Tick);
            //timerVideoTime.Start();
        }


        void timer_Tick(object sender, EventArgs e)
        {
            // Check if the video finished calculate its total time
            if (VideoME.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (totalTime.TotalSeconds > 0)
                {
                    // Updating time slider
                    TimeSlider.Value = VideoME.Position.TotalSeconds /
                                       totalTime.TotalSeconds;
                }
            }
        }


        /// <summary>
        /// Happens when the thumb is moved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            int SliderValue = (int)TimeSlider.Value;

            TimeSpan ts = new TimeSpan(0, 0, 0, SliderValue);
            VideoME.Position = ts;
            videoTime = ts;
        }

        #endregion

        private void WhiteHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlackHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YellowHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GreenHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlueHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RedHatBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
