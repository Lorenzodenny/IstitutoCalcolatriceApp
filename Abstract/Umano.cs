using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Abstract
{
    public abstract class Umano : IPersona
    {
        protected string _nome;
        protected string _cognome;

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public Umano(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }

        public abstract void Saluta();

        public abstract string GetDettagli();

    }
}
