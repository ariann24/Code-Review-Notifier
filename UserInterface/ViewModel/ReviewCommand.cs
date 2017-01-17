using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;

namespace CodeReviewNotifier.ViewModel
{
    public class ReviewCommand : ICommand
    {
        public Action Function
        { get; set; }

        public ReviewCommand()
        {
        }

        public ReviewCommand(Action function)
        {
            Function = function;
        }

        public bool CanExecute(object parameter)
        {
            if (Function != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (Function != null)
            {
                Function();
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
