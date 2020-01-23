using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickContact.Model;
using System.ComponentModel;

namespace QuickContact
{
    public class ListeContactsViewModel : INotifyPropertyChanged
    {

        //data access layer
        MaDAL db = new MaDAL();

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<Contact> Liste
        {
            get
            {
                return db.Contacts.ToList();
            }
        }


        public void SauvegarderContact()
        {
            db.SaveChanges();
        }

        public void SupprimerContact(Contact c)
        {
            db.Contacts.Remove(c);
            SauvegarderContact();
            OnPropertyChanged("Liste");
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
