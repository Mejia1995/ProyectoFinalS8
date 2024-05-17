using Newtonsoft.Json;
using ProyectoFinalS8.Models;
using System.Collections.ObjectModel;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_Orden : ContentPage
{

    private const string url = "http://192.168.18.17/sistemaOT/wsordenTrabajo.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<CrearOrden> orden;
    public Vista_Orden()
	{
		InitializeComponent();
        ObtenerDatos();
    }
    public async void ObtenerDatos()
    {
        var content = await cliente.GetStringAsync(url);
        List<CrearOrden> mostrar = JsonConvert.DeserializeObject<List<CrearOrden>>(content);
        orden = new ObservableCollection<CrearOrden>(mostrar);
        listOrdenes.ItemsSource = orden;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)

    {
        Navigation.PushAsync(new Vista_Agregar());

    }

    private void listOrdenes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objEstudiante = (CrearOrden)e.SelectedItem;
        Navigation.PushAsync(new Vista_Actualizar_Eliminar(objEstudiante));
    }
}