using System.Reflection.Metadata;

namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class Libro : ITipoNodo
    {
        public string Nombre { get; set; }//atributo no usado
        public int Nivel { get; set; }//atributo no usado
        public int? Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }

        public Libro(int? isbn, string titulo, string autor, string categoria)
        {
            Isbn = isbn;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
        }

        //Impresion de cada Libro con sus datos
        public string ImprimirDato()
        {
            string datos = $"""
                ISBN: {Isbn}
                Titulo: {Titulo}
                Autor: {Autor}
                Categoria: {Categoria}
                """;
            return datos;
        }
    }
}
