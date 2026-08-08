using System.IO;
using System.Security.Cryptography.X509Certificates;
class Uczen
{
    FileStream FIN, FOUT;
    int[] oceny = new int[11];
    string uczen;
    double srednia = 0;
    double suma = 0;
    public void wczytaj_dane()
    {
        Console.Write("Podaj imię i nazwisko ucznia: ");
        uczen = Console.ReadLine();



        Console.WriteLine("Wylosowane oceny: ");
        Random random = new Random();
        for (int i = 1; i <= 10; i++)
        {
            oceny[i] = random.Next(1, 7);
            
            Console.WriteLine($"Ocena {i}: {oceny[i]}");
        }

    }

    public void oblicz_srednia()
    {
        for(int i = 1; i <= 10; i++)
        {
            suma += oceny[i];
        }
        srednia = suma / 10;

    }
    public void wyswietl()
    {
        Console.WriteLine($"Uczeń: {uczen}");
        Console.WriteLine("Oceny: ");
        for(int i=1; i <= 10; i++)
        {
            Console.Write($"{oceny[i], 4}");
            
        }
        Console.WriteLine();
        Console.Write($"Średnia ocen: {srednia}\n");
    }

    public void Zapisz_do_pliku()
    {
        FOUT = new FileStream("Uczen.txt", FileMode.Create);
        StreamWriter zapis = new StreamWriter(FOUT);
        zapis.WriteLine(uczen, srednia, oceny);
        zapis.Close();
        FOUT.Close();
    }
    public void Odczytaj_z_pliku()
    {
        Console.WriteLine("Odczytuje dane z pliku: ");
        FIN = new FileStream("Uczen.txt", FileMode.Open);
        StreamReader odczyt = new StreamReader(FIN);    
        odczyt.Close();
        FIN.Close();



    }   
    static void Main(string[] args)
    {
        Uczen uczen = new Uczen(); 
        uczen.wczytaj_dane();
        uczen.oblicz_srednia();
        uczen.wyswietl();  
        uczen.Zapisz_do_pliku();
        uczen.Odczytaj_z_pliku();


    }
}