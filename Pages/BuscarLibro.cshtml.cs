using IPC2_Proyecto2_S22026_202500286.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class BuscarLibroModel : PageModel
    {
        [BindProperty]
        public int BookCode{get; set;}
        public string mensaje{get; set;}
        public string? resultado{get; set;}
        public ArbolAvl _ArbolLibros;
        public ArbolCategoria _ArbolCategoria;

        public BuscarLibroModel(ArbolAvl arbolAvl, ArbolCategoria arbolCategoria)
        {
            _ArbolLibros = arbolAvl;
            _ArbolCategoria = arbolCategoria;
        }
        public void OnGet()
        {
        }
        
        public IActionResult OnPost()
        {
            if (BookCode==0)
            {
                ModelState.AddModelError(string.Empty, "Escribe un Isbn por favor.");
                return Page();
            }
            
            NodoAvl Resultado = _ArbolLibros.BuscarNodo(_ArbolLibros.Raiz, BookCode);

            if (Resultado == null)
            {
                return Page();
            }

            mensaje="Libro encontrado!";
            resultado = Resultado.Dato.ToString();
            return Page();
        }
    }
}
