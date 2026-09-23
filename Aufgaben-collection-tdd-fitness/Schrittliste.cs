using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgaben_collection_tdd_fitness
{
    class SchrittListe
    {
        private List<int> schritte = new List<int>();

        public void TagHinzufuegen(int schritte) //int schritte ist unglücklich gewählt
        {
           this.schritte.Add(schritte); 
            //wegen der input variable schritte muss mit this.schritte
            //auf die liste gezeigt werden
        }

        public int AnzahlTage()
        {
           int anzahl = 0;

           foreach (int nameTotalEgal in schritte)
                anzahl++;

          return anzahl; 
        }

        public double DurchschnittSchritte()
        {
            double anzahl = 0;
            double summe = 0;
            double durchschnitt = 0;

            foreach (int eintrag in schritte)
                anzahl++;

            foreach (int eintrag in schritte)
                summe += eintrag;

            durchschnitt = summe / anzahl; //Anzahl darf nicht null sein

            return durchschnitt;
        }
    }
}
