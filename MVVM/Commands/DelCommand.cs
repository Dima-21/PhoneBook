using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModels;
using MVVM.Models;

namespace MVVM.Commands
{
    class DelCommand : MyCommand
    {
        public DelCommand(DataManager dm) : base(dm)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Contact c = dm.SelectedContact;
            dm.Contacts.Remove(c);
            dm.DelContact(c);
        }
    }
}
