using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Abstract;

namespace ConsoleApp.Core
{
    internal class EserciziSeparati
    {
        public static void Eserci()
        {
            ProcessNumber();

            // Pattern Matching => capiamo il type di un oggetto

            object obj = 123;

            switch (obj)
            {
                case int i:
                    Console.WriteLine($"È un intero: {i}");
                    break;
                case string s:
                    Console.WriteLine($"È una stringa: {s}");
                    break;
                case null:
                    Console.WriteLine("È null");
                    break;
                default:
                    Console.WriteLine("Tipo sconosciuto");
                    break;
            }

            // Operatori logici

            int a1 = 5, b1 = 10, c = 15;
            bool result = a1 < b1 || c > b1 && a1 > c;

            Console.WriteLine(result);


            // Array di interfaccia
            IPersona[] persone = new IPersona[4];

            persone[0] = new Professore("Marco", "Silveri", "Web Development");
            persone[1] = new Alunno("Antonio", "Silveri", "5B");
            persone[2] = new Professore("Laura", "Carpentieri");
            persone[3] = new Alunno("Alberto", "Silveri");

            foreach (var persona in persone)
            {
                persona.Saluta();
                Console.WriteLine(persona.GetDettagli());
            }

            persone[0].Nome = "Valerio";
            persone[0].Cognome = "NonRicordo";

            Console.WriteLine("Dopo aver assegnato un altro nome, quindi aver sovrascritto la memoria Heap dell'oggetto[0]");

            foreach (var persona in persone)
            {
                persona.Saluta();
                Console.WriteLine(persona.GetDettagli());
            }


            // ValueType ReferenceType
            // ValueType memorizza nello stack

            int a = 5;
            int b = a;  // b è una copia di a
            b = 10;     // Modifica b, non influisce su a
            Console.WriteLine(a); // Output: 5
            Console.WriteLine(b); // Output: 10

            // ReferenceType salva nella memoria Heap, ma string è particolare il C#

            string s1 = "Hello";
            string s2 = s1;  // s2 punta agli stessi dati di s1 ("Hello")
            s2 = "World";    // s2 ora punta a nuovi dati ("World"), s1 rimane invariato

            Console.WriteLine(s1); // Output: Hello
            Console.WriteLine(s2); // Output: World

            // Passaggio di parametro per Valore e per Riferimento


            int valore = 5;
            Console.WriteLine($"Valore iniziale: {valore}"); // 5

            IncrementaValore(valore);
            Console.WriteLine($"Dopo IncrementaValore: {valore}"); // 5

            IncrementaRiferimento(ref valore);
            Console.WriteLine($"Dopo IncrementaRiferimento: {valore}"); // 6

            int outValore;
            AssegnaValore(out outValore);
            Console.WriteLine($"Dopo AssegnaValore: {outValore}"); // 10
        }

        // Try Catching di errori
        public static void ProcessNumber()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Inserisci un numero intero:");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Hai inserito il numero: {number}");
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Errore: Il valore inserito non è un numero intero valido. {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Errore: Il numero inserito è troppo grande o troppo piccolo. {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Si è verificato un errore imprevisto: {ex.Message}");
                }
            }

        }



        static void IncrementaValore(int numero)
        {
            numero++;
        }

        static void IncrementaRiferimento(ref int numero)
        {
            numero++;
        }

        static void AssegnaValore(out int numero)
        {
            numero = 10;
        }
    }
}
