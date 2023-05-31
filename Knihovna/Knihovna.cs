using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_knih
{
    class Knihovna
    {
        private List<Kniha> knihy = new List<Kniha>();
        //pridani knihy
        public void PridatKnihy()
        {
            Kniha kniha = new Kniha();
            try
            {
                Console.Write("Napiš název:");
                kniha.Nazev = Console.ReadLine();
                Console.Write("Napiš autora (Jen přijmení):");
                string autor = Console.ReadLine();
                kniha.Autor = char.ToUpper(autor[0]) + autor.Substring(1).ToLower(); //aby vzdy bylo prijmeni velkym pismenem u nazvu ne protoze muze byt naschval nazev malým pismen u knih
                Console.Write("Napiš rok:");
                kniha.Rok = int.Parse(Console.ReadLine());
                knihy.Add(kniha);
                Console.Clear();
                Console.WriteLine($"{kniha.Nazev} byl/a přidán/a");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chyba při přidávání produktu: " + ex.Message);
            }
        }
        //odebirani knih
        public void OdebratKnihu()
        {
            znovu:
            try
            {           
                foreach (Kniha kniha in knihy)
                {
                    Console.WriteLine($"{(knihy.IndexOf(kniha) + 1)}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine("Napiš číslo řádku produktu který chceš odebrat a ukonči odebírání pomocí čísla 0");
                int delka = knihy.Count();
                int indexListu = int.Parse(Console.ReadLine()) - 1;
                if (indexListu == 0)
                {
                    return;
                }
                if (delka < indexListu) //zajisteni chyby kdyz byste napsali vesti cislo nez je knih v listu
                {
                    Console.Clear();
                    goto znovu;
                }
                else if (delka >= indexListu)  
                {
                    knihy.RemoveAt(indexListu);
                    Console.Clear();
                    goto znovu;
                }                   
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Chyba při odebírání produktu: {ex.Message}");
                goto znovu;
            }
        }
        //vypis knih
        public void VypisKnih()
        {
            Console.WriteLine("Výpis knih");
            Console.WriteLine("-------------");
            foreach (Kniha kniha in knihy)
            {
                Console.WriteLine($"{knihy.IndexOf(kniha) + 1}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
            }

        }
        //vyhledani dle nazvu
        //zde jsem nepouzil psani velkym pismen jako u autora protoze kniha muze dle meho byt psana malym jako design nebo tak neco
        public void VyhledaniNazvu()
        {
            try
            {
                Console.Write("Zadej název: ");
                string hledanyNazev = Console.ReadLine();
                Console.Clear();
                List<Kniha> nalezenyNazev = knihy.FindAll(knihy => knihy.Nazev.Contains(hledanyNazev));
                Console.WriteLine("Výpis knih dle názvu");
                Console.WriteLine("---------------------");
                foreach (Kniha kniha in nalezenyNazev)
                {
                    Console.WriteLine($"{nalezenyNazev.IndexOf(kniha) + 1}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při vyhledání dle názvu {ex.Message}");
            }
        }
        //vyhledani dle autora
        public void VyhledaniAutor()
        {
            try
            {
                Console.Write("Zadej autora: ");
                string hledanyAutor = Console.ReadLine();
                hledanyAutor = hledanyAutor = char.ToUpper(hledanyAutor[0]) + hledanyAutor.Substring(1).ToLower(); //zajišteno psani velkeho pismena na zacatku
                Console.Clear();
                List<Kniha> nalezenaKniha = knihy.FindAll(knihy => knihy.Autor.Contains(hledanyAutor));
                Console.WriteLine("Výpis knih dle autora");
                Console.WriteLine("---------------------");
                foreach (Kniha kniha in nalezenaKniha)
                {
                    Console.WriteLine($"{nalezenaKniha.IndexOf(kniha) + 1}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
                }
            }
            catch (Exception ex) 
            { 
             Console.WriteLine ($"Chyba při vyhledání dle autora {ex.Message}");
            }
        }
        //vyhledani dle roku
        public void VyhledaniRok()
        {
            try
            {
                Console.Write("Zadej rok: ");
                int hledanyRok = int.Parse(Console.ReadLine());
                Console.Clear();
                List<Kniha> nalezenaKniha = knihy.FindAll(knihy => knihy.Rok == hledanyRok);
                Console.WriteLine("Výpis knih dle roku");
                Console.WriteLine("---------------------");
                foreach (Kniha kniha in nalezenaKniha)
                {
                    Console.WriteLine($"{nalezenaKniha.IndexOf(kniha) + 1}) {kniha.Nazev} - {kniha.Autor} - {kniha.Rok}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při vyhledání dle autora {ex.Message}");
            }
        }
        //ukladani listu do budoucna
        public void Ulozeni(string nazevSouboru)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(nazevSouboru)) //vpise list do souboru
                {
                    foreach (Kniha kniha in knihy)
                    {
                        string radek = $"{kniha.Nazev},{kniha.Autor},{kniha.Rok}";
                        sw.WriteLine(radek);
                    }
                }
                Console.WriteLine("Seznam knih byl uložen do souboru.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při ukládání seznamu knih: {ex.Message}");
            }
        }
        //Nacteni listu z minula
        public void Nacteni(string nazevSouboru)
        {
            try
            {
                if (File.Exists(nazevSouboru))
                {
                    using (StreamReader sr = new StreamReader(nazevSouboru)) //cte z souboru
                    {
                        string radek;
                        while ((radek = sr.ReadLine()) != null) //dokud nebude list prazdny
                        {
                            string[] polozky = radek.Split(','); //carkami se rozdeluji nazev,autor,rok
                            if (polozky.Length == 3)
                            {
                                string nazev = polozky[0];
                                string autor = polozky[1];
                                int rok = int.Parse(polozky[2]);                               
                                
                                    Kniha kniha = new Kniha
                                    {
                                        Nazev = nazev,
                                        Autor = autor,
                                        Rok = rok
                                    };
                                    knihy.Add(kniha);                                
                            }
                        }
                    }
                    Console.WriteLine("Seznam knih byl načten ze souboru.");
                }
                else
                {
                    Console.WriteLine("Soubor se seznamem knih neexistuje.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při načítání seznamu knih ze souboru: {ex.Message}");
            }
        }
    }
}         
