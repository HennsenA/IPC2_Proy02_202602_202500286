namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class NodoAvl
    {
        public Libro Dato { get; set; }
        public NodoAvl Padre {  get; set; }
        public NodoAvl Izquierdo { get; set; }
        public NodoAvl Derecho { get; set; }
        public int Altura { get; set; }
        
        public NodoAvl(Libro dato)
        {
            Dato = dato;
            Padre = null;
            Izquierdo = null;
            Derecho = null;
            Altura = 1;
        }

        public bool EsHoja()
        {
            return Izquierdo == null && Derecho == null;
        }

        public int Grado()
        {
            if (Derecho != null && Izquierdo == null)
            {
                return 1;
            }
            else if (Derecho == null && Izquierdo != null)
            {
                return -1;
            }
            else if (Derecho == null && Izquierdo == null)
            {
                return 2;
            }
            return 0;
        }

        public NodoAvl NodoMenor()
        {
            if (Derecho.Dato.Isbn > Izquierdo.Dato.Isbn)
            {
                return Derecho;
            }
            else
            {
                return Izquierdo;
            }
        }
    }
}
