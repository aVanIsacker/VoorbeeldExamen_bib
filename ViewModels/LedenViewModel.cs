using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using VoorbeeldExamen_bib.Models;
using VoorbeeldExamen_boeken.Models;
using VoorbeeldExamen_boeken.Services;
using VoorbeeldExamen_boeken.Utilities;

namespace VoorbeeldExamen_boeken.ViewModels
{
    public class LedenViewModel : ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Lid> _leden;
        private Lid _selectedLid;

        public Lid SelectedLid
        {
            get { return _selectedLid; }
            set { OnPropertyChanged(ref _selectedLid, value); }
        }


        //using observable collection
        public ObservableCollection<Lid> Leden
        {
            get { return _leden; }
            set { OnPropertyChanged(ref _leden, value); }
        }

        //using dataservice
        public LedenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Leden = new ObservableCollection<Lid>(_dataService.GeefAlleLeden());

            AddLidCommand = new RelayCommand(VoegLidToe);
            EditLidCommand = new RelayCommand(WijzigLidGegevens);
            DeleteLidCommand = new RelayCommand(VerwijderLid);

        }

        public ICommand AddLidCommand { get; private set; }
        public ICommand EditLidCommand { get; private set; }
        public ICommand DeleteLidCommand { get; private set; }

        private void VerwijderLid()
        {
            Leden = new ObservableCollection<Lid>(_dataService.VerwijderLid(SelectedLid));
            if (_leden.Count > 0) SelectedLid = _leden[0];
        }

        private void WijzigLidGegevens()
        {
            _dataService.WijzigLid(SelectedLid);
        }

        private void VoegLidToe()
        {
            Lid lid = new Lid() { LidNr = 0, Voornaam = "NA", Familienaam = "NA", Email = "NA" };
            Leden = new ObservableCollection<Lid>(_dataService.VoegLidToe(lid));
            SelectedLid = _leden[_leden.Count - 1];
        }

       

    }
}
