using System.Windows.Input;

namespace WPFMobile.Services
{
    // The RelayCommand class provides a flexible way to handle commands in WPF applications.
    // It allows to pass delegates (methods) for execution and for determining if the command can execute.
    // The command logic is defined in the ViewModel.

    public class RelayCommand : ICommand
    {
        // Action delegate is used to define a method that does not return a value
        // Func delegate is used to define a method that returns a value
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        // CanExecuteChanged event is used to notify the command manager that the command can be executed
        // This event is crucial for enabling or disabling UI elements based on the command's state.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Constructor to initialize the _execute and _canExecute fields
        // - execute: A delegate that defines the method to be called when the command is executed.
        // - canExecute: A delegate that defines the method to be called to determine if the command can execute.
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
