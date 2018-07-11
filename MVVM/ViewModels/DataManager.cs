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
using MVVM.Commands;

namespace MVVM.ViewModels
{
    class DataManager : INotifyPropertyChanged
    {
        private XDocument doc;
        private string path;

        private Contact selectedContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        // Commands:

        private AddCommand add;
        public AddCommand Add
        {
            get
            {
                if (add == null)
                    add = new AddCommand(this);
                return add;
            }
        }

        private DelCommand del;
        public DelCommand Del
        {
            get
            {
                if (del == null)
                    del = new DelCommand(this);
                return del;
            }
        }

        private SaveCommand save;
        public SaveCommand Save
        {
            get
            {
                if (save == null)
                    save = new SaveCommand(this);
                return save;
            }

        }

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        public void SaveContact(Contact c)
        {
            XElement newElem = new XElement("contact",
                new XAttribute("person", c.Person),
                new XAttribute("phone", c.Phone),
                new XAttribute("email", c.Email));
            doc.Element("root").Add(newElem);
            doc.Save(path);
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

        public void DelContact(Contact c)
        {
            var res = doc.Element("root").Elements("contact")
                .Where(x => x.Attribute("person").Value == c.Person).FirstOrDefault();
            if (res != null)
            {
                res.Remove();
                doc.Save(path);
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
