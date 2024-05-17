using ProyectoFinalS8.Models;

namespace ProyectoFinalS8.Vistas;

public partial class Vista_LOGIN : ContentPage
{
  
    public Vista_LOGIN()
	{
		InitializeComponent();
       
    }

    private  void BtnIngresar_Clicked(object sender, EventArgs e)

    {


    } 
    

    private void BtnRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vista_Orden());
    }
}