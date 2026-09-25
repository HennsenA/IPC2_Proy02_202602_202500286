using IPC2_Proyecto2_S22026_202500286.Models;
using System.Xml.Linq;

namespace IPC2_Proyecto2_S22026_202500286.Controller
{
    public class ManejoXml
    {
        private Stream XmlStream;
        private XDocument XmlFile;
        public ManejoXml(Stream xmlstream)
        {
            XmlStream = xmlstream;
        }

        public bool CargaArchivo()
        {
            try
            {
                if (XmlStream.Length==0)
                {
                    //ruta vacia
                    return false;
                }

                XmlFile = XDocument.Load(XmlStream);
                return true;
            }
            catch (FileNotFoundException)
            {
                //archivo no encontrado
                return false;
            }
            catch (System.Xml.XmlException)
            {
                //archivo con formato incorrecto o corrupto
                return false;
            }
        }
        public ArbolCategoria CargarCategorias()
        {
            ArbolCategoria arbol = new ArbolCategoria();
            try
            {
                var ListaCategorias = XmlFile.Root!.Element("listaCategorias")!.Elements("categoria");

                if (ListaCategorias == null)
                {
                    return null;
                }

                foreach (XElement categoria in ListaCategorias)
                {
                    string nombre = categoria.Value.Trim();
                    string? padre = categoria.Attribute("padre")?.Value;

                    Categorias nueva = new Categorias(padre,nombre);

                    arbol.InsertarCat(new NodoCategoria(nueva));
                }

                return arbol;
            }
            catch (System.Xml.XmlException)
            {
                return null;
            }
        }
        public ArbolAvl CargarLibros()
        {
            ArbolAvl arbol = new ArbolAvl();

            try
            {
                var ListaLibros = XmlFile.Root!.Element("listaLibros")?.Elements("libro");

                if (ListaLibros == null)
                {
                    return null;
                }

                foreach (XElement libro in ListaLibros)
                {
                    int isbn = int.Parse(libro.Element("ISBN")!.Value);
                    string titulo = libro.Element("titulo")!.Value;
                    string autor = libro.Element("autor")!.Value;
                    string categoria = libro.Element("categoria")!.Value;

                    Libro nuevo = new Libro(isbn, titulo, autor, categoria);

                    arbol.Raiz = arbol.InsertarNodo(arbol.Raiz, nuevo);
                }

                return arbol;
            }
            catch (System.Xml.XmlException)
            {
                return null;
            }
        }
    }
}
