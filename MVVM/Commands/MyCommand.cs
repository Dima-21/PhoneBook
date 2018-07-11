using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Commands
{
    abstract class MyCommand : ICommand
    {
        protected DataManager dm;
        protected MyCommand(DataManager dm)
        {
            this.dm = dm;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

}
