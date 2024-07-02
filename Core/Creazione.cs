using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;

namespace ConsoleApp.Core
{
    public static class Creazione
    {
        private static string RichiediInput(string messaggio)
        {

            string input;

            try
            {
                do
                {
                    Console.WriteLine(messaggio);
                    input = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Input non valido o campo vuoto. Riprova");
                    }
                } while (string.IsNullOrEmpty(input));

                return input;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O durante la lettura dell'input: {ex.Message}");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Memoria insufficiente per completare l'operazione: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"L'input è troppo lungo: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore imprevisto: {ex.Message}");
            }

            return null;
        }

        public static Professore CreaProfessore()
        {
            try
            {
                string nome = RichiediInput("Inserisci il tuo nome");
                string cognome = RichiediInput("Inserisci il tuo cognome");

                Console.WriteLine("Il professore ha già una materia? (si/no)");
                string haMateria = Console.ReadLine().Trim().ToLower();

                Professore prof;
                if (haMateria == "si")
                {
                    string materia = RichiediInput("Che materia insegna?");
                    prof = new Professore(nome, cognome, materia);
                }
                else
                {
                    prof = new Professore(nome, cognome);
                }

                return prof;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O durante la creazione del professore: {ex.Message}");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Memoria insufficiente per completare l'operazione: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"L'input è troppo lungo: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore imprevisto durante la creazione del professore: {ex.Message}");
            }

            return null;
        }

        public static Alunno CreaAlunno()
        {
            try
            {
                string nome = RichiediInput("Inserisci il tuo nome");
                string cognome = RichiediInput("Inserisci il tuo cognome");

                Console.WriteLine("L'alunno ha già una classe? (si/no)");
                string haClasse = Console.ReadLine().Trim().ToLower();

                Alunno alunno;
                if (haClasse == "si")
                {
                    string classe = RichiediInput("Che classe frequenta");
                    alunno = new Alunno(nome, cognome, classe);
                }
                else
                {
                    alunno = new Alunno(nome, cognome);
                }

                return alunno;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O durante la creazione dell'alunno: {ex.Message}");
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Memoria insufficiente per completare l'operazione: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"L'input è troppo lungo: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore imprevisto durante la creazione dell'alunno: {ex.Message}");
            }

            return null;

        }
    }


}
