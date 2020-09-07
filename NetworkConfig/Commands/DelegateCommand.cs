﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetworkConfig.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {

            if (this.canExecute == null)
            {
                return true;
            }

            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
