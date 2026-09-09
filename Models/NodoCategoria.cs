namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class NodoCategoria
    {
        public Categorias Datos {  get; set; }
        public NodoCategoria HermanoDer {  get; set; }
        public NodoCategoria SubCatIzq {  get; set; }
        public NodoCategoria Padre {  get; set; }

        public NodoCategoria(Categorias datos)
        {
            Datos = datos;
            HermanoDer = null;
            SubCatIzq = null;
            Padre = null;
        }

        public bool EsHoja()
        {
            return SubCatIzq == null;
        }

        public void InsertarLibros() { }
    }
}
