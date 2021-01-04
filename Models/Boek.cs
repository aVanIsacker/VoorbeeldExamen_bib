using System;
using System.Collections.Generic;
using System.Text;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_boeken.Models
{
    public class Boek : ObservableObject
    {
        private string _titel;
        private string _auteur;
        private string _categorie;
        private string _samenvatting;
        private string _foto;

        private int _BoekNr;

        //constructor boek
        public Boek(string titel, string auteur, string categorie,string samenvatting, string foto)
        {
            Titel = titel;
            Auteur = auteur;
            Categorie = categorie;
            Samenvatting = samenvatting;
            Foto = foto;
        }

        //getters en setters
        public int BoekNr
        {
            get => _BoekNr;
            set
            {
                OnPropertyChanged(ref _BoekNr, value);
            }
        }

        public string Titel
        {
            get => _titel; 
            set
            {              
                OnPropertyChanged(ref _titel,value);
            }
        }
        public string Auteur
        {
            get => _auteur; set
            {
                OnPropertyChanged(ref _auteur, value);
            }
        }
        public string Categorie
        {
            get => _categorie; set
            {
                OnPropertyChanged(ref _categorie, value);
            }
        }
        public string Samenvatting
        {
            get => _samenvatting; set
            {
                OnPropertyChanged(ref _samenvatting, value);
            }
        }
        public string Foto
        {
            get => _foto; set
            {
                OnPropertyChanged(ref _foto, value);
            }
        }
    }
}
