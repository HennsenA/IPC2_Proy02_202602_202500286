using IPC2_Proyecto2_S22026_202500286.Controller;
using IPC2_Proyecto2_S22026_202500286.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Dynamic;

namespace IPC2_Proyecto2_S22026_202500286.Pages.Configuration
{
    public class CargaXmlModel : PageModel
    {
        [BindProperty]
        public IFormFile XmlFile { get; set; }
        public string Mensaje { get; set; }
        private  ArbolAvl _ArbolLibros;
        private  ArbolCategoria _ArbolCategorias;

        public CargaXmlModel(ArbolCategoria _arbolcategoria, ArbolAvl _arbolavl)
        {
            _ArbolLibros=_arbolavl;
            _ArbolCategorias=_arbolcategoria;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if(XmlFile==null || XmlFile.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Por favor, selecciona un archivo XML válido.");
                return Page();
            }

            string extension = Path.GetExtension(XmlFile.FileName);
            if (extension.ToLower() != ".xml")
            {
                ModelState.AddModelError(string.Empty, "El archivo debe tener extensión .xml");
                return Page();
            }

            bool estado;
            using (var stream = XmlFile.OpenReadStream())
            {
                var parser = new ManejoXml(stream);
                estado = parser.CargaArchivo();
                if (!estado)
                {
                    ModelState.AddModelError(string.Empty, "Error: El archivo no se cargo correctamente");
                    return Page();
                }

                _ArbolCategorias = parser.CargarCategorias();
                _ArbolLibros = parser.CargarLibros();

                if (_ArbolCategorias == null)
                {
                    ModelState.AddModelError(string.Empty, "Advertencia: Arbol categoria es nulo");
                }

                if (_ArbolLibros == null)
                {
                    ModelState.AddModelError(string.Empty, "Advertencia: Arbol libros es nulo");
                }
            }

            Mensaje = "Archivo cargado correctamente!";
            return Page();
        }
    }
}
