using System.Reflection.Metadata;

namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class Libro : TipoNodo
    {
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }

        public Libro(int isbn, string titulo, string autor, string categoria)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
        }

        //Impresion de cada Libro con sus datos
        public void ImprimirDato()
        {
            
        }
    }
}
