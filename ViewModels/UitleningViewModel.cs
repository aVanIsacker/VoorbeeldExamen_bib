using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VoorbeeldExamen_bib.Models;
using VoorbeeldExamen_boeken.Services;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_bib.ViewModels
{
    public class UitleningViewModel : ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Uitlening> _uitleningen;
        private Uitlening _selectedUitlening;

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

        }

        public ICommand AddUitleningCommand { get; private set; }
        public ICommand EditUitleningCommand { get; private set; }
        public ICommand DeleteUitleningCommand { get; private set; }

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



    }
}
