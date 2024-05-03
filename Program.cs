using System;
using System.Collections.Generic;

namespace Lab29
{
   

    internal class Program
    {
        static List<Zoomagaza> magaza = new List<Zoomagaza>();
        static Dictionary<string, string> users = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            users.Add("admin", "12345");

           

        l1:
            Console.WriteLine("Magazaya xos gelmisiz");
            Console.WriteLine("1.Daxil ol");
            Console.WriteLine("2.Qeydiyatdan kec");

            string input1 = Console.ReadLine();
            switch (input1)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                default:
                    Console.WriteLine("Duzgun reqem daxil edin");
                    goto l1;
            }
        }

        static void Login()
        {
            l1:
            Console.WriteLine("Istifadeci adi daxil edin");
            string username = Console.ReadLine();
            Console.WriteLine("Parol daxil edin");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("Giris basarili!");
                MainMenu();
            }
            else
            {
                Console.WriteLine("Yanlis istifadeci adi veya parol!");
                goto l1;
            }
        }

        static void Register()
        {
           l1:
            Console.WriteLine("Adinizi daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("Istifadeci adi daxil edin");
            string username = Console.ReadLine();
            Console.WriteLine("Parol daxil edin");
            string password = Console.ReadLine();

            users.Add(username, password);

            Console.WriteLine("Qeydiyyatdan kecdiz");

            if (username==username && password==password)
            {
               
                Login();
            }
            else
            {
                Console.WriteLine("Melumatlari duzgun daxil etmemisiz");
                goto l1;
            }
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Mehsul elave et");
                Console.WriteLine("2. Mehsullari goster");
                Console.WriteLine("3. Mehsulu deyis");
                Console.WriteLine("4. Mehsulu sil");
                Console.WriteLine("5. Cix");

                Console.Write("Seciminiz: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMehsul();
                        break;
                    case "2":
                        ListMehsul();
                        break;
                    case "3":
                        UpdateMehsul();
                        break;
                    case "4":
                        DeleteMehsul();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Duzgun secim daxil edin!");
                        break;
                }
            }
        }

        static void AddMehsul()
        {
            Console.WriteLine("Mehsulun adini daxil edin: ");
            string name = Console.ReadLine();
            Console.WriteLine("Id daxil edin: ");
            int number = Convert.ToInt32(Console.ReadLine());

            magaza.Add(new Zoomagaza { Name = name, Id = number });
            Console.WriteLine("Mehsul elave olundu.");
        }

        static void ListMehsul()
        {
            if (magaza.Count == 0)
            {
                Console.WriteLine("Mehsul yoxdu.");
            }
            else
            {
                Console.WriteLine("Butun mehsullar:");
                foreach (var item in magaza)
                {
                    Console.WriteLine($"Adı: {item.Name}, Id: {item.Id}");
                }
            }
        }

        static void UpdateMehsul()
        {
            Console.WriteLine("Yenilemek ucun Id daxil edin: ");
            int number = Convert.ToInt32(Console.ReadLine());

            var mehsul = magaza.Find(s => s.Id == number);
            if (mehsul == null)
            {
                Console.WriteLine("Mehsul tapilmadi.");
            }
            else
            {
                Console.WriteLine("Adi daxil edin: ");
                mehsul.Name = Console.ReadLine();
                Console.WriteLine("Mehsul deyisdirildi.");
            }
        }

        static void DeleteMehsul()
        {
            Console.WriteLine("Mehsulun Id sini daxil edin: ");
            int number = Convert.ToInt32(Console.ReadLine());

            var mehsul = magaza.Find(s => s.Id == number);
            if (mehsul == null)
            {
                Console.WriteLine("Mehsul tapilmadi.");
            }
            else
            {
                magaza.Remove(mehsul);
                Console.WriteLine("Mehsul silindi.");
            }
        }
    }
}
