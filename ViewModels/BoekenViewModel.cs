﻿


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoorbeeldExamen_boeken.Utilities;
using VoorbeeldExamen_boeken.Models;
using VoorbeeldExamen_boeken.Services;

namespace VoorbeeldExamen_boeken.ViewModel
{
    public class BoekenViewModel : ObservableObject
    {
        private IDataService _dataService;
        private IDialogService _dialogService;

        private ObservableCollection<Boek> _boeken;

        public ObservableCollection<Boek> Boeken
        {
            get { return _boeken; }
            set
            {

                OnPropertyChanged(ref _boeken, value);
            }
        }


        private Boek _selectedBoek;

        public Boek SelectedBoek
        {
            get => _selectedBoek;
            set
            {
                OnPropertyChanged(ref _selectedBoek, value);
            }
        }

        



        public BoekenViewModel(IDataService dataservice, IDialogService dialogService)
        {
            _dataService = dataservice;
            _dialogService = dialogService;
            Boeken = new ObservableCollection<Boek>(_dataService.GeefAlleBoeken());
            _selectedBoek = _boeken[0];
        }
        
      
    }
}
