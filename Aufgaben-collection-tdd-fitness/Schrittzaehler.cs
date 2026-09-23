using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgaben_collection_tdd_fitness
{
    internal class Schrittzaehler
    {
        //Feld
        private int[] schritte;

        //Konstruktor
        public Schrittzaehler(int[] schritte)
        {
            this.schritte = schritte;
        }

        //Methoden
        public int GesamtSchritte()
        {
            int summe = 0;
            for (int i = 0; i < schritte.Length; i++)
            {
                summe += schritte[i];
            }
            return summe;
        }

        public double DurchschnittSchritte()
        {
            int durschnitt = 0;
            int summe = 0;
            if( schritte.Length == 0) { return 0; }
            for (int i = 0; i < schritte.Length; i++)
            {
                summe += schritte[i];
            }
            
            durschnitt = summe / schritte.Length;//Achtung länge könnte null sein
            return durschnitt;
        }

        public int MaximaleSchritte()
        {
            int max = 0;
            for (int i = 0; i < schritte.Length; i++)
            {
                if (schritte[i] > max)
                    max = schritte[i];
            }
            return max;
        }

        public int AnzahlZieltageErreicht(int ziel)
        {
            int anzahl = 0;
            for (int i = 0; i < schritte.Length; i++)
            {
                if (schritte[i] >= ziel)
                    anzahl++;
            }
            return anzahl;
        }
    }
}
