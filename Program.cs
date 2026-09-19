/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();*/


using IPC2_Proyecto2_S22026_202500286.Models;

namespace IPC2_Proyecto2_S22026_202500286
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ArbolCategoria arbol = new ArbolCategoria();
            arbol.InsertarCat(new NodoCategoria(new Categorias("Historia", "Era Medieval")));
            arbol.InsertarCat(new NodoCategoria(new Categorias("Arte", "Renacimiento")));
            arbol.InsertarCat(new NodoCategoria(new Categorias("Biologia", "Zoologia")));

            Console.WriteLine("Numero de nodos: "+ arbol.NoNodos());
        }
    }
}