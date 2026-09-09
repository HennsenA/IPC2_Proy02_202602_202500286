namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class Categorias : TipoNodo
    {
        public string Padre { get; set; }
        public string Nombre { get; set; }
        public Listas ListaLibros { get; set; }

        public Categorias(string padre, string nombre)
        {
            Padre = padre;
            Nombre = nombre;
        }

        //Impresion de la lista de los libros guardados en la categoria
        public void ImprimirDato()
        {

        }
    }
}
