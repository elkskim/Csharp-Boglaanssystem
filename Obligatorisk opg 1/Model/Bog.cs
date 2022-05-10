using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opg_1.Model
{
    public class Bog : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private Laaner _laaner;
        public int ID { get; set; }
        public string Name
        {
            get { return _name; }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public string Description
        {
            get { return _description; }

            set
            {
                if (_description != value)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public Laaner Laaner
        {
            get { return _laaner; }

            set
            {
                if (_laaner != value)
                {
                    _laaner = value;
                    NotifyPropertyChanged("Laaner");
                }
            }
        }

                   
        public Bog (string name, string description)
        {
            _name = name;
            _description = description;
        }

       public Bog()
        {

        }

        public string Show
        {
            get { return Name; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
    
}
