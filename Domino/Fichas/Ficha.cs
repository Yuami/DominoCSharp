namespace Domino
{
    public class Ficha
    {
        public Ficha(int i, int d)
        {
            Valores[(int) Orientacion.Derecha] = d;
            Valores[(int) Orientacion.Izquierda] = i;
        }

        public int[] Valores { get; } = new int[2];
        public bool Vertical { get; set; } = false;

        public bool IsDoble()
        {
            return Valores[0] == Valores[1];
        }
        
        public int GetValorTotal() {
            return Valores[0] + Valores[1];
        }

        public void girarFicha()
        {
            var temp = Valores[0];
            Valores[0] = Valores[1];
            Valores[1] = temp;
        }
        
        public void SetVertical(bool vertical) {
            Vertical = vertical;
        }

        public override string ToString()
        {
            return "[" + Valores[(int) Orientacion.Izquierda] + "|" + Valores[ (int) Orientacion.Derecha] + "]";
        }
    }
}