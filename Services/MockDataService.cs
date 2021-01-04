using VoorbeeldExamen_boeken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using VoorbeeldExamen_bib.Models;

namespace VoorbeeldExamen_boeken.Services
{
    public class MockDataService : IDataService
    {
        #region fields
        private IList<Boek> _boeken;
        private IList<Lid> _leden;
        private IList<Uitlening> _uitleningen;

        //private IList<Uitlening> _uitleningen;
        #endregion
        public MockDataService()
        {
            InitLists();
        }

        

        private void InitLists()
        {
            InitBoeken();
            InitLeden();
            InitUitLeningen();
        }

       
        private void InitBoeken()
        {

            _boeken = new List<Boek>();

            //geeft running directory van de running appliction
            //encoding nodig om onleesbare tekens weg te werken
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/Data/boeken.txt", Encoding.UTF7))
            {
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    //parsen van string naar character
                    string[] substrings = line.Split(char.Parse(";"));
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Resources", substrings[2]);
                    _boeken.Add(new Boek(substrings[1], substrings[0], substrings[4], substrings[3], AppDomain.CurrentDomain.BaseDirectory + "/Resources/" + substrings[2]));
                }
            }

        }


        private void InitLeden()
        {
           
            _leden = new List<Lid>() {
                 new Lid(){ LidNr=1,Voornaam="Jan",Familienaam="Jansens", Email="J.J@hotmail.com" },
                 new Lid(){ LidNr=2,Voornaam="Piet",Familienaam="Pieters", Email="pp@hotmail.com"},
                 new Lid(){ LidNr=3,Voornaam="Kris",Familienaam="Korneslis", Email="kk@hotmail.com" }
            };
        }

        private void InitUitLeningen()
        {
            _uitleningen = new List<Uitlening>() {
                 new Uitlening(){ UitleningsNr=1,Contact = _leden[0],UitleningsDatum = DateTime.Now },
                 new Uitlening(){ UitleningsNr=2,Contact = _leden[1],UitleningsDatum = DateTime.Now },
                 new Uitlening(){ UitleningsNr=3,Contact = _leden[2],UitleningsDatum = DateTime.Now },
                 new Uitlening(){ UitleningsNr=4,Contact = _leden[1],UitleningsDatum = DateTime.Now },
                 new Uitlening(){ UitleningsNr=5,Contact = _leden[0],UitleningsDatum = DateTime.Now },

            };
        }

        //Boek
        public IList<Boek> GeefAlleBoeken()
        {
            return _boeken;
        }

        //lid
        public IList<Lid> GeefAlleLeden()
        {
            return _leden;
        }


        public IList<Lid> VerwijderLid(Lid selectedLid)
        {
            _leden.Remove(selectedLid);
            return _leden;
        }

        public IList<Lid> VoegLidToe(Lid lid)
        {
            int LidNr = (_leden.Count > 0) ? _leden.Max(b => b.LidNr) + 1 : 1;
            lid.LidNr = LidNr;
            _leden.Add(lid);
            return _leden;
        }

        public void WijzigLid(Lid selectedLid)
        {
            int index = _leden.IndexOf(selectedLid);
            if (index >= 0)
            {
                _leden[index] = selectedLid;
            }
        }


        //Uitlening
        public IList<Uitlening> GeefAlleUitleningen()
        {
            return _uitleningen;
        }

        public IList<Uitlening> VerwijderUitlening(Uitlening selectedUitlening)
        {
            _uitleningen.Remove(selectedUitlening);
            return _uitleningen;
        }

        public IList<Uitlening> VoegUitleningToe(Uitlening uitlening)
        {
            //autonummering
            int UniekNr = (_uitleningen.Count > 0) ? _uitleningen.Max(b => b.UitleningsNr) + 1 : 1;
            uitlening.UitleningsNr = UniekNr;

            _uitleningen.Add(uitlening);
            return _uitleningen;
        }

        public void WijzigUitlening(Uitlening selectedUitlening)
        {
            int index = _uitleningen.IndexOf(selectedUitlening);
            if (index >= 0)
            {
                _uitleningen[index] = selectedUitlening;
            }
        }
    }
}
