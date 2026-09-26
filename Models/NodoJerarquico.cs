namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class NodoJerarquico : ITipoNodo
    {
        
        public string Nombre { get; set; }
        public Categorias Dato{ get; set; }
        public int Nivel { get; set; }

        public NodoJerarquico(Categorias dato, int nivel)
        {
            Dato = dato;
            Nivel = nivel;
            Nombre = dato.Nombre;
        }
        public string ImprimirDato()
        {
            string informacion = $"Nombre: {Nombre}, Nivel: {Nivel}";
            return null;
        }
    }
}
