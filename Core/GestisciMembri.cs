using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;

namespace ConsoleApp.Core
{
    internal class GestisciMembri
    {
        private static Istituto istituto = new Istituto();

        public static void GestisciInserimentoMembri()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Ciao, benvenuto sei un alunno o un professore? (alunno/professore)");
                    string ruolo = Console.ReadLine().Trim().ToLower();

                    if (ruolo == "professore")
                    {
                        Professore prof = Creazione.CreaProfessore();
                        istituto.AggiungiProfessore(prof);
                    }
                    else if (ruolo == "alunno")
                    {
                        Alunno alunno = Creazione.CreaAlunno();
                        istituto.AggiungiAlunno(alunno);
                    }
                    else
                    {
                        Console.WriteLine("il ruolo non esiste, ridigita corettamente");
                        continue;
                    }

                    Console.Clear();

                    Console.WriteLine("Vuoi creare un'altro utente? (si/no)");
                    string risposta = Console.ReadLine().Trim().ToLower();

                    Console.Clear();

                    if (risposta != "si")
                    {
                        Console.WriteLine("Vuoi visionare la lista dell'istituto dei prof e degli alunni? (si/no)");
                        string visione = Console.ReadLine().Trim().ToLower();

                        Console.Clear();

                        if (visione == "si")
                        {
                            istituto.VisualizzaIstituto();
                        }
                        Console.WriteLine("Arrivederci!!!");
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante l'inseriemnto membri: {ex.Message}");
            }
        }
    }
}
