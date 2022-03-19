using System;
using System.Windows.Input;

namespace MitulPesterii
{
    /// <summary>
    /// A simple class to just execute a function you pass in
    /// </summary>
    class RelayCommand : ICommand
    {

        #region Private members

        /// <summary>
        /// The function that will be executed
        /// </summary>
        private Action mAction;

        #endregion

        #region Public members

        /// <summary>
        /// The function that will be called when the <see cref="CanExecute(object)"/> value is changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };


        /// <summary>
        /// A command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Execute the function
            mAction();
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor that takes the function and executes it
        /// </summary>
        /// <param name="action">The function to be executed</param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion
    }
}
