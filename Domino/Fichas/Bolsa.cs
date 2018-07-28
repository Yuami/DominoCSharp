using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domino
{
    public class Bolsa
    {
        private readonly List<Ficha> bolsa = new List<Ficha>();

        public Bolsa(int maximoFichas)
        {
            for (var i = 0; i <= maximoFichas; i++)
            for (var j = 0; j <= i; j++)
                bolsa.Add(new Ficha(i, j));

            bolsa = bolsa.OrderBy(f => Guid.NewGuid()).ToList();
        }

        public int GetTotalFichas()
        {
            return bolsa.Count;
        }

        public Ficha SacarFicha()
        {
            if (!bolsa.Any()) return null;
            var f = bolsa[0];
            bolsa.RemoveAt(0);
            return f;
        }

        public override string ToString()
        {
            return "Fichas en la bolsa: " + bolsa.Count;
        }
        
        public static string fichasToString(List<Ficha> bolsa) {
            var fichas = new StringBuilder();
            for (var i = 0; i < bolsa.Count; i++)
                fichas.Append(i + 1).Append(":").Append(bolsa[i]).Append(" ");

            return fichas.ToString();
        }
    }
}