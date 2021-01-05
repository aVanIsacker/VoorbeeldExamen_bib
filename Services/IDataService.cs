using VoorbeeldExamen_boeken.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VoorbeeldExamen_bib.Models;

namespace VoorbeeldExamen_boeken.Services
{
    public interface IDataService
    {
        IList<Boek> GeefAlleBoeken();

        //leden
        IList<Lid> GeefAlleLeden();
        IList<Lid> VerwijderLid(Lid selectedlid);
        IList<Lid> VoegLidToe(Lid lid);
        void WijzigLid(Lid selectedLid);

        //uitleningen
        IList<Uitlening> GeefAlleUitleningen();
        IList<Uitlening> VerwijderUitlening(Uitlening selectedUitlening);
        IList<Uitlening> VoegUitleningToe(Uitlening uitlening);
        void WijzigUitlening(Uitlening selectedUitlening);

       
        //boeken uit uitgeleende boeken aanpassen
        IList<Lid> VerwijderBoekVoorLid(int KlantIndex, Boek boek);
        IList<Lid> VoegBoekToeVoorLid(int KlantIndex, Boek boek);

        ////geef uitlening voor lid
        //IList<Lid> GeefGeleendeBoekenVoorLid(Lid selectedLid);

    }
}