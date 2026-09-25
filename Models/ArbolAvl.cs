using System.Numerics;

namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class ArbolAvl
    {
        public NodoAvl Raiz { get; set;  }

        public ArbolAvl()
        {
            Raiz = null;
        }

        public NodoAvl InsertarNodo(NodoAvl nodo, Libro NuevoLibro)
        {
            if (nodo == null)
            {
                nodo = new NodoAvl(NuevoLibro);

                return nodo;
            }
            else
            {
                if (nodo.Dato.Isbn == NuevoLibro.Isbn)
                {
                    return nodo;
                }

                if (NuevoLibro.Isbn > nodo.Dato.Isbn)
                {
                    nodo.Derecho = InsertarNodo(nodo.Derecho, NuevoLibro);
                }
                else
                {
                    nodo.Izquierdo = InsertarNodo(nodo.Izquierdo, NuevoLibro);
                }

                nodo.Altura = 1 + nodo.Grado();

                return Balanceo(nodo);
            }
        }

        public NodoAvl Eliminar(NodoAvl nodo, Libro libro)
        {
            if (nodo == null)//Arbol vacio o nodo inexistente
            {
                return null;
            }

            if (libro.Isbn > nodo.Dato.Isbn)
            {
                nodo.Derecho = Eliminar(nodo.Derecho, libro);
                return Balanceo(nodo.Derecho);
            }
            else if (libro.Isbn < nodo.Dato.Isbn)
            {
                nodo.Izquierdo = Eliminar(nodo.Izquierdo, libro);
                return Balanceo(nodo.Izquierdo);
            }
            else
            {
                //El nodo es una hoja
                if (nodo.EsHoja() == true)
                {
                    nodo = null;
                    return nodo;
                }

                //El nodo tiene un hijo
                if (nodo.Grado() == 1)
                {
                    return nodo.Derecho;
                }
                if (nodo.Grado() == -1)
                {
                    return nodo.Izquierdo;
                }

                //El nodo tiene dos hijos
                if (nodo.Grado() == 2)
                {
                    return nodo.Derecho.NodoMenor(); //se toma al menor del arbol derecho 
                }
            }
            return nodo;
        }

        public bool Buscar(NodoAvl nodo, int isbn)
        {
            if (nodo == null)
            {
                return false;
            }

            if (nodo.Dato.Isbn == isbn)
            {
                return true;
            }

            if (isbn > nodo.Dato.Isbn)
            {
                return Buscar(nodo.Derecho, isbn);
            }
            else
            {
                return Buscar(nodo.Izquierdo, isbn);
            }
        }

        public NodoAvl BuscarNodo(NodoAvl nodo, int? isbn){
            if (nodo == null)
            {
                return null;
            }

            if (nodo.Dato.Isbn == isbn)
            {
                return nodo;
            }

            if(isbn < nodo.Dato.Isbn)
            {
                return BuscarNodo(nodo.Izquierdo, isbn);
            }
            else
            {
                return BuscarNodo(nodo.Derecho, isbn);
            }
        }

        public string InOrder(NodoAvl nodo)
        {
            String lista = "";
            if (nodo != null)
            {
                lista += InOrder(nodo.Izquierdo);
                lista += nodo.Dato.Isbn.ToString() + " ";
                lista += InOrder(nodo.Derecho);
            }
            return lista;
        }

        public NodoAvl MenorLibro()
        {
            var actual=Raiz;
            while (actual.Izquierdo != null)
            {
                actual=actual.Izquierdo;
            }
            return actual;
        }
        public NodoAvl MayorLibro()
        {
            var actual=Raiz;
            while (actual.Derecho != null)
            {
                actual=actual.Derecho;
            }
            return actual;
        }
        public int FactorBalance(NodoAvl nodo)
        {
            return CalcAltura(nodo.Izquierdo) - CalcAltura(nodo.Derecho);
        }

        public int CalcAltura(NodoAvl nodo)
        {
            int alturaD = 0, alturaI = 0;

            if (nodo == null)
            {
                return 0;
            }
            if (nodo.Derecho != null)
            {
                alturaD = CalcAltura(nodo.Derecho) + 1;
            }
            if (nodo.Izquierdo != null)
            {
                alturaI = CalcAltura(nodo.Izquierdo) + 1;
            }

            if (alturaD > alturaI)
            {
                return alturaD;
            }
            else
            {
                return alturaI;
            }
        }

        public NodoAvl Balanceo(NodoAvl nodo)
        {
            int fb = FactorBalance(nodo);

            if (fb >= -1 && fb <= 1)
            {
                return nodo;
            }

            //Primer caso LR
            if (fb > 1 && FactorBalance(nodo.Izquierdo) < 0)
            {
                nodo.Izquierdo = RotarIzquierda(nodo.Izquierdo);
                return RotarDerecha(nodo);
            }
            else if (fb > 1 && FactorBalance(nodo.Izquierdo) >= 0)//Segundo caso LL
            {
                return RotarDerecha(nodo);
            }

            //Tercer caso RL
            if (fb < -1 && FactorBalance(nodo.Derecho) > 0)
            {
                nodo.Derecho = RotarDerecha(nodo.Derecho);
                return RotarIzquierda(nodo);
            }
            else if (fb < -1 && FactorBalance(nodo.Derecho) <= 0)
            {
                return RotarIzquierda(nodo);
            }

            return nodo;
        }
        public NodoAvl RotarDerecha(NodoAvl nodo)
        {
            NodoAvl nuevaRaiz = nodo.Izquierdo;
            nodo.Izquierdo = nuevaRaiz.Derecho;
            nuevaRaiz.Derecho = nodo;

            return nuevaRaiz;
        }
        public NodoAvl RotarIzquierda(NodoAvl nodo)
        {
            NodoAvl nuevaRaiz = nodo.Derecho;
            nodo.Derecho = nuevaRaiz.Izquierdo;
            nuevaRaiz.Izquierdo = nodo;

            return nuevaRaiz;
        }
    }
}
