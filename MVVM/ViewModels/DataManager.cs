using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MVVM.Models;
using System.Collections.ObjectModel;

namespace MVVM.ViewModels
{
    class DataManager : INotifyPropertyChanged
    {
        private XDocument doc;
        private string path;

        private Contact selectedContact;

        public ObservableCollection<Contact> Contacts{ get; set; }

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public DataManager()
        {
            Contacts = new ObservableCollection<Contact>();
            path = @"..\..\Data\Contacts.xml";
            doc = XDocument.Load(path);
            LoadData();
        }

        public void LoadData()
        {
            var res = doc.Element("root").Elements("contact").ToList();
            foreach (var x in res)
            {
                Contact c = new Contact()
                {
                    Person = x.Attribute("person").Value,
                    Phone = x.Attribute("phone").Value,
                    Email = x.Attribute("email").Value
                };
                Contacts.Add(c);
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
