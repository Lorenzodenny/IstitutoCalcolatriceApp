using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp.Core
{
    internal class Calcolatrice
    {
        public static void Calcoli()
        {
            try
            {
                string operazione;
                while (true)
                {
                    Console.WriteLine("Che operazione vuoi compiere? (addizione, sottrazione, moltiplicazione, divisione o media)");
                    operazione = Console.ReadLine().Trim().ToLower();

                    if (operazione == "addizione" || operazione == "sottrazione" || operazione == "moltiplicazione" || operazione == "divisione" || operazione == "media")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Operazione non valida. Riprova");
                    }
                }

                List<double> numeri = new List<double>();
                Console.WriteLine("Inserisci i numeri che vuoi, e digita 'fine' quando vuoi per terminare l'inserimento ");

                while (true)
                {
                    string input = Console.ReadLine().Trim().ToLower();
                    if (input == "fine")
                    {
                        break;
                    }
                    else if (double.TryParse(input, out double numero))
                    {
                        numeri.Add(numero);
                    }
                    else
                    {
                        Console.WriteLine($"inserisci un numero valido, {input} non va bene");
                    }
                }

                if (numeri.Count < 1 && operazione != "media")
                {
                    Console.WriteLine("Inserisci piu numeri");
                    return;
                }

                double risultato = 0;
                bool operazioneValida = true;

                switch (operazione)
                {
                    case "addizione":
                        risultato = Somma(numeri);
                        break;
                    case "sottrazione":
                        risultato = Sottrazione(numeri);
                        break;
                    case "moltiplicazione":
                        risultato = Moltiplicazione(numeri);
                        break;
                    case "divisione":
                        try
                        {
                            risultato = Divisione(numeri);
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine(ex.Message);
                            operazioneValida = false;
                        }
                        break;
                    case "media":
                        risultato = numeri.Media();
                        break;
                }

                if (operazioneValida)
                {
                    Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }



            static double Somma(List<double> numeri)
            {
                double risultato = 0;

                foreach (var numero in numeri)
                {
                    risultato += numero;
                }

                return risultato;
            }

            static double Sottrazione(List<double> numeri)
            {
                double risultato = numeri[0];

                for (int i = 1; i < numeri.Count; i++)
                {
                    risultato -= numeri[i];
                }

                return risultato;
            }

            static double Moltiplicazione(List<double> numeri)
            {
                double risultato = 1;

                foreach (var numero in numeri)
                {
                    risultato *= numero;
                }

                return risultato;
            }

            static double Divisione(List<double> numeri)
            {
                double risultato = numeri[0];

                for (int i = 1; i < numeri.Count; i++)
                {
                    if (numeri[i] == 0)
                    {
                        throw new DivideByZeroException("Non si può dividere per zero.");
                    }
                    risultato /= numeri[i];
                }

                return risultato;
            }
        }
    }
}
