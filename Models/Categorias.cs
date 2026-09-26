namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class Categorias : ITipoNodo
    {
        public int Nivel { get; set; }//atributo no usado, solo para cumplir con interfaz
        public string Padre { get; set; }
        public string Nombre { get; set; }
        public Listas ListaLibros { get; set; }

        public Categorias(string padre, string nombre)
        {
            Padre = padre;
            Nombre = nombre;
        }

        //Impresion de la lista de los libros guardados en la categoria
        public string ImprimirDato()
        {
            ListaLibros.ImprimirLista();
            return "";
        }
    }
}
