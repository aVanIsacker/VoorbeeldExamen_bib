using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //using sytem DataAnnotations
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
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


        //private Lid _contact;
        //public Lid Contact
        //{
        //    get { return _contact; }
        //    set { OnPropertyChanged(ref _contact, value); }
        //}

        private Lid _lid;
        public Lid Lid
        {
            get { return _lid; }
            set { OnPropertyChanged(ref _lid, value); }
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
