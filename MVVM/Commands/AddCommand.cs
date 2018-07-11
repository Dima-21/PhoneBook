using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModels;
using MVVM.Models;
using System.Windows;

namespace MVVM.Commands
{
    class AddCommand : MyCommand
    {
        public AddCommand(DataManager dm) : base(dm)
        {

        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Contact c = new Contact();
            dm.SelectedContact = c;
            dm.Contacts.Add(c);
            MessageBox.Show("Контакт успешно добавлен");

        }
    }
}
