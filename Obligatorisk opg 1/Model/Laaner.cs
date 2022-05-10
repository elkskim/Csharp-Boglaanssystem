using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opg_1.Model
{
    public class Laaner : INotifyPropertyChanged
    {
        private ObservableCollection<Bog> _bogList = new ObservableCollection<Bog>();
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Adresse { get; set; }

        public ObservableCollection<Bog> bogList
        {
            get { return _bogList; }
            set
            {
                if (bogList != value)
                {
                    _bogList = bogList;
                }
            }
        }
            

        public Laaner(string name, int age, string adresse)
        {
            Name = name;
            Age = age;
            Adresse = adresse;
        }

        public Laaner()
        {

        }


        public string Show
        {
            get { return String.Format("ID: {0} - Navn: {1}", ID, Name); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
