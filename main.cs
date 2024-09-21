using System;
using System.Timers;

class ToplamaOyunu
{
    static int puan = 0;
    static Random random = new Random();
    static Timer timer;
    static int sure = 30; // Oyunun süresi (saniye)

    static void Main(string[] args)
    {
        Console.WriteLine("Toplama Oyununa Hoşgeldiniz!");
        Console.WriteLine("Ekrana gelen sayıları toplayın ve puan kazanın.");
        Console.WriteLine($"Süreniz: {sure} saniye");
        Console.WriteLine("Başlamak için herhangi bir tuşa basın...");
        Console.ReadKey();

        Baslat();
    }

    static void Baslat()
    {
        timer = new Timer(1000); // 1 saniyelik interval
        timer.Elapsed += Timer_Tick;
        timer.Start();

        while (sure > 0)
        {
            int sayi1 = random.Next(1, 10);
            int sayi2 = random.Next(1, 10);
            Console.WriteLine($"\n{sayi1} + {sayi2} = ?");
            
            string giris = Console.ReadLine();
            if (int.TryParse(giris, out int kullaniciCevabi))
            {
                if (kullaniciCevabi == sayi1 + sayi2)
                {
                    puan += 10;
                    Console.WriteLine("Doğru! +10 Puan");
                }
                else
                {
                    Console.WriteLine("Yanlış cevap!");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş, lütfen sayı girin.");
            }
        }

        timer.Stop();
        Console.WriteLine("\nSüre doldu!");
        Console.WriteLine($"Toplam Puanınız: {puan}");
    }

    private static void Timer_Tick(object sender, ElapsedEventArgs e)
    {
        sure--;
        if (sure <= 0)
        {
            timer.Stop();
        }
    }
}
