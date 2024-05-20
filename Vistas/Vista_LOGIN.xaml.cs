using Newtonsoft.Json;
using ProyectoFinalS8.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace ProyectoFinalS8.Vistas;

public partial class Vista_LOGIN : ContentPage
{
  
    public Vista_LOGIN()
	{
		InitializeComponent();
       
    }

    private  async void BtnIngresar_Clicked(object sender, EventArgs e)

    {
        var email = txtEmail.Text;
        var password = txtPassword.Text;

        var loginData = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

        var content = new FormUrlEncodedContent(loginData);

        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.PostAsync("http://192.168.18.17/sistemaOT/wsLogin.php", content);
                var responseString = await response.Content.ReadAsStringAsync();

                var loginResponse = JsonConvert.DeserializeObject<LoginResponse1>(responseString);

                if (loginResponse.Status == "success")
                {
                    await DisplayAlert("Éxito", "Login successful", "OK");
                    // Navegar a la página principal u otra vista
                    // Por ejemplo: await Navigation.PushAsync(new MainPage());
                    await Navigation.PushAsync(new Vista_Orden());
                }
                else
                {
                    await DisplayAlert("Error", loginResponse.Message, "Cerrar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }
    }




    private void BtnRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vista_REGISTRO());
    }
}