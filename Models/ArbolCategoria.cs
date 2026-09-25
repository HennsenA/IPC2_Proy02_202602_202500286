namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class ArbolCategoria
    {
        private NodoCategoria Raiz { get; set; }
        private int CantidadNodos { get; set; }

        public ArbolCategoria()
        {
            Raiz = new NodoCategoria(new Categorias("", "inicial"));
            CantidadNodos = 0;
        }

        public bool Vacio()
        {
            return Raiz == null;
        }
        public int NoNodos()
        {
            return CantidadNodos;
        }

        //Implementar metodos
        public bool InsertarCat(NodoCategoria nodo)
        {
            if (ExisteCat(nodo.Datos.Nombre) == true)
            {
                Console.WriteLine("La categoria ya existe");
                return false;//Categoria ya existe
            }

            //Primer caso: La categoria es una raiz
            if (nodo.Datos.Padre==null) {
                Insercion(Raiz, nodo);
            }
            else //Nodo hijo (subcategoria)
            {
                NodoCategoria padre = BuscarCat(Raiz, nodo.Datos.Padre);
                if (padre == null)
                {
                    return false;
                }

                Insercion(padre, nodo);
            }
            CantidadNodos++;
            return true;
        }
        private void Insercion(NodoCategoria padre, NodoCategoria hijo)
        {
            if (padre.SubCatIzq == null)//Primera subcategoria
            {
                padre.SubCatIzq = hijo;
                return;
            }

            //Verificacion con primera subcategoria
            if(String.Compare(hijo.Datos.Nombre, padre.SubCatIzq.Datos.Nombre) > 0)
            {
                NodoCategoria aux = padre.SubCatIzq;
                padre.SubCatIzq = hijo;
                hijo.HermanoDer = aux;
                return;
            }

            //Verificacion con hermanos (Insercion en cualquier posicion del arbol menos el final)
            var actual = padre.SubCatIzq;
            bool insertado = false;
            while (actual.HermanoDer!=null && insertado==false)
            {
                int comparacion = string.Compare(hijo.Datos.Nombre, actual.HermanoDer.Datos.Nombre);
                if (comparacion > 0)
                {
                    NodoCategoria aux = actual.HermanoDer;
                    actual.HermanoDer = hijo;
                    hijo.HermanoDer = aux;
                    insertado = true;
                } else if (comparacion < 0)
                {
                    actual = actual.HermanoDer;
                }
                else
                {
                    //Categoria ya existe
                    return;
                }
            }

            //Insercion al final de los hermanos
            actual.HermanoDer = hijo;
        }

        public bool ExisteCat(string nombre)
        {
            return BuscarCat(Raiz, nombre) != null;
        }
        public NodoCategoria BuscarCat(NodoCategoria nodo, string nombre)
        {
            if (nodo == null)
            {
                return null;
            }

            // Verificar el nodo actual (excepto la raíz artificial)
            if (nodo != Raiz && string.Equals(nodo.Datos.Nombre, nombre))
            {
                return nodo;
            }

            // Buscar en los hijos (recursivo)
            NodoCategoria hijo = nodo.SubCatIzq;
            while (hijo != null)
            {
                NodoCategoria encontrado = BuscarCat(hijo, nombre);
                if (encontrado != null)
                {
                    return encontrado;
                }
                hijo = hijo.HermanoDer;
            }

            return null;
        }

        public string[] ListaPadres()
        {
            string nombres="";
            string[] ListaPadres; 

            var actual = Raiz.SubCatIzq;
            while (actual != null)
            {
                nombres = nombres + actual.Datos.Nombre + ",";
                actual=actual.HermanoDer;
            }

            ListaPadres = nombres.Split(",");
            return ListaPadres;
        }
    }
}
