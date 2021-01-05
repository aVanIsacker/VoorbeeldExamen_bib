using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VoorbeeldExamen_boeken.Models;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_bib.Models
{
    public class Lid : ObservableObject
    {
        private int _lidNr;
        private string _voornaam;      
        private string _familienaam;
        private string _email;

        //Lid kan meerdere boeken uitlenen per keer, dus relatie 1 lid to many boeken
        private ObservableCollection<Boek> _geleendeBoeken;

        public ObservableCollection<Boek> GeleendeBoeken
        {
            get
            {
                return _geleendeBoeken;
            }
            set
            {
                OnPropertyChanged(ref _geleendeBoeken, value);
            }
        }



        //constructor
        public Lid()
        {
            GeleendeBoeken = new ObservableCollection<Boek>();
        }



        ////had dit eerst geprobeerd
        //private List<Boek> _geleendeBoeken;
        //public List<Boek> GeleendeBoeken
        //{
        //    get { return _geleendeBoeken; }
        //    set { OnPropertyChanged(ref _geleendeBoeken, value); }
        //}
        //constructor
        //public Lid()
        //{
        //    _geleendeBoeken = new List<Boek>();
        //}


        //getters en setters
        public int LidNr
        {
            get => _lidNr;
            set
            {
                OnPropertyChanged(ref _lidNr, value);
            }
        }
        public string Voornaam
        {
            get => _voornaam; set
            {
                OnPropertyChanged(ref _voornaam, value);
            }
        }
        public string Familienaam
        {
            get => _familienaam; set
            {
                OnPropertyChanged(ref _familienaam, value);
            }
        }
        public string Email
        {
            get => _email; set
            {
                OnPropertyChanged(ref _email, value);
            }
        }

        

    }
}
