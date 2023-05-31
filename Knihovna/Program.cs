using Knihovna_knih;
bool exit = false;
Knihovna knihovna = new Knihovna();
string nazevSouboru = "seznam_knih.txt"; //nazev souboru kde je vse ulozeno
knihovna.Nacteni(nazevSouboru); //nacte se list z minula
while (!exit)
{
    Console.WriteLine("------------------------");
    Console.WriteLine("Vyberte akci pomocí kliknutí čísla na klávesnici");
    Console.WriteLine("------------------------");
    Console.WriteLine("1. Přidat knihu");
    Console.WriteLine("2. Odebrat knihu");
    Console.WriteLine("3. Výpis knih");
    Console.WriteLine("4. Vyhledání dle názvu");
    Console.WriteLine("5. Vyhledání dle autora");
    Console.WriteLine("6. Vyhledání dle roku");
    Console.WriteLine("7. Konec programu (potřeba pro uložení");
    ConsoleKeyInfo vyber = Console.ReadKey(); //diky tomuto staci kliknout pouze klavesu a neni potreba klikat enter
    switch (vyber.Key) //pouzity case protoze jsou super
    {
        //pridani
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            Console.Clear();
            knihovna.PridatKnihy();
            break;
        //odebrani
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            Console.Clear();
            knihovna.OdebratKnihu();
            Console.Clear();
            break;
        //vypis knih
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            Console.Clear();
            knihovna.VypisKnih();
            break;
        //vyhledani dle nazvu
        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            Console.Clear();
            knihovna.VyhledaniNazvu();
            break;
            //vyhledani dle autora
        case ConsoleKey.D5:
        case ConsoleKey.NumPad5:
            Console.Clear();
            knihovna.VyhledaniAutor();
            break;
            //vyhledani dle roku
        case ConsoleKey.D6:
        case ConsoleKey.NumPad6:
            Console.Clear();
            knihovna.VyhledaniRok();
            break;
        //konec
        case ConsoleKey.D7:
        case ConsoleKey.NumPad7:
            knihovna.Ulozeni(nazevSouboru); //prepisuje soubor
            exit = true; //kvuli tomuto se ukonci program
            Console.Clear();
            Console.WriteLine("Program byl ukončen :)");
            break;
        //chyba
        default:
            Console.Clear();
            Console.WriteLine("Neplatná volba");
            break;
    }
}
