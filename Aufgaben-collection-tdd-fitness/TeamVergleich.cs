using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgaben_collection_tdd_fitness
{
    class TeamVergleich
    {
        private Dictionary<string, int> gesamtschritte = new Dictionary<string, int>();

        public void PersonHinzufuegen(string name, int gesamtschritte)
        {
            this.gesamtschritte.Add(name, gesamtschritte);
        }

        public string AktivstePerson()
        {
            string _aktivstePerson = "";
            int max = 0;
            foreach (int schritte in gesamtschritte.Values)
            {
                if(schritte > max) max = schritte;

            }

            foreach(var eintrag in gesamtschritte)
            {
                if (max == eintrag.Value)
                    _aktivstePerson = eintrag.Key;
            }
            return _aktivstePerson;
        }

        public bool EnthaeltPerson(string name)
        {
            bool nameVorhanden = false;

            foreach(string suche in gesamtschritte.Keys)
            {
                if (suche == name) nameVorhanden =true;
                else nameVorhanden = false; 
            }
            return nameVorhanden;
        }
    }
}
