namespace Aufgaben_collection_tdd_fitness
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Teil 1 – Pflicht
            //TestGesamtSchritte();                    //1=geschafft
            //TestDurchschnittSchritte();              //1
            //TestMaximaleSchritte();                  //1
            //TestAnzahlZieltageErreicht();            //1

            // Teil 2a – optional
            //TestTagHinzufuegenUndAnzahlTage();        //1
            //TestDurchschnittMehrereTage();            //1
            //TestDurchschnittEinTag();                 //1

            // Teil 2b – optional
            //TestAktivstePerson();
            //TestEnthaeltPersonVorhanden();            //1
            //TestEnthaeltPersonNichtVorhanden();       //1
        }

        //----------------------------------------------------------------------------------------
        //Aufgabe 1
        //----------------------------------------------------------------------------------------
        static void TestGesamtSchritte()
        {
            var tracker = new Schrittzaehler(new int[] { 8000, 10500, 6000, 12000, 9500 });
            int ergebnis = tracker.GesamtSchritte();
            if (ergebnis == 46000)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"GesamtSchritte() → erwartet: 46000, erhalten: {ergebnis}");
            Console.ResetColor();
        }

        static void TestDurchschnittSchritte()
        {
            var tracker = new Schrittzaehler(new int[] { 8000, 10500, 6000, 12000, 9500 });
            double ergebnis = tracker.DurchschnittSchritte();
            if (ergebnis == 9200)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DurchschnittSchritte() → erwartet: 9200, erhalten: {ergebnis}");
            Console.ResetColor();
        }

        static void TestMaximaleSchritte()
        {
            var tracker = new Schrittzaehler(new int[] { 8000, 10500, 6000, 12000, 9500 });
            int ergebnis = tracker.MaximaleSchritte();
            if (ergebnis == 12000)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"MaximaleSchritte() → erwartet: 12000, erhalten: {ergebnis}");
            Console.ResetColor();
        }

        static void TestAnzahlZieltageErreicht()
        {
            // Grenzfall: 10000 Schritte gilt als "genau erreicht" und zählt mit
            var tracker = new Schrittzaehler(new int[] { 8000, 10500, 6000, 12000, 10000 });
            int ergebnis = tracker.AnzahlZieltageErreicht(10000);
            if (ergebnis == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"AnzahlZieltageErreicht(10000) → erwartet: 3, erhalten: {ergebnis}");
            Console.ResetColor();
        }

        //----------------------------------------------------------------------------------------
        //Aufgabe 2a
        //----------------------------------------------------------------------------------------
        static void TestTagHinzufuegenUndAnzahlTage()
        {
            var liste = new SchrittListe();
            liste.TagHinzufuegen(8000);
            liste.TagHinzufuegen(10500);
            int ergebnis = liste.AnzahlTage();
            if (ergebnis == 2)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"AnzahlTage() nach 2x TagHinzufuegen() → erwartet: 2, erhalten: {ergebnis}");
            Console.ResetColor();
        }
        static void TestDurchschnittMehrereTage()
        {
            var liste = new SchrittListe();
            liste.TagHinzufuegen(8000);
            liste.TagHinzufuegen(10000);
            liste.TagHinzufuegen(12000);
            double ergebnis = liste.DurchschnittSchritte();
            if (ergebnis == 10000)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DurchschnittSchritte() bei 3 Tagen → erwartet: 10000, erhalten: {ergebnis}");
            Console.ResetColor();
        }
        static void TestDurchschnittEinTag()
        {
            // Grenzfall: nur ein einziger erfasster Tag
            var liste = new SchrittListe();
            liste.TagHinzufuegen(7500);
            double ergebnis = liste.DurchschnittSchritte();
            if (ergebnis == 7500)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DurchschnittSchritte() bei 1 Tag → erwartet: 7500, erhalten: {ergebnis}");
            Console.ResetColor();
        }

        //----------------------------------------------------------------------------------------
        //Aufgabe 2b
        //----------------------------------------------------------------------------------------
        static void TestAktivstePerson()
        {
            var team = new TeamVergleich();
            team.PersonHinzufuegen("Mira", 42000);
            team.PersonHinzufuegen("Jonas", 51000);
            team.PersonHinzufuegen("Alina", 38000);
            string ergebnis = team.AktivstePerson();
            if (ergebnis == "Jonas")
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"AktivstePerson() → erwartet: Jonas, erhalten: {ergebnis}");
            Console.ResetColor();
        }
        static void TestEnthaeltPersonVorhanden()
        {
            var team = new TeamVergleich();
            team.PersonHinzufuegen("Mira", 42000);
            bool ergebnis = team.EnthaeltPerson("Mira");
            if (ergebnis == true)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"EnthaeltPerson(\"Mira\") → erwartet: True, erhalten: {ergebnis}");
            Console.ResetColor();
        }
        static void TestEnthaeltPersonNichtVorhanden()
        {
            // Grenzfall: Abfrage einer Person, die nie hinzugefügt wurde
            var team = new TeamVergleich();
            team.PersonHinzufuegen("Mira", 42000);
            bool ergebnis = team.EnthaeltPerson("Bruno");
            if (ergebnis == false)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"EnthaeltPerson(\"Bruno\") → erwartet: False, erhalten: {ergebnis}");
            Console.ResetColor();
        }
    }
}
