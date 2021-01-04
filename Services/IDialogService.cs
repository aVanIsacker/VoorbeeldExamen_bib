using System;
using System.Collections.Generic;
using System.Text;

namespace VoorbeeldExamen_boeken.Services
{
    public interface IDialogService
    {
        T OpenDialog<T>(DialogViewModelBase<T> viewModel);
    }
}
