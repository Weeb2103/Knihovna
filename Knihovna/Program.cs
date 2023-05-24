using Knihovna_knih;
bool exit = false;
Knihovna knihovna = new Knihovna();
string nazevSouboru = "seznam_knih.txt";
knihovna.Nacteni(nazevSouboru);
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
    Console.WriteLine("7. Konec programu");
    ConsoleKeyInfo vyber = Console.ReadKey();
    switch (vyber.Key)
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
        //inventar
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            Console.Clear();
            knihovna.VypisKnih();
            break;
        //vyhledani dle autora
        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            Console.Clear();
            knihovna.VyhledaniNazvu();
            break;
        case ConsoleKey.D5:
        case ConsoleKey.NumPad5:
            Console.Clear();
            knihovna.VyhledaniAutor();
            break;
        case ConsoleKey.D6:
        case ConsoleKey.NumPad6:
            Console.Clear();
            knihovna.VyhledaniRok();
            break;
        //konec
        case ConsoleKey.D7:
        case ConsoleKey.NumPad7:
            knihovna.Ulozeni(nazevSouboru);
            exit = true;
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
