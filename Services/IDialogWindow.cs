using System;
using System.Collections.Generic;
using System.Text;

namespace VoorbeeldExamen_boeken.Services
{
    public interface IDialogWindow
    {
        bool? DialogResult { get; set; }
        object DataContext { get; set; }
        bool? ShowDialog();
    }
}
