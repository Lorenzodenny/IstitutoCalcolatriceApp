using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Model;

namespace ConsoleApp.Core
{
    public class Istituto
    {
        private List<Professore> professori = new List<Professore>();
        private List<Alunno> alunni = new List<Alunno>();

        public void AggiungiProfessore(Professore prof)
        {
            professori.Add(prof);
        }

        public void AggiungiAlunno(Alunno alunno)
        {
            alunni.Add(alunno);
        }

        public void VisualizzaIstituto()
        {
            try
            {
                Console.WriteLine("La lista dei professori:");

                foreach (var prof in professori)
                {
                    prof.Saluta();
                }

                Console.WriteLine("La lista degli alunni:");

                foreach (var alunno in alunni)
                {
                    alunno.Saluta();
                }

                Console.WriteLine("Vuoi filtrare per materia o classe? (si/no)");
                string filtro = Console.ReadLine().Trim().ToLower();

                if (filtro == "si")
                {
                    while (true)
                    {
                        Console.WriteLine("vuoi filtrare per classe o per materia? (classe/materia)");
                        string classeMateria = Console.ReadLine().Trim().ToLower();

                        if (classeMateria == "classe")
                        {
                            Console.WriteLine("Dimmi che classe vuoi ricercare?");
                            string classe = Console.ReadLine().Trim().ToLower();

                            TrovaAlunniClasse(classe);
                            break;
                        }
                        else if (classeMateria == "materia")
                        {
                            Console.WriteLine("Dimmi che materia vuoi ricercare?");
                            string materia = Console.ReadLine().Trim().ToLower();

                            TrovaProfMateria(materia);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Questo filtro non esiste. Riprova");
                            continue;
                        }
                    }

                }

                while (true)
                {
                    Console.WriteLine("Vuoi inserire un nuovo membro o uscire (inserire/uscire)");
                    string scelta = Console.ReadLine().Trim().ToLower();

                    if (scelta == "uscire")
                    {
                        Console.WriteLine("Arrivederci");
                        Environment.Exit(0); // Termina l'applicazione
                    }
                    else if (scelta == "inserire")
                    {
                        GestisciMembri.GestisciInserimentoMembri();
                    }
                    else
                    {
                        Console.WriteLine("Opzione non valida. Riprova.");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la visualizzazione dell'istituto: {ex.Message}");
            }

        }


        public void TrovaProfMateria(string materia)
        {

            try
            {
                var profTrovati = professori.Where(p => p.Materia == materia).ToList();

                if (profTrovati.Count > 0)
                {
                    Console.WriteLine($"i professori che insegnano {materia} sono:");
                    foreach (var prof in profTrovati)
                    {
                        prof.Saluta();
                    }
                }
                else
                {
                    Console.WriteLine($"non ci sono professori che insegno {materia}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella ricerca della materia per i professori: {ex.Message}");
            }

        }

        public void TrovaAlunniClasse(string classe)
        {
            try
            {
                var alunniTrovati = alunni.Where(a => a.Classe == classe).ToList();

                if (alunniTrovati.Count > 0)
                {
                    Console.WriteLine($"Gli alunni frequentanti la classe {classe} sono:");
                    foreach (var alunno in alunniTrovati)
                    {
                        alunno.Saluta();
                    }
                }
                else
                {
                    Console.WriteLine($"Non ci sono alunni della classe {classe}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nella ricerca della classe per gli alunni {ex.Message}");
            }
        }

    }
}
