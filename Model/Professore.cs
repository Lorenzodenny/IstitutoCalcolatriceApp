using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Abstract;

namespace ConsoleApp.Model
{
    public class Professore : Umano
    {
        private string _materia;

        //public string Nome
        //{
        //    get { return _nome; }
        //    set { _nome = value.ToUpper(); }
        //}

        public string Materia
        {
            get { return _materia; }
            set { _materia = value.ToLower(); }
        }

        public Professore(string nome, string cognome, string materia) : base(nome, cognome)
        {
            Materia = materia;
        }

        public Professore(string nome, string cognome) : base(nome, cognome)
        {
            Materia = "non assegnata";
        }

        public override void Saluta()
        {
            if (Materia == "non assegnata")
            {
                Console.WriteLine($"Ciao sono un professore e mi chiamo {Nome} {Cognome}");
            }
            else
            {
                Console.WriteLine($"Ciao sono {Nome} {Cognome} e sono il professore di {Materia}");
            }
        }

        public override string GetDettagli()
        {
            return $"{Nome} {Cognome}, Professore di {Materia}";
        }
    }
}
