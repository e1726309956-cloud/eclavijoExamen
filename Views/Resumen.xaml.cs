namespace eclavijoExamen.Views;

using System.Text;

public partial class Resumen : ContentPage
{
    string usuarioConectado = "";
    public Resumen(string usuario,string nombre,string apellido,string edad,string fecha,string plan,bool casillero,string montoInicial,string pagoMensual,string pagoTotal)
	{
		InitializeComponent();
        usuarioConectado = usuario;

        lblUsuario.Text =
            "Usuario Conectado: " + usuario;

        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha;
        lblPlan.Text = plan;

        lblCasillero.Text =
            casillero ? "SI" : "NO";

        lblMontoInicial.Text = montoInicial;
        lblPagoMensual.Text = pagoMensual;
        lblPagoTotal.Text = pagoTotal;
    }


    private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
        new Login());

    }

    private async void btnGenerartxt_Clicked(object sender, EventArgs e)
    {
        try
        {
            string datos =
                "REPORTE DE SOCIO" + Environment.NewLine +
                "Nombre: " + lblNombre.Text + Environment.NewLine +
                "Apellido: " + lblApellido.Text + Environment.NewLine +
                "Edad: " + lblEdad.Text + Environment.NewLine +
                "Fecha Inicio: " + lblFecha.Text + Environment.NewLine +
                "Plan: " + lblPlan.Text + Environment.NewLine +
                "Casillero: " + lblCasillero.Text + Environment.NewLine +
                "Monto Inicial: " + lblMontoInicial.Text + Environment.NewLine +
                "Pago Mensual: " + lblPagoMensual.Text + Environment.NewLine +
                "Pago Total: " + lblPagoTotal.Text;

            string escritorio =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.Desktop);

            string ruta =
                Path.Combine(escritorio, "SociosGym.txt");

            File.WriteAllText(ruta, datos);

            await DisplayAlert(
                "Éxito",
                "Archivo guardado en:\n" + ruta,
                "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Error",
                ex.Message,
                "Cerrar");
        }

    }
}