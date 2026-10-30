using Microsoft.Win32;

namespace eclavijoExamen.Views;

public partial class Login : ContentPage
{
    string usuario = "";
    string contrasena = "";

    string[,] usuarios =
{
        {"recepcion","gym2026"},
        {"entrenador","fit_01"},
        {"uisrael","2026"},
        {"gerente","admin123"}
        };

    public Login()
	{
		InitializeComponent();
	}

    private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
    {
		try {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            bool acceso = false;

            for (int i = 0; i < 4; i++)
            {
                if (usuario == usuarios[i, 0] &&
                   contrasena == usuarios[i, 1])
                {
                    acceso = true;
                    break;
                }
            }

            if (acceso)
            {
                await Navigation.PushAsync(
                    new Registro(usuario));
            }
            else
            {
                await DisplayAlert("Error",
                    "Usuario o contraseña incorrectos",
                    "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error",
                ex.Message,
                "OK");
        }

    }

    private async void btnAcerca_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Acerca de", "ERIK CLAVIJO / SISTEMAS / PARALELO A", "CERRAR");

    }
}