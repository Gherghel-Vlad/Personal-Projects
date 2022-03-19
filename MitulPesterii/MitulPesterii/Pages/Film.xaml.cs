using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace MitulPesterii.Pages
{
    /// <summary>
    /// Interaction logic for Film.xaml
    /// </summary>
    public partial class Film : Page
    {
        // Shows the button image and function
        private int ok = 0;

        public delegate void timerTick();
        DispatcherTimer ticks = new DispatcherTimer();
        timerTick tick;

        private TimeSpan videoTime = new TimeSpan(0, 0, 0, 0);
        public Film()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;

            VideoME.Play();
            VideoME.Stop();
            TimeSlider.Value = 0;
            VolumSlider.Value = 1;
            VideoME.MediaOpened += VideoME_MediaOpened;
        }

        /// <summary>
        /// Sets the values for the sliders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoME_MediaOpened(object sender, RoutedEventArgs e)
        {
            VideoME.Volume = (double)VolumSlider.Value;
            TimeSlider.Maximum = VideoME.NaturalDuration.TimeSpan.TotalSeconds;

            ticks.Interval = TimeSpan.FromSeconds(1);
            ticks.Tick += ticks_Tick;
            tick = new timerTick(changeStatus);
            ticks.Start();



        }

        /// <summary>
        /// This is happening every 1 s (the timer)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void changeStatus()
        {

            TimeSlider.Value = VideoME.Position.TotalSeconds;

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
                PlayPauseImg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/VideoIcons/StopIcon.png", UriKind.Absolute));
                VideoME.Position = videoTime;
                VideoME.Play();
                ok = 1;
            }
            else
            {
                PlayPauseImg.Source = new BitmapImage(new Uri(@"pack://application:,,,/Images/VideoIcons/PlayIcon.png", UriKind.Absolute));
                ok = 0;
                videoTime = VideoME.Position;
                VideoME.Pause();
            }
        }

        private void TimeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            int SliderValue = (int)TimeSlider.Value;

            TimeSpan ts = new TimeSpan(0, 0, 0, SliderValue);
            VideoME.Position = ts;
            videoTime = ts;
        }

        void ticks_Tick(object sender, object e)
        {
            Dispatcher.Invoke(tick);
        }
    }
}
