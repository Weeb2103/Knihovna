﻿using Knihovna_knih;
bool exit = false;
Knihovna knihovna = new Knihovna();
while (!exit)
{
    Console.WriteLine("------------------------");
    Console.WriteLine("Vyberte akci pomocí kliknutí čísla na klávesnici");
    Console.WriteLine("------------------------");
    Console.WriteLine("1. Přidat knihu");
    Console.WriteLine("2. Odebrat knihu");
    Console.WriteLine("3. Výpis knih");
    Console.WriteLine("4. Konec programu");
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
        //konec
        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            exit = true;
            Console.Clear();
            Console.WriteLine("Program byl ukončen :)");
            break;
        //chyba
        default: //použito kdyby uživatel zadal jiné znaky něž 1, 2, 3, 4 
            Console.Clear();
            Console.WriteLine("Neplatná volba");
            break;
    }
}