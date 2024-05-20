using System.Net;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_REGISTRO : ContentPage
{
	public Vista_REGISTRO()
	{
		InitializeComponent();
	}

    private void BtnGuardarRegistro_Clicked(object sender, EventArgs e)

    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add(" Nombre", txtNombre.Text);
            parametros.Add("Apellido", txtApellido.Text);
            parametros.Add("Email", txtEmail.Text);
            parametros.Add("Password", txtPassword.Text);
            parametros.Add("Departamentos",txtDepart.Text);

            cliente.UploadValues("http://192.168.18.17/sistemaOT/wsusuarios1.php", "POST", parametros);

            DisplayAlert("Alerta", "Usuario registrado exitosamente", "OK");
            Navigation.PushAsync(new Vista_LOGIN());
        }
        catch (Exception ex) { 
        

            DisplayAlert("Alerta", ex.Message, "cerrar");
        }

    }

    private  async void BtnTomarFoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                imgFoto.Source = ImageSource.FromStream(() => stream);

                // Mostrar mensaje de éxito
                await DisplayAlert("Alerta", "Foto guardada exitosamente", "OK");
            }
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error si ocurre algún problema
            await DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}



   