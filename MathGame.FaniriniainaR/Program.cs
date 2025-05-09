using System;
using System.Collections.Generic;

namespace JeuMaths
{
    class Program
    {
        static List<string> historique = new List<string>();
        static int score = 0;
        static int niveauMax = 10;
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu de maths !");
            Console.WriteLine("------Choisissez votre niveau-------");
            Console.WriteLine("1 - Niveau Facile");
            Console.WriteLine("2 - Niveau normal");
            Console.WriteLine("3 - Niveau Difficile");
            Console.Write("Votre choix: ");
            string niveau = Console.ReadLine();

            switch (niveau)
            {
                case "1":
                    niveauMax = 10;
                    break;
                case "2":
                    niveauMax = 20;
                    break;
                case "3":
                    niveauMax = 30;
                    break;
                default:
                    Console.WriteLine("Niveau invalide, le niveau facile sera utilisé par défaut.");
                    niveauMax = 10;
                    break;
            }

            bool continuer = true;
            while(continuer)
            {
                Console.WriteLine("----------------Menu----------------");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Soustraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Voir l'historique");
                Console.WriteLine("6 - Quitter");
                Console.Write("Votre choix: ");
                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        Jouer("+");
                        break;
                    case "2":
                        Jouer("-");
                        break;
                    case "3":
                        Jouer("*");
                        break;
                    case "4":
                        Jouer("/");
                        break;
                    case "5":
                        AfficherHistorique();
                        break;
                    case "6":
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide, veuillez réessayer.");
                        break;
                }
            }
        }

        static void Jouer(string operateur)
            {
                int a, b, resultatAttendu = 0;
                string question = null;

                if (operateur == "+")
                {
                    a = random.Next(1, niveauMax);
                    b = random.Next(1, niveauMax);
                    resultatAttendu = a + b;
                    question = $"{a} + {b} = ?";
                }
                else if (operateur == "-")
                {
                    a = random.Next(1, niveauMax);
                    b = random.Next(1, a);
                    resultatAttendu = a - b;
                    question = $"{a} - {b} = ?";
                }
                else if (operateur == "*")
                {
                    a = random.Next(1, niveauMax);
                    b = random.Next(1, niveauMax);
                    resultatAttendu = a * b;
                    question = $"{a} * {b} = ?";
                }
                else if (operateur == "/")
                {
                    b = random.Next(1, niveauMax);
                    resultatAttendu = random.Next(1, niveauMax);
                    a = resultatAttendu * b;
                    question = $"{a} / {b} = ?";
                }

                var debut = DateTime.Now;
                Console.WriteLine(question);
                Console.Write("Votre réponse: ");
                string reponse = Console.ReadLine();
                var fin = DateTime.Now;
                var tempsEcoule = (fin - debut).TotalMinutes;

                if (int.TryParse(reponse, out int resultatInt) && resultatInt == resultatAttendu)
                {
                    Console.WriteLine("Correct !");
                    score++;
                    historique.Add($"{question} Votre réponse: {reponse} | Correct | Temps: {tempsEcoule:F1}s");
                }
                else
                {
                    Console.WriteLine($"Incorrect ! La bonne réponse est {resultatAttendu}");
                    historique.Add($"{question} Votre réponse: {reponse} | Incorrect | Temps: {tempsEcoule:F1}s");
                }
            }

            static void AfficherHistorique()
            {
                Console.WriteLine("Historique des réponses:");
                foreach (var item in historique)
                {
                    Console.WriteLine(item);
                }
            }
    }
}
