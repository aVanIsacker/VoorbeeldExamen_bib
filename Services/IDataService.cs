using VoorbeeldExamen_boeken.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VoorbeeldExamen_bib.Models;

namespace VoorbeeldExamen_boeken.Services
{
    public interface IDataService
    {
        IList<Boek> GeefAlleBoeken();

        IList<Lid> GeefAlleLeden();
        IList<Lid> VerwijderLid(Lid selectedlid);
        IList<Lid> VoegLidToe(Lid lid);
        void WijzigLid(Lid selectedLid);

        IList<Uitlening> GeefAlleUitleningen();
        IList<Uitlening> VerwijderUitlening(Uitlening selectedUitlening);
        IList<Uitlening> VoegUitleningToe(Uitlening uitlening);
        void WijzigUitlening(Uitlening selectedUitlening);
    }
}