# Aufgabe: Fitness-Tracker – Schrittzahlen auswerten

**Thema**: Algorithmus-Aufgaben zu `Collections` (`Array`, `List`, `Dictionary`), Aggregationsfunktionen, `Unit-Test`-basiert (`TDD`)

## Szenario

Bei der (fiktiven) Firma NovaSoft GmbH wird eine kleine Fitness-App für Mitarbeitende entwickelt, die ihre Schrittzahlen der letzten Tage trackt. Die App soll den Nutzer:innen auf einen Blick zeigen, wie aktiv sie waren – ohne dass diese selbst rechnen müssen.

## User-Story

*Erstellt von: Petra Wanders, Product Owner – NovaSoft GmbH*

> Als Nutzer:in möchte ich meine Schrittzahlen der letzten Tage automatisch ausgewertet bekommen, damit ich meinen Fortschritt einfach überblicken kann.

## Deine Rolle

Du bist Developer im Scrum-Team der NovaSoft GmbH. Kevin Läufer, dein Kollege, hat aus der User-Story bereits Testfälle abgeleitet und dazu passende Klassen vorbereitet.

Diese Klassen sind noch nicht fertig implementiert – sie kompilieren, aber jede Methode wirft aktuell einen `NotImplementedException`-Fehler. Du befindest dich damit in der **Rot-Phase** von Red-Green-Refactor: Die Tests sind geschrieben, schlagen aber (noch) fehl, weil die Produktionslogik fehlt.

**Deine Aufgabe:** Implementiere die Methoden in den vorgegebenen Klassen so, dass alle Tests grün werden. Du darfst die Testmethoden und die Methodensignaturen (Name, Parameter, Rückgabetyp) nicht verändern.

---

## Teil 1 (Pflicht): Schrittzahlen mit dem Array auswerten

### Vorgegebene Klasse

```csharp
class Schrittzaehler
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
        throw new NotImplementedException();
    }

    public double DurchschnittSchritte()
    {
        throw new NotImplementedException();
    }

    public int MaximaleSchritte()
    {
        throw new NotImplementedException();
    }

    public int AnzahlZieltageErreicht(int ziel)
    {
        throw new NotImplementedException();
    }
}
```

**Wichtiger Hinweis:** Verwende zur Implementierung ausschließlich klassische Schleifen (`for` oder `foreach`). LINQ (`Sum()`, `Max()`, `Average()`, `Count()` etc.) ist in dieser Aufgabe **nicht erlaubt** – du sollst die Berechnungslogik selbst nachvollziehen.

### Vorgegebener Testcode

```csharp
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
```

---

## Teil 2a (optional): Schrittzahlen mit der List sammeln

Statt eines von Anfang an feststehenden Arrays kommen die Schrittzahlen im Laufe der Woche einzeln dazu. Dafür eignet sich eine `List<int>` besser als ein Array, da ihre Größe nicht vorher feststehen muss.

### Vorgegebene Klasse

```csharp
class SchrittListe
{
    private List<int> schritte = new List<int>();

    public void TagHinzufuegen(int schritte)
    {
        throw new NotImplementedException();
    }

    public int AnzahlTage()
    {
        throw new NotImplementedException();
    }

    public double DurchschnittSchritte()
    {
        throw new NotImplementedException();
    }
}
```

### Vorgegebener Testcode

```csharp
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
```

---

## Teil 2b (optional): Team-Vergleich mit dem Dictionary

Jetzt geht es nicht mehr um die Tageswerte einer Person, sondern um den Vergleich mehrerer Personen. Jede Person hat bereits ihre Gesamtschrittzahl der Woche ermittelt (z. B. mit `Schrittzaehler` aus Teil 1). Diese Werte sollen jetzt Personen zugeordnet gespeichert werden – dafür eignet sich ein `Dictionary<string, int>` (Name → Gesamtschritte).

### Vorgegebene Klasse

```csharp
class TeamVergleich
{
    private Dictionary<string, int> gesamtschritte = new Dictionary<string, int>();

    public void PersonHinzufuegen(string name, int gesamtschritte)
    {
        throw new NotImplementedException();
    }

    public string AktivstePerson()
    {
        throw new NotImplementedException();
    }

    public bool EnthaeltPerson(string name)
    {
        throw new NotImplementedException();
    }
}
```

### Vorgegebener Testcode

```csharp
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
```

---

## Alle Tests in Main aufrufen

```csharp
static void Main(string[] args)
{
    // Teil 1 – Pflicht
    TestGesamtSchritte();
    TestDurchschnittSchritte();
    TestMaximaleSchritte();
    TestAnzahlZieltageErreicht();

    // Teil 2a – optional
    TestTagHinzufuegenUndAnzahlTage();
    TestDurchschnittMehrereTage();
    TestDurchschnittEinTag();

    // Teil 2b – optional
    TestAktivstePerson();
    TestEnthaeltPersonVorhanden();
    TestEnthaeltPersonNichtVorhanden();
}
```


---


## Hinweis zum Vorgehen (Red-Green-Refactor)

Die Tests und Klassengerüste sind bereits vorgegeben und befinden sich aktuell in der **Rot-Phase**: Jede Methode wirft `NotImplementedException`, das Programm kompiliert aber bereits vollständig.

Gehe Methode für Methode vor:
1. Wähle eine Methode aus und ersetze `throw new NotImplementedException();` durch echten Code. Kommentiere die anderen Testaufrufe temporär aus.
2. Führe das Programm aus und prüfe, ob der zugehörige Test grün wird. 
3. Erst wenn ein Test grün ist, gehe zur nächsten Methode über.

