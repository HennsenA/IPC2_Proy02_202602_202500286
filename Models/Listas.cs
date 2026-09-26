namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class Listas
    {
        public NodoLista Inicio { get; set; }

        public Listas()
        {
            Inicio = null;
        }

        public void Insertar(NodoLista nuevo)
        {
            if (Inicio == null)
            {
                Inicio = nuevo;
            }
            else
            {
                var actual = Inicio;

                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;//Insercion de nuevo elemento
            }
        }

        public void Eliminar(NodoLista nodo)
        {
            var actual = Inicio;

            while (actual.Siguiente != null)
            {
                if(actual.Siguiente.Equals(nodo))
                {
                    //Cambio de puntero para eliminar el nodo de la lista
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }

            Console.WriteLine("No se encontro el nodo a eliminar");
        }

        public NodoLista Buscar(NodoLista nodo)
        {
            var actual = Inicio;

            while(actual != null)
            {
                if (actual.Equals(nodo))
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }

            return actual;
        }

        public void ImprimirLista()
        {
            var actual = Inicio;
            while (actual != null)
            {
                actual.Valor.ImprimirDato();
                actual = actual.Siguiente;
            }
        }
    }
}
