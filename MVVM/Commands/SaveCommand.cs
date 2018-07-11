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
    class SaveCommand : MyCommand
    {
        public SaveCommand(DataManager dm) : base(dm)
        { }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Contact c = dm.SelectedContact;
            dm.SaveContact(c);
            MessageBox.Show($"Контакт {c.Person} - успешно сохранен");
        }
    }
}
