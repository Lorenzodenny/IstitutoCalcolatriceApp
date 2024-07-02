using System;
using System.Runtime.CompilerServices;
using ConsoleApp.Core;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Sei qui per l'istituto, la calcolatrice o gli esercizi (istituto, calcolatrice, esercizi)");
                    string scelta = Console.ReadLine().Trim().ToLower();

                    switch (scelta)
                    {
                        case "istituto":
                            GestisciMembri.GestisciInserimentoMembri();
                            break;

                        case "calcolatrice":
                            Calcolatrice.Calcoli();
                            break;

                        case "esercizi":
                            EserciziSeparati.Eserci();
                            break;

                        default:
                            Console.WriteLine("Scelta non valida riprova");
                            continue;
                    }
                    break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
