using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IPC2_Proyecto2_S22026_202500286.Models;
using IPC2_Proyecto2_S22026_202500286.Pages.Configuration;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class VerCatalogoModel : PageModel
    {
        public Listas ListaJerarquica { get; set; }
        public ArbolCatService CatService;
        public int estado { get; set; }
        public string mensaje { get; set; }
        public VerCatalogoModel(ArbolCatService catService)
        {
            CatService = catService;
            ListaJerarquica = new Listas();
            estado = 2;
            if (CatService._ArbolCategorias != null)
            {
                CatService._ArbolCategorias.PreOrderJerarquia(CatService._ArbolCategorias.Raiz.SubCatIzq, 0, ListaJerarquica);
                Console.WriteLine("Nodo inicial Lista: " + ListaJerarquica.Inicio.Valor.Nombre);
            }
        }

        public void OnGet()
        {
            if (CatService._ArbolCategorias == null)
            {
                estado = -1;
                mensaje = "No hay estructura, el arbol no se ha cargado";
                return;
            }

            if (ListaJerarquica.Inicio == null)
            {
                estado = -1;
                mensaje = "La lista esta vacia";
                return;
            }
        }
    }
}
