using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace VoorbeeldExamen_boeken.Services
{
    public class FileDialogWindow : IFileDialogService
    {


        public string OpenFile(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == true)
                return dialog.FileName;
            return null;
        }


    }
}
