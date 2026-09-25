using IPC2_Proyecto2_S22026_202500286.Models;
using IPC2_Proyecto2_S22026_202500286.Pages.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class LibroMayorMenorModel : PageModel
    {
        public ArbolAvlService AvlService;
        public int estado { get; set; }
        public string titulo { get; set; }
        public string mensaje { get; set; }
        public NodoAvl Nodo { get; set; }
        public LibroMayorMenorModel(ArbolAvlService avlService)
        {
            AvlService = avlService;
        }
        public void OnGet(int tipo)
        {
            if (AvlService._ArbolLibros == null)
            {
                mensaje = "Advertencia: El Arbol no se ha cargado";
                estado = 1;
                return;
            }

            if (tipo > 0)
            {
                Nodo = AvlService._ArbolLibros.MayorLibro();
                titulo = "Ultimo Libro";
            }
            else
            {
                Nodo = AvlService._ArbolLibros.MenorLibro();
                titulo = "Primer Libro";
            }
        }
    }
}
