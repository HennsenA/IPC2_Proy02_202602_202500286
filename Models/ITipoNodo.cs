namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public interface ITipoNodo
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        string ImprimirDato();
    }
}
