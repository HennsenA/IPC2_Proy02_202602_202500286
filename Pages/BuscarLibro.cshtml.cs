using IPC2_Proyecto2_S22026_202500286.Models;
using IPC2_Proyecto2_S22026_202500286.Pages.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class BuscarLibroModel : PageModel
    {
        [BindProperty]
        public int BookCode{get; set;}
        public string mensaje{get; set;}
        public int estado{get; set;}
        public NodoAvl? resultado{get; set;}
        private ArbolAvlService _ArbolLibros;
        private ArbolAvl arbol;

        public BuscarLibroModel(ArbolAvlService _arbolLibros)
        {
            _ArbolLibros = _arbolLibros;
            arbol = _ArbolLibros._ArbolLibros;
            estado=2;//Estado inicial
        }

        public void OnGet()
        {
            if (arbol == null)
            {
                mensaje = "Advertencia: El arbol no se ha cargado";
                estado = 1;
            }
        }
        
        public IActionResult OnPost()
        {
            if (BookCode==0)
            {
                ModelState.AddModelError(string.Empty, "Escribe un Isbn por favor.");
                estado = 1;
                mensaje = "Advertencia: Entrada vacía";
                return Page();
            }

            if (arbol == null)
            {
                mensaje="Error: No hay registros en el arbol";
                estado = -1;
                return Page();
            }
            NodoAvl Resultado = arbol.BuscarNodo(arbol.Raiz, BookCode);

            if (Resultado == null)
            {
                mensaje="Lo sentimos, No se encontró el registro";
                estado = 1;
                return Page();
            }

            mensaje="Libro encontrado!";
            resultado = Resultado;
            estado=0;
            return Page();
        }
    }
}
