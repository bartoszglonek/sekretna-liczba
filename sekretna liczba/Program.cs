using System;

class Program
{
    struct PoziomTrudnosci
    {
        public string Nazwa;
        public int IloscProb;
        public int ZakresOd;
        public int ZakresDo;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("WITAJ W GRZE SEKRETNA LICZBA");

        PoziomTrudnosci wybranyPoziom = WybierzPoziomTrudnosci();
        RozpocznijGre(wybranyPoziom);
    }

    static PoziomTrudnosci WybierzPoziomTrudnosci()
    {
        PoziomTrudnosci[] poziomy = {
            new PoziomTrudnosci { Nazwa = "latwy", IloscProb = 2, ZakresOd = 1, ZakresDo = 9 },
            new PoziomTrudnosci { Nazwa = "sredni", IloscProb = 5, ZakresOd = 10, ZakresDo = 99 },
            new PoziomTrudnosci { Nazwa = "trudny", IloscProb = 8, ZakresOd = 100, ZakresDo = 999 }
        };

        while (true)
        {
            Console.WriteLine("Wybierz poziom trudnosci (1 - latwy, 2 - sredni, 3 - trudny):");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                case "2":
                case "3":
                    Console.Clear();
                    Console.WriteLine($"Wybrales poziom {poziomy[int.Parse(wybor) - 1].Nazwa}.");
                    return poziomy[int.Parse(wybor) - 1];
                default:
                    Console.WriteLine("Wybrales nieodpowiedni poziom, sprobuj ponownie.");
                    break;
            }
        }
    }

    static void RozpocznijGre(PoziomTrudnosci poziom)
    {
        Random rnd = new Random();
        int sekretnaLiczba = rnd.Next(poziom.ZakresOd, poziom.ZakresDo + 1);

        Console.WriteLine($"\nPoziom trudnosci: {poziom.Nazwa}. Masz {poziom.IloscProb} proby, aby odgadnac liczbe z zakresu {poziom.ZakresOd}-{poziom.ZakresDo}.");

        //Console.WriteLine("Sekretna liczba to: " + sekretnaLiczba); // odkomentuj, aby zobaczyć sekretną liczbę

        for (int proba = 1; proba <= poziom.IloscProb; proba++)
        {
            Console.Write($"Proba {proba}: ");
            if (!int.TryParse(Console.ReadLine(), out int zgadywanaLiczba) ||
                zgadywanaLiczba < poziom.ZakresOd || zgadywanaLiczba > poziom.ZakresDo)
            {
                Console.WriteLine("NIEPRAWIDLOWA LICZBA. Wprowadz liczbe z odpowiedniego zakresu!");
                proba--;
                continue;
            }

            if (zgadywanaLiczba == sekretnaLiczba)
            {
                Console.WriteLine("Brawo! Odgadles liczbe!");
                return;
            }
            else if (zgadywanaLiczba < sekretnaLiczba)
            {
                Console.WriteLine("TWOJA LICZBA JEST MNIEJSZA OD SEKRETNEJ LICZBY");
            }
            else
            {
                Console.WriteLine("TWOJA LICZBA JEST WIĘKSZA OD SEKRETNEJ LICZBY");
            }
        }

        Console.WriteLine("SKONCZYLY SIE PROBY. Sekretna liczba to: " + sekretnaLiczba);
    }
}
