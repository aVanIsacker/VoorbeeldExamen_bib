using System;
using System.Collections.Generic;
using System.Text;
using VoorbeeldExamen_boeken.Models;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_bib.Models
{
    public class Uitlening : ObservableObject
    {
        //private int _uitleningsNr;
        private DateTime _uitleningsDatum;
        //private DateTime _vervalDatum;

        public int UitleningsNr { get; set; }

        public DateTime UitleningsDatum
        {
            get
            {
                return _uitleningsDatum;
            }
            set
            {
                OnPropertyChanged(ref _uitleningsDatum, value);
            }
        }

        public DateTime VervalDatum { get; set; }


        private Lid _contact;
        public Lid Contact
        {
            get { return _contact; }
            set { OnPropertyChanged(ref _contact, value); }
        }

        private Boek _leesBoek;
        public Boek LeesBoek
        {
            get { return _leesBoek; }
            set { OnPropertyChanged(ref _leesBoek, value); }
        }


        //public Lid Lid
        //{
        //    get { return Lid; }
        //    set {  Lid = value; }

        //}
    }     
}
