using ProyectoFinalS8.Models;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_Actualizar_Eliminar : ContentPage
{
    public Vista_Actualizar_Eliminar(CrearOrden datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.ID_orden.ToString();
        txtTSolicitado.Text = datos.TrabajoSolicitado.ToString();
        txtESolicitante.Text = datos.EmpresaSolicitante.ToString();
        txtDSolicitado.Text = datos.DepartamentoSolicitado.ToString();
        String mostrarfecha = txtFecha.Date.ToString("yyyy-MM-dd");
        mostrarfecha.ToString();

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient();
            var parametros = new Dictionary<string, string>
        {
            {"ID_orden", txtCodigo.Text},
            {"TrabajoSolicitado", txtTSolicitado.Text},
            {"EmpresaSolicitante", txtESolicitante.Text},
            {"DepartamentoSolicitado",txtDSolicitado.Text},
            {"Fecha", txtFecha.Date.ToString("yyyy-MM-dd") },
        };

            var content = new FormUrlEncodedContent(parametros);
            var url = $"http://localhost/sistemaOT/wsordenTrabajo.php?ID_orden={txtCodigo.Text}&TrabajoSolicitado={txtTSolicitado.Text}&EmpresaSolicitante={txtESolicitante.Text}&DepartamentoSolicitado={txtDSolicitado.Text}&Fecha={txtFecha.Date.ToString("yyyy-MM-dd")}";
            var response = httpClient.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var respuestaServidor = response.Content.ReadAsStringAsync().Result;
                DisplayAlert("Respuesta del servidor", respuestaServidor, "OK");
                Navigation.PushAsync(new Vista_Orden());
            }
            else
            {
                DisplayAlert("Alerta", "Error al actualizar el registro", "cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var httpClient = new HttpClient();
            var url = $"http://192.168.18.17/sistemaOT/wsordenTrabajo.php?ID_orden={txtCodigo.Text}";
            var response = httpClient.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                Navigation.PushAsync(new Vista_Orden());
            }
            else
            {
                DisplayAlert("Alerta", "Error al eliminar el registro", "cerrar");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "cerrar");
        }

    }

}