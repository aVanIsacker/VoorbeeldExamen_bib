using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VoorbeeldExamen_bib.Models;
using VoorbeeldExamen_boeken.Models;
using VoorbeeldExamen_boeken.Services;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_bib.ViewModels
{
    public class UitleningViewModel : ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Uitlening> _uitleningen;
        private Uitlening _selectedUitlening;

        private ObservableCollection<Boek> _boeken;
        private Boek _selectedBoek;

        private ObservableCollection<Lid> _leden;
        private Lid _selectedLid;

        

        private ObservableCollection<Lid> _geleendeBoeken;

        public ObservableCollection<Lid> GeleendeBoeken
        {
            get { return _geleendeBoeken; }
            set
            {

                OnPropertyChanged(ref _geleendeBoeken, value);
            }
        }

        public Uitlening SelectedUitlening
        {
            get { return _selectedUitlening; }
            set { OnPropertyChanged(ref _selectedUitlening, value); }
        }


        //using observable collection
        public ObservableCollection<Uitlening> Uitleningen
        {
            get { return _uitleningen; }
            set { OnPropertyChanged(ref _uitleningen, value); }
        }

        //using dataservice
        public UitleningViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Uitleningen = new ObservableCollection<Uitlening>(_dataService.GeefAlleUitleningen());

            AddUitleningCommand = new RelayCommand(VoegUitleningToe);
            EditUitleningCommand = new RelayCommand(WijzigUitlening);
            DeleteUitleningCommand = new RelayCommand(VerwijderUitlening);

            AddBookToUitleningCommand = new RelayCommand(VoegBoekToeVoorLid);
            DeleteBookFromUitleningCommand = new RelayCommand(VerwijderBoekVoorLid);

            Leden = new ObservableCollection<Lid>(_dataService.GeefAlleLeden());

       
            //GeleendeBoeken = new ObservableCollection<Lid>(_dataService.GeefGeleendeBoekenVoorLid(SelectedLid));

            SelectedLid = _leden[0];
            SelectedUitlening = _uitleningen[0];
            //SelectedBoek = _boeken[0];

        }

        public ICommand AddUitleningCommand { get; private set; }
        public ICommand EditUitleningCommand { get; private set; }
        public ICommand DeleteUitleningCommand { get; private set; }

        //boek in geleende boeken wijzigen
        public ICommand AddBookToUitleningCommand { get; private set; }
        public ICommand DeleteBookFromUitleningCommand { get; private set; }

        //uitleningen aanpassen
        private void VerwijderUitlening()
        {
            Uitleningen = new ObservableCollection<Uitlening>(_dataService.VerwijderUitlening(SelectedUitlening));
            if (_uitleningen.Count > 0) SelectedUitlening = _uitleningen[0];
        }

        private void WijzigUitlening()
        {
            _dataService.WijzigUitlening(SelectedUitlening);
        }

        private void VoegUitleningToe()
        {
            Uitlening uitlening = new Uitlening() { UitleningsNr = 0, UitleningsDatum = DateTime.Now , VervalDatum = DateTime.Now.AddDays(21)}; //add contact
            Uitleningen = new ObservableCollection<Uitlening>(_dataService.VoegUitleningToe(uitlening));
            SelectedUitlening = _uitleningen[_uitleningen.Count - 1];
        }

       

        //voor de leden
        public ObservableCollection<Lid> Leden
        {
            get { return _leden; }
            set { OnPropertyChanged(ref _leden, value); }
        }

        public Lid SelectedLid
        {
            get { return _selectedLid; }
            set { OnPropertyChanged(ref _selectedLid, value); }
        }

        // deze moet nog uitgezocht worden
        private void VerwijderBoekVoorLid()
        {
            //    GeleendeBoeken = new ObservableCollection<Uitlening>(_dataService.VerwijderBoekVoorLid(SelectedBoek));
            //    if (GeleendeBoeken.Count > 0) SelectedBoek = _geleendeBoeken[0];
            //

            throw new NotImplementedException();
        }

        private void VoegBoekToeVoorLid()
        {
            //GeleendeBoeken geleendeBoeken = new GeleendeBoeken() { Eerst = "NA", Tweede = "NA", Derde = "NA" }; //not sure
            //Leden = new ObservableCollection<Lid>(_dataService.VoegBoekToeVoorLid(SelectedLid, SelectedBoek));

            //GeleendeBoeken = new ObservableCollection<Uitlening>(_dataService.VoegBoekToeVoorLid(SelectedBoek));
            //SelectedBoek = GeleendeBoeken[GeleendeBoeken.Count - 1];

            throw new NotImplementedException();
        }




        // voor de boeken
        public ObservableCollection<Boek> Boeken
        {
            get { return _boeken; }
            set { OnPropertyChanged(ref _boeken, value); }
        }
        private Boek SelectedBoek
        {
            get { return _selectedBoek; }
            set { OnPropertyChanged(ref _selectedBoek, value); }
        }
    }
}
