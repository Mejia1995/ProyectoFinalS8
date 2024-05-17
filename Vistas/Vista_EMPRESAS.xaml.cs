using Newtonsoft.Json;
using ProyectoFinalS8.Models;
using System.Collections.ObjectModel;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_EMPRESAS : ContentPage
{
	private const string url= "http://192.168.18.17/sistemaOT/wsempresas.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Empresas> emp;

    public Vista_EMPRESAS()
	{
		InitializeComponent();
        ObtenerDatos();
	}


    public async void ObtenerDatos()
    {
        var content = await cliente.GetStringAsync(url);
        List<Empresas> mostrar = JsonConvert.DeserializeObject<List<Empresas>>(content);
        emp = new ObservableCollection<Empresas>(mostrar);
        listEstudiante.ItemsSource = emp;
    }
}