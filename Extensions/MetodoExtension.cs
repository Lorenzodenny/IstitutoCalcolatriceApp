using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Extensions
{
    public static class MetodoExtension
    {
        public static double Media(this List<double> numeri)
        {
            if (numeri.Count == 0)
            {
                throw new InvalidOperationException("La lista è vuota.");
            }

            double somma = 0;

            foreach (var numero in numeri)
            {
                somma += numero;
            }

            double media = somma / numeri.Count;

            return media;

        }
    }
}
