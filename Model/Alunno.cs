using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Abstract;

namespace ConsoleApp.Model
{
    public class Alunno : Umano
    {
        // data layer
        // dto modello uscita al client
        private string _classe;

        public string Classe
        {
            get { return _classe; }
            set { _classe = value.ToLower(); }
        }

        public Alunno(string nome, string cognome, string classe) : base(nome, cognome)
        {
            Classe = classe;
        }

        public Alunno(string nome, string cognome) : base(nome, cognome)
        {
            Classe = "non assegnata";
        }

        public override void Saluta()
        {
            if (Classe == "non assegnata")
            {
                Console.WriteLine($"Ciao io sono l'alunno nuovo e mi chiamo {Nome} {Cognome}");
            }
            else
            {
                Console.WriteLine($"Ciao io sono l'alunno {Nome} {Cognome} della classe {Classe}");
            }
        }

        public override string GetDettagli()
        {
            return $"{Nome} {Cognome}, Alunno della classe {Classe}";
        }
    }
}
