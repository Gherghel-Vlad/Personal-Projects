using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MitulPesterii
{
    public static class Animations
    {

        #region Page animations

        /// <summary>
        /// Slides and fades in a page to left in seconds
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(Page page, double seconds, double offset)
        {
            page.Visibility = Visibility.Collapsed;

            // Creates the storyboard
            Storyboard sb = new Storyboard();

            // Creating the slide animation
            var anim = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                AccelerationRatio = 0.9f
            };

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Setting the slide property
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(anim);
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Slides and fades out a page to left in seconds
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(Page page, double seconds, double offset)
        {
            
            // Creates the storyboard
            Storyboard sb = new Storyboard();

            // Creating the slide animation
            var anim = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                AccelerationRatio = 0.9f
            };

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // Setting the slide property
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(anim);
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Slides and fades in a page to right in seconds
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeft(Page page, double seconds, double offset)
        {
            page.Visibility = Visibility.Collapsed;

            // Creates the storyboard
            Storyboard sb = new Storyboard();

            // Creating the slide animation
            var anim = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                AccelerationRatio = 0.9f
            };

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Setting the slide property
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(anim);
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region ScrollViewer animations

        /// <summary>
        /// Slides and fades in a scrollviewer to right in seconds
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftScrollViewer(ScrollViewer sv, double seconds, double offset)
        {
            sv.Visibility = Visibility.Collapsed;

            // Creates the storyboard
            Storyboard sb = new Storyboard();

            // Creating the slide animation
            var anim = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                AccelerationRatio = 0.9f
            };

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Setting the slide property
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(anim);
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(sv);

            //Make the page visible
            sv.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Frame animations

        /// <summary>
        /// Slides and fades out a frame to right in seconds
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAFrameToRight(Frame frame, double seconds, double offset)
        {

            // Creates the storyboard
            Storyboard sb = new Storyboard();

            // Solved the fade in/out problem of the page and frame... finally...
            sb.AutoReverse = true;

            

            // Creating the slide animation
            var anim = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                AccelerationRatio = 0.9f

            };

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // Setting the slide property
            Storyboard.SetTargetProperty(anim, new PropertyPath("Margin"));

            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(anim);
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(frame);

            //Make the page visible
            frame.Visibility = Visibility.Visible;

            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));

        }

        /// <summary>
        /// Fades out a frame in seconds
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task FadeOutAFrame(Frame frame, double seconds, double offset)
        {

            // Creates the storyboard
            Storyboard sb = new Storyboard();

            sb.AutoReverse = true;

            // Creating the fade animation
            var fadeAnim = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };
            
            // Setting the fade property
            Storyboard.SetTargetProperty(fadeAnim, new PropertyPath("Opacity"));

            // Adding the animations
            sb.Children.Add(fadeAnim);

            //Begining the animations
            sb.Begin(frame);
            
            //Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
            

        }
        #endregion

        #region Button animations

        public static async Task ButtonMarginAnimation(Button button, Thickness currentmargin, Thickness desiredmargin, double seconds)
        {
            // Creating the storyboard
            Storyboard sb = new Storyboard();

            //Creating the animation
            ThicknessAnimation ta = new ThicknessAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = currentmargin,
                To = desiredmargin,
                AccelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(ta, new PropertyPath("Margin"));

            // Adding the animation
            sb.Children.Add(ta);

            // Start the animation
            sb.Begin(button);

            await Task.Delay((int)(seconds * 1000));
        }

        public static async Task ButtonWidthAnimation(Button button, double currentwidth, double desiredwidth, double seconds)
        {
            // Creating the storyboard
            Storyboard sb = new Storyboard();

            //Creating the animation
            DoubleAnimation ta = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = currentwidth,
                To = desiredwidth,
                AccelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(ta, new PropertyPath("Width"));

            // Adding the animation
            sb.Children.Add(ta);

            // Start the animation
            sb.Begin(button);

            await Task.Delay((int)(seconds * 1000));
        }


        #endregion

    }
}
