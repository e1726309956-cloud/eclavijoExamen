namespace eclavijoExamen.Views;

public partial class Registro : ContentPage
{
    string usuarioConectado = "";
    double pagoMensual = 0;
    double pagoTotal = 0;

    public Registro(string usuario)
	{
		InitializeComponent();
        usuarioConectado = usuario;

        lblUsuario.Text =
            "Usuario conectado: " + usuario;

        dpFecha.MinimumDate = DateTime.Today;
    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || 
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                await DisplayAlert(
                    "Error",
                    "Debe completar todos los campos",
                    "Cerrar");

                return;
            }

            if (pkPlan.SelectedItem == null)
            {
                await DisplayAlert(
                    "Error",
                    "Debe seleccionar un plan",
                    "Cerrar");

                return;
            }

            int edad;

            if (!int.TryParse(txtEdad.Text, out edad))
            {
                await DisplayAlert("Error",
                    "Ingrese una edad válida",
                    "Cerrar");
                return;
            }

            if (edad < 16)
            {
                await DisplayAlert("Error",
                    "La edad mínima es 16 años",
                    "Cerrar");
                return;
            }

            double montoInicial;

            if (!double.TryParse(txtMontoInicial.Text,
                out montoInicial))
            {
                await DisplayAlert("Error",
                    "Ingrese un monto válido",
                    "Cerrar");
                return;
            }

            if (montoInicial < 120 ||
                montoInicial > 600)
            {
                await DisplayAlert("Error",
                    "El monto debe estar entre 120 y 600",
                    "Cerrar");
                return;
            }

            double costo = 1200;

            double saldo = costo - montoInicial;

            pagoMensual =
                (saldo / 5) + (costo * 0.02);

            if (swCasillero.IsToggled)
            {
                pagoMensual += 10;
            }

            pagoTotal =
                montoInicial + (pagoMensual * 5);

            txtPagoMensual.Text =
                pagoMensual.ToString("F2");
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Error",
                ex.Message,
                "Cerrar");
        }

    }

    private async void btnResumen_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(
                new Resumen(
                    usuarioConectado,
                    txtNombre.Text,
                    txtApellido.Text,
                    txtEdad.Text,
                    dpFecha.Date.Value.ToShortDateString(),
                    pkPlan.SelectedItem.ToString(),
                    swCasillero.IsToggled,
                    txtMontoInicial.Text,
                    txtPagoMensual.Text,
                    pagoTotal.ToString("F2")
                    ));
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
