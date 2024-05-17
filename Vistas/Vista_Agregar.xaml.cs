using System.Net;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_Agregar : ContentPage
{
	public Vista_Agregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("TrabajoSolicitado", txtTrabajoSolicitado.Text);
            parametros.Add("EmpresaSolicitante", txtEmpSolicitante.Text);
            parametros.Add("DepartamentoSolicitado", txtDepSolicitado.Text);
            parametros.Add("Fecha", txtFecha.Text);
            cliente.UploadValues("http://192.168.18.17/sistemaOT/wsordenTrabajo.php", "POST", parametros);
            Navigation.PushAsync(new Vista_Orden());
        }
		catch (Exception ex)
		{

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }
    }
}