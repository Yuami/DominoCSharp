using System;
using System.Collections.Generic;
using System.Text;

namespace Domino
{
    public class Tablero
    {
        private List<Ficha> fichas = new List<Ficha>();
        private List<Ficha> extremos = new List<Ficha>();

        public void Add(Ficha f, Orientacion o)
        {
            if (!compOrientacion(f, o)) f.girarFicha();

            if (o == Orientacion.Derecha)
                fichas.Add(f);
            else
                fichas.Insert(0, f);
            f.SetVertical(f.IsDoble());

            var i = (int) o;
            extremos.RemoveAt(i);
            extremos.Insert(i, f);
        }

        public void Add(Ficha f)
        {
            fichas.Add(f);
            f.SetVertical(f.IsDoble());
            foreach (var o in Enum.GetValues(typeof(Orientacion)))
                extremos.Insert((int) o, f);
        }

        public List<Orientacion> OrientacionesPosibles(Ficha f)
        {
            var list = new List<Orientacion>((Orientacion[]) Enum.GetValues(typeof(Orientacion)));
            return list.FindAll(o => isUtilizable(f, o));
        }

        private bool isUtilizable(Ficha f, Orientacion o)
        {
            if (compOrientacion(f, o))
                return true;
            f.girarFicha();
            return compOrientacion(f, o);
        }


        private bool compOrientacion(Ficha f, Orientacion o)
        {
            var val = (int) o;
            return extremos[val].Valores[val] == f.Valores[++val % extremos.Count];
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            s.Append("\nFichas tablero: \n");
            fichas.ForEach(f => s.Append(f));

            s.Append("\nFichas en los extremos: \n");
            extremos.ForEach(f => s.Append(f));
            s.Append("\n");

            return s.ToString();
        }
    }
}