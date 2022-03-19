using MitulPesterii.Pages;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MitulPesterii
{
    class WindowViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin that makes the drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;


        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// This is the current page for the content frame
        /// </summary>
        private Page mContentPage = new StartPage();

        #endregion

        #region Public Members

        #region Window-related properties


        /// <summary>
        /// The minimum height the window can go 
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 824;

        /// <summary>
        /// The minimum width the window can go 
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 1536;

        public int ResizeBorder { get; set; } = 6;


        /// <summary>
        /// The space where the outer shadow is seen
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The window corner radius
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The space where you can get the resize cursor, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        /// <summary>
        /// The inner padding content value
        /// </summary>
        public Thickness InnetContentPadding { get { return new Thickness(ResizeBorder); } }
        /// <summary>
        /// The space where the outer shadow is seen
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The window corner radius
        /// </summary>
        public CornerRadius WindowRadiusThickness { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 36;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Page related properties

        #region BACKGROUND

        private string backgroundImage = "/Images/Backgrounds/CaveBackgroundWithFire.png";


        /// <summary>
        /// Background image path for the main window
        /// </summary>
        public string BackgroundImage
        {
            get
            {
                return backgroundImage;
            }
            set
            {
                backgroundImage = value;
            }
        }

        #endregion

        /// <summary>
        /// Returns the content frame's page
        /// </summary>
        //public Page ContentPage
        //{
        //    get
        //    {
        //        return mContentPage;
        //    }

        //    set
        //    {
        //        mContentPage = value;
        //    }
        //}
        public Page ContentPage { get; set; } = new StartPage();

        /// <summary>
        /// Returns the button's page for the side frame
        /// </summary>
        public Page ButtonsPage
        {
            get
            {
                return new ButtonsPage();
            }
        }

        public BaseViewModel ViewModel { get; set; }

        #endregion

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the menu
        /// </summary>
        public ICommand MenuCommand { get; set; }
        public ICommand ChangeContentFramePageCommand { get; set; }
        #endregion

        #region Constructor

        public WindowViewModel(Window window)
        {
            mWindow = window;

            // First update of the main window s size properties
            //UpdateMainWindowSize(mWindow.Width, mWindow.Height);

            // Making an event that will fire when the window is maximized/minimized
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire all of these properties again when sth happens to the state of the window
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadiusThickness));
                //UpdateMainWindowSize(mWindow.Width, mWindow.Height);
            };

            //Creating the commands
            MinimizeCommand = new RelayCommand(() => { mWindow.WindowState = WindowState.Minimized; });
            MaximizeCommand = new RelayCommand(() => { mWindow.WindowState ^= WindowState.Maximized; });
            CloseCommand = new RelayCommand(() => { mWindow.Close(); });
            MenuCommand = new RelayCommand(() => { SystemCommands.ShowSystemMenu(mWindow,GetMousePosition()); });
            
            //Fixing the resizing issue
            var resizer = new WindowResizer(mWindow);

        }

        
        #endregion

        #region Helpers

        /// <summary>
        /// Gets the current mouse position on screen
        /// </summary>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        /// <summary>
        /// Updates the main window's sizes properties
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        //private void UpdateMainWindowSize(double width, double height)
        //{
        //    MainWindowSize.MainWindowWidth = mWindow.Width;
        //    MainWindowSize.MainWindowHeight = mWindow.Height;
        //}

        #endregion


    }
}
