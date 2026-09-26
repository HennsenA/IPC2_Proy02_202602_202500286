namespace IPC2_Proyecto2_S22026_202500286.Models
{
    public class NodoLista
    {
        public ITipoNodo Valor {  get; set; }
        public NodoLista Siguiente { get; set; }

        public NodoLista(ITipoNodo valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}
