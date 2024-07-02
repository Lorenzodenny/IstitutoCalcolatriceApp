using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Abstract
{
    internal interface IPersona
    {
        string Nome { get; set; }
        string Cognome { get; set; }
        void Saluta();
        string GetDettagli();
    }
}
