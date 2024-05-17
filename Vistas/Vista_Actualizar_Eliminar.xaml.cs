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
        txtFecha.Text = datos.Fecha.ToString();

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {

    }
}