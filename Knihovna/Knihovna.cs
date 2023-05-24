﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_knih
{
    class Knihovna
    {
        private List<Kniha> knihy = new List<Kniha>();
        public void PridatKnihy()
        {
             Kniha kniha= new Kniha();
            try
            {
                Console.Write("Napiš název:");
                kniha.Nazev = Console.ReadLine();
                Console.Write("Napiš autora:");
                kniha.Autor = Console.ReadLine();
                Console.Write("Napiš rok");
                kniha.Rok = int.Parse(Console.ReadLine());
                knihy.Add(kniha);
                Console.Clear();
                Console.WriteLine($"{kniha.Nazev} byl přidán");
            }
            catch (Exception ex) 
            {
             Console.WriteLine("Chyba při přidávání produktu: " + ex.Message);
            }
        }
        public void OdebratKnihu()
        {
            try
            {
                znovu:
                foreach (Kniha kniha in knihy)
                {
                    Console.WriteLine($"{(knihy.IndexOf(kniha) + 1)}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}"); 
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine("Napiš číslo řádku produktu který chceš odebrat a ukonči odebírání pomocí čísla 777");
                int indexListu = int.Parse(Console.ReadLine()) - 1;
                if (indexListu == 777); 
                else
                    knihy.RemoveAt(indexListu);
                Console.Clear();
                goto znovu;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při odebírání produktu: " + ex.Message);
            }
        }
        public void VypisKnih()
        {
            Console.WriteLine("Výpis knih");
            Console.WriteLine("-------------");
            foreach(Kniha kniha in knihy)
            {
                Console.WriteLine($"{(knihy.IndexOf(kniha) + 1)}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
            }

        }





















    }
}