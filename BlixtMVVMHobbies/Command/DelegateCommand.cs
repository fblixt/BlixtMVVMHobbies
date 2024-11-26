using System;
using System.Windows.Input;

namespace BlixtMVVMHobbies.Command
{
    public class DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand

    {
        private readonly Action<object?> _execute = execute;
        private readonly Func<object?, bool>? _canExecute = canExecute;

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);
    }
}
