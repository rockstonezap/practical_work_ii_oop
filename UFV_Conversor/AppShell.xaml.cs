namespace UFV_Conversor;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Registering Routes
		Routing.RegisterRoute("Privacy Policy", typeof(PrivacyPolicy));
		Routing.RegisterRoute("Register", typeof(Register));
		Routing.RegisterRoute("Login", typeof(Login));
		Routing.RegisterRoute("Converter", typeof(Converter));
	}
}
