using IPC2_Proyecto2_S22026_202500286.Pages.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IPC2_Proyecto2_S22026_202500286.Pages
{
    public class RegistroLibroModel : PageModel
    {
        public ArbolCatService CatService;
        public ArbolAvlService AvlService;
        public string[] ListaCategorias { get; set; }
        public string mensaje { get; set; }
        public int estado { get; set; }
        [BindProperty]
        public int? isbn { get; set; }
        [BindProperty]
        public string nombre { get; set; }
        [BindProperty]
        public string autor { get; set; }
        [BindProperty]
        public string categoria { get; set; }
        public RegistroLibroModel(ArbolCatService catService, ArbolAvlService avlService)
        {
            CatService = catService;
            AvlService = avlService;
            if (CatService._ArbolCategorias != null)
            {
                ListaCategorias = listaCategorias(CatService._ArbolCategorias.PreOrder(CatService._ArbolCategorias.Raiz.SubCatIzq));
            }
            else
            {
                ListaCategorias = null;
            }
            estado = 2;
        }
        public void OnGet()
        {
            //Console.WriteLine("Lista de Categorias: \n"+CatService._ArbolCategorias.PreOrder(CatService._ArbolCategorias.Raiz.SubCatIzq));
            if(ListaCategorias == null)
            {
                estado = 1;
                mensaje = "Advertencia: El arbol no ha sido cargado";
                return;
            }

            if(ListaCategorias.Length == 0)
            {
                estado = 1;
                mensaje = "Advertencia: No hay elementos en la lista de categorias";
                return;
            }
        }

        public IActionResult OnPost()
        {
            if (isbn == 0)
            {
                estado = 1;
                mensaje = "Por favor ingrese el ISBN del libro";
                return Page();
            }

            if(nombre==null || nombre == "")
            {
                estado = 1;
                mensaje = "Por favor ingrese el nombre del libro";
                return Page();
            }

            if (autor == null || autor == "")
            {
                estado = 1;
                mensaje = "Por favor ingrese el autor del libro";
                return Page();
            }

            if (categoria == null || categoria == "")
            {
                estado = 1;
                mensaje = "Por favor ingrese la categoria del libro";
                return Page();
            }

            AvlService._ArbolLibros.Raiz = AvlService._ArbolLibros.InsertarNodo(AvlService._ArbolLibros.Raiz, new Models.Libro(isbn,nombre,autor,categoria));
            estado = 0;
            mensaje = "Libro registrado correctamente!";
            return Page();
        }

        private string[] listaCategorias(string ListaCruda)
        {
            string[] ListaCategorias = ListaCruda.Split(",");
            return ListaCategorias;
        }
    }
}
