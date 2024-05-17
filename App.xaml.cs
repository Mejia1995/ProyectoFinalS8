namespace ProyectoFinalS8
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Vistas.Vista_LOGIN());
        }
    }
}
