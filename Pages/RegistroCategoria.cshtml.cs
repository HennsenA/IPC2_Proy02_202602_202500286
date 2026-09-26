using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IPC2_Proyecto2_S22026_202500286.Pages.Configuration;
using IPC2_Proyecto2_S22026_202500286.Models;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class RegistroCategoriaModel : PageModel
    {
        public ArbolCatService CatService;
        [BindProperty]
        public string padre{get; set;}
        [BindProperty]
        public string nombre{get; set;}
        public int estado{get; set;}
        public string mensaje{get; set;}
        public string[]? ListaPadres{get; set;} 

        public RegistroCategoriaModel(ArbolCatService catService)
        {
            CatService=catService;
            if (CatService._ArbolCategorias != null)
            {
                ListaPadres = CatService._ArbolCategorias.PreOrder(CatService._ArbolCategorias.Raiz.SubCatIzq).Split(",");
            }
            else
            {
                ListaPadres=null;
            }
            estado=2;
        }

        public void OnGet()
        {
            if (ListaPadres == null)
            {
                estado=1;
                mensaje="Advertencia: El árbol no ha sido cargado";
                return;
            }

            if (ListaPadres.Length==0)
            {
                estado=1;
                mensaje="Advertencia: La lista de padres está vacía";
                return ;
            }
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Nombre ingresado: "+nombre);
            Console.WriteLine("Padre ingresado: "+padre);
            if (nombre==null)
            {
                estado=1;
                mensaje="Por favor, ingresa el nombre de la categoría";
                Console.WriteLine("El nombre está vacío");
                return Page();
            }
            bool insertado = CatService._ArbolCategorias.InsertarCat(new NodoCategoria(new Categorias(padre,nombre)));
            if (!insertado)
            {
                estado=-1;
                mensaje="Error: la categoría no se registró";
                Console.WriteLine("No se realizó la inserción");
                return Page();
            }

            estado=0;
            mensaje="Categoría registrada exitosamente!";
            return Page();
        }
    }
}
