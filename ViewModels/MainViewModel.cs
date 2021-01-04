

using VoorbeeldExamen_boeken.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using VoorbeeldExamen_boeken.Utilities;
using System.Diagnostics;
using VoorbeeldExamen_boeken.ViewModel;
using VoorbeeldExamen_bib.ViewModels;

namespace VoorbeeldExamen_boeken.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IDialogService _dialogService;
        private IDataService _dataService;
        private BoekenViewModel _boekenVM;
        private LedenViewModel _ledenVM;

        private UitleningViewModel _uitleningVM;


        public MainViewModel()
        {
            _dialogService = new DialogService();
            _dataService = new MockDataService();

            BoekenVM = new BoekenViewModel(_dataService, _dialogService);
            LedenVM = new LedenViewModel(_dataService);

            UitleningVM = new UitleningViewModel(_dataService);
        }

        public UitleningViewModel UitleningVM
            {
                get { return _uitleningVM; }
                set { OnPropertyChanged(ref _uitleningVM, value); }
            }


        public BoekenViewModel BoekenVM
        {
            get { return _boekenVM; }
            set { OnPropertyChanged(ref _boekenVM, value); }
        }
        public LedenViewModel LedenVM
        {
            get { return _ledenVM; }
            set { OnPropertyChanged(ref _ledenVM, value); }
        }
    }
}



